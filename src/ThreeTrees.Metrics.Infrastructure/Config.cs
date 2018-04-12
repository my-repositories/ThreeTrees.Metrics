// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.IO;

using Microsoft.Extensions.Configuration;

namespace ThreeTrees.Metrics.Infrastructure
{
    /// <summary>
    /// The config.
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Initializes static members of the <see cref="Config"/> class.
        /// </summary>
        static Config()
        {
            Values = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile(Path.GetFullPath(Path.Combine(@"../../tools/appsettings.json")), true, true)
                .Build();
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        private static IConfiguration Values { get; }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string Get(string key) => Values[key];
    }
}
