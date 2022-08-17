using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ftl.Backoffice.Application.Contact.Dtos
{
    public class GetContactsResponseDto
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
    }
}
