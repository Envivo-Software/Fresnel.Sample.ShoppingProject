// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.Contacts;
using Acme.OnlineShopping.Shopping;
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes;
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
        /// The reference number for this Account
        /// </summary>
        [JsonInclude]
        public int AccountNo { get; internal set; }

        /// <summary>
        /// The date this Account was opened
        /// </summary>
        public DateTime OpenedOn { get; set; }

        /// <summary>
        /// Any Orders associated with this Account. Orders are placed via the Shopping Cart associated with the Customer.
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        [Collection(addMethodName: nameof(AddToOrders))]
        [AllowedOperations(canAdd: false, canCreate: false, canRemove: false)]
        [JsonInclude]
        public ICollection<Order> Orders { get; internal set; }

        /// <summary>
        /// Adds the given Order to this Account
        /// </summary>
        /// <param name="newOrder"></param>
        [Visible(false)]
        public void AddToOrders(Order newOrder)
        {
            newOrder.Account = AggregateReference<Account>.From(this);
            Orders.Add(newOrder);
        }

        /// <summary>
        /// The Payments associated with this Account
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [Collection(canExpandRows: true)]
        public ICollection<Payment> Payments { get; set; }

        /// <summary>
        /// The Customer's billing address (if different from their address)
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        public AddressInfo BillingAddress { get; set; }

        /// <summary>
        /// The customer this account belongs to
        /// </summary>
        [Relationship(RelationshipType.OwnedBy)]
        [UI(renderOption: UiRenderOption.InlineSimple)]
        [JsonInclude]
        public Customer Customer { get; internal set; }

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
            return $"No:{AccountNo} ({Customer})";
        }
    }
}
