using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3DemoProject.Api.Domain
{
    public class Address:BaseModel
    {
        [ForeignKey("Login.Id")]
        public string LoginId { get; set; }

        [StringLength(64, ErrorMessage = "StreetName cannot contain more than 64 chars")]
        public string StreetName { get; set; }


        [StringLength(32, ErrorMessage = "StreetNumber cannot contain more than 32 chars")]
        public string StreetNumber { get; set; }


        [StringLength(8, ErrorMessage = "ZipCode cannot contain more than 8 chars")]
        public string ZipCode { get; set; }


        [StringLength(32, ErrorMessage = "CityName cannot contain more than 32 chars")]
        public string CityName { get; set; }

    }
}
