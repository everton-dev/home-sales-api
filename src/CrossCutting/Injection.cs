using Application.Configuration.Map;
using Application.Handlers;
using Application.Pipelines;
using Domain.Interfaces.Repositories;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CrossCutting
{
    public static class Injection
    {
        /// <summary>
        /// Add repositories injection.
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBrandRepository), typeof(BrandRepository));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IRoomRepository), typeof(RoomRepository));
        }

        /// <summary>
        /// Add Mediator and pipelines.
        /// </summary>
        /// <param name="services"></param>
        public static void AddMediator(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(MeasureTime<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateCommandHandler<,>));

            services.AddMediatR(typeof(ProductCreateHandler).GetTypeInfo().Assembly);
        }

        /// <summary>
        /// Add Automapper.
        /// </summary>
        /// <param name="services"></param>
        public static void AddAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BrandAutoMapping), typeof(ProductAutoMapping), typeof(RoomAutoMapping));
        }
    }
}