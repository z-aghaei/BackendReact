using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepositoryUser
    {
        Task AddAsync(User user, CancellationToken cancellationToken);
    }
}
