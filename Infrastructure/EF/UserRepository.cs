using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF
{
    public class UserRepository :  IRepositoryUser
    {
     private readonly DbSet<User> _user;
     private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext dbContext) {
            _user = dbContext.Users;
            _appDbContext = dbContext;
        }
        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            await _user.AddAsync(user);
        }
    }
}
