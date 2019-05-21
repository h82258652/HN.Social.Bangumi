using Microsoft.Extensions.DependencyInjection;

namespace HN.Social.Bangumi
{
    public interface IBangumiClientBuilder
    {
        IServiceCollection Services { get; }

        IBangumiClient Build();
    }
}
