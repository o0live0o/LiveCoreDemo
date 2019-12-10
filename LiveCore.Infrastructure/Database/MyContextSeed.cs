using LiveCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCore.Infrastructure.Database
{
     public class MyContextSeed
    {
        public static async Task SeedAsync(MyContext myContext)
        {
            if (!myContext.Users.Any())
            {
                myContext.Users.AddRange(
                    new List<User> { 
                        new User{  UserName ="Admin",
                        Pwd = "123456",
                        UUID = Guid.NewGuid().ToString()
                        }
                    });
            }
            await myContext.SaveChangesAsync();
        }
    }
}
