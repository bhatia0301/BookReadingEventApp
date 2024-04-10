using BookReadingApp.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookReadingApp.Application.Interfaces
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUser(Signup user);
        Task<SignInResult> LoginUser(Login user);
        Task SignOut();
        string GetEmail(string organiser);

    }
}
