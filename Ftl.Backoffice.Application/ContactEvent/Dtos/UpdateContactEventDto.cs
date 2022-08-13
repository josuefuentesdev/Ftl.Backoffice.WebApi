using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftl.Backoffice.Application.ContactEvent.Dtos
{
    public class UpdateContactEventDto
    {
        public int ContactId { get; set; }
        public string EventType { get; set; }
    }
}
