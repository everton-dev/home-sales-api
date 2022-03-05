using Domain.Commands.Responses;
using Domain.Validators;
using MediatR;
using System.Text.Json.Serialization;

namespace Domain.Commands.Requests
{
    public class ProductSetImagesCommand : ValidateCommand, IRequest<DefaultResponse<Models.Product>>
    {
        public string Id { get; private set; }
        public ProductImageRequest[] Images { get; private set; }

        [JsonConstructor]
        public ProductSetImagesCommand(string id, ProductImageRequest[] images)
        {
            Id = id;
            Images = images;
        }

        public override async Task ValidateAsync()
        {
            if (!string.IsNullOrWhiteSpace(Id))
                AddNotification("Id", "Id is required.");
            else if (!GuidValidator.IsGuid(Id))
                AddNotification("Id", "Id is not valid.");

            if (Images == null)
                AddNotification("Images", "Images is required.");
            else if (Images.Length <= 0)
                AddNotification("Images", "Images is empty.");

            await Task.CompletedTask;
        }
    }
}