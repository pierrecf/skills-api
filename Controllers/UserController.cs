using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skills_api.Models;
using skills_api.Services.Interfaces;

namespace skills_api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController (IUserService userService) : ControllerBase
    {
        

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users= await userService.GetAllUsersAsync();
            return Ok(users);
        }
    }
}
