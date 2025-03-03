using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepositoryUser//:IRepository<User>
    {
        Task AddAsync(User user, CancellationToken cancellationToken);
    }
}
