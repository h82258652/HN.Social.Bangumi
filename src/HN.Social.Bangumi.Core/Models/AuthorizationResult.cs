﻿using Newtonsoft.Json;

namespace HN.Social.Bangumi.Models
{
    public class AuthorizationResult
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }
    }
}
