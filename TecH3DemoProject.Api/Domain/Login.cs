using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecH3DemoProject.Api.Domain
{
    public class Login : BaseModel
    {
        [Required]
        [EmailAddress]
        [StringLength(128, ErrorMessage = "Email cannot have more than 128 chars")]
        public string Email { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "Password cannot have more than 64 chars")]
        [JsonIgnore]
        public string Password { get; set; }

        [ForeignKey("Role.Id")]
        public int RoleId { get; set; } = 1; // 1 = customerId

        public Role Role { get; set; }

        public IEnumerable<Address> Address { get; set; }
    }

    public class Role 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
