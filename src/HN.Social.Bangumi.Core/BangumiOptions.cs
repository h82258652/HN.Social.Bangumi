using System;

namespace HN.Social.Bangumi
{
    /// <summary>
    /// Bangumi 配置项。
    /// </summary>
    public class BangumiOptions
    {
        /// <summary>
        /// App ID。
        /// </summary>
        public string AppID { get; set; }

        /// <summary>
        /// App Secret。
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// 回调地址
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// 重试次数。
        /// </summary>
        public int RetryCount { get; set; }

        /// <summary>
        /// 重试间隔。
        /// </summary>
        public TimeSpan RetryDelay { get; set; } = TimeSpan.Zero;
    }
}
