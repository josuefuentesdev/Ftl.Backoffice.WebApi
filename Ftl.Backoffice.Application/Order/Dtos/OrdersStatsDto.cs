using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftl.Backoffice.Application.Order.Dtos
{
    public class OrdersStatsDto
    {
        public int Count { get; set; }
        public Decimal? Revenue { get; set; }
        public DateTimeOffset LastOrder { get; set; }
    }
}
