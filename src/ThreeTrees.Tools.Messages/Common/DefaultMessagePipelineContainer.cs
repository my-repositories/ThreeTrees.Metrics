// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using ThreeTrees.Tools.Messages.Abstractions;

namespace ThreeTrees.Tools.Messages.Common
{
    /// <summary>
    /// Simple message pipeline container with default arrays implementation.
    /// </summary>
    public class DefaultMessagePipelineContainer : IMessagePipelineContainer
    {
        /// <summary>
        /// Default static instance.
        /// </summary>
        public static readonly IMessagePipelineContainer Default = new DefaultMessagePipelineContainer();

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultMessagePipelineContainer"/> class.
        /// </summary>
        public DefaultMessagePipelineContainer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultMessagePipelineContainer"/> class.
        /// </summary>
        /// <param name="pipelines">Pipelines enumerable.</param>
        public DefaultMessagePipelineContainer(IEnumerable<IMessagePipeline> pipelines)
        {
            if (pipelines == null)
            {
                throw new ArgumentNullException(nameof(pipelines));
            }

            this.Pipelines = pipelines.ToArray();
        }

        /// <inheritdoc />
        public IMessagePipeline[] Pipelines { get; set; } = new IMessagePipeline[0];
    }
}
