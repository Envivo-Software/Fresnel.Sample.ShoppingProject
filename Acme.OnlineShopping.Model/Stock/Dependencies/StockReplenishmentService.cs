// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;

namespace Acme.OnlineShopping.Stock.Dependencies
{
    /// <summary>
    /// Used to send re-supply orders to Suppliers
    /// </summary>
    public class StockReplenishmentService : IDomainService
    {
        /// <summary>
        /// Identifies all low stock levels, and sends order emails to the relevant suppliers
        /// </summary>
        public void SendOrdersToSuppliers()
        {
            // Domain logic goes here
        }
    }
}