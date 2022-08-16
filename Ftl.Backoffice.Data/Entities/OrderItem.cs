using Ftl.Backoffice.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftl.Backoffice.Core.Entities
{
    public class OrderItem : AuditableEntity
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string ContactEmail { get; set; }
        public string? ExecutionId { get; set; }
        public string Status { get; set; }
        public Decimal? NetPrice { get; set; }
    }
}
