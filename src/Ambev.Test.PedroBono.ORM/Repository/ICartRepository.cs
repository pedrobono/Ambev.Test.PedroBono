using Ambev.Test.PedroBono.Domain.Entities;
using Ambev.Test.PedroBono.ORM.Common;

namespace Ambev.Test.PedroBono.ORM.Repository
{
    /// <summary>
    /// Implementation of ICartRepository using Entity Framework Core
    /// </summary>
    public interface ICartRepository
    {

        /// <summary>
        /// Creates a new cart in the database
        /// </summary>
        /// <param name="cart">The cart to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created cart</returns>
        Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a cart by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the cart</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The cart if found, null otherwise</returns>
        Task<Cart?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a cart from the database
        /// </summary>
        /// <param name="id">The unique identifier of the cart to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the cart was deleted, false if not found</returns>
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a paginated list of carts from the database based on specified filtering and ordering conditions.
        /// </summary>
        /// <param name="request">An object containing pagination and filtering parameters.</param>
        /// <param name="cancellationToken">A cancellation token to propagate notification that the operation should be canceled.</param>
        /// <returns>A paginated result containing a list of carts and total count, or null if no carts are found.</returns>
        Task<PaginatedResult<Cart>?> ListPaginatedAsync(PaginedFilter request, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing cart in the database.
        /// </summary>
        /// <param name="cart">The cart object containing updated values.</param>
        /// <param name="cancellationToken">A cancellation token to propagate notification that the operation should be canceled.</param>
        /// <returns>The updated cart object after saving changes to the database.</returns>
        Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken = default);
    }
}