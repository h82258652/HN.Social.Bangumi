using HN.Social.Bangumi.Models;

namespace HN.Social.Bangumi
{
    public interface IAccessTokenStorage
    {
        void Clear();

        AccessToken Load();

        void Save(AccessToken accessToken);
    }
}
