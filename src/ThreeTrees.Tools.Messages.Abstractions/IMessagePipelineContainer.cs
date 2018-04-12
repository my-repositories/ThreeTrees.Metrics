// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace ThreeTrees.Tools.Messages.Abstractions
{
    /// <summary>
    /// Container to store message pipelines.
    /// </summary>
    public interface IMessagePipelineContainer
    {
        /// <summary>
        /// Gets or sets pipelines array.
        /// </summary>
        IMessagePipeline[] Pipelines { get; set; }
    }
}
