namespace InvoceCustomCodeApi.Host.Providers;

public class CreateResponseUseCaseProvider(IServiceProvider serviceProvider) 
    : ICreateResponseUseCaseProvider
{
    public CreateResponseUseCase Provide(string path)
    {
        return path.Contains("custom") 
            ? serviceProvider.GetRequiredService<CreateCustomResponseUseCase>() 
            : serviceProvider.GetRequiredService<CreateResponseUseCase>();
    }
}