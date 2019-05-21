using System;
using System.Threading.Tasks;
using HN.Social.Bangumi.Models;

namespace HN.Social.Bangumi.Authorization
{
    public interface IAuthorizationProvider
    {
        Task<AuthorizationResult> AuthorizeAsync(Uri authorizationUri, Uri callbackUri);

        Task<AuthorizationResult> RefreshAsync(string refreshToken);
    }
}
