using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PSCore.Helpers;
using PSCore.Repositories;

namespace PSCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public IConfiguration Configuration { get; }
        public string connStr = String.Empty;

        public UsersController(IConfiguration configuration, IWebHostEnvironment env, IUserService userService)
        {
            Configuration = configuration;
            _userService = userService;
        }

        [Route("me")]
        [TLVAuthorize]
        [HttpGet]
        public async Task<IActionResult> Me()
        {
            try
            {
                var _user = this.User;
                //_userService.

                UsersRepository repo = new UsersRepository(Configuration, this.User);
                return CreatedAtAction("me", repo.Me());
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }
    }
}
