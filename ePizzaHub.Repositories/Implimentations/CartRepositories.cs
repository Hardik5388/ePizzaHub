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
    public class CartRepositories : Repositories<Cart>, ICartRepositories
    {
        public CartRepositories(AppDbContext context) : base(context) 
        {
            
        }
        public Cart GetCart(Guid id)
        {
            return _context.Carts.Include(c=>c.CartItems).Where(c=> c.Id == id && c.IsActive == true).FirstOrDefault();
        }
    }
}
