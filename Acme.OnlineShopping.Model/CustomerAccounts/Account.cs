// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.Contacts;
using Acme.OnlineShopping.Shopping;
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Acme.OnlineShopping.CustomerAccounts
{
    /// <summary>
    /// An account associated with a Customer
    /// </summary>
    public class Account : IAggregateRoot
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Account()
        {
            this.Payments = new List<Payment>();
            this.Orders = new List<Order>();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The customer this account belongs to
        /// </summary>
        [Relationship(RelationshipType.OwnedBy)]
        [UI(renderOption: UiRenderOption.InlineSimple)]
        [JsonInclude]
        public Customer Customer { get; internal set; }

        /// <summary>
        /// The Customer's billing address (if different from their address)
        /// </summary>
        public AddressInfo BillingAddress { get; set; }

        /// <summary>
        /// The date this Account was opened
        /// </summary>
        public DateTime OpenedOn { get; set; }

        /// <summary>
        /// Any Orders associated with this Account
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        public ICollection<Order> Orders { get; set; }

        /// <summary>
        /// Adds the given Order to this Account
        /// </summary>
        /// <param name="order"></param>
        [Visible(false)]
        public void AddToOrders(Order order)
        {
            Orders.Add(order);
            order.Account = this;
        }

        /// <summary>
        /// The Payments associated with this Account
        /// </summary>
        [Relationship(RelationshipType.Has)]
        public ICollection<Payment> Payments { get; set; }

        /// <summary>
        /// Optional: The date when the Account was closed
        /// </summary>
        public DateTime? ClosedOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsClosed => ClosedOn != null;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Customer?.ToString() ?? string.Empty;
        }
    }
}
