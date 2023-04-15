using Funq;
using ServiceStack;
using QuizChallengeWebApi.ServiceInterface;

[assembly: HostingStartup(typeof(QuizChallengeWebApi.AppHost))]

namespace QuizChallengeWebApi;

public class AppHost : AppHostBase, IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices(services => {
            // Configure ASP.NET Core IOC Dependencies
        });

    public AppHost() : base("QuizChallengeWebApi", typeof(MyServices).Assembly) {}

    public override void Configure(Container container)
    {
        // Configure ServiceStack only IOC, Config & Plugins
        SetConfig(new HostConfig {
            UseSameSiteCookies = true,
        });
    }
}
