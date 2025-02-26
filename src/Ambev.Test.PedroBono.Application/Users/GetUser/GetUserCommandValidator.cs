﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Users.GetUser
{
    /// <summary>
    /// Validator for GetUserCommand
    /// </summary>
    public class GetUserCommandValidator : AbstractValidator<GetUserCommand>
    {
        /// <summary>
        /// Initializes validation rules for GetUserCommand
        /// </summary>
        public GetUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("User ID is required");
        }
    }
}
