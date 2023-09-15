using SecuestroBienes.Interfaces;
using SecuestroBienes.Models.DataContext;
using SecuestroBienes.Models.Entities;

namespace SecuestroBienes.Repositories
{
    public class BandejaTrabajoRepository : GenericRepository<BandejaTrabajo>, IBandejaTrabajoRepository
    {
        public BandejaTrabajoRepository(SecuestroDbContext dbContext) : base(dbContext)
        {
        }
    }
}
