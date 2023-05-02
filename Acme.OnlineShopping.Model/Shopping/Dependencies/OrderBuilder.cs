// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.Web;
using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Acme.OnlineShopping.Shopping.Dependencies
{
    /// <summary>
    /// Converts shopping carts into Orders
    /// </summary>
    public class OrderBuilder : IDomainDependency
    {
        /// <summary>
        /// Creates a new Order from the contents of the given Shopping Cart
        /// </summary>
        /// <param name="shoppingCart"></param>
        /// <param name="customer"></param>
        /// <param name="placementDate"></param>
        /// <returns></returns>
        public Order CreateOrder(ShoppingCart shoppingCart, DateTime? placementDate)
        {
            if (shoppingCart.WebUser?.Customer == null)
                return null;

            // You could run Some domain rules/checks here,
            // before creating an Order.

            var newOrder = new Order()
            {
                Id = Guid.NewGuid(),
                OrderNo = Environment.TickCount,
                PlacementDate = DateTime.Now,
                OrderItems =
                    shoppingCart.Items
                    .Select(li => new OrderItem
                    {
                        Product = li.Product,
                        Price = li.Price,
                        Quantity = li.Quantity,
                    })
                    .ToList()
            };

            foreach (var orderItem in newOrder.OrderItems)
            {
                orderItem.Order = newOrder;
            }

            if (placementDate != null)
            {
                newOrder.PlacementDate = placementDate.Value;
            }

            shoppingCart.WebUser?.Customer.Account.AddToOrders(newOrder);

            return newOrder;
        }
    }
}