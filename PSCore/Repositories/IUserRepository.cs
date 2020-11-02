using PSCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PSCore.Repositories
{
    public interface IUserRepository : IRepository<HVNUser>
    {
        Task<HVNUser> GetHVNUserAsync(CancellationToken cancellationToken);

        Task<HVNUser> GetHVNUserByIdAsync(Guid orderId, CancellationToken cancellationToken);

        Task<List<HVNUser>> GetHVNUserByGuidAsync(Guid customerId, CancellationToken cancellationToken);
    }
}
