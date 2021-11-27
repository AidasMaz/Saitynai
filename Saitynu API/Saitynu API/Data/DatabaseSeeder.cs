using Microsoft.AspNetCore.Identity;
using Saitynu_API.Auth.Model;
using Saitynu_API.Data.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Data
{
    public class DatabaseSeeder
    {
        private readonly UserManager<RestUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(UserManager<RestUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            foreach (var role in RestUserRoles.All)
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            #region Adding default admins
            //var newAdminUser = new RestUser
            //{
            //    UserName = "admin1",
            //    Email = "admin1@admin.com"
            //};

            //var existingAdminUser = await _userManager.FindByNameAsync(newAdminUser.UserName);
            //if (existingAdminUser == null)
            //{
            //    var createAdminUserResult = await _userManager.CreateAsync(newAdminUser, "Saitynai123!");
            //    if (createAdminUserResult.Succeeded)
            //    {
            //        await _userManager.AddToRolesAsync(newAdminUser, RestUserRoles.All);
            //    }
            //}

            var newAdminUsers = new List<RestUser>();
            var adminUser1 = new RestUser
            {
                UserName = "admin1",
                Email = "admin1@admin.com"
            };
            var adminUser2 = new RestUser
            {
                UserName = "admin2",
                Email = "admin2@admin.com"
            };
            newAdminUsers.Add(adminUser1);
            newAdminUsers.Add(adminUser2);

            foreach (var adminUser in newAdminUsers)
            {
                var existingAdminUser = await _userManager.FindByNameAsync(adminUser.UserName);
                if (existingAdminUser == null)
                {
                    var createAdminUserResult = await _userManager.CreateAsync(adminUser, "Saitynai123!");
                    if (createAdminUserResult.Succeeded)
                    {
                        await _userManager.AddToRolesAsync(adminUser, RestUserRoles.All);
                    }
                }
            }
            #endregion
            #region Adding default testers
            //var newTesterUser = new RestUser
            //{
            //    UserName = "tester1",
            //    Email = "tester1@test.com"
            //};

            //var existingTesterUser = await _userManager.FindByNameAsync(newTesterUser.UserName);
            //if (existingTesterUser == null)
            //{
            //    var createTesterUserResult = await _userManager.CreateAsync(newTesterUser, "Saitynai123!");
            //    if (createTesterUserResult.Succeeded)
            //    {
            //        await _userManager.AddToRoleAsync(newTesterUser, RestUserRoles.Tester);
            //    }
            //}

            var newTesterUsers = new List<RestUser>();
            var testerUser1 = new RestUser
            {
                UserName = "tester1",
                Email = "tester1@test.com"
            };
            var testerUser2 = new RestUser
            {
                UserName = "tester2",
                Email = "tester2@test.com"
            };
            newTesterUsers.Add(testerUser1);
            newTesterUsers.Add(testerUser2);


            foreach (var testUser in newTesterUsers)
            {
                var existingTesterUser = await _userManager.FindByNameAsync(testUser.UserName);
                if (existingTesterUser == null)
                {
                    var createTesterUserResult = await _userManager.CreateAsync(testUser, "Saitynai123!");
                    if (createTesterUserResult.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(testUser, RestUserRoles.Tester);
                    }
                }
            }
            #endregion
        }
    }
}
