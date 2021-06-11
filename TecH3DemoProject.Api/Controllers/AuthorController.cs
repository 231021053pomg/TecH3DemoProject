using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Domain;
using TecH3DemoProject.Api.Services;

namespace TecH3DemoProject.Api.Controllers
{
    //[Authorize(Roles = UserRoles.Admin)]

    // Controller tager sig af HttpRequests og returnerer data til client...
    [ApiController]
    [Route("api/author")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/author
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            // example to illustrate endpoint being testable for pretty much everything
            try
            {
                var authors = await _authorService.GetAllAuthors();
                if (authors == null)
                {
                    // something has gone wrong serverside, return code 500
                    return Problem("Unexpected null returned from service");
                }
                else if ((authors as List<Author>).Count == 0)
                {
                    // no data exists, but everything is still ok, return code 204
                    return NoContent();
                }
                // we got data! return with code 200
                return Ok(authors);
            }
            catch (Exception ex)
            {
                // handle any other exeptions raised by sending code 500
                return Problem(ex.Message);
            }
        }

        // GET api/author/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Author))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var author = await _authorService.GetAuthorById(id);
                if (author == null)
                {
                    return NotFound();
                }
                return Ok(author);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // POST api/author
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(Author author)
        {
            try
            {
                if (author == null)
                {
                    return BadRequest("Author fail");
                }
                var newAuthor = await _authorService.Create(author);
                return Ok(newAuthor);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // PUT api/author/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Author author)
        {
            try
            {
                var editAuthor = await _authorService.Update(id, author);
                if (editAuthor == null)
                {
                    return Problem("Edit failed somehow");
                }
                return Ok(editAuthor);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // DELETE api/author/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var author = await _authorService.Delete(id);
                return Ok(author);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
