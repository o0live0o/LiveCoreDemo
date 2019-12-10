using LiveCore.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveCore.Api.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly MyContext _myContext;

        public UserController(MyContext myContext)
        {
            _myContext = myContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            var users = await _myContext.Users.ToListAsync();
            return Ok(users);
        }
    }
}
