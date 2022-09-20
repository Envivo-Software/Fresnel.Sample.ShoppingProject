// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using System.ComponentModel.DataAnnotations;

namespace Acme.OnlineShopping.Contacts
{
    /// <summary>
    /// The details of an address
    /// </summary>
    public class AddressInfo
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HouseName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Town { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 
        /// </summary>
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
                .ToList();
            var line1 = string.Join(" ", line1Parts);

            var line2Parts =
                new string[] { Town, County, Country, PostalCode }
                .Where(p => !string.IsNullOrEmpty(p))
                .ToList();
            var line2 = string.Join(",", line2Parts);

            return $"{line1}, {line2}";
        }
    }
}
