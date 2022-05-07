using Nest;

namespace n5now.Services
{
    public interface IESClientProvider
    {
        ElasticClient GetClient();
    }
}
