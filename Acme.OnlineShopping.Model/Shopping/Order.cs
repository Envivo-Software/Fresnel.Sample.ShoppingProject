// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.Contacts;
using Acme.OnlineShopping.CustomerAccounts;
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Acme.OnlineShopping.Shopping
{
    /// <summary>
    /// An Order placed by a customer
    /// </summary>
    public class Order : IAggregateRoot
    {
        private Payment _Payment;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The account this order belongs to
        /// </summary>
        [Relationship(RelationshipType.OwnedBy)]
        public Account Account { get; internal set; }

        /// <summary>
        /// The reference number for this order
        /// </summary>
        public int OrderNo { get; set; }

        /// <summary>
        /// The current state of this Order
        /// </summary>
        public OrderState OrderState { get; set; }

        /// <summary>
        /// The date the order was placed
        /// </summary>
        public DateTime PlacementDate { get; internal set; }

        /// <summary>
        /// The data the order was shipped
        /// </summary>
        public DateTime? ShippedDate { get; internal set; }

        /// <summary>
        /// Optional: the address to ship to (if different to billing address)
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        public AddressInfo ShipTo { get; set; }

        /// <summary>
        /// The payment for this order
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        public Payment Payment
        {
            get => _Payment; set
            {
                _Payment = value;
                _Payment.Order = this;
            }
        }

        /// <summary>
        /// The items contained within this order
        /// </summary>
        /// <remarks>These items are automatically created from the Shopping Cart, and cannot be updated manually</remarks>
        [Relationship(RelationshipType.Owns)]
        [UI(renderOption: UiRenderOption.InlineExpanded)]
        public ICollection<OrderItem> OrderItems { get; internal set; }
    }
}