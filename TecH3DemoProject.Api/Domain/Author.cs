using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TecH3DemoProject.Api.Domain
{
    public class Author: BaseModel
    {

        public Author()
        {
            Books = new List<Book>();
        }

        // Id exists in BaseModel

        [Required]
        [StringLength(32, ErrorMessage = "Firstname length can't be more than 32 chars")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Lastname length can't be more than 32 chars")]
        public string LastName { get; set; }

        public IEnumerable<Book> Books { get; set; }

    }
}
