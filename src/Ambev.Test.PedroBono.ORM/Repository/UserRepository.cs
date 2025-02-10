﻿using Ambev.Test.PedroBono.Domain.Entities;
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
    /// Implementation of IUserRepository using Entity Framework Core
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly PostgresContext _context;

        /// <summary>
        /// Initializes a new instance of UserRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public UserRepository(PostgresContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new user in the database
        /// </summary>
        /// <param name="user">The user to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created user</returns>
        public async Task<User> CreateAsync(User user, CancellationToken cancellationToken = default)
        {
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return user;
        }

        /// <summary>
        /// Retrieves a user by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the user</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The user if found, null otherwise</returns>
        public async Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Users.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        /// <summary>
        /// Retrieves a user by their email address
        /// </summary>
        /// <param name="emailUsername">The email address or username to search for</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The user if found, null otherwise</returns>
        public async Task<User?> GetByEmailOrUsernameAsync(string emailUsername, CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => (u.Email == emailUsername || u.Username == emailUsername), cancellationToken);
        }

        /// <summary>
        /// Deletes a user from the database
        /// </summary>
        /// <param name="id">The unique identifier of the user to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the user was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var user = await GetByIdAsync(id, cancellationToken);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default)
        {
            _context.ChangeTracker.Clear();
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user;
        }

        public async Task<PaginatedResult<User>?> ListPaginatedAsync(PaginedFilter request, CancellationToken cancellationToken)
        {
            var count = await _context.Users.CountAsync(cancellationToken);
            var usersQueryable = _context.Users.AsQueryable();

            var conditions = request.Order.Split(',');
            int qtyConditions = 0;

            foreach (var condition in conditions)
            {
                var fieldAndOrder = condition.TrimStart().TrimEnd().Split(" ");
                var field = fieldAndOrder[0];
                var order = fieldAndOrder[1];

                if (order.ToLower() == "desc")
                    if (qtyConditions > 0)
                        usersQueryable = ((IOrderedQueryable<User>)usersQueryable).ThenByDescending(GetKeySelector(field));
                    else
                        usersQueryable = usersQueryable.OrderByDescending(GetKeySelector(field));
                else
                    if (qtyConditions > 0)
                        usersQueryable = ((IOrderedQueryable<User>)usersQueryable).ThenBy(GetKeySelector(field));
                    else
                        usersQueryable = usersQueryable.OrderBy(GetKeySelector(field));

                qtyConditions++;
            }

            var items = await usersQueryable.Skip((request.Page - 1) * request.Size).Take(request.Size).ToListAsync();
            return new PaginatedResult<User>(items, count, request.Page, request.Size);
        }

        private static Expression<Func<User, object>> GetKeySelector(string field) => field.ToLower().Trim() switch
        {
            "username" => user => user.Username,
            "email" => user => user.Email,
            "firstname" => user => user.FirstName,
            "lastname" => user => user.LastName,
            "phone" => User => User.Phone,
            "role" => user => user.Role,
            "status" => user => user.Status,
            _ => user => user.Id
        };
    }
}