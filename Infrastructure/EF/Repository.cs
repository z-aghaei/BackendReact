using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF
{
    public class Repository<T> : Domain.Repositories.IRepository<T> where T : class
    {
        private DbContext _dbContext;
        public void Add(T entity)
        {
            _dbContext.Add(entity);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
