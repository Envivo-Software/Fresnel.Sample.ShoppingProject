// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Acme.OnlineShopping.Stock
{
    /// <summary>
    /// The Stock details for a Product
    /// </summary>
    public class StockDetail : IAggregateRoot
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [ConcurrencyCheck]
        public long Version { get; set; }

        /// <summary>
        /// The Product these details are for
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [UI(renderOption: UiRenderOption.InlineSimple)]
        public Product? Product { get; set; }

        /// <summary>
        /// The Unit Price for this product
        /// </summary>
        public double UnitPrice { get; set; }

        /// <summary>
        /// The number of items within a single Unit
        /// </summary>
        public int QuantityPerUnit { get; set; }

        /// <summary>
        /// The number of Units currently held in stock
        /// </summary>
        public int UnitsInStock { get; set; }

        /// <summary>
        /// The number of units needed to trigger a Re-order request
        /// </summary>
        public int ReorderLevel { get; set; }

        /// <summary>
        /// Determines if this Product is not longer supplied
        /// </summary>
        public bool IsDiscontinued { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.Product} ({this.UnitsInStock} remaining)";
        }
    }
}