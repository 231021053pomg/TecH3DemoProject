using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3DemoProject.Api.Database;
using TecH3DemoProject.Api.Domain;

namespace TecH3DemoProject.Api.Repositories
{

    public interface IUserRepository
    {
        Task<List<Login>> GetAllLogins();
        Task<Login> GetLoginById(int id);
        Task<Login> CreateLogin(Login login);
        Task<Login> UpdateLogin(int id, Login login);
        Task<Login> DeleteLogin(int id);

        Task<Login> Login(string email, string password);
    }
    public class UserRepository : IUserRepository
    {
        private readonly TecH3DemoContext _context;

        public UserRepository(TecH3DemoContext context)
        {
            _context = context;
        }

        public async Task<List<Login>> GetAllLogins()
        {
            return await _context.Login
                .Where(l => l.deletedAt == null)
                .ToListAsync();
        }

        public async Task<Login> GetLoginById(int id)
        {
            return await _context.Login
                .Where(l => l.deletedAt == null)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Login> Login(string email, string password)
        {
            return await _context.Login
                .Where(l => l.deletedAt == null)
                .FirstOrDefaultAsync(l => l.Email == email && l.Password == password);
        }

        public async Task<Login> CreateLogin(Login login)
        {
            login.createdAt = DateTime.Now;
            _context.Login.Add(login);
            await _context.SaveChangesAsync();
            return login;
        }
        
        public async Task<Login> UpdateLogin(int id, Login login)
        {
            var editLogin = await GetLoginById(id);
            if(editLogin != null)
            {
                editLogin.updatedAt = DateTime.Now;
                editLogin.Email = login.Email;
                if(login.Password != "")
                {
                    editLogin.Password = login.Password;
                }
            }
            return editLogin;
        }

        public async Task<Login> DeleteLogin(int id)
        {
            var deleteLogin = await GetLoginById(id);
            if(deleteLogin != null)
            {
                deleteLogin.deletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return deleteLogin;
        }


    }
}
