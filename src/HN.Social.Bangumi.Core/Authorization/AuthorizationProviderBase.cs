using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HN.Social.Bangumi.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HN.Social.Bangumi.Authorization
{
    public abstract class AuthorizationProviderBase : IAuthorizationProvider
    {
        private readonly BangumiOptions _bangumiOptions;

        protected AuthorizationProviderBase(IOptions<BangumiOptions> bangumiOptionsAccesser)
        {
            _bangumiOptions = bangumiOptionsAccesser.Value;
        }

        public async Task<AuthorizationResult> AuthorizeAsync(Uri authorizationUri, Uri callbackUri)
        {
            var authorizationCode = await GetAuthorizationCodeAsync(authorizationUri, callbackUri);
            using (var client = new HttpClient())
            {
                var postData = new Dictionary<string, string>
                {
                    ["grant_type"] = "authorization_code",
                    ["client_id"] = _bangumiOptions.AppID,
                    ["client_secret"] = _bangumiOptions.AppSecret,
                    ["code"] = authorizationCode,
                    ["redirect_uri"] = _bangumiOptions.CallbackUrl
                };

                var postContent = new FormUrlEncodedContent(postData);

                var response = await client.PostAsync(Constants.AccessTokenUrl, postContent);
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AuthorizationResult>(json);
            }
        }

        public async Task<AuthorizationResult> RefreshAsync(string refreshToken)
        {
            using (var client = new HttpClient())
            {
                var postData = new Dictionary<string, string>
                {
                    ["grant_type"] = "refresh_token",
                    ["client_id"] = _bangumiOptions.AppID,
                    ["client_secret"] = _bangumiOptions.AppSecret,
                    ["refresh_token"] = refreshToken,
                    ["redirect_uri"] = _bangumiOptions.CallbackUrl
                };

                var postContent = new FormUrlEncodedContent(postData);

                var response = await client.PostAsync(Constants.AccessTokenUrl, postContent);
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AuthorizationResult>(json);
            }
        }

        protected abstract Task<string> GetAuthorizationCodeAsync(Uri authorizationUri, Uri callbackUri);
    }
}
