using ePizzaHub.Repositories.Interfaces;
using ePizzaHub.Services.Interfaces;
using ePizzaHubCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Services.Implimentations
{
    public class CartServices : Services<Cart>, ICartServices
    {
        ICartRepositories _cartRepo;
        IRepositories<CartItem> _cartItemRepo;
        public CartServices(ICartRepositories cartRepo, IRepositories<CartItem> cartItemRepo) : base(cartRepo) 
        {
           _cartRepo = cartRepo;
            _cartItemRepo = cartItemRepo;
        }
        public Cart AddItem(int UserId, int ItemId, Guid CartId, decimal UnitPrice, int Quantity)
        {
            try
            {
                Cart cart = _cartRepo.GetCart(CartId);
                if (cart == null)
                {
                    cart = new Cart();
                    CartItem item = new CartItem {ItemId = ItemId, UnitPrice = UnitPrice, Quantity = Quantity };
                    cart.UserId = UserId;
                    cart.Id = CartId;
                    cart.CreatedDate = DateTime.Now;
                    cart.IsActive = true;
                    item.CartId = cart.Id;
                    cart.CartItems.Add(item);
                    _cartRepo.Add(cart);
                    _cartRepo.SaveChanges();

                }
                else 
                {
                    CartItem cartItem = cart.CartItems.Where(p => p.ItemId == ItemId).FirstOrDefault();
                    if(cartItem == null)
                    {
                        cartItem = new CartItem { ItemId = ItemId, UnitPrice = UnitPrice, Quantity = Quantity };
                        cartItem.CartId = cart.Id;
                        cart.CartItems.Add(cartItem);

                        _cartItemRepo.Update(cartItem);
                        _cartItemRepo.SaveChanges();

                    }
                    else
                    {
                         cartItem.Quantity += Quantity;
                        _cartItemRepo.Update(cartItem);
                        _cartItemRepo.SaveChanges();
                    }

                }
                return cart;
            }
            catch (Exception ex)
            {

                throw;
            }
            return null;
        }
    }
}
