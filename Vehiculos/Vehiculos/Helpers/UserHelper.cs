﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehiculos.Data;
using Vehiculos.Data.Entities;

namespace Vehiculos.Models.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _dataContext;
        private readonly SignInManager<User> _signInManager;
        public UserHelper(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, DataContext dataContext,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dataContext = dataContext;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
            }
        }

        public Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _dataContext.Users
                .Include(x => x.DocumentType)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
