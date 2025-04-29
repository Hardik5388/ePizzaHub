using ePizzaHub.Models;
using ePizzaHub.Repositories.Interfaces;
using ePizzaHub.Services.Interfaces;
using ePizzaHubCore;
using ePizzaHubCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Services.Implimentations
{
    public class AuthServices : IAuthServices
    {
        IUserRepositories _Userrepo;
        public AuthServices(IUserRepositories Userrepo) 
        {
            _Userrepo = Userrepo;
        }
        public UserModel ValidateUser(string Email, string Password)
        {
            UserModel user = _Userrepo.ValidateUser(Email, Password);
            if (user != null)
            {
                return user;
            }
            return null;
        }
    }
}
