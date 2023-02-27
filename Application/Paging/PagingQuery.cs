using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject.Paging
{
    public class PagingQuery
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Sort { get; set; } = "FirstName";
        public SortDirection SortingDirection { get; set; }



        public enum SortDirection
        {
            ASC = 1,
            DESC = 2
        }
    }
}

