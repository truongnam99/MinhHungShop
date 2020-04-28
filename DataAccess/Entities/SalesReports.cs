using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class SalesReports
    {
        public long Id { get; set; }
        public DateTime? DateReport { get; set; }
        public decimal? Revenue { get; set; }
    }
}
