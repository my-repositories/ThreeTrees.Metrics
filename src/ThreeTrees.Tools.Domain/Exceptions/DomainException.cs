// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;

namespace ThreeTrees.Tools.Domain.Exceptions
{
    /// <inheritdoc />
    public class DomainException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainException"/> class.
        /// </summary>
        public DomainException()
            : base("DomainException")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public DomainException(string message)
            : base(message)
        {
        }
    }
}
