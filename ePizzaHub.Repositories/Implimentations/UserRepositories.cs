using ePizzaHub.Models;
using ePizzaHub.Repositories.Interfaces;
using ePizzaHubCore;
using ePizzaHubCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Implimentations
{
    public class UserRepositories : Repositories<User>, IUserRepositories
    {
        public UserRepositories(AppDbContext db) : base(db)
        {

        }
        public UserModel ValidateUser(string Email, string Password)
        {
            User user = _context.Users.Include(u => u.Roles).Where(u => u.Email == Email).FirstOrDefault();
            if (user != null)
            {
                bool isVerified = BCrypt.Net.BCrypt.Verify(Password, user.Password);
                if (isVerified) 
                {
                    UserModel userModel = new UserModel
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Roles = user.Roles.Select(r => r.Name).ToArray()
                    };
                    return userModel;
                }

            }
            return null;

        }
    }

}