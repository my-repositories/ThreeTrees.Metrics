// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace ThreeTrees.Tools.Domain.Exceptions
{
    /// <inheritdoc />
    public class NotFoundException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        public NotFoundException()
            : base("NotFoundException")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}
