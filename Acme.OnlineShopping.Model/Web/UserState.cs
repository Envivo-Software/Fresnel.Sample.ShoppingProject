// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
namespace Acme.OnlineShopping.Web
{
    /// <summary>
    /// Defines the various states an online user can be in 
    /// </summary>
    public enum UserState
    {
        /// <summary>
        /// The user is brand new, and not active yet
        /// </summary>
        New,

        /// <summary>
        /// The user is active
        /// </summary>
        Active,

        /// <summary>
        /// The user is temporarily blocked from the site
        /// </summary>
        Blocked,

        /// <summary>
        /// The user has been banned indefinitely
        /// </summary>
        Banned
    }
}
