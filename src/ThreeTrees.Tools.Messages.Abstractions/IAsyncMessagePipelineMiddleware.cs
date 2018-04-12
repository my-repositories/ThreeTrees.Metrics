// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Threading;
using System.Threading.Tasks;

namespace ThreeTrees.Tools.Messages.Abstractions
{
    /// <summary>
    /// Async pipeline handler to process message. It may change message context.
    /// </summary>
    public interface IAsyncMessagePipelineMiddleware
    {
        /// <summary>
        /// Gets middleware id.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Handles the message in context asynchronously.
        /// </summary>
        /// <param name="messageContext">Message execution context.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task HandleAsync(IMessageContext messageContext, CancellationToken cancellationToken =
            default(CancellationToken));
    }
}
