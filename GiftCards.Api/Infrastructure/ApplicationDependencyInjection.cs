using FluentValidation;
using GiftCards.Api.Infrastructure.Persistence;
using GiftCards.Api.Shared.Behaviors;
using MediatR;

namespace GiftCards.Api.Infrastructure
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ApplicationDependencyInjection).Assembly);
            });

            services.AddValidatorsFromAssemblyContaining<Program>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.RegisterEventStore();

            return services;
        }
    }
}
