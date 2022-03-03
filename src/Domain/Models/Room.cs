namespace Domain.Models
{
    public class Room : IEquatable<Room>
    {
        public string Id { get; }
        public string Description { get; }

        public Room(string id, string description)
        {
            Id = id;
            Description = description;
        }

        public bool Equals(Room? other)
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
            return Equals((Room?)other);
        }

        public override int GetHashCode() =>
            $"{Id}:{Description}".GetHashCode();

        public override string ToString() =>
            $"{{\"id\":{Id},\"description\":\"{Description}\"}}";

        public static bool operator ==(Room? left, Room? right) => Equals(left, right);
        public static bool operator !=(Room? left, Room? right) => !Equals(left, right);

    }
}