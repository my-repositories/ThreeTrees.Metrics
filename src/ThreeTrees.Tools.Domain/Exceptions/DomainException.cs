// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;

namespace ThreeTrees.Tools.Domain.Exceptions
{
    /// <inheritdoc />
    public class DomainException : Exception
    {
        /// <inheritdoc />
        public DomainException()
            : base("DomainException")
        {
        }

        /// <inheritdoc />
        public DomainException(string message)
            : base(message)
        {
        }
    }
}
