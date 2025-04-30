using ePizzaHub.Services.Interfaces;
using ePizzaHub.UI.Helpers;
using ePizzaHubCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ePizzaHub.UI.Controllers
{
    public class CartController : BaseController
    {
        ICartServices _cartServices;

        public CartController(ICartServices cartServices)
        {
            _cartServices = cartServices;   
        }
        Guid CartId
        {
            get
            {
                Guid id;
                string CID = Request.Cookies["CID"];
                if (string.IsNullOrEmpty(CID))
                {
                    id = Guid.NewGuid();
                    Response.Cookies.Append("CID", id.ToString(), new CookieOptions { Expires = DateTime.Now.AddDays(1) });
                }
                else
                {
                    id = Guid.NewGuid();
                }
                return id;
            }
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Cart/AddToCart/{ItemId}/{UnitPrice}/{Quantity}")]
        public IActionResult AddToCart(int ItemId,decimal UnitPrice,int Quantity)
        {
            try
            {
                int userId = CurrentUser == null ? 0 : CurrentUser.Id;
                if(ItemId > 0)
                {
                    Cart cart = _cartServices.AddItem(userId,ItemId,CartId,UnitPrice,Quantity);
                    JsonSerializerOptions jsonOptions = new JsonSerializerOptions()
                    {
                        ReferenceHandler = ReferenceHandler.IgnoreCycles
                    };
                    var data = JsonSerializer.Serialize(cart,jsonOptions);
                    return Json(data);
                }
                return Json("");
            }
            catch (Exception ex)
            {
                return Json("");
            }
        }
    }
}
