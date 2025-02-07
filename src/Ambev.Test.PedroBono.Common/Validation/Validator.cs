﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Common.Validation
{

    public static class Validator
    {
        public static async Task<IEnumerable<ValidationErrorDetail>> ValidateAsync<T>(T instance)
        {
            Type validatorType = typeof(IValidator<>).MakeGenericType(typeof(T));

            if (Activator.CreateInstance(validatorType) is not IValidator validator)
            {
                throw new InvalidOperationException($"No validator found for: {typeof(T).Name}");
            }

            var result = await validator.ValidateAsync(new ValidationContext<T>(instance));

            if (!result.IsValid)
            {
                return result.Errors.Select(o => (ValidationErrorDetail)o);
            }

            return [];
        }
    }
}
