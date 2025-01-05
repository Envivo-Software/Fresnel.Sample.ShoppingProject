// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0

using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Acme.OnlineShopping.Stock.Dependencies
{
    /// <summary>
    /// Builds demo Category data
    /// </summary>
    public class DemoCategoriesBuilder : IDomainDependency
    {
        /// <summary>
        /// Returns a set of Categories for demo use
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Category> Build()
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
    }
}
