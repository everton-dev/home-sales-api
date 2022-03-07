namespace Domain.Extensions
{
    public static class StreamExtensions
    {
        public static string ConvertToBase64(this Stream stream)
        {
            var bytes = default(byte[]);
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            return Convert.ToBase64String(bytes);
        }
    }
}