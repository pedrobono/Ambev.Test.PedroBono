﻿using Ambev.Test.PedroBono.Common.Validation;
using Ambev.Test.PedroBono.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Users.UpdateUser
{
    /// <summary>
    /// Command for creating a new user.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for creating a user, 
    /// including username, password, phone number, email, status, and role. 
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="UpdateUserResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="UpdateUserCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class UpdateUserCommand : IRequest<UpdateUserResult>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly Updated user.
        /// </summary>
        /// <value>A Id that uniquely identifies the Updated user in the system.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the user to be Updated.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the First of the user to be Updated.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Last of the user to be Updated.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password for the user.
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number for the user.
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address for the user.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the status of the user.
        /// </summary>
        public UserStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the role of the user.
        /// </summary>
        public UserRole Role { get; set; }


        public ValidationResultDetail Validate()
        {
            var validator = new UpdateUserCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
