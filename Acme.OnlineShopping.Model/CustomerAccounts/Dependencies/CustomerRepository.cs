﻿// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.Stock;
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Acme.OnlineShopping.CustomerAccounts.Dependencies
{
    /// <summary>
    /// Repository for managing Customers in a data store
    /// </summary>
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly InMemoryRepository<Customer> _InMemoryRepository = new();


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="aggregateRoot"></param>
        /// <returns></returns>
        public Task DeleteAsync(Customer aggregateRoot)
        {
            return _InMemoryRepository.DeleteAsync(aggregateRoot);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public IQueryable<Customer> GetQuery()
        {
            return _InMemoryRepository.GetQuery();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Customer> LoadAsync(Guid id)
        {
            return _InMemoryRepository.LoadAsync(id);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="aggregateRoot"></param>
        /// <returns></returns>
        public Task<IAggregateLock> LockAsync(Customer aggregateRoot)
        {
            return _InMemoryRepository.LockAsync(aggregateRoot);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="aggregateRoot"></param>
        /// <param name="newObjects"></param>
        /// <param name="modifiedObjects"></param>
        /// <param name="deletedObjects"></param>
        /// <returns></returns>
        public Task<int> SaveAsync(Customer aggregateRoot, IEnumerable<object> newObjects, IEnumerable<object> modifiedObjects, IEnumerable<object> deletedObjects)
        {
            return _InMemoryRepository.SaveAsync(aggregateRoot, newObjects, modifiedObjects, deletedObjects);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="aggregateRoot"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task UnlockAsync(Customer aggregateRoot)
        {
            return Task.CompletedTask;
        }
    }
}
