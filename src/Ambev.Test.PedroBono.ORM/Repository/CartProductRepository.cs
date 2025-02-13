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
    /// Implementation of ICartProductRepository using Entity Framework Core
    /// </summary>
    public class CartProductRepository : ICartProductRepository
    {
        private readonly PostgresContext _context;

        /// <summary>
        /// Initializes a new instance of CartCartProductRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public CartProductRepository(PostgresContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new cartCartProduct in the database
        /// </summary>
        /// <param name="cartCartProduct">The cartCartProduct to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created cartCartProduct</returns>
        public async Task<CartProduct> CreateAsync(CartProduct cartCartProduct, CancellationToken cancellationToken = default)
        {
            await _context.CartProducts.AddAsync(cartCartProduct, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return cartCartProduct;
        }

        /// <summary>
        /// Retrieves a cartCartProduct by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the cartCartProduct</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The cartCartProduct if found, null otherwise</returns>
        public async Task<CartProduct?> GetByIdAsync(int id, CancellationToken cancellationToken = default) => 
            await _context.CartProducts.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        /// <summary>
        /// Deletes a cartCartProduct from the database
        /// </summary>
        /// <param name="id">The unique identifier of the cartCartProduct to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the cartCartProduct was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var cartCartProduct = await GetByIdAsync(id, cancellationToken);
            if (cartCartProduct == null)
                return false;

            _context.CartProducts.Remove(cartCartProduct);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <summary>
        /// Updates an existing cartCartProduct in the database.
        /// </summary>
        /// <param name="cartCartProduct">The cartCartProduct object containing updated values.</param>
        /// <param name="cancellationToken">A cancellation token to propagate notification that the operation should be canceled.</param>
        /// <returns>The updated cartCartProduct object after saving changes to the database.</returns>
        public async Task<CartProduct> UpdateAsync(CartProduct cartCartProduct, CancellationToken cancellationToken = default)
        {
            _context.ChangeTracker.Clear();
            _context.CartProducts.Update(cartCartProduct);
            await _context.SaveChangesAsync(cancellationToken);
            return cartCartProduct;
        }

        /// <summary>
        /// Retrieves a paginated list of cartCartProducts from the database based on specified filtering and ordering conditions.
        /// </summary>
        /// <param name="request">An object containing pagination and filtering parameters.</param>
        /// <param name="cancellationToken">A cancellation token to propagate notification that the operation should be canceled.</param>
        /// <returns>A paginated result containing a list of cartCartProducts and total count, or null if no cartCartProducts are found.</returns>
        public async Task<PaginatedResult<CartProduct>?> ListPaginatedAsync(PaginedFilter request, CancellationToken cancellationToken)
        {
            var count = await _context.CartProducts.CountAsync(cancellationToken);
            var cartCartProductsQueryable = _context.CartProducts.AsQueryable();

            var conditions = request.Order.Split(',');
            int qtyConditions = 0;

            foreach (var condition in conditions)
            {
                var fieldAndOrder = condition.TrimStart().TrimEnd().Split(" ");
                var field = fieldAndOrder[0];
                var order = fieldAndOrder[1];

                if (order.ToLower() == "desc")
                    if (qtyConditions > 0)
                        cartCartProductsQueryable = ((IOrderedQueryable<CartProduct>)cartCartProductsQueryable).ThenByDescending(GetKeySelector(field));
                    else
                        cartCartProductsQueryable = cartCartProductsQueryable.OrderByDescending(GetKeySelector(field));
                else
                    if (qtyConditions > 0)
                        cartCartProductsQueryable = ((IOrderedQueryable<CartProduct>)cartCartProductsQueryable).ThenBy(GetKeySelector(field));
                    else
                        cartCartProductsQueryable = cartCartProductsQueryable.OrderBy(GetKeySelector(field));

                qtyConditions++;
            }


            var items = await cartCartProductsQueryable.Skip((request.Page - 1) * request.Size).Take(request.Size).ToListAsync();
            return new PaginatedResult<CartProduct>(items, count, request.Page, request.Size);
        }

        /// <summary>
        /// Constructs a key selector expression based on the given field name for sorting cartCartProducts.
        /// </summary>
        /// <param name="field">The field name to use for sorting cartCartProducts.</param>
        /// <returns>A lambda expression representing the key selector for the specified field.</returns>
        private static Expression<Func<CartProduct, object>> GetKeySelector(string field) => field.ToLower().Trim() switch
        {
            "productid" => cartCartProduct => cartCartProduct.ProductId,
            "cartid" => cartCartProduct => cartCartProduct.CartId,
            "quantity" => cartCartProduct => cartCartProduct.Qty,
            _ => cartCartProduct => cartCartProduct.Id
        };

        /// <summary>
        /// Deletes all products associated with a specific cart.
        /// </summary>
        /// <param name="id">The unique identifier of the cart to delete all products from.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous delete operation.</returns>
        public async Task<bool> DeleteAllByCartIdAsync(int id, CancellationToken cancellationToken)
        {
            var cartProducts = _context.CartProducts.Where(x => x.CartId == id);

            _context.RemoveRange(cartProducts);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}