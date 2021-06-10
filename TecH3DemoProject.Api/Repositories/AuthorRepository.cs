using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Database;
using TecH3DemoProject.Api.Domain;

namespace TecH3DemoProject.Api.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAll();
        Task<Author> GetById(int id);
        Task<Author> Create(Author author);
        Task<Author> Update(int id, Author author);
        Task<Author> Delete(int id);
        //Task<Author> Delete(Author author);
    }


    // Repository er database arbejds-hesten. Det er kun igennem denne klasse Author data hentes/sendes
    public class AuthorRepository : IAuthorRepository
    {
        private readonly TecH3DemoContext _context;

        public AuthorRepository(TecH3DemoContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAll()
        {
            return await _context.Author
                .Where(a => a.deletedAt == null) // filtrer alle "slettede" fra
                //.OrderBy(a => a.createdAt) // især brugbart hvis ID er en Guid
                .OrderBy(a => a.FirstName)
                .OrderBy(a => a.LastName)
                .Include(a => a.Books)
                .ToListAsync();
        }

        public async Task<Author> GetById(int id)
        {
            return await _context.Author
                .Where(a => a.deletedAt == null) // filtrer alle "slettede" fra
                .Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Author> Create(Author author)
        {
            // tilføj oprettet dato og tid til elementet, så kan man sortere efter oprettelse
            author.createdAt = DateTime.Now;
            _context.Author.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> Update(int id, Author author)
        {
            var editAuthor = await _context.Author.FirstOrDefaultAsync(a => a.Id == id);
            if (editAuthor != null)
            {
                // tilføj rettelses tiden til elementet, så vi kan tracke seneste ændring
                editAuthor.updatedAt = DateTime.Now;
                editAuthor.FirstName = author.FirstName;
                editAuthor.LastName = author.LastName;
                _context.Author.Update(editAuthor);
                await _context.SaveChangesAsync();
            }
            return editAuthor;
        }

        public async Task<Author> Delete(int id)
        {
            var author = await _context.Author.FirstOrDefaultAsync(a => a.Id == id);
            if (author != null)
            {
                // soft delete tilføjer datetime for sletningstid, frem for at slette
                author.deletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return author;
        }
    }
}
