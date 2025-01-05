// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.Contacts;
using Acme.OnlineShopping.Shopping;
using Acme.OnlineShopping.Web;
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Acme.OnlineShopping.CustomerAccounts
{
    /// <summary>
    /// A customer
    /// </summary>
    public class Customer : IAggregateRoot
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Customer()
        {
            this.Name = new NameInfo();
            this.Address = new AddressInfo();
            this.ContactInformation = new ContactInfo();
            this.Account = new Account();
            this.WebUser = new WebUser();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The customer's name information
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        public NameInfo Name { get; set; }

        /// <summary>
        /// The customer's default address
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        public AddressInfo Address { get; set; }

        /// <summary>
        /// The customer's contact phone number
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        public ContactInfo ContactInformation { get; set; }

        /// <summary>
        /// The customer's account, where billing and payment occurs
        /// </summary>
        [UI(renderOption: UiRenderOption.InlineSimple)]
        [Relationship(RelationshipType.Has)]
        [JsonInclude]
        public Account Account { get; internal set; }

        /// <summary>
        /// The user's entry into the online shopping site
        /// </summary>
        [UI(renderOption: UiRenderOption.InlineSimple)]
        [Relationship(RelationshipType.Owns)]
        [JsonInclude]
        public WebUser WebUser { get; internal set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name?.ToString() ?? string.Empty;
        }
    }
}
