using System;
using System.Net.Http;
using HN.Social.Bangumi;
using HN.Social.Bangumi.Authorization;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace UwpDemo
{
    public sealed partial class MainPage
    {
        private readonly IBangumiClient _client;

        public MainPage()
        {
            _client = new BangumiClientBuilder()
                .WithConfig(options =>
                {
                    options.AppID = "bgm1515abd9ed193565";
                    options.AppSecret = "2b709137d48c1fb50895f2defd017cba";
                    options.CallbackUrl = "https://github.com/h82258652/HN.Bangumi";
                    options.RetryCount = 5;
                    options.RetryDelay = TimeSpan.FromSeconds(0.3);
                })
                .UseDefaultAuthorizationProvider()
                .UseDefaultAccessTokenStorage()
                .Build();

            InitializeComponent();
        }

        private async void IsSignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (_client.IsSignIn)
            {
                await new MessageDialog("已登录").ShowAsync();
            }
            else
            {
                await new MessageDialog("未登录").ShowAsync();
            }
        }

        private async void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await _client.SignInAsync();
                await new MessageDialog("登录成功").ShowAsync();
            }
            catch (UserCancelAuthorizationException)
            {
                await new MessageDialog("取消了授权").ShowAsync();
            }
            catch (Exception ex) when (ex is HttpErrorAuthorizationException || ex is HttpRequestException)
            {
                await new MessageDialog("网络错误").ShowAsync();
            }
        }

        private async void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            await _client.SignOutAsync();
            await new MessageDialog("登出完成").ShowAsync();
        }
    }
}
