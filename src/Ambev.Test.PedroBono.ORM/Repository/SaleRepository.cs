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
    /// Implementation of ISaleRepository using Entity Framework Core
    /// </summary>
    public class SaleRepository : ISaleRepository
    {
        private readonly PostgresContext _context;

        /// <summary>
        /// Initializes a new instance of SaleRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public SaleRepository(PostgresContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new sale in the database
        /// </summary>
        /// <param name="sale">The sale to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale</returns>
        public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            await _context.Sales.AddAsync(sale, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return sale;
        }

        /// <summary>
        /// Retrieves a sale by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale if found, null otherwise</returns>
        public async Task<Sale?> GetByIdAsync(int id, CancellationToken cancellationToken = default) => 
            await _context.Sales.Include(x => x.Customer).Include(x => x.Products).Include("Products.Product").FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        /// <summary>
        /// Deletes a sale from the database
        /// </summary>
        /// <param name="id">The unique identifier of the sale to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the sale was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var sale = await GetByIdAsync(id, cancellationToken);
            if (sale == null)
                return false;

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <summary>
        /// Updates an existing sale in the database.
        /// </summary>
        /// <param name="sale">The sale object containing updated values.</param>
        /// <param name="cancellationToken">A cancellation token to propagate notification that the operation should be canceled.</param>
        /// <returns>The updated sale object after saving changes to the database.</returns>
        public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            _context.ChangeTracker.Clear();
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync(cancellationToken);
            return sale;
        }

        /// <summary>
        /// Retrieves a paginated list of sales from the database based on specified filtering and ordering conditions.
        /// </summary>
        /// <param name="request">An object containing pagination and filtering parameters.</param>
        /// <param name="cancellationToken">A cancellation token to propagate notification that the operation should be canceled.</param>
        /// <returns>A paginated result containing a list of sales and total count, or null if no sales are found.</returns>
        public async Task<PaginatedResult<Sale>?> ListPaginatedAsync(PaginedFilter request, CancellationToken cancellationToken)
        {
            var count = await _context.Sales.CountAsync(cancellationToken);
            var salesQueryable = _context.Sales.Include(x => x.Customer).Include(x => x.Products).Include("Products.Product").AsQueryable();

            var conditions = request.Order.Split(',');
            int qtyConditions = 0;

            foreach (var condition in conditions)
            {
                var fieldAndOrder = condition.TrimStart().TrimEnd().Split(" ");
                var field = fieldAndOrder[0];
                var order = fieldAndOrder[1];

                if (order.ToLower() == "desc")
                    if (qtyConditions > 0)
                        salesQueryable = ((IOrderedQueryable<Sale>)salesQueryable).ThenByDescending(GetKeySelector(field));
                    else
                        salesQueryable = salesQueryable.OrderByDescending(GetKeySelector(field));
                else
                    if (qtyConditions > 0)
                        salesQueryable = ((IOrderedQueryable<Sale>)salesQueryable).ThenBy(GetKeySelector(field));
                    else
                        salesQueryable = salesQueryable.OrderBy(GetKeySelector(field));

                qtyConditions++;
            }


            var items = await salesQueryable.Skip((request.Page - 1) * request.Size).Take(request.Size).ToListAsync();
            return new PaginatedResult<Sale>(items, count, request.Page, request.Size);
        }

        /// <summary>
        /// Constructs a key selector expression based on the given field name for sorting sales.
        /// </summary>
        /// <param name="field">The field name to use for sorting sales.</param>
        /// <returns>A lambda expression representing the key selector for the specified field.</returns>
        private static Expression<Func<Sale, object>> GetKeySelector(string field) => field.ToLower().Trim() switch
        {
            "product" => sale => sale.Products,
            "customer" => sale => sale.CustomerId,
            "status" => sale => sale.Status,
            "date" => sale => sale.Date,
            "user" => Sale => Sale.UserId,
            _ => sale => sale.Id
        };
    }
}