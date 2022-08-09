using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftl.Backoffice.Application.Order.Dtos
{
    public class UpdateOrderDto
    {
        public int ContactId { get; set; }
        public string Status { get; set; }
    }
}
