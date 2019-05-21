using System;
using System.Net.Http;
using System.Windows;
using HN.Social.Bangumi;
using HN.Social.Bangumi.Authorization;

namespace DesktopDemo
{
    public partial class MainWindow
    {
        private readonly IBangumiClient _client;

        public MainWindow()
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

        private void IsSignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (_client.IsSignIn)
            {
                MessageBox.Show("已登录");
            }
            else
            {
                MessageBox.Show("未登录");
            }
        }

        private async void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await _client.SignInAsync();
                MessageBox.Show("登录成功");
            }
            catch (UserCancelAuthorizationException)
            {
                MessageBox.Show("取消了授权");
            }
            catch (Exception ex) when (ex is HttpErrorAuthorizationException || ex is HttpRequestException)
            {
                MessageBox.Show("网络错误");
            }
        }

        private async void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            await _client.SignOutAsync();
            MessageBox.Show("登出完成");
        }
    }
}
