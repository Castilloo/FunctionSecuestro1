using SecuestroBienes.Interfaces;
using SecuestroBienes.Models.Entities;
using SecuestroBienes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecuestroBienes.Models.DataContext
{
    public class UnitOfWork : IUnitOfWork
    {
        public ISecuestroBienRepository _secuestroBienRepository;
        public IBandejaTrabajoRepository _bandejaTrabajoRepository;
        private readonly SecuestroDbContext _dbContext;

        public UnitOfWork(SecuestroDbContext dbContext) => _dbContext = dbContext;

        public ISecuestroBienRepository SecuestroBienRepository
        {
            get
            {
                return _secuestroBienRepository == null ?
                    _secuestroBienRepository = new SecuestroBienRepository(_dbContext) :
                    _secuestroBienRepository;

            }
        }

        public IBandejaTrabajoRepository BandejaTrabajoRepository
        {
            get
            {
                return _bandejaTrabajoRepository == null ?
                    _bandejaTrabajoRepository = new BandejaTrabajoRepository(_dbContext) :
                    _bandejaTrabajoRepository;

            }
        }

        public async Task<int> Save() => await _dbContext.SaveChangesAsync();

        public async void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
