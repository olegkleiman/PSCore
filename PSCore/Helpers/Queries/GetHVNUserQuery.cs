using MediatR;
using PSCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSCore.Helpers.Queries
{
    public class GetHVNUserQuery : IRequest<HVNUser>
    {
    }
}
