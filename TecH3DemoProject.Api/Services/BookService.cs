using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Domain;

namespace TecH3DemoProject.Api.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> CreateAsync(string title, DateTime published, int pages, int authorId);
        Task<Book> UpdateAsync(int id, string title, DateTime published, int pages, int authorId);
        Task<Book> DeleteAsync(int id);
    }

    public class BookSerice : IBookService
    {
        public Task<Book> CreateAsync(string title, DateTime published, int pages, int authorId)
        {
            throw new NotImplementedException();
        }

        public Task<Book> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetAllBooksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> UpdateAsync(int id, string title, DateTime published, int pages, int authorId)
        {
            throw new NotImplementedException();
        }
    }
}
