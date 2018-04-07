// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace ThreeTrees.Metrics.Web.Models
{
    /// <summary>
    /// The error view model.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets the request id.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether the show request id.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}