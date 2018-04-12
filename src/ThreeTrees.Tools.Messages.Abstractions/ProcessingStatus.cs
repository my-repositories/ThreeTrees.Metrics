﻿// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace ThreeTrees.Tools.Messages.Abstractions
{
    /// <summary>
    /// Message processing status.
    /// </summary>
    public enum ProcessingStatus : byte
    {
        /// <summary>
        /// Default command state.
        /// </summary>
        NotInitialized,

        /// <summary>
        /// The command in a processing state.
        /// </summary>
        Processing,

        /// <summary>
        /// Command has been completed.
        /// </summary>
        Completed,

        /// <summary>
        /// Command has been failed while execution. Mostly exception occurred
        /// in handler.
        /// </summary>
        Failed,

        /// <summary>
        /// Command has been rejected. It may be validation error.
        /// </summary>
        Rejected
    }
}
