using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;
        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }
        public static ShopCart GetCart(IServiceProvider Services)
        {
            ISession Session = Services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var Context = Services.GetService<AppDBContent>();
            string shopCartId = Session.GetString("CartId") ?? Guid.NewGuid().ToString();

            Session.SetString("CartId", shopCartId);

            return new ShopCart (Context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Car car)
        {
            appDBContent.ShopCartItems.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                Car = car,
                Price = car.Price
            });

            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> getShopItems()
        {
            return appDBContent.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Car).ToList();
        }
    }
}
