// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel.DataAnnotations;

namespace ThreeTrees.Metrics.Shared
{
    /// <inheritdoc />
    /// <summary>
    /// The attribute for range between minimum year and current year.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class RangeUntilCurrentYearAttribute : RangeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RangeUntilCurrentYearAttribute"/> class.
        /// </summary>
        /// <param name="minimum">The minimal value for year.</param>
        public RangeUntilCurrentYearAttribute(int minimum)
            : base(minimum, DateTime.Now.Year)
        {
        }
    }
}
