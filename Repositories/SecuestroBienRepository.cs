using SecuestroBienes.Interfaces;
using SecuestroBienes.Models.DataContext;
using SecuestroBienes.Models.Entities;

namespace SecuestroBienes.Repositories
{
    public class SecuestroBienRepository : GenericRepository<SecuestroBiene>, ISecuestroBienRepository
    {

        public SecuestroBienRepository(SecuestroDbContext dbContext) : base(dbContext) { }
    }
}
