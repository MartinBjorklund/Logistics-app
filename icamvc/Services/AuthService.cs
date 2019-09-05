using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICAMVC.Services
{
    public class AuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<bool> UserExist(string email)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(email);
            return user != null;
        }

        public async Task<bool> IsInRoleAsync(string email, string rolename)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(email);
            return await _userManager.IsInRoleAsync(user, rolename);
        }

        public async Task<bool> RoleExistsAsync(string rolename)
        {
            return await _roleManager.RoleExistsAsync(rolename);
        }

        public async Task CreateRoleAsync(string rolename)
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = rolename });
        }

        public async Task AddToRoleAsync(string email, string rolename)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(email);
            await _userManager.AddToRoleAsync(user, rolename);
        }

        public async Task CreateSuperAdminIfNotExist()
        {
            const string role = "SuperAdmin";
            IdentityUser user = await CreateUserIfNotExist("superadmin@gmail.com", "aQ!234567890");
            await CreateRole(role);
            await AddRoleToUser(role, user);
        }

        public async Task<IList<string>> GetRolesForUser(string email)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(email);

            return await _userManager.GetRolesAsync(user);
        }

        public async Task SignInByEmail(string email)
        {
            IdentityUser user = await _userManager.FindByNameAsync(email);
            await _signInManager.SignInAsync(user, true);
        }


        private async Task AddRoleToUser(string role, IdentityUser user)
        {
            if (!await _userManager.IsInRoleAsync(user, role))
            {
                IdentityResult result = await _userManager.AddToRoleAsync(user, role);
                if (!result.Succeeded)
                    throw new Exception($"Couldn't add role {role} to {user.Email}");
            }
        }

        private async Task CreateRole(string role)
        {
            bool roleExist = await RoleExistsAsync(role); // _roleManager.RoleExistsAsync(role);

            if (!roleExist)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(role));
                if (!result.Succeeded)
                    throw new Exception($"Couldn't create role {role}");
            }
        }

        private async Task<IdentityUser> CreateUserIfNotExist(string email, string password)
        {
            IdentityUser user = await _userManager.FindByNameAsync(email);

            if (user == null)
            {
                IdentityResult result = await _userManager.CreateAsync(new IdentityUser(email), password);
                if (!result.Succeeded)
                    throw new Exception($"Couldn't create user {email}");
            }

            return user;

        }
    }
}
