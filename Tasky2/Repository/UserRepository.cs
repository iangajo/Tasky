using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasky2.Data;
using Tasky2.Entities;
using Tasky2.Models;
using Task = Tasky2.Entities.Task;

namespace Tasky2.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(RegistrationViewModel viewModel)
        {

            if (_dbContext.User.Any(u => u.Email == viewModel.Email))
            {
                return 0;
            }

            var entity = _dbContext.User.Add(new User()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Password = viewModel.Password,
                Email = viewModel.Email

            }).Entity;

            await _dbContext.SaveChangesAsync();

            return entity.UserId;
        }

        public async Task<User> Authenticate(LoginViewModel viewModel)
        {
            var isAuthenticated = await _dbContext.User.AnyAsync(u => u.Email == viewModel.Email && u.Password == viewModel.Password);

            return isAuthenticated ? _dbContext.User.FirstOrDefault(u => u.Email == viewModel.Email && u.Password == viewModel.Password) : null;
        }
    }
}
