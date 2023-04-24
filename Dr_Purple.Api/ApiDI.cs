namespace Dr_Purple.Api;
public static class ApiDI
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddControllers();
        return services;
    }
}
