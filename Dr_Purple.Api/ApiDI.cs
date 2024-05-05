using Dr_Purple.Api.Helpers.AuthenticatedUser;
using Dr_Purple.Api.Helpers.Files;
using Dr_Purple.Application.Utility.Files;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Api;
public static class ApiDI
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddTransient<IFileHelper, FileHelper>()
               .AddTransient<IAuthenticatedUserService, AuthenticatedUserService>()
               .AddHttpContextAccessor();

        services.AddCors(opt =>
         {
             opt.AddDefaultPolicy(builder =>
             {
                 builder.AllowAnyOrigin()
                     .AllowAnyHeader()
                     .AllowAnyMethod();
             });
         });
        services.AddControllers();
        return services;
    }
}