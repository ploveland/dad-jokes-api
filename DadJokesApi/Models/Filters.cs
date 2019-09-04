using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dadjokes.Models
{
    public class Filters
    {
        public string OrderBy { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 200;

        public string Search { get; set; }
    }
}