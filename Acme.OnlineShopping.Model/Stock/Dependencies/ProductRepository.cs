using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Acme.OnlineShopping.Stock.Dependencies
{
    public class ProductRepository : IRepository<Product>
    {
        private static readonly List<Product> _Products = BuildProductsForDemo();

        private static List<Product> BuildProductsForDemo()
        {
            var results = new List<Product> {
                new Product{
                    Name = "Arturia Microfreak Synthesizer",
                    Description = "Micro wavetable synth",
                    Price= 299
                },
                new Product{
                    Name = "Korg Monologue Synthesizer",
                    Description = "Analog mono synth",
                    Price= 149
                 },
                new Product{
                    Name = "Korg R3 Synthesizer",
                    Description = "Digital virtual analog synth",
                    Price= 249
                 },
                new Product{
                    Name = "Akai MPK-25 Midi Controller",
                    Description = "25 key controller with CC and NRPN support",
                    Price= 49
                 },
                new Product{
                    Name = "Alesis Micron Synthesizer",
                    Description = "Digital virtual analog synth",
                    Price= 239
                 },
                new Product{
                    Name = "Modal SKULPT Synth",
                    Description = "Portable digital analog synth",
                    Price= 99
                 },
                new Product{
                    Name = "Zoom ARQ 48 Groove Box",
                    Description = "Portable sequencer + synth",
                    Price= 349
                 },
            };

            foreach (var product in results)
            {
                product.Id = Guid.NewGuid();
            }

            return results;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public IQueryable<Product> GetAll()
        {
            return _Products.AsQueryable();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public Product? Load(Guid id)
        {
            return _Products.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public int Save(Product product, IEnumerable<object> newObjects, IEnumerable<object> modifiedObjects, IEnumerable<object> deletedObjects)
        {
            var newProducts = newObjects.OfType<Product>();
            foreach (var prod in newProducts)
            {
                Save(prod);
            }

            var modifiedProducts = modifiedObjects.OfType<Product>();
            foreach (var prod in modifiedProducts)
            {
                Save(prod);
            }

            return newProducts.Count() + modifiedProducts.Count();
        }

        private void Save(Product product)
        {
            Delete(product);

            var copy = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Categories = product.Categories.ToList(),
                Stock = product.Stock.ToList(),
                Supplier = product.Supplier,
            };
            _Products.Add(copy);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public void Delete(Product product)
        {
            var match = _Products.FirstOrDefault(p => p.Id == product.Id);
            if (match != null)
            {
                _Products.Remove(match);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public IAggregateLock? Lock(Product product)
        {
            // Not applicable
            return null;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public void Unlock(Product product)
        {
            // Not applicable
        }
    }
}
