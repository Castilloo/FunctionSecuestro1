using SecuestroBienes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecuestroBienes.Models.DataContext
{
    public class UnitOfWork : IUnitOFWork
    {
        public ISecuestroBienRepository _secuestroBienRepository { get; }
        public IBandejaTrabajoRepository _bandejaTrabajoRepository { get; }
        private readonly SecuestroDbContext _dbContext;

        public UnitOfWork(SecuestroDbContext dbContext, ISecuestroBienRepository secuestroBienRepository, IBandejaTrabajoRepository bandejaTrabajoRepository)
        {
            _dbContext = dbContext;
            _secuestroBienRepository = secuestroBienRepository;
            _bandejaTrabajoRepository = bandejaTrabajoRepository;
        }


        public async Task<int> Save() => await _dbContext.SaveChangesAsync();

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
