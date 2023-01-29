// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.Stock;
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System.ComponentModel.DataAnnotations;

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
        public Order Order { get; internal set; }

        /// <summary>
        /// The product being ordered
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [UI(renderOption: UiRenderOption.InlineSimple)]
        public Product Product { get; internal set; }

        /// <summary>
        /// The number of items ordered
        /// </summary>
        public int Quantity { get; internal set; }

        /// <summary>
        /// The price at the time the order was placed
        /// </summary>
        [DataType(DataType.Currency)]
        public double Price { get; internal set; }
    }
}