using System;
using HN.Social.Bangumi.Authorization;

namespace HN.Social.Bangumi
{
    public static class BangumiClientBuilderExtensions
    {
        public static IBangumiClientBuilder UseDefaultAccessTokenStorage(this IBangumiClientBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.UseAccessTokenStorage<UwpAccessTokenStorage>();
        }

        public static IBangumiClientBuilder UseDefaultAuthorizationProvider(this IBangumiClientBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.UseAuthorizationProvider<UwpAuthorizationProvider>();
        }
    }
}
