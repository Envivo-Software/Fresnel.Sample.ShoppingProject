// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.Contacts;
using Envivo.Fresnel.ModelAttributes;
using System.ComponentModel.DataAnnotations;

namespace Acme.OnlineShopping.Stock
{
    public class Supplier
    {
        [Key]
        public Guid Id { get; set; }

        public AddressInfo Address { get; set; }

        public PhoneInfo Phone { get; set; }

        public string Email { get; set; }

        [Relationship(RelationshipType.Has)]
        public ICollection<Product> Products { get; set; }
    }
}
