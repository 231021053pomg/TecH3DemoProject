using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3DemoProject.Api.DTO
{
    public class LoginRequest
    {
        [Required]
        [StringLength(128, ErrorMessage = "Email length can't be more than 128 chars")]
        public string Email { get; set; }

        [JsonIgnore]
        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 or more chars")]
        [StringLength(64, ErrorMessage = "Password length can't be more than 64 chars")]
        public string Password { get; set; }
    }
}
