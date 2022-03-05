using System.Text;

namespace Domain.Models
{
    public class Product : IEquatable<Product>
    {
        public string Id { get; private set; }
        public string Description { get; private set; }
        public Room Room { get; private set; }
        public Brand Brand { get; private set; }
        public decimal OriginalValue { get; private set; }
        public decimal SaleValue { get; private set; }
        public decimal? SoldBy { get; private set; }
        public bool? Active { get; private set; }
        public DateTime? SoldDate { get; private set; }
        public ICollection<ProductImage>? Images { get; private set; }

        public Product(string id, string description, Room room, Brand brand, decimal originalValue, decimal saleValue, decimal? soldBy = null, bool? active = true, DateTime? soldDate = null, ICollection<ProductImage>? images = null)
        {
            Id = id;
            Description = description;
            Room = room;
            Brand = brand;
            OriginalValue = originalValue;
            SaleValue = saleValue;
            SoldBy = soldBy;
            Active = active;
            Images = images;
        }

        public async Task SellAsync(decimal soldBy)
        {
            this.SoldBy = soldBy;
            this.Active = false;
            this.SoldDate = DateTime.Now;

            await Task.CompletedTask;
        }

        public void ActiveProduct() =>
            this.Active = true;
        public void InactiveProduct() =>
            this.Active = false;

        public async Task AddImageAsync(ProductImage image)
        {
            Images = Images ?? new List<ProductImage>();
            Images.Add(image);

            await Task.CompletedTask;
        }

        public bool Equals(Product? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return false;
            return Id == other.Id &&
                Description == other.Description &&
                Room.Equals(other.Room) &&
                Brand.Equals(other.Brand) &&
                OriginalValue == other.OriginalValue &&
                SaleValue == other.SaleValue &&
                SoldBy == other.SoldBy &&
                Active == other.Active &&
                SoldDate == other.SoldDate &&
                Images == other.Images;
        }

        public override bool Equals(object? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != GetType()) return false;
            return Equals((Product?)other);
        }

        public override int GetHashCode() =>
            $"{Id}:{Description}".GetHashCode();

        public override string ToString() =>
            $"{{\"id\":{Id},\"description\":\"{Description}\",\"room\":{{{Room}}},\"brand\":{{{Brand}}},\"originalValue\":{OriginalValue},\"saleValue\"={SaleValue},\"soldBy\":{SoldBy},\"active\":{Active},\"SoldDate\":{SoldDate}{ImagesToJsonString()}}}";

        private string ImagesToJsonString()
        {
            var result = $"\"images\" : []";

            if (Images == null)
                return result;

            if (Images.Count <= 0)
                return result;

            var jsonImages = new StringBuilder();
            foreach (var image in Images)
                jsonImages.Append($"{{{image}}},");

            result = $"\"images\" : [{jsonImages.ToString().Substring(0, jsonImages.ToString().Length - 2)}]";

            return result;
        }

        public static bool operator ==(Product? left, Product? right) => Equals(left, right);
        public static bool operator !=(Product? left, Product? right) => !Equals(left, right);
    }
}