using System.Text.Json.Serialization;

namespace Domain.Commands.Requests
{
    public class ProductImageRequest
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Base64 { get; private set; }

        [JsonConstructor]
        public ProductImageRequest(string name, string type, string base64)
        {
            Name = name;
            Type = type;
            Base64 = base64;
        }
    }
}