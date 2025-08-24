// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Acme.OnlineShopping.CustomerAccounts;
using Acme.OnlineShopping.Stock;
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Acme.OnlineShopping.Shopping
{
    /// <summary>
    /// An entry within an Order
    /// </summary>
    public class OrderItem : IEntity
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The Order this item belongs to
        /// </summary>
        [Relationship(RelationshipType.OwnedBy)]
        [UI(renderOption: UiRenderOption.InlineSimple)]
        public EntityReference<Order> Order { get; internal set; }

        /// <summary>
        /// The product being ordered
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [UI(renderOption: UiRenderOption.InlineSimple)]
        public AggregateReference<Product> Product { get; internal set; }

        /// <summary>
        /// The number of items ordered
        /// </summary>
        public int Quantity { get; internal set; }

        /// <summary>
        /// The price at the time the order was placed
        /// </summary>
        [DataType(DataType.Currency)]
        public double Price { get; internal set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Product?.ToString() ?? string.Empty;
        }
    }
}
