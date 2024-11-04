
public static class RegisterServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<IGymService, GymService>();
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<IUserClientService, UserClientService>();
        services.AddScoped<IUserTrainerService, UserTrainerService>();
        services.AddScoped<IUserServiceService, UserServiceService>();
        return services;
    }
}