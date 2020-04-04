using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Chromely.Quasar1.Models.Config {

    /// <summary> Extension methods for the configuration builder.
    ///           Allows for the overriding of specific values if not already set. </summary>
    public static class ConfigBuilderExt {

        /// <summary>
        ///     An IConfigurationBuilder extension method that checks to see if a value is set, then
        ///     tries to set it from an Enviromental variable if not.
        /// </summary>
        /// <param name="builder"> The configuration builder to act on. </param>
        /// <param name="key">     The key to look for. </param>
        /// <param name="envvar">  The Enviromental variable to look for. </param>
        /// <returns> An IConfigurationBuilder. </returns>
        public static IConfigurationBuilder AddIfNotSetEnv(this IConfigurationBuilder builder,
            string key, string envvar) {

            // Check to see if the setting is already set
            var tmpcfg = builder.Build();
            var cfgval = tmpcfg.GetValue<string>(key);
            if (cfgval != null) return builder;

            // Set the value to the env var if its set
            var env_value = Environment.GetEnvironmentVariable(envvar);
            if (env_value != null) {
                var urldict = new Dictionary<string, string> { { key, env_value } };
                builder.AddInMemoryCollection(urldict);
            }
            return builder;
        }

        /// <summary>
        ///     An IConfigurationBuilder extension method that checks to see if a value is set, then
        ///     tries to set it from a default value if not.
        /// </summary>
        /// <param name="builder"> The configuration builder to act on. </param>
        /// <param name="key">     The key to look for. </param>
        /// <param name="value">   The default value to use. </param>
        /// <returns> An IConfigurationBuilder. </returns>
        public static IConfigurationBuilder AddIfNotSetValue(this IConfigurationBuilder builder,
                string key, string value) {

            // Check to see if the setting is already set
            var tmpcfg = builder.Build();
            var cfgval = tmpcfg.GetValue<string>(key);
            if (cfgval != null) return builder;

            // Set the value to a default
            var urldict = new Dictionary<string, string> { { key, value } };
            builder.AddInMemoryCollection(urldict);
            return builder;
        }
    }
}
