namespace InvoceCustomCodeApi.Host;

public class Startup(IConfiguration configuration)
{
    private IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" }); });

        services.AddTransient<CreateCustomResponseUseCase>();
        services.AddTransient<CreateResponseUseCase>();

        services.AddSingleton<ICreateResponseUseCaseProvider, CreateResponseUseCaseProvider>();

        services.AddMvc();
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1"); });
        }
        
        app.UseMiddleware<Middleware.Middleware>();
        
        app.UseRouting();
        
        app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(_ => true)
            .AllowCredentials());
        
        app.MapControllerRoute(
            "default", "{controller=Home}/{action=Index}/{id?}");
    }
}
