using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PSCore.Helpers;
using PSCore.Helpers.Queries;
using PSCore.Models;
using PSCore.Repositories;

namespace PSCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly IMediator _mediator;

        public IConfiguration Configuration { get; }
        public string connStr = String.Empty;

        public UsersController(IConfiguration configuration, 
                                IWebHostEnvironment env, 
                                IUserService userService,
                                IMediator mediator)
        {
            Configuration = configuration;
            _userService = userService;
            _mediator = mediator;
        }

        [Route("me")]
        [TLVAuthorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<HVNUser>> Me()
        {
            try
            {
                var _user = this.User;
                //_userService.

                var resp = await _mediator.Send(new GetHVNUserQuery()
                {
                    caller = this.User.ToString()
                });
                return resp;

                //UserRepository repo = new UserRepository(Configuration, this.User);
                //return CreatedAtAction("me", repo.Me());
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }
    }
}
