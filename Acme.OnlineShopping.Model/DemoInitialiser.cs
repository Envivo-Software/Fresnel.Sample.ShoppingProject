using Acme.OnlineShopping.Stock.Dependencies;
using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Acme.OnlineShopping.Model
{
    public class DemoInitialiser : IDomainDependency
    {
        private readonly CategoryRepository _CategoryRepository;
        private readonly DemoCategoriesBuilder _DemoCategoriesBuilder;

        private readonly ProductRepository _ProductRepository;
        private readonly DemoProductsBuilder _DemoProductsBuilder;

        public DemoInitialiser
        (
            CategoryRepository categoryRepository,
            DemoCategoriesBuilder demoCategoriesBuilder,
                
            ProductRepository productRepository,
            DemoProductsBuilder demoProductsBuilder
        )
        {
            _CategoryRepository = categoryRepository;
            _DemoCategoriesBuilder = demoCategoriesBuilder;
            _ProductRepository = productRepository;
            _DemoProductsBuilder = demoProductsBuilder;
        }

        public async Task SetupDemoDataAsync()
        {
            if (!_CategoryRepository.GetQuery().Any())
                await SaveToRepo(_CategoryRepository, _DemoCategoriesBuilder.Build());

            if (!_ProductRepository.GetQuery().Any())
                await SaveToRepo(_ProductRepository, _DemoProductsBuilder.Build());
        }

        private async Task SaveToRepo<T>(IRepository<T> repo, IEnumerable<T> items)
            where T : class
        {
            foreach (var singleItem in items)
            {
                await repo.SaveAsync(singleItem, [singleItem], [], []);
            }
        }
    }
}