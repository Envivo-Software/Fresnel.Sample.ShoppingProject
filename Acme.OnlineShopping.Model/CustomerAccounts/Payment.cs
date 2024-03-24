// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.Shopping;
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Acme.OnlineShopping.CustomerAccounts
{
    /// <summary>
    /// A record of a payment for an Order
    /// </summary>
    public class Payment : IEntity
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The time the payment was made
        /// </summary>
        public DateTime PaidAt { get; set; }

        /// <summary>
        /// The amount paid
        /// </summary>
        [DataType(DataType.Currency)]
        public double TotalAmount { get; set; }

        /// <summary>
        /// Any special notes about this payment
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// The Order that this payment is for
        /// </summary>
        [Relationship(RelationshipType.OwnedBy)]
        [UI(renderOption: UiRenderOption.InlineSimple)]
        [JsonInclude]
        public Order Order { get; internal set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{TotalAmount:C}, paid on {PaidAt:dd/MM/yyyy}";
        }
    }
}
