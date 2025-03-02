using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
