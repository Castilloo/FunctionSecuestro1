using Microsoft.Extensions.Configuration;
using SecuestroBienes.Interfaces;
using SecuestroBienes.Repositories;
using System.Data;
using System.Threading.Tasks;

namespace SecuestroBienes.Models.DataContext
{
    internal class UnitOfWork2 : IUnitOfWork
    {
        private readonly IConfiguration _config;
        private IDbConnection _dbConnection;
        private IDbTransaction _dbTransaction;
        private ISecuestroBienRepository _secuestroBienRepository;
        private readonly DapperContext _dbContext;

        public UnitOfWork2(IConfiguration config, ISecuestroBienRepository secuestroBienRepository, DapperContext dbContext)
        {
            _config = config;
            _dbContext = dbContext;
            _dbConnection = dbContext.CreateConnection();
            _dbConnection.Open();
            _dbTransaction = _dbConnection.BeginTransaction();

        }

        public async Task<int> Save() => await _dbContext.SaveChangesAsync();

        public void Dispose()
        {
            //await Save();
            //_dbContext.Dispose();
        }
    }
}
