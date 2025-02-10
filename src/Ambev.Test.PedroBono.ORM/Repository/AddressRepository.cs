using Ambev.Test.PedroBono.Common.Security;
using Ambev.Test.PedroBono.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.ORM.Repository
{
    /// <summary>
    /// Implementation of IAddressRepository using Entity Framework Core
    /// </summary>
    public class AddressRepository : IAddressRepository
    {
        private readonly PostgresContext _context;

        /// <summary>
        /// Initializes a new instance of AddressRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public AddressRepository(PostgresContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a address in the database
        /// </summary>
        /// <param name="address">The address to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created address</returns>
        public async Task<Address> CreateAsync(Address address, CancellationToken cancellationToken = default)
        {
            var pastAddress = await GetByUserIdAsync(address.UserId, cancellationToken);

            if (pastAddress != null)
                _context.Remove(pastAddress);

            await _context.Addresses.AddAsync(address, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return address;
        }

        /// <summary>
        /// Retrieves a address by their user identifier
        /// </summary>
        /// <param name="userId">The unique identifier of the user</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The address if found, null otherwise</returns>
        public async Task<Address?> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default) =>
            await _context.Addresses.FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
    }
}
