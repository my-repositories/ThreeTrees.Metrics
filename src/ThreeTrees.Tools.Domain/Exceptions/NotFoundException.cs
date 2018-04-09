// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace ThreeTrees.Tools.Domain.Exceptions
{
    /// <inheritdoc />
    public class NotFoundException : DomainException
    {
        /// <inheritdoc />
        public NotFoundException()
            : base("NotFoundException")
        {
        }

        /// <inheritdoc />
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}
