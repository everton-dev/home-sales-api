namespace Domain.Settings
{
    public class HomeSalesDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ProductCollectionName { get; set; } = null!;
        public string BrandCollectionName { get; set; } = null!;
        public string RoomCollectionName { get; set; } = null!;
    }
}