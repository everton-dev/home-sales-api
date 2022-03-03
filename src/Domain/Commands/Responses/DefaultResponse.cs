namespace Domain.Commands.Responses
{
    public class DefaultResponse
    {
        public static DefaultResponse OK = new();

        public DefaultResponse()
        {
            Erros = new List<string>();
        }

        public ICollection<string> Erros { get; private set; }
        public bool Success => !(Erros.Count > 0);
        public async Task<DefaultResponse> AddValidationAsync(string error)
        {
            Erros.Add(error);
            return await Task.FromResult(this);
        }
    }

    public class DefaultResponse<TResponse> : DefaultResponse
    {
        public TResponse? Data { get; set; }
    }
}