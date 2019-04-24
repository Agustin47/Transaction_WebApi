
namespace Infrastructure
{

    using Microsoft.Extensions.DependencyInjection;
    using MediatR;
    using Contract;
    using Services;

    public static class ServicesInyectionExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void ServicesInyections(this IServiceCollection services)
        {

            services.AddMediatR();

            services.AddTransient<IConvertService, >();
        }
    }
}
