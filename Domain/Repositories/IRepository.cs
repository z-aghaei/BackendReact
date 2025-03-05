using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(User user, CancellationToken cancellationToken);

        Task<User> GetAsync(string username, string password, CancellationToken cancellationToken);

        Task<User> GetById(int id);

        Task<List<User>> GetAll();

        Task UpdateAsync(User entity, CancellationToken cancellationToken);
        Task DeleteAsync(User entity, CancellationToken cancellationToken);

    }
}
