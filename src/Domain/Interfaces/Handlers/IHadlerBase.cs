namespace Domain.Interfaces.Handlers
{
    public interface IHadlerBase<TResponse, TRequest>
    {
        Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken);
    }
}