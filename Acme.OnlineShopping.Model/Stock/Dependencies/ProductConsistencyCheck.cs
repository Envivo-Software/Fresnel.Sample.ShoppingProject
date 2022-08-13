using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Acme.OnlineShopping.Stock.Dependencies
{
    /// <summary>
    /// Checks that Products are consistent, before being saved
    /// </summary>
    public class ProductConsistencyCheck : IConsistencyCheck<Product>
    {
        public Assertion Check(Product product)
        {
            var allExceptions = new List<Exception>();

            if (string.IsNullOrEmpty(product.Name))
            {
                var error = new ValidationException("Name must be provided");
                allExceptions.Add(error);
            }

            if (!product.Categories.Any())
            {
                var error = new ValidationException("At least 1 Category must be assigned");
                allExceptions.Add(error);
            }

            return allExceptions.Any() ?
                    Assertion.Fail(allExceptions) :
                    Assertion.Pass;
        }
    }
}