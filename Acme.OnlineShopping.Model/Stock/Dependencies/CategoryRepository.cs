// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Acme.OnlineShopping.Stock.Dependencies
{
    /// <summary>
    /// Repository for managing Categories in a data store
    /// </summary>
    public class CategoryRepository : IRepository<Category>
    {
        private static InMemoryRepository<Category> _InMemoryRepository = new();

        public CategoryRepository(DemoCategoriesBuilder demoCategoriesBuilder)
        {
            if (!_InMemoryRepository.GetAll().Any())
            {
                _InMemoryRepository = new(demoCategoriesBuilder.Build());
            }
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
