using Microsoft.EntityFrameworkCore;
using SecuestroBienes.Interfaces;
using SecuestroBienes.Models.DataContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecuestroBienes.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly SecuestroDbContext _dbContext;
        private SecuestroDbContext dbContext;

        public GenericRepository(SecuestroDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TEntity>> ObtenerTodos()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }
    }
}