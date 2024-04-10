using BookReadingApp.Application.Interfaces;
using BookReadingApp.Core.Modals;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingApp.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUser(Signup userSignup)
        {
            var user = new IdentityUser()
            {
                UserName = userSignup.userName,
                Email = userSignup.email
            };
            var result = await _userManager.CreateAsync(user, userSignup.password);
            return result;
        }

        public async Task<SignInResult> LoginUser(Login user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.userName, user.password, true, false);
            return result;
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }

        public string GetEmail(string organiser)
        {
            var result = _userManager.Users.FirstOrDefault(x => x.UserName == organiser).Email;
            return result;
        }
    }
}
