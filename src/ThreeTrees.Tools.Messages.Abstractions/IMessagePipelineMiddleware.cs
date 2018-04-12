// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace ThreeTrees.Tools.Messages.Abstractions
{
    /// <summary>
    /// Pipeline handler to process message. It may change message context.
    /// </summary>
    public interface IMessagePipelineMiddleware
    {
        /// <summary>
        /// Gets middleware id.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Handles the message in context.
        /// </summary>
        /// <param name="messageContext">Message execution context.</param>
        void Handle(IMessageContext messageContext);
    }
}
