// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0

using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Acme.OnlineShopping.Stock.Dependencies
{
    /// <summary>
    /// Builds demo Product data
    /// </summary>
    public class DemoProductsBuilder : IDomainDependency
    {
        private readonly CategoryRepository _CategoryRepository;

        public DemoProductsBuilder(CategoryRepository categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }

        /// <summary>
        /// Returns a set of Products for demo use
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> Build()
        {
            var results = new List<Product> {
                new Product{
                    Name = "Arturia Microfreak Synthesizer",
                    Description = "Micro wavetable synth",
                    Price = 299,
                },
                new Product{
                    Name = "Korg Monologue Synthesizer",
                    Description = "Analog mono synth",
                    Price = 149
                 },
                new Product{
                    Name = "Korg R3 Synthesizer",
                    Description = "Digital virtual analog synth",
                    Price = 249
                 },
                new Product{
                    Name = "Akai MPK-25 Midi Controller",
                    Description = "25 key controller with CC and NRPN support",
                    Price = 49
                 },
                new Product{
                    Name = "Alesis Micron Synthesizer",
                    Description = "Digital virtual analog synth",
                    Price = 239
                 },
                new Product{
                    Name = "Modal SKULPT Synth",
                    Description = "Portable digital analog synth",
                    Price = 99
                 },
                new Product{
                    Name = "Zoom ARQ 48 Groove Box",
                    Description = "Portable sequencer + synth",
                    Price = 349
                 },
            };

            AssignSynthCategories(results);
            AssignMidiCategories(results);

            foreach (var product in results)
            {
                product.Id = Guid.NewGuid();
            }

            return results;
        }

        private void AssignSynthCategories(List<Product> results)
        {
            var synthCategories =
                _CategoryRepository.GetAll()
                .Where(c => c.Name == "Synthesizer")
                .ToList();

            var synths =
                results.Where(p => p.Description.Contains("synth"))
                .ToList();

            foreach (var prod in synths)
            {
                prod.AssignCategories(synthCategories);
            }
        }

        private void AssignMidiCategories(List<Product> results)
        {
            var midiCategories =
                _CategoryRepository.GetAll()
                .Where(c => c.Name == "Midi Controller")
                .ToList();

            foreach (var prod in results)
            {
                prod.AssignCategories(midiCategories);
            }
        }
    }
}
