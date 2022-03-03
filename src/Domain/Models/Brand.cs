namespace Domain.Models
{
    public class Brand : IEquatable<Brand>
    {
        public string Id { get; }
        public string Description { get; }

        public Brand(string id, string description)
        {
            Id = id;
            Description = description;
        }

        public bool Equals(Brand? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return false;
            return Id == other.Id &&
                Description == other.Description;
        }

        public override bool Equals(object? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != GetType()) return false;
            return Equals((Brand?)other);
        }

        public override int GetHashCode() =>
            $"{Id}:{Description}".GetHashCode();

        public override string ToString() =>
            $"{{\"id\":{Id},\"description\":\"{Description}\"}}";

        public static bool operator ==(Brand? left, Brand? right) => Equals(left, right);
        public static bool operator !=(Brand? left, Brand? right) => !Equals(left, right);
    }
}