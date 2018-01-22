using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KurumsalProjem.Northwind.Entities.Concrete;
using KurumsalProjem.Northwind.MvcWebUI.ExtensionMethods;
using Microsoft.AspNetCore.Http;

namespace KurumsalProjem.Northwind.MvcWebUI.Services
{
    public class CartSessionService : ICartSessionService
    {
        private IHttpContextAccessor _httContextAccessor;

        public CartSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httContextAccessor = httpContextAccessor;
        }
        public Cart GetCart()
        {
            Cart cartToCheck =_httContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            if (cartToCheck==null)
            {
                _httContextAccessor.HttpContext.Session.SetObject("cart",new Cart());
                cartToCheck= _httContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            }
            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            _httContextAccessor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}
