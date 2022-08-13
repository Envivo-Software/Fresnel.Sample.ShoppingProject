using Envivo.Fresnel.ModelAttributes;
using System.ComponentModel.DataAnnotations;

namespace Acme.OnlineShopping.Contacts
{
    public class PhoneInfo
    {
        [Key]
        public Guid Id { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string AreaCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Number { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Extension { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{AreaCode} {Number} {Extension}";
        }
    }
}
