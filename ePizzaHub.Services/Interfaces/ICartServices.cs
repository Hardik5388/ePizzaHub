using ePizzaHubCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Services.Interfaces
{
    public interface ICartServices : IServices<Cart>
    {
        Cart AddItem(int UserId, int ItemId, Guid CartId, decimal UnitPrice, int Quantity);
    }
}
