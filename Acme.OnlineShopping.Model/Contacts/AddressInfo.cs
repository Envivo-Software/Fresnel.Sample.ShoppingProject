using Envivo.Fresnel.ModelAttributes;
using System.ComponentModel.DataAnnotations;

namespace Acme.OnlineShopping.Contacts
{
    public class AddressInfo
    {
        [Key]
        public Guid Id { get; set; }

        public string HouseName { get; set; }

        public string HouseNumber { get; set; }

        public string Street { get; set; }

        public string Town { get; set; }

        public string County { get; set; }

        public string Country { get; set; }

        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var line1Parts =
                new string[] { HouseName, HouseNumber, Street }
                .Where(p => !string.IsNullOrEmpty(p))
                .ToArray();
            var line1 = string.Join(" ", line1Parts);

            var line2Parts =
                new string[] { Town, County, Country, PostalCode }
                .Where(p => !string.IsNullOrEmpty(p))
                .ToArray();
            var line2 = string.Join(",", line2Parts);

            return $"{line1}, {line2}";
        }
    }
}
