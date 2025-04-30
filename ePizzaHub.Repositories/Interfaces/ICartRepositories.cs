using ePizzaHubCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Interfaces
{
    public interface ICartRepositories : IRepositories<Cart>
    {
        Cart GetCart(Guid id);
    }
}
