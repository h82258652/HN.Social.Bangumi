using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Options;

namespace HN.Social.Bangumi.Authorization
{
    public class DesktopAuthorizationProvider : AuthorizationProviderBase
    {
        public DesktopAuthorizationProvider(IOptions<BangumiOptions> bangumiOptionsAccesser) : base(bangumiOptionsAccesser)
        {
        }

        protected override Task<string> GetAuthorizationCodeAsync(Uri authorizationUri, Uri callbackUri)
        {
            var authorizationDialog = new AuthorizationDialog(authorizationUri);
            var dialogResult = authorizationDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                return Task.FromResult(authorizationDialog.AuthorizationCode);
            }
            else
            {
                if (authorizationDialog.IsHttpError)
                {
                    throw new HttpErrorAuthorizationException();
                }
                else
                {
                    throw new UserCancelAuthorizationException();
                }
            }
        }
    }
}
