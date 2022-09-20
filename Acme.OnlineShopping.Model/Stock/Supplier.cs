// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.Contacts;
using Envivo.Fresnel.ModelAttributes;
using System.ComponentModel.DataAnnotations;

namespace Acme.OnlineShopping.Stock
{
    /// <summary>
    /// Details for a registered Supplier
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The Supplier's address
        /// </summary>
        public AddressInfo Address { get; set; }

        /// <summary>
        /// The Supplier's Phone contact info
        /// </summary>
        public PhoneInfo Phone { get; set; }

        /// <summary>
        /// The Supplier's email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The Products this Supplier provides
        /// </summary>
        [Relationship(RelationshipType.Has)]
        public ICollection<Product> Products { get; set; }
    }
}
