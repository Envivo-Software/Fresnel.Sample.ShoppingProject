// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System.ComponentModel.DataAnnotations;

namespace Acme.OnlineShopping.Contacts
{
    /// <summary>
    /// Contact details for a person or party
    /// </summary>
    public class ContactInfo
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
        /// 
        /// </summary>
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{AreaCode} {Number} {Extension}, {Email}";
        }
            }
}
