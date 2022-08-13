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
        public IEnumerable<Product> GetResults()
        {
            return _ProductRepo.GetAll();
        }
    }
}
