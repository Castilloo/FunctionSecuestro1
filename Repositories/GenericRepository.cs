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
        private DbSet<TEntity> _dbSet;

        public GenericRepository(SecuestroDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();

        }

        public async Task<IEnumerable<TEntity>> ObtenerTodos()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task CrearBD()
        {
            await _dbContext.Database.EnsureCreatedAsync();
        }
    }
}