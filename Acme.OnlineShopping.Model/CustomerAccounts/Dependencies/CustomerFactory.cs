// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.Contacts;
using Acme.OnlineShopping.Web;
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Acme.OnlineShopping.CustomerAccounts.Dependencies
{
    /// <summary>
    /// Used for creating new Customer instances
    /// </summary>
    public class CustomerFactory : IFactory<Customer>
    {
        /// <summary>
        /// Creates a Customer complete with it's necessary properties
        /// </summary>
        /// <returns></returns>
        public Customer Create()
        {
            return CreateWithName(null, null);
        }

        /// <summary>
        /// Creates a Customer with the given name
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public Customer CreateWithName(string firstName, string lastName)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = new NameInfo
                {
                    FirstName = firstName,
                    LastName = lastName
                },
                Address = new AddressInfo(),
                ContactInformation = new ContactInfo(),
                WebUser = new WebUser
                {
                    Id = Guid.NewGuid(),
                    Login_ID = $"{lastName?.ToLower()}{firstName?.ToLower()?.First()}{DateTime.Now.Second}",
                    Password = $"{Environment.TickCount}",
                    State = UserState.New,
                },
                Account = new Account
                {
                    Id = Guid.NewGuid(),
                    AccountNo = Environment.TickCount,
                    OpenedOn = DateTime.Now,
                    BillingAddress = new AddressInfo(),
                },
            };

            customer.WebUser.Customer = customer;

            var shoppingCart = new ShoppingCart
            {
                Id = Guid.NewGuid(),
                WebUser = customer.WebUser
            };
            customer.WebUser.ShoppingCart = shoppingCart;

            customer.Account.Customer = EntityReference<Customer>.From(customer);

            return customer;
        }
    }
}
