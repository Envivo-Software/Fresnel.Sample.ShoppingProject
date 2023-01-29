// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Acme.OnlineShopping.Stock.Dependencies
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class CategoryQuerySpecification : IQuerySpecification<Category>
    {
        private readonly IRepository<Category> _CategoryRepository;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="categoryRepository"></param>
        public CategoryQuerySpecification(IRepository<Category> categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Category> GetResults()
        {
            return _CategoryRepository.GetAll();
        }
    }
}
