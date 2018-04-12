// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;

namespace ThreeTrees.Tools.Messages.Abstractions
{
    /// <summary>
    /// Message context. Contains objects to execute, metadata and current execution state.
    /// The specific instance is created for every request.
    /// </summary>
    public interface IMessageContext
    {
        /// <summary>
        /// Gets unique message id.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets current service provider.
        /// </summary>
        IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Gets or sets identifier for content.
        /// Can be used to determine unique processing content type and where to find base class.
        /// </summary>
        string ContentId { get; set; }

        /// <summary>
        /// Gets or sets current message content. May be command object or event object.
        /// </summary>
        object Content { get; set; }

        /// <summary>
        /// Gets or sets get or sets current status of message context execution.
        /// </summary>
        ProcessingStatus Status { get; set; }

        /// <summary>
        /// Gets or sets exception that describes error when status is failed.
        /// </summary>
        Exception FailException { get; set; }

        /// <summary>
        /// Gets or sets current processing pipeline or null.
        /// </summary>
        IMessagePipeline Pipeline { get; set; }

        /// <summary>
        /// Gets or sets local key/value collection of objects that are shared across current message scope.
        /// Expect that dictionary implementation can not be thread safe.
        /// </summary>
        IDictionary<object, object> Items { get; set; }
    }
}
