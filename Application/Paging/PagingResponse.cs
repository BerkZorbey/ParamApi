using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject.Paging
{
    public class PagingResponse
    {
        public int TotalCount { get; set; } = 0;
        public int TotalPages { get; set; } = 1;
        public int? NextPage { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int? PreviousPage { get; set; }
    }
}
