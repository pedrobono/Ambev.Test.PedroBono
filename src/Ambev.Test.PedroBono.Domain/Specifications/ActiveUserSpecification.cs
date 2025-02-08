using Ambev.Test.PedroBono.Domain.Entities;
using Ambev.Test.PedroBono.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Domain.Specifications
{
    public class ActiveUserSpecification : ISpecification<User>
    {
        public bool IsSatisfiedBy(User user)
        {
            return user.Status == UserStatus.Active;
        }
    }
}
