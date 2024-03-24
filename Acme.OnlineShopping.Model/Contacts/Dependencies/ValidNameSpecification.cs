// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Acme.OnlineShopping.Contacts.Dependencies
{
    /// <summary>
    /// Checks to perform before setting a Name value   
    /// </summary>
    public class ValidNameSpecification : ISpecification<string>
    {
        /// <inheritdoc/>
        public Assertion IsSatisfiedBy(string newName)
        {
            var allExceptions = new List<Exception>();

            if (string.IsNullOrEmpty(newName))
            {
                var error = new ValidationException("Name must be provided");
                allExceptions.Add(error);
            }

            var regex = new Regex(@"^[a-z ,.'-]+$", RegexOptions.IgnoreCase);
            if (!string.IsNullOrEmpty(newName) &&
                !regex.IsMatch(newName))
            {
                var error = new ValidationException("Name contains invalid characters");
                allExceptions.Add(error);
            }

            return allExceptions.Any() ?
                    Assertion.Fail(allExceptions) :
                    Assertion.Pass;
        }
    }
}