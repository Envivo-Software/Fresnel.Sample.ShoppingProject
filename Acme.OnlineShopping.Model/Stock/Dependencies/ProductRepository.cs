// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Acme.OnlineShopping.Stock.Dependencies
{
    /// <summary>
    /// Repository for managing Products in a data store
    /// </summary>
    public class ProductRepository : IRepository<Product>
    {
        private static InMemoryRepository<Product> _InMemoryRepository = new();

        public ProductRepository(DemoProductsBuilder demoProductsBuilder)
        {
            if (!_InMemoryRepository.GetAll().Any())
            {
                _InMemoryRepository = new(demoProductsBuilder.Build());
            }
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
