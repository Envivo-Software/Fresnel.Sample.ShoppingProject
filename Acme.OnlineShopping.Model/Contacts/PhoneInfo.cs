// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System.ComponentModel.DataAnnotations;

namespace Acme.OnlineShopping.Contacts
{
    /// <summary>
    /// Phone contact details
    /// </summary>
    public class PhoneInfo
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.PhoneNumber)]
        public string AreaCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.PhoneNumber)]
        public string Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.PhoneNumber)]
        public string Extension { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{AreaCode} {Number} {Extension}";
        }
    }
}
