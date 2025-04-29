using ePizzaHub.Models;
using ePizzaHubCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Services.Interfaces
{
    public interface IItemServices : IServices<Item>
    {
        IEnumerable<ItemModel> GetItems();
    }
   
}
