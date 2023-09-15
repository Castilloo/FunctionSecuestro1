using System;
using System.Threading.Tasks;

namespace SecuestroBienes.Interfaces
{
    public interface IUnitOFWork : IDisposable
    {
        ISecuestroBienRepository _secuestroBienRepository { get; }
        IBandejaTrabajoRepository _bandejaTrabajoRepository { get; }
        Task<int> Save();
    }
}
