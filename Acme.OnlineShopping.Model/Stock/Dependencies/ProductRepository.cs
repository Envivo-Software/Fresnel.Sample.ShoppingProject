using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Acme.OnlineShopping.Stock.Dependencies
{
    public class ProductRepository : IRepository<Product>
    {
        private static readonly InMemoryRepository<Product> _InMemoryRepository = new InMemoryRepository<Product>(BuildProductsForDemo());

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
            return _InMemoryRepository.GetAll();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public Product? Load(Guid id)
        {
            return _InMemoryRepository.Load(id);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public int Save(Product product, IEnumerable<object> newObjects, IEnumerable<object> modifiedObjects, IEnumerable<object> deletedObjects)
        {
            return _InMemoryRepository.Save(product, newObjects, modifiedObjects, deletedObjects);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public void Delete(Product product)
        {
            _InMemoryRepository.Delete(product);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public IAggregateLock? Lock(Product product)
        {
            return _InMemoryRepository.Lock(product);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public void Unlock(Product product)
        {
            _InMemoryRepository.Unlock(product);
        }
    }
}
