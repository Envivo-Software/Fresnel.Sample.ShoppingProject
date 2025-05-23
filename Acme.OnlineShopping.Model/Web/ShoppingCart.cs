// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.CustomerAccounts;
using Acme.OnlineShopping.Shopping;
using Acme.OnlineShopping.Shopping.Dependencies;
using Acme.OnlineShopping.Stock;
using Acme.OnlineShopping.Stock.Dependencies;
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Acme.OnlineShopping.Web
{
    /// <summary>
    /// An Order placed by a customer
    /// </summary>
    public class ShoppingCart : IAggregateRoot
    {
        private ICollection<ShoppingCartItem> _Items = new List<ShoppingCartItem>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ShoppingCart()
        {
            this.CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The Web User this cart belongs to
        /// </summary>
        [Relationship(RelationshipType.OwnedBy)]
        [UI(renderOption: UiRenderOption.InlineSimple)]
        [JsonInclude]
        public WebUser? WebUser { get; internal set; }

        /// <summary>
        /// The date/time when this cart was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The items contained within this cart
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        [Collection(addMethodName: nameof(AddToItems),
                    removeMethodName: nameof(RemoveFromItems),
                    visibleColumnNames: [nameof(ShoppingCartItem.Product),
                                         nameof(ShoppingCartItem.Quantity),
                                         nameof(ShoppingCartItem.Price)],
                    canExpandRows: true)]
        [AllowedOperations(canAdd: false, canCreate: false)]
        [UI(renderOption: UiRenderOption.InlineExpanded)]
        public ICollection<ShoppingCartItem> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

        /// <summary>
        /// Adds the given item to this cart
        /// </summary>
        /// <param name="item"></param>
        public void AddToItems(ShoppingCartItem item)
        {
            item.ShoppingCart = AggregateReference<ShoppingCart>.From(this);
            _Items.Add(item);
        }

        /// <summary>
        /// Removes the given item from this cart
        /// </summary>
        /// <param name="item"></param>
        public void RemoveFromItems(ShoppingCartItem item)
        {
            item.ShoppingCart = null;
            _Items.Remove(item);
        }

        /// <summary>
        /// Adds the given product to the user's shopping cart
        /// </summary>
        /// <param name="product">The product chosen by the web user</param>
        /// <param name="quantity">The quantity of this item</param>
        /// <returns></returns>
        public ShoppingCartItem AddItemToCart
        (
            [Required]
            [FilterQuerySpecification(typeof(ProductQuerySpecification))]
            Product product,

            [Required]
            [Range(0,99)]
            int quantity = 1
        )
        {
            var newItem = new ShoppingCartItem
            {
                Product = product,
                Quantity = quantity,
                Price = product.Price
            };
            AddToItems(newItem);
            return newItem;
        }

        /// <summary>
        /// Places this order
        /// </summary>
        /// <param name="orderBuilder"></param>
        /// <param name="placementDate">Used to override the date of the order</param>
        /// <returns></returns>
        public Order ConfirmAndPlaceOrder(OrderBuilder orderBuilder, DateTime? placementDate)
        {
            var newOrder = orderBuilder.CreateOrder(this, placementDate);

            ClearAllItems();

            return newOrder;
        }

        private void ClearAllItems()
        {
            // We can't just clear the Items - we need to unlink every Item in it:
            foreach (var item in this.Items.ToList())
            {
                RemoveFromItems(item);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return WebUser?.ToString() ?? string.Empty;
        }
    }
}