// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Acme.OnlineShopping.Stock.Dependencies
{
    /// <summary>
    /// Used to query for Products
    /// </summary>
    public class ProductQuerySpecification : IQuerySpecification<Product>
    {
        private readonly IRepository<Product> _ProductRepo;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="productRepo"></param>
        public ProductQuerySpecification(IRepository<Product> productRepo)
        {
            _ProductRepo = productRepo;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetResultsAsync()
        {
            await Task.CompletedTask;
            return _ProductRepo.GetQuery().AsEnumerable();
        }
    }
}
