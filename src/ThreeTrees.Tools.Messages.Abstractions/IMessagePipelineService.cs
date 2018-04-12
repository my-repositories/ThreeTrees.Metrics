// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;

namespace ThreeTrees.Tools.Messages.Abstractions
{
    /// <summary>
    /// Pipelines service. The inteface describes class properties requires for
    /// base pipelinse service that will be used for all messages processing.
    /// </summary>
    public interface IMessagePipelineService
    {
        /// <summary>
        /// Gets or sets pipelines related to service.
        /// </summary>
        IMessagePipelineContainer PipelineContainer { get; set; }

        /// <summary>
        /// Gets or sets current used service provider.
        /// </summary>
        IServiceProvider ServiceProvider { get; set; }
    }
}
