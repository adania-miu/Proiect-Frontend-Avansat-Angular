using Microsoft.AspNetCore.Identity;
using Backend.BLL.Interfaces;
using Backend.BLL.Models;
using Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BLL.Managers
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenHelper _tokenHelper;
        public static Random random = new Random();
        public string IBANgenerator()
        {
            const string chars2 = "RO";
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return chars2 + new string(Enumerable.Repeat(chars, 32)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public AuthManager(SignInManager<User> signInManager,
            ITokenHelper tokenHelper,
            UserManager<User> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHelper = tokenHelper;
        }
        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null)
                return new LoginResult
                {
                    Success = false
                };

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);

            if (result.Succeeded)
            {
                var token = await _tokenHelper.GenerateAccessToken(user);
                var refreshToken = _tokenHelper.CreateRefreshToken();

                user.RefreshToken = refreshToken;
                await _userManager.UpdateAsync(user);

                return new LoginResult
                {
                    Success = true,
                    AccessToken = token,
                    RefreshToken = refreshToken
                };
            }
            else
                return new LoginResult
                {
                    Success = false
                };
        }

        public async Task<int> Register(RegisterModel registerModel)
        {
            var user = new User
            {
                Email = registerModel.Email,
                UserName = registerModel.UserName,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                UserType = "",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                Sold = 0,
                IBAN = IBANgenerator()
            };
            if (await _userManager.FindByEmailAsync(user.Email) != null)
            {
                return 2; //email already used
            }
            if (await _userManager.FindByNameAsync(user.UserName) != null)
            {
                return 3; //username already used
            }

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, registerModel.Role);

                return 1; //successfully created
            }

            return 0; //error while creating account

        }


        public async Task<string> Refresh(RefreshModel refreshModel)
        {
            var principal = _tokenHelper.GetPrincipalFromExpiredToken(refreshModel.AccessToken);
            var username = principal.Identity.Name;

            var user = await _userManager.FindByNameAsync(username);

            if (user.RefreshToken != refreshModel.RefreshToken)
                return "Bad Refresh";

            var newJwtToken = await _tokenHelper.GenerateAccessToken(user);

            return newJwtToken;
        }
    }
}
