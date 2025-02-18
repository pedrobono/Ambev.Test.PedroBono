using Ambev.Test.PedroBono.Domain.Entities;
using Ambev.Test.PedroBono.ORM.Common;

namespace Ambev.Test.PedroBono.ORM.Repository
{
    /// <summary>
    /// Implementation of ISaleProductRepository using Entity Framework Core
    /// </summary>
    public interface ISaleProductRepository
    {

        /// <summary>
        /// Creates a new saleProduct in the database
        /// </summary>
        /// <param name="saleProduct">The saleProduct to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created saleProduct</returns>
        Task<SaleProduct> CreateAsync(SaleProduct saleProduct, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a saleProduct by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the saleProduct</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The saleProduct if found, null otherwise</returns>
        Task<SaleProduct?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a saleProduct from the database
        /// </summary>
        /// <param name="id">The unique identifier of the saleProduct to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the saleProduct was deleted, false if not found</returns>
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a paginated list of saleProducts from the database based on specified filtering and ordering conditions.
        /// </summary>
        /// <param name="request">An object containing pagination and filtering parameters.</param>
        /// <param name="cancellationToken">A cancellation token to propagate notification that the operation should be canceled.</param>
        /// <returns>A paginated result containing a list of saleProducts and total count, or null if no saleProducts are found.</returns>
        Task<PaginatedResult<SaleProduct>?> ListPaginatedAsync(PaginedFilter request, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing saleProduct in the database.
        /// </summary>
        /// <param name="saleProduct">The saleProduct object containing updated values.</param>
        /// <param name="cancellationToken">A cancellation token to propagate notification that the operation should be canceled.</param>
        /// <returns>The updated saleProduct object after saving changes to the database.</returns>
        Task<SaleProduct> UpdateAsync(SaleProduct saleProduct, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a paginated list of saleProducts from the database based on specified filtering and ordering conditions.
        /// </summary>
        /// <param name="saleId">The Id of a Sale</param>
        /// <param name="request">An object containing pagination and filtering parameters.</param>
        /// <param name="cancellationToken">A cancellation token to propagate notification that the operation should be canceled.</param>
        /// <returns>A paginated result containing a list of saleProducts and total count, or null if no saleProducts are found.</returns>
        Task<PaginatedResult<SaleProduct>?> ListPaginatedFromSaleAsync(int saleId, PaginedFilter request, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves a saleProduct by their unique identifier and sale id
        /// </summary>
        /// <param name="saleProductId">The unique identifier of the saleProduct</param>
        /// <param name="saleId">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The saleProduct if found, null otherwise</returns>
        Task<SaleProduct?> GetByIdAndSaleIdAsync(int saleProductId, int saleId, CancellationToken cancellationToken);
    }
}