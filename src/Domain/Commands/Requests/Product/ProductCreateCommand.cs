using Domain.Commands.Responses;
using Domain.Validators;
using MediatR;
using System.Text.Json.Serialization;

namespace Domain.Commands.Requests
{
    public class ProductCreateCommand : ValidateCommand, IRequest<DefaultResponse>
    {
        public string Description { get; private set; }
        public string RoomId { get; private set; }
        public string BrandId { get; private set; }
        public decimal OriginalValue { get; private set; }
        public decimal SaleValue { get; private set; }

        [JsonConstructor]
        public ProductCreateCommand(string description, string roomId, string brandId, decimal originalValue, decimal saleValue)
        {
            Description = description;
            RoomId = roomId;
            BrandId = brandId;
            OriginalValue = originalValue;
            SaleValue = saleValue;
        }

        public override async Task ValidateAsync()
        {
            if (string.IsNullOrWhiteSpace(Description))
                AddNotification("Description", "Description is required.");

            if (string.IsNullOrWhiteSpace(RoomId))
                AddNotification("Room.Id", "Id Room is required.");
            else if (!GuidValidator.IsGuid(RoomId))
                AddNotification("Room.Id", "Id Room is not valid.");

            if (string.IsNullOrWhiteSpace(BrandId))
                AddNotification("BrandId", "Id Brand is required.");
            else if (!GuidValidator.IsGuid(BrandId))
                AddNotification("BrandId", "Id Brand is not valid.");

            if (OriginalValue <= 0)
                AddNotification("OriginalValue", "OriginalValue is required.");

            await Task.CompletedTask;
        }
    }
}