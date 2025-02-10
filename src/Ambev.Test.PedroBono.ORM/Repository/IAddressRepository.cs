using Ambev.Test.PedroBono.Domain.Entities;

namespace Ambev.Test.PedroBono.ORM.Repository
{
    public interface IAddressRepository
    {
        Task<Address> CreateAsync(Address address, CancellationToken cancellationToken = default);
        Task<Address?> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default);
    }
}