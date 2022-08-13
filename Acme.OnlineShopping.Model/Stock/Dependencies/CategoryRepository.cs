using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Acme.OnlineShopping.Stock.Dependencies
{
    public class CategoryRepository : IRepository<Category>
    {
        private static readonly InMemoryRepository<Category> _InMemoryRepository = new InMemoryRepository<Category>(BuildCategoriesForDemo());

        private static List<Category> BuildCategoriesForDemo()
        {
            var results = new List<Category> {
                new Category{ Name = "Synthesizer" },
                new Category{ Name = "Midi Controller" },
                new Category{ Name = "Audio Interface" },
                new Category{ Name = "Speaker" },
                new Category{ Name = "Headphones" },
                new Category{ Name = "Mixer" },
            };

            foreach (var category in results)
            {
                category.Id = Guid.NewGuid();
            }

            return results;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public IQueryable<Category> GetAll()
        {
            return _InMemoryRepository.GetAll();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public Category? Load(Guid id)
        {
            return _InMemoryRepository.Load(id);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public int Save(Category category, IEnumerable<object> newObjects, IEnumerable<object> modifiedObjects, IEnumerable<object> deletedObjects)
        {
            return _InMemoryRepository.Save(category, newObjects, modifiedObjects, deletedObjects);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public void Delete(Category category)
        {
            _InMemoryRepository.Delete(category);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public IAggregateLock? Lock(Category category)
        {
            return _InMemoryRepository.Lock(category);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public void Unlock(Category category)
        {
            _InMemoryRepository.Unlock(category);
        }
    }
}
