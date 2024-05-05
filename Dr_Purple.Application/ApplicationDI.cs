using Dr_Purple.Application.Background_Tasks;
using Dr_Purple.Application.Behaviors;
using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Constants.Notification;
using Dr_Purple.Application.Utility.Background_Tasks;
using Dr_Purple.Application.Utility.Security;
using Dr_Purple.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace Dr_Purple.Application;
public static class ApplicationDI
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configration)
    {
        var notificationSettings = new NotificationSettings();
        configration.Bind(NotificationSettings.SectionName, notificationSettings);

        var taskSettings = new TaskSettings();
        configration.Bind(TaskSettings.SectionName, taskSettings);

        return services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
                       .AddAuth(configration)
                       .AddBehaviour()
                       .AddSingleton(typeof(MessageService).Assembly)
                       .AddSingleton(Options.Create(notificationSettings))
                       .AddSingleton(Options.Create(taskSettings))
                       .AddTransient<INotificationService, NotificationService>()
                       .AddTransient<ITaskSettingsService, TaskSettingsService>()
                       .AddInfrastructure(configration);
                       //.AddBackgroundTasks();
    }
    private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configration)
    {
        var jwtSettings = new JwtSettings();
        configration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings))
            .AddTransient<IJwtTokenGenerator, JwtTokenGenerator>()
            .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });

        return services;
    }

    private static IServiceCollection AddBehaviour(this IServiceCollection services)
    {
        return services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>))
                        .AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
    }
    public static IServiceCollection AddBackgroundTasks(this IServiceCollection services)
    {
        return services.AddHostedService<ServiceTimeScheduler>();
                       //.AddHostedService<AppointmentPerContractScheduler>()
                       //.AddHostedService<AppointmentPerServiceScheduler>()
                      // .AddHostedService<SellPerMaterialScheduler>();
    }
}

