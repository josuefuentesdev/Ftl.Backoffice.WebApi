using Ftl.Backoffice.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ftl.Backoffice.Application.Contact.Dtos
{
    public class GetOneContactResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        private string? _email;
        public string? Email
        {
            get
            {
                return _email;
            }
            set
            {
                Regex regex = new Regex("[a-zA-Z0-9]");
                if (value != null) _email = regex.Replace(value, "*");
                else _email = "";
            }
        }
        public string? CreatedBy { get; set; }
        public DateTimeOffset Created { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModified { get; set; }
    }
}
