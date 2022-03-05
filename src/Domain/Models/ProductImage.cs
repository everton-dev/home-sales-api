namespace Domain.Models
{
    public class ProductImage : IEquatable<ProductImage>
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Url { get; private set; }

        public ProductImage(string name, string type, string url)
        {
            Name = name;
            Type = type;
            Url = url;
        }

        public bool Equals(ProductImage? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return false;
            return Name == other.Name &&
                Type == other.Type &&
                Url == other.Url;
        }

        public override bool Equals(object? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != GetType()) return false;
            return Equals((ProductImage?)other);
        }

        public override int GetHashCode() =>
            $"{Url}".GetHashCode();

        public override string ToString() =>
            $"{{\"Name\":{Name},\"Type\":\"{Type}\",\"Url\":\"{Url}\"}}";

        public static bool operator ==(ProductImage? left, ProductImage? right) => Equals(left, right);
        public static bool operator !=(ProductImage? left, ProductImage? right) => !Equals(left, right);
    }
}