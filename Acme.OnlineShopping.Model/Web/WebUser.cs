﻿// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.CustomerAccounts;
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Acme.OnlineShopping.Web
{
    /// <summary>
    /// Provides a Customer access to the online Shopping Cart
    /// </summary>
    public class WebUser : IAggregateRoot
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The Customer that this web user belongs to
        /// </summary>
        [Relationship(RelationshipType.OwnedBy)]
        [UI(renderOption: UiRenderOption.SeparateTabExpanded)]
        [JsonInclude]
        public Customer? Customer { get; internal set; }

        /// <summary>
        /// The user's login ID
        /// </summary>
        public string? Login_ID { get; set; }

        /// <summary>
        /// The user's password
        /// </summary>
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        /// <summary>
        /// The current state for this user
        /// </summary>
        public UserState State { get; set; }

        /// <summary>
        /// The user's shopping cart
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        [UI(renderOption: UiRenderOption.InlineSimple)]
        public ShoppingCart? ShoppingCart { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"LoginID: {Login_ID}";
        }
    }
}
