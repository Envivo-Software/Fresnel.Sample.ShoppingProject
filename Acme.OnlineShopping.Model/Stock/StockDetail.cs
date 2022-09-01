// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Acme.OnlineShopping.Stock
{
    public class StockDetail : IAggregateRoot
    {
        [Key]
        public Guid Id { get; set; }

        [ConcurrencyCheck]
        public long Version { get; set; }

        [Relationship(RelationshipType.Has)]
        [UI(renderOption: UiRenderOption.InlineSimple)]
        public Product? Product { get; set; }

        public double UnitPrice { get; set; }

        public int QuantityPerUnit { get; set; }

        public int UnitsInStock { get; set; }

        public int ReorderLevel { get; set; }

        public bool IsDiscontinued { get; set; }

        public override string ToString()
        {
            return string.Concat(this.Product, " (", this.UnitsInStock, " remaining");
        }
    }
}