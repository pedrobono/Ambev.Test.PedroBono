using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Test.PedroBono.ORM.Common
{
    public class PaginedFilter
    {
        /// <summary>
        /// Page number for pagination (default: 1)
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Number of items per page(default: 10)
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Ordering of results (e.g., "username asc, email desc")
        /// </summary>
        public string Order { get; set; }
    }
}
