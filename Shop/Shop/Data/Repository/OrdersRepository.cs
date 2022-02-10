using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent; 
            this.shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            appDBContent.SaveChanges();

            var items = shopCart.ListShopItems;

            foreach (var element in items)
            {
                var OrderDetail = new OrderDetail()
                {
                    CarId = element.Car.id,
                    OrderId = order.id,
                    Price = element.Price
                };

                appDBContent.OrderDetail.Add(OrderDetail);
            }
            appDBContent.SaveChanges();
        }
    }
}