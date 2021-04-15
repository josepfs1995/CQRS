using CQRS.WebAPI.Applications.Interfaces;
using CQRS.WebAPI.Applications.Services;
using CQRS.WebAPI.Domain.Commads.PersonCommands;
using CQRS.WebAPI.Domain.Events.RedisEvents;
using CQRS.WebAPI.Domain.Interfaces;
using CQRS.WebAPI.Extensions;
using CQRS.WebAPI.Infra.Commands;
using CQRS.WebAPI.Infra.Events;
using CQRS.WebAPI.Infra.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.WebAPI.Configurations{
    public static class DIConfiguration{
        public static IServiceCollection AddDIConfiguration(this IServiceCollection services){
            services.AddScoped<IRedisContext, RedisContext>();


            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IRequestHandler<CreatePersonCommand, bool>, PersonCommandHandler>();
            services.AddScoped<IPersonAppService, PersonAppService>();

            services.AddScoped<IRedisRepository, RedisRepository>();
            // services.AddScoped<INotificationHandler<CreateRedisEvent<CreatePersonCommand>>, RedisEventHandler>();
            return services;
        }
    }
}