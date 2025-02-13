using Ambev.Test.PedroBono.Domain.Entities;
using Ambev.Test.PedroBono.ORM.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.ORM.Repository
{
    /// <summary>
    /// Implementation of ICartRepository using Entity Framework Core
    /// </summary>
    public class CartRepository : ICartRepository
    {
        private readonly PostgresContext _context;

        /// <summary>
        /// Initializes a new instance of CartRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public CartRepository(PostgresContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new cart in the database
        /// </summary>
        /// <param name="cart">The cart to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created cart</returns>
        public async Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default)
        {
            await _context.Carts.AddAsync(cart, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return cart;
        }

        /// <summary>
        /// Retrieves a cart by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the cart</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The cart if found, null otherwise</returns>
        public async Task<Cart?> GetByIdAsync(int id, CancellationToken cancellationToken = default) => 
            await _context.Carts.Include(x => x.CartProducts).FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        /// <summary>
        /// Deletes a cart from the database
        /// </summary>
        /// <param name="id">The unique identifier of the cart to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the cart was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var cart = await GetByIdAsync(id, cancellationToken);
            if (cart == null)
                return false;

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <summary>
        /// Updates an existing cart in the database.
        /// </summary>
        /// <param name="cart">The cart object containing updated values.</param>
        /// <param name="cancellationToken">A cancellation token to propagate notification that the operation should be canceled.</param>
        /// <returns>The updated cart object after saving changes to the database.</returns>
        public async Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken = default)
        {
            _context.ChangeTracker.Clear();
            cart.UpdatedAt = DateTime.UtcNow;
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync(cancellationToken);
            return cart;
        }

        /// <summary>
        /// Retrieves a paginated list of carts from the database based on specified filtering and ordering conditions.
        /// </summary>
        /// <param name="request">An object containing pagination and filtering parameters.</param>
        /// <param name="cancellationToken">A cancellation token to propagate notification that the operation should be canceled.</param>
        /// <returns>A paginated result containing a list of carts and total count, or null if no carts are found.</returns>
        public async Task<PaginatedResult<Cart>?> ListPaginatedAsync(PaginedFilter request, CancellationToken cancellationToken)
        {
            var count = await _context.Carts.CountAsync(cancellationToken);
            var cartsQueryable = _context.Carts.AsQueryable();

            var conditions = request.Order.Split(',');
            int qtyConditions = 0;

            foreach (var condition in conditions)
            {
                var fieldAndOrder = condition.TrimStart().TrimEnd().Split(" ");
                var field = fieldAndOrder[0];
                var order = fieldAndOrder[1];

                if (order.ToLower() == "desc")
                    if (qtyConditions > 0)
                        cartsQueryable = ((IOrderedQueryable<Cart>)cartsQueryable).ThenByDescending(GetKeySelector(field));
                    else
                        cartsQueryable = cartsQueryable.OrderByDescending(GetKeySelector(field));
                else
                    if (qtyConditions > 0)
                        cartsQueryable = ((IOrderedQueryable<Cart>)cartsQueryable).ThenBy(GetKeySelector(field));
                    else
                        cartsQueryable = cartsQueryable.OrderBy(GetKeySelector(field));

                qtyConditions++;
            }


            var items = await cartsQueryable.Skip((request.Page - 1) * request.Size).Take(request.Size).Include(x => x.CartProducts).ToListAsync();
            return new PaginatedResult<Cart>(items, count, request.Page, request.Size);
        }

        /// <summary>
        /// Constructs a key selector expression based on the given field name for sorting carts.
        /// </summary>
        /// <param name="field">The field name to use for sorting carts.</param>
        /// <returns>A lambda expression representing the key selector for the specified field.</returns>
        private static Expression<Func<Cart, object>> GetKeySelector(string field) => field.ToLower().Trim() switch
        {
            "userid" => cart => cart.UserId,
            "date" => cart => cart.Date,
            _ => cart => cart.Id
        };
    }
}