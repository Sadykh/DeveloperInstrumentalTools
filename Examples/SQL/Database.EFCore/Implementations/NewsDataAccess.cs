using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Database.EFCore.Contracts;
using Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.EFCore.Implementations
{
    public class UserDataAccess: IUserDataAccess
    {
        
        private ExampleContext ExampleContext { get; }
        
        public UserDataAccess(ExampleContext exampleContext)
        {
            ExampleContext = exampleContext;
        }

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken ct = default)
        {
            return await this.ExampleContext.Users
                .Include(x => x.News)
                .OrderBy(x => x.TimeStamp)
                .ToListAsync(ct);
        }
    }
}