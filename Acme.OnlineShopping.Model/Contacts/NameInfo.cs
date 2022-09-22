// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Acme.OnlineShopping.Contacts.Dependencies;
using System.ComponentModel.DataAnnotations;

namespace Acme.OnlineShopping.Contacts
{
    /// <summary>
    /// The name details for a person
    /// </summary>
    public class NameInfo
    {
        private string? _FirstName;
        private string? _LastName;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The person's title (optional)
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The person's first name
        /// </summary>
        public string? FirstName
        {
            get => _FirstName;
            set
            {
                //if (string.IsNullOrEmpty(value))
                //{
                //    var message = "This value must be provided";
                //    throw new ArgumentNullException(nameof(FirstName), message);
                //}

                var check = ValidNameSpecification?.IsSatisfiedBy(value);
                if (check?.HasFailed == true)
                {
                    throw check.FailureException;
                }
                _FirstName = value;
            }
        }

        /// <summary>
        /// The person's last name
        /// </summary>
        public string? LastName
        {
            get => _LastName;
            set
            {
                var check = ValidNameSpecification?.IsSatisfiedBy(value);
                if (check?.HasFailed == true)
                {
                    throw check.FailureException;
                }
                _LastName = value;
            }
        }

        /// <summary>
        /// Used to check that names are valid
        /// </summary>
        public ValidNameSpecification? ValidNameSpecification { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Title} {FirstName} {LastName}";
        }
    }
}
