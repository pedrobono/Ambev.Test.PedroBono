using Ambev.Test.PedroBono.Domain.Entities;
using Ambev.Test.PedroBono.ORM.Common;

namespace Ambev.Test.PedroBono.ORM.Repository
{
    /// <summary>
    /// Implementation of ISaleRepository using Entity Framework Core
    /// </summary>
    public interface ISaleRepository
    {

        /// <summary>
        /// Creates a new sale in the database
        /// </summary>
        /// <param name="sale">The sale to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale</returns>
        Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a sale by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale if found, null otherwise</returns>
        Task<Sale?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a sale from the database
        /// </summary>
        /// <param name="id">The unique identifier of the sale to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the sale was deleted, false if not found</returns>
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a paginated list of sales from the database based on specified filtering and ordering conditions.
        /// </summary>
        /// <param name="request">An object containing pagination and filtering parameters.</param>
        /// <param name="cancellationToken">A cancellation token to propagate notification that the operation should be canceled.</param>
        /// <returns>A paginated result containing a list of sales and total count, or null if no sales are found.</returns>
        Task<PaginatedResult<Sale>?> ListPaginatedAsync(PaginedFilter request, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing sale in the database.
        /// </summary>
        /// <param name="sale">The sale object containing updated values.</param>
        /// <param name="cancellationToken">A cancellation token to propagate notification that the operation should be canceled.</param>
        /// <returns>The updated sale object after saving changes to the database.</returns>
        Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);
    }
}