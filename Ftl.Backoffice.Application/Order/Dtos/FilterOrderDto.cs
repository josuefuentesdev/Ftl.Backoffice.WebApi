using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftl.Backoffice.Application.Order.Dtos
{
    public record FilterOrderDto
    {
        public DateTimeOffset StartAt { get; set; }
        public DateTimeOffset EndAt { get; set; }
    }
}
