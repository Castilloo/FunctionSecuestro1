using System;
using System.Threading.Tasks;

namespace SecuestroBienes.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISecuestroBienRepository SecuestroBienRepository { get; }
        IBandejaTrabajoRepository BandejaTrabajoRepository { get; }
        Task<int> Save();
    }
}
