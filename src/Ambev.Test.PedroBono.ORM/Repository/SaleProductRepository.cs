using Ambev.Test.PedroBono.Domain.Entities;
using Ambev.Test.PedroBono.ORM.Common;
using MediatR;
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
    /// Implementation of ISaleProductRepository using Entity Framework Core
    /// </summary>
    public class SaleProductRepository : ISaleProductRepository
    {
        private readonly PostgresContext _context;

        /// <summary>
        /// Initializes a new instance of SaleProductRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public SaleProductRepository(PostgresContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new saleProduct in the database
        /// </summary>
        /// <param name="saleProduct">The saleProduct to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created saleProduct</returns>
        public async Task<SaleProduct> CreateAsync(SaleProduct saleProduct, CancellationToken cancellationToken = default)
        {
            await _context.SaleProducts.AddAsync(saleProduct, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return saleProduct;
        }

        /// <summary>
        /// Retrieves a saleProduct by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the saleProduct</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The saleProduct if found, null otherwise</returns>
        public async Task<SaleProduct?> GetByIdAsync(int id, CancellationToken cancellationToken = default) => 
            await _context.SaleProducts.Include(x => x.Product).FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        /// <summary>
        /// Deletes a saleProduct from the database
        /// </summary>
        /// <param name="id">The unique identifier of the saleProduct to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the saleProduct was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var saleProduct = await GetByIdAsync(id, cancellationToken);
            if (saleProduct == null)
                return false;

            _context.SaleProducts.Remove(saleProduct);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <summary>
        /// Updates an existing saleProduct in the database.
        /// </summary>
        /// <param name="saleProduct">The saleProduct object containing updated values.</param>
        /// <param name="cancellationToken">A cancellation token to propagate notification that the operation should be canceled.</param>
        /// <returns>The updated saleProduct object after saving changes to the database.</returns>
        public async Task<SaleProduct> UpdateAsync(SaleProduct saleProduct, CancellationToken cancellationToken = default)
        {
            _context.ChangeTracker.Clear();
            _context.SaleProducts.Update(saleProduct);
            await _context.SaveChangesAsync(cancellationToken);
            return saleProduct;
        }

        /// <summary>
        /// Retrieves a paginated list of saleProducts from the database based on specified filtering and ordering conditions.
        /// </summary>
        /// <param name="request">An object containing pagination and filtering parameters.</param>
        /// <param name="cancellationToken">A cancellation token to propagate notification that the operation should be canceled.</param>
        /// <returns>A paginated result containing a list of saleProducts and total count, or null if no saleProducts are found.</returns>
        public async Task<PaginatedResult<SaleProduct>?> ListPaginatedAsync(PaginedFilter request, CancellationToken cancellationToken)
        {
            var count = await _context.SaleProducts.CountAsync(cancellationToken);
            var saleProductsQueryable = _context.SaleProducts.AsQueryable();

            var conditions = request.Order.Split(',');
            int qtyConditions = 0;

            foreach (var condition in conditions)
            {
                var fieldAndOrder = condition.TrimStart().TrimEnd().Split(" ");
                var field = fieldAndOrder[0];
                var order = fieldAndOrder[1];

                if (order.ToLower() == "desc")
                    if (qtyConditions > 0)
                        saleProductsQueryable = ((IOrderedQueryable<SaleProduct>)saleProductsQueryable).ThenByDescending(GetKeySelector(field));
                    else
                        saleProductsQueryable = saleProductsQueryable.OrderByDescending(GetKeySelector(field));
                else
                    if (qtyConditions > 0)
                        saleProductsQueryable = ((IOrderedQueryable<SaleProduct>)saleProductsQueryable).ThenBy(GetKeySelector(field));
                    else
                        saleProductsQueryable = saleProductsQueryable.OrderBy(GetKeySelector(field));

                qtyConditions++;
            }


            var items = await saleProductsQueryable.Skip((request.Page - 1) * request.Size).Take(request.Size).ToListAsync();
            return new PaginatedResult<SaleProduct>(items, count, request.Page, request.Size);
        }

        /// <summary>
        /// Constructs a key selector expression based on the given field name for sorting saleProducts.
        /// </summary>
        /// <param name="field">The field name to use for sorting saleProducts.</param>
        /// <returns>A lambda expression representing the key selector for the specified field.</returns>
        private static Expression<Func<SaleProduct, object>> GetKeySelector(string field) => field.ToLower().Trim() switch
        {
            "product" => saleProduct => saleProduct.ProductId,
            "productName" => saleProduct => saleProduct.Product.Title,
            "status" => saleProduct => saleProduct.Status,
            "unitprice" => saleProduct => saleProduct.UnitPrice,
            "qty" => SaleProduct => SaleProduct.Qty,
            "total" => SaleProduct => SaleProduct.Total,
            "discount" => SaleProduct => SaleProduct.Discount,
            _ => saleProduct => saleProduct.Id
        };

        public async Task<PaginatedResult<SaleProduct>?> ListPaginatedFromSaleAsync(int saleId, PaginedFilter request, CancellationToken cancellationToken)
        {
            var count = await _context.SaleProducts.Where(saleProduct => saleProduct.SaleId == saleId).CountAsync(cancellationToken);
            var saleProductsQueryable = _context.SaleProducts.Where(saleProduct => saleProduct.SaleId == saleId).Include(x => x.Product).AsQueryable();

            var conditions = request.Order.Split(',');
            int qtyConditions = 0;

            foreach (var condition in conditions)
            {
                var fieldAndOrder = condition.TrimStart().TrimEnd().Split(" ");
                var field = fieldAndOrder[0];
                var order = fieldAndOrder[1];

                if (order.ToLower() == "desc")
                    if (qtyConditions > 0)
                        saleProductsQueryable = ((IOrderedQueryable<SaleProduct>)saleProductsQueryable).ThenByDescending(GetKeySelector(field));
                    else
                        saleProductsQueryable = saleProductsQueryable.OrderByDescending(GetKeySelector(field));
                else
                    if (qtyConditions > 0)
                    saleProductsQueryable = ((IOrderedQueryable<SaleProduct>)saleProductsQueryable).ThenBy(GetKeySelector(field));
                else
                    saleProductsQueryable = saleProductsQueryable.OrderBy(GetKeySelector(field));

                qtyConditions++;
            }


            var items = await saleProductsQueryable.Skip((request.Page - 1) * request.Size).Take(request.Size).ToListAsync();
            return new PaginatedResult<SaleProduct>(items, count, request.Page, request.Size);
        }


        /// <summary>
        /// Retrieves a saleProduct by their unique identifier and sale id
        /// </summary>
        /// <param name="saleProductId">The unique identifier of the saleProduct</param>
        /// <param name="saleId">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The saleProduct if found, null otherwise</returns>
        public async Task<SaleProduct?> GetByIdAndSaleIdAsync(int saleProductId, int saleId, CancellationToken cancellationToken = default) =>
            await _context.SaleProducts.Include(x => x.Product).FirstOrDefaultAsync(o => o.Id == saleProductId && o.SaleId == saleId, cancellationToken);
    }
}