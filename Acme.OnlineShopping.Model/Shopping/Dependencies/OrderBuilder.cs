// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.CustomerAccounts;
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
        /// <param name="account"></param>
        /// <param name="shoppingCart"></param>
        /// <returns></returns>
        public Order CreateOrder(Account account, ShoppingCart shoppingCart)
        {
            // You could run Some domain rules/checks here,
            // before creating an Order.

            var result = new Order(account)
            {
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

            return result;
        }
    }
}