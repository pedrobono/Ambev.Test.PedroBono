using Ambev.Test.PedroBono.Domain.Entities;
using Ambev.Test.PedroBono.ORM.Common;

namespace Ambev.Test.PedroBono.ORM.Repository
{
    /// <summary>
    /// Implementation of ICartProductRepository using Entity Framework Core
    /// </summary>
    public interface ICartProductRepository
    {

        /// <summary>
        /// Creates a new cartProduct in the database
        /// </summary>
        /// <param name="cartProduct">The cartProduct to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created cartProduct</returns>
        Task<CartProduct> CreateAsync(CartProduct cartProduct, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a cartProduct by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the cartProduct</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The cartProduct if found, null otherwise</returns>
        Task<CartProduct?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a cartProduct from the database
        /// </summary>
        /// <param name="id">The unique identifier of the cartProduct to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the cartProduct was deleted, false if not found</returns>
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a paginated list of cartProducts from the database based on specified filtering and ordering conditions.
        /// </summary>
        /// <param name="request">An object containing pagination and filtering parameters.</param>
        /// <param name="cancellationToken">A cancellation token to propagate notification that the operation should be canceled.</param>
        /// <returns>A paginated result containing a list of cartProducts and total count, or null if no cartProducts are found.</returns>
        Task<PaginatedResult<CartProduct>?> ListPaginatedAsync(PaginedFilter request, CancellationToken cancellationToken);

        /// <summary>
        /// Updates an existing cartProduct in the database.
        /// </summary>
        /// <param name="cartProduct">The cartProduct object containing updated values.</param>
        /// <param name="cancellationToken">A cancellation token to propagate notification that the operation should be canceled.</param>
        /// <returns>The updated cartProduct object after saving changes to the database.</returns>
        Task<CartProduct> UpdateAsync(CartProduct cartProduct, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes all products associated with a specific cart.
        /// </summary>
        /// <param name="id">The unique identifier of the cart to delete all products from.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous delete operation.</returns>
        Task<bool> DeleteAllByCartIdAsync(int id, CancellationToken cancellationToken);
    }
}