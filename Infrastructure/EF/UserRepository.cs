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
  
     private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext dbContext) {
         
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
           
           
        }

        public async Task<User> GetAsync(string username,string password, CancellationToken cancellationToken)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(user => user.UserName.Equals(username) & user.PasswordHash.Equals(password));
        }

        public async Task<List<User>> GetAll()
        {
            return await _appDbContext.Users.Where(item => item.IsDeleted == false).ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _appDbContext.Users.Where(item => item.IsDeleted == false && item.Id == id).AsNoTracking(). FirstOrDefaultAsync();
                
                

        }

        public async Task UpdateAsync(User entity, CancellationToken cancellationToken)
        {
            try
            {
                _appDbContext.Update(entity);
                await _appDbContext.SaveChangesAsync();
            }
            catch(Exception)
            {

            }
         
        }

        public async Task DeleteAsync(User entity, CancellationToken cancellationToken)
        {
            try
            {
                entity.IsDeleted= true;
                _appDbContext.Update(entity);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
        }
    }
}
