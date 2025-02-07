using Microsoft.AspNetCore.Builder;

namespace Ambev.Test.PedroBono.IoC
{
    public interface IModuleInitializer
    {
        void Initialize(WebApplicationBuilder builder);
    }
}
