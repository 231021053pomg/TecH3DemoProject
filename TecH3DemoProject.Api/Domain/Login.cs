using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TecH3DemoProject.Api.Domain
{
    public class Login : BaseModel
    {
        [Required]
        [StringLength(128, ErrorMessage = "Email length can't be more than 128 chars")]
        public string Email { get; set; }

        [JsonIgnore]
        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 or more chars")]
        [StringLength(64, ErrorMessage = "Password length can't be more than 64 chars")]
        public string Password { get; set; }

        [Required]
        [Range(0,100, ErrorMessage ="AccessLevel must be between 0 and 100")]
        public int AccessLevel { get; set; } // 0 = gæst, 1 = kunde, 100 = admin
    }
}
