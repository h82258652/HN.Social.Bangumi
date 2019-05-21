using System;
using HN.Social.Bangumi.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace HN.Social.Bangumi
{
    public static class BangumiClientBuilderExtensions
    {
        public static IBangumiClientBuilder UseAccessTokenStorage<T>(this IBangumiClientBuilder builder) where T : class, IAccessTokenStorage
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Services.AddTransient<IAccessTokenStorage, T>();
            return builder;
        }

        public static IBangumiClientBuilder UseAuthorizationProvider<T>(this IBangumiClientBuilder builder) where T : class, IAuthorizationProvider
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Services.AddTransient<IAuthorizationProvider, T>();
            return builder;
        }

        public static IBangumiClientBuilder WithConfig(this IBangumiClientBuilder builder, Action<BangumiOptions> configureOptions)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configureOptions == null)
            {
                throw new ArgumentNullException(nameof(configureOptions));
            }

            builder.Services.Configure(configureOptions);
            return builder;
        }
    }
}
