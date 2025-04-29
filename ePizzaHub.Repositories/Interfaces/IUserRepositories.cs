using ePizzaHubCore.Entities;
using ePizzaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Interfaces
{
    public interface IUserRepositories : IRepositories<User>
    {
        UserModel ValidateUser(string email, string password);
    }
}
