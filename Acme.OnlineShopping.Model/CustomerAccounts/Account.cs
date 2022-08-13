using Acme.OnlineShopping.Contacts;
using Acme.OnlineShopping.Shopping;
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Acme.OnlineShopping.CustomerAccounts
{
    public class Account: IAggregateRoot
    {
        public Account()
        {
            this.Payments = new List<Payment>();
            this.Orders = new List<Order>();
        }

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The customer this account belongs to
        /// </summary>
        [Relationship(RelationshipType.OwnedBy)]
        public Customer Customer { get; internal set; }

        public AddressInfo BillingAddress { get; set; }

        public DateTime OpenedOn { get; set; }


        [Relationship(RelationshipType.Owns)]
        public ICollection<Order> Orders { get; set; }

        [Visible(false)]
        public void AddToOrders(Order order)
        {
            order.Account = this;
        }

        [Relationship(RelationshipType.Has)]
        public ICollection<Payment> Payments { get; set; }

        public DateTime? ClosedOn { get; set; }

        public bool IsClosed => ClosedOn != null;
    }
}
