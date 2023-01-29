// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
namespace Acme.OnlineShopping.Shopping
{
    /// <summary>
    /// The state of an Order
    /// </summary>
    public enum OrderState
    {
        /// <summary>
        /// The order is new, and has not been processed yet
        /// </summary>
        New,

        /// <summary>
        /// The order is temporarily on hold
        /// </summary>
        Hold,

        /// <summary>
        /// The order has been shipped
        /// </summary>
        Shipped,

        /// <summary>
        /// The order has been delivered, and confirmation received
        /// </summary>
        Delivered,

        /// <summary>
        /// The order is now complete
        /// </summary>
        Closed
    }
}
