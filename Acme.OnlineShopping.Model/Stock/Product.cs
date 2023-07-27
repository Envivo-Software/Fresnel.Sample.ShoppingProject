// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.Stock.Dependencies;
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Acme.OnlineShopping.Stock
{
    /// <summary>
    /// A Product that is sold on the web site
    /// </summary>
    public class Product : IAggregateRoot
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Product()
        {
            this.Stock = new List<StockDetail>();
            this.Categories = new List<AggregateReference<Category>>();
        }

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
        /// The short name for this product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Detailed description for this product
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// The price per unit
        /// </summary>
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        /// <summary>
        /// The product's Supplier
        /// </summary>
        [Relationship(RelationshipType.Has)]
        public Supplier Supplier { get; set; }

        /// <summary>
        /// The categories that this product is assigned to
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [FilterQuerySpecification(typeof(CategoryQuerySpecification))]
        public ICollection<AggregateReference<Category>> Categories { get; set; }

        /// <summary>
        /// Stock information for this product
        /// </summary>
        [Relationship(RelationshipType.Has)]
        public ICollection<StockDetail> Stock { get; set; }

        /// <summary>
        /// Assigns the selected Categories to this Product
        /// </summary>
        /// <param name="categories"></param>
        public void AssignCategories(
            [FilterQuerySpecification(typeof(CategoryQuerySpecification))]
            IEnumerable<Category> categories)
        {
            foreach (var category in categories)
            {
                var aggregateRef = AggregateReference<Category>.From(category);
                this.Categories.Add(aggregateRef);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}