// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.Contacts;
using Acme.OnlineShopping.Web;
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
            var customer = new Customer
            {
                Name = new NameInfo(),
                Address = new AddressInfo(),
                Phone = new PhoneInfo(),
                WebUser = new WebUser
                {
                    State = UserState.New,
                },
                Account = new Account
                {
                    OpenedOn = DateTime.Now,
                    BillingAddress = new AddressInfo(),
                },
            };

            customer.WebUser.Customer = customer;

            var shoppingCart = new ShoppingCart
            {
                WebUser = customer.WebUser
            };
            customer.WebUser.ShoppingCart = shoppingCart;

            customer.Account.Customer = customer;

            return customer;
        }

        /// <summary>
        /// Creates a Customer with the given name
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public Customer CreateWithName(string firstName, string lastName)
        {
            var customer = Create();
            customer.Name.FirstName = firstName;
            customer.Name.LastName = lastName;

            customer.WebUser.Login_ID = $"{lastName?.ToLower()}{firstName?.ToLower()?.First()}{DateTime.Now.Second}";
            customer.WebUser.Password = $"{Environment.TickCount}";

            return customer;
        }
    }
}
