using MediatR;
using PSCore.Models;
using PSCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PSCore.Helpers.Queries
{
    public class GetHVNUserQueryHandler : IRequestHandler<GetHVNUserQuery, HVNUser>
    {
        private readonly IUserRepository _userRepository;

        public GetHVNUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        Task<HVNUser> IRequestHandler<GetHVNUserQuery, HVNUser>.Handle(GetHVNUserQuery request, CancellationToken cancellationToken)
        {
            var caller = request.caller;
            return _userRepository.GetHVNUserAsync(cancellationToken);
        }
    }
}
