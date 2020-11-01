using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSCore.Models
{
    public class AuthenticateResponse
    {
        public string Name { get; set; }
        public string AccountName { get; set; }

        public string Token { get; set; }

        public AuthenticateResponse(HVNUser user, string token)
        {
            Name = user.userName;
            AccountName = user.userAccountName;
            Token = token;
        }
    }
}
