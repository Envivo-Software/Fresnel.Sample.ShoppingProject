using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Acme.OnlineShopping.Stock.Dependencies
{
    public class CategoryRepository : IRepository<Category>
    {
        private static readonly List<Category> _Categories = BuildCategorysForDemo();

        private static List<Category> BuildCategorysForDemo()
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
            return _Categories.AsQueryable();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public Category? Load(Guid id)
        {
            return _Categories.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public int Save(Category category, IEnumerable<object> newObjects, IEnumerable<object> modifiedObjects, IEnumerable<object> deletedObjects)
        {
            var newCategories = newObjects.OfType<Category>();
            foreach (var cat in newCategories)
            {
                Save(cat);
            }

            var modifiedCategories = modifiedObjects.OfType<Category>();
            foreach (var cat in modifiedCategories)
            {
                Save(cat);
            }

            return newCategories.Count() + modifiedCategories.Count();
        }

        private void Save(Category category)
        {
            Delete(category);

            var copy = new Category
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };
            _Categories.Add(copy);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public void Delete(Category category)
        {
            var match = _Categories.FirstOrDefault(p => p.Id == category.Id);
            if (match != null)
            {
                _Categories.Remove(match);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public IAggregateLock? Lock(Category category)
        {
            // Not applicable
            return null;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public void Unlock(Category category)
        {
            // Not applicable
        }
    }
}
