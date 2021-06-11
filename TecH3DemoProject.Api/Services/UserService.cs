using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TecH3DemoProject.Api.Domain;
using TecH3DemoProject.Api.Repositories;

namespace TecH3DemoProject.Api.Services
{
    public interface IUserService
    {
        Task<List<Login>> GetAllLogins();
        Task<Login> GetById(int id);
        Task<Login> GetUserByEmailAndPassword(string email, string password);
        Task<Login> Create(Login login);
        Task<Login> Update(int id, Login login);
        Task<Login> Delete(int id);
        // bool IsAnExistingUser(string userName);
        // bool IsValidUserCredentials(string userName, string password);
        // string GetUserRole(string userName);
    }

    public class UserService : IUserService
    {
        //private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;

        //private readonly IDictionary<string, string> _users = new Dictionary<string, string>
        //{
        //    { "test1", "password1" },
        //    { "test2", "password2" },
        //    { "admin", "securePassword" }
        //};

        // inject your database here for user validation
        public UserService(/*ILogger<UserService> logger,*/ IUserRepository userRepository)
        {
            _userRepository = userRepository;
            //_logger = logger;
        }

        public Task<Login> Create(Login login)
        {
            throw new System.NotImplementedException();
        }

        public Task<Login> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Login>> GetAllLogins()
        {
            var logins = await _userRepository.GetAllLogins();
            return logins;
        }

        public Task<Login> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Login> GetUserByEmailAndPassword(string email, string password)
        {
            var login = await _userRepository.Login(email, password);
            return login;
        }

        public Task<Login> Update(int id, Login login)
        {
            throw new System.NotImplementedException();
        }


        //// TODO: perform real login on repo.
        //public async Task<bool> IsValidUserCredentials(string userName, string password)
        //{
        //    //_logger.LogInformation($"Validating user [{userName}]");
        //    if (string.IsNullOrWhiteSpace(userName))
        //    {
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(password))
        //    {
        //        return false;
        //    }

        //    var login = await _userRepository.Login(userName, password);

        //    return login != null;
        //}

        //// TODO: replace with repo call
        //public bool IsAnExistingUser(string userName)
        //{
        //    return _users.ContainsKey(userName);
        //}

        //// TODO: update with repo call, should use actual data not "Admin" username
        //public string GetUserRole(string userName)
        //{
        //    if (!IsAnExistingUser(userName))
        //    {
        //        return string.Empty;
        //    }

        //    if (userName == "admin")
        //    {
        //        return UserRoles.Admin;
        //    }

        //    return UserRoles.Customer;
        //}
    }

    

    public static class UserRoles
    {
        public const string Admin = nameof(Admin);
        public const string Customer = nameof(Customer);
    }
}
