using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF
{
    public class UserRepository : IRepositoryUser
    {
        //private readonly DbSet<User> _user;
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext dbContext)
        {
            // _user = dbContext.Users;
            _appDbContext = dbContext;
        }
        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            _appDbContext.Users.Add(user);
            try
            {
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
            }

            //_user.AddAsync(user);
        }
<<<<<<< HEAD
        public async Task<User> GetAsync(string username, CancellationToken cancellationToken)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(user => user.UserName.Equals(username));
        }

        public async Task<List<User>> GetAll()
        {
            return await _appDbContext.Users.Where(item => item.IsDeleted == false).ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _appDbContext.Users.Where(item => item.IsDeleted == false && item.Id == id). FirstOrDefaultAsync();
                
                

        }

    }
}
