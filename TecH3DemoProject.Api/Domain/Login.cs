using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3DemoProject.Api.Domain
{
    public class Login:BaseModel
    {
        [Required]
        [EmailAddress]
        [StringLength(128, ErrorMessage ="Email cannot have more than 128 chars")]
        public string Email { get; set; }

        [Required]
        [StringLength(64, ErrorMessage ="Password cannot have more than 64 chars")]
        public string Password { get; set; }

        public int AccessLevel { get; set; } = 0;

        public List<Address> Address { get; set; }
    }
}
