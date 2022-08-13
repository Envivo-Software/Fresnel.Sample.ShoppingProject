using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Acme.OnlineShopping.Stock
{
    /// <summary>
    /// A Category that Products are assigned to
    /// </summary>
    public class Category : IAggregateRoot
    {
        public Category()
        {
            this.Products = new List<Product>();
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
        /// The short name of this category
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The long description for this category
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// The products assigned to this category
        /// </summary>
        [Relationship(RelationshipType.Has)]
        public ICollection<Product> Products { get; set; }

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