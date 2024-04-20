namespace InvoceCustomCodeApi.Host.Middleware;

public class Middleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context, ICreateResponseUseCaseProvider useCaseProvider)
    {
        if (!context.Request.Path.HasValue)
        {
            await next(context);
        }

        var createResponseUseCase = useCaseProvider.Provide(context.Request.Path.Value);
        context.Items["CreateResponseUseCase"] = createResponseUseCase;

        await next(context);
    }
}