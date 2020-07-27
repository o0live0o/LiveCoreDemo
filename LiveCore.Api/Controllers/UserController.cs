using LiveCore.Infrastructure.Database;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace LiveCore.Api.Controllers
{
    [EnableCors("any")]
    //[Route("api/users")]
    [Route("api/[controller]/[action]")]
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
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string privateKey =  rsa.ToXmlString(true);
            string publicKey = rsa.ToXmlString(false);

            rsa.FromXmlString(publicKey);
            byte[] publicByte = rsa.Encrypt(Encoding.UTF8.GetBytes(DateTime.Now.ToString()+"云在水流斋"+ DateTime.Now.ToString()), false);
            string publicStr = Convert.ToBase64String(publicByte);

            RSACryptoServiceProvider rsaPrivate = new RSACryptoServiceProvider();
            rsaPrivate.FromXmlString(privateKey);
            byte[] privateByte = rsaPrivate.Decrypt(Convert.FromBase64String(publicStr), false);
            string privateStr = Encoding.UTF8.GetString(privateByte);

            var users = await _myContext.Users.ToListAsync();
            return Ok(users);
        }
    }
}
