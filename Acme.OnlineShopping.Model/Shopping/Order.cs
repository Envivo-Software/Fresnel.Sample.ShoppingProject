// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.Contacts;
using Acme.OnlineShopping.CustomerAccounts;
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Acme.OnlineShopping.Shopping
{
    /// <summary>
    /// An Order placed by a customer
    /// </summary>
    public class Order : IAggregateRoot
    {
        private Payment? _Payment;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <remarks>Allow the JSON serialiser to create this object, but prevent the UI from allowing manually created instances</remarks>
        [Visible(isVisible: false)]
        public Order()
        {
            this.Account = null;
            this.OrderItems = new List<OrderItem>();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Order(AggregateReference<Account> account)
            : this()
        {
            this.Account = account;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The Account this order belongs to
        /// </summary>
        [Relationship(RelationshipType.OwnedBy)]
        [UI(renderOption: UiRenderOption.InlineSimple)]
        [JsonInclude]
        public AggregateReference<Account> Account { get; internal set; }

        /// <summary>
        /// The reference number for this order
        /// </summary>
        [JsonInclude]
        public int OrderNo { get; internal set; }

        /// <summary>
        /// The current state of this Order
        /// </summary>
        public OrderState OrderState { get; set; }

        /// <summary>
        /// The date the order was placed
        /// </summary>
        [JsonInclude]
        public DateTime PlacementDate { get; internal set; }

        /// <summary>
        /// The data the order was shipped
        /// </summary>
        [JsonInclude]
        public DateTime? ShippedDate { get; internal set; }

        /// <summary>
        /// Optional: the address to ship to (if different to billing address)
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        public AddressInfo? ShipTo { get; set; }

        /// <summary>
        /// The payment for this order
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        public Payment? Payment
        {
            get => _Payment; set
            {
                _Payment = value;
                if (_Payment != null)
                {
                    _Payment.Order = this;
                }
            }
        }

        /// <summary>
        /// The items contained within this order
        /// </summary>
        /// <remarks>These items are automatically created from the Shopping Cart, and cannot be updated manually</remarks>
        [Relationship(RelationshipType.Owns)]
        [UI(renderOption: UiRenderOption.InlineExpanded)]
        [Collection(canExpandRows: true)]
        [JsonInclude]
        public ICollection<OrderItem> OrderItems { get; internal set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{OrderNo}, placed {PlacementDate:d}, {Payment}";
        }
    }
}