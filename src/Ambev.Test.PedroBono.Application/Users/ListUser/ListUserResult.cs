using Ambev.Test.PedroBono.Application.Users.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.Application.Users.ListUser
{
    /// <summary>
    /// Represents the response returned after get a user by an ID.
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of an user,
    /// which can be used for subsequent operations or reference.
    /// </remarks>
    public class ListUserResult
    {
        public List<GetUserResult> Data { get; set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
    }
}
