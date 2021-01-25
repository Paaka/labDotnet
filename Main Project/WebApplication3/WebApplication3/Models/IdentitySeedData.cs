using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApplication3.Models
{
    public class IdentitySeedData
    {
        private const string Login = "Admin";
        private const string Password = "Admin123!";

        public static async Task EnsurePopulated(UserManager<IdentityUser> userManager)
        {
            IdentityUser user = await userManager.FindByNameAsync(Login);

            if(user == null)
            {
                user = new IdentityUser("Admin");
                await userManager.CreateAsync(user, Password);
            }
        }

    }
}
