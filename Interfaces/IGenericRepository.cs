using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecuestroBienes.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> ObtenerTodos();
        Task CrearBD();
    }
}
