using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepositoryUser
    {
        Task AddAsync(User user, CancellationToken cancellationToken);

        Task<User> GetAsync(string username, CancellationToken cancellationToken);

        Task<User> GetById(int id);

        Task<List<User>> GetAll();

    }
}
