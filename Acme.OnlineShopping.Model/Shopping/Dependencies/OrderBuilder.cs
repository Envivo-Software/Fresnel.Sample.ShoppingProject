// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.Stock;
using Acme.OnlineShopping.Web;
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Acme.OnlineShopping.Shopping.Dependencies
{
    /// <summary>
    /// Converts shopping carts into Orders
    /// </summary>
    public class OrderBuilder : IDomainDependency
    {
        private readonly IModelSpace _ModelSpace;

        public OrderBuilder(IModelSpace modelSpace)
        {
            _ModelSpace = modelSpace;
        }

        /// <summary>
        /// Creates a new Order from the contents of the given Shopping Cart
        /// </summary>
        /// <param name="shoppingCart"></param>
        /// <param name="placementDate"></param>
        /// <returns></returns>
        public async Task<Order> CreateOrderAsync(ShoppingCart shoppingCart, DateTime? placementDate)
        {
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
                        Product = AggregateReference<Product>.From(li.Product),
                        Price = li.Price,
                        Quantity = li.Quantity,
                    })
                    .ToList()
            };

            foreach (var orderItem in newOrder.OrderItems)
            {
                orderItem.Order = EntityReference<Order>.From(newOrder);
            }

            if (placementDate != null)
            {
                newOrder.PlacementDate = placementDate.Value;
            }

            // Now we can add the Order to the Customer's account:
            var customer = await shoppingCart.Customer?.ResolveAsync(_ModelSpace);
            if (customer != null)
            {
                customer.Account.AddToOrders(newOrder);
            }

            return newOrder;
        }
    }
}
