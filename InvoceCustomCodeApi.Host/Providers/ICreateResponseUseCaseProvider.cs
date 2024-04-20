namespace InvoceCustomCodeApi.Host.Providers;

public interface ICreateResponseUseCaseProvider
{
    CreateResponseUseCase Provide(string path);
}