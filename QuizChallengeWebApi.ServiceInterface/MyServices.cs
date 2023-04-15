using ServiceStack;
using QuizChallengeWebApi.ServiceModel;

namespace QuizChallengeWebApi.ServiceInterface;

public class MyServices : Service
{
    public object Any(Hello request)
    {
        return new HelloResponse { Result = $"Hello, {request.Name}!" };
    }
}