using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Database.EFCore.Entities;

namespace Database.EFCore.Contracts
{
    public interface INewsDataAccess
    {
        Task<IEnumerable<News>> GetAllAsync(CancellationToken ct = default);
    }
}