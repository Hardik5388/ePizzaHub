using ePizzaHub.Models;
using ePizzaHubCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Services.Interfaces
{
    public interface IAuthServices 
    {
        UserModel ValidateUser(string email, string password);
    }
    
}
