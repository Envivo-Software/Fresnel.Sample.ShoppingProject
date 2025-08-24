// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
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
    /// An entry within an Order
    /// </summary>
    public class ShoppingCartItem : IEntity
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The Shopping Cart this item belongs to
        /// </summary>
        [Relationship(RelationshipType.OwnedBy)]
        [UI(renderOption: UiRenderOption.InlineSimple)]
        public AggregateReference<ShoppingCart>? ShoppingCart { get; internal set; }

        /// <summary>
        /// The Product added to the cart
        /// </summary>
        [Relationship(type: RelationshipType.Has)]
        [UI(renderOption: UiRenderOption.InlineSimple)]
        [FilterQuerySpecification(typeof(ProductQuerySpecification))]
        public Product? Product { get; internal set; }

        /// <summary>
        /// The number of items requested
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The price at the time the order was added to the cart
        /// </summary>
        [DataType(DataType.Currency)]
        public double Price { get; set; }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Product}, {Quantity} @ {Price:C}";
        }
    }
}
