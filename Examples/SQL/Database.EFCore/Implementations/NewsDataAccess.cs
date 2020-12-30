using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Database.EFCore.Contracts;
using Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.EFCore.Implementations
{
    public class NewsDataAccess: INewsDataAccess
    {
        
        private ExampleContext ExampleContext { get; }
        
        public NewsDataAccess(ExampleContext exampleContext)
        {
            ExampleContext = exampleContext;
        }

        public async Task<IEnumerable<News>> GetAllAsync(CancellationToken ct = default)
        {
            return await this.ExampleContext.News
                .Include(x => x.User)
                .OrderBy(x => x.TimeStamp)
                .ToListAsync(ct);
        }
    }
}