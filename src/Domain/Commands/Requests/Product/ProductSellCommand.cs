using Domain.Commands.Responses;
using Domain.Models;
using Domain.Validators;
using MediatR;
using System.Text.Json.Serialization;

namespace Domain.Commands.Requests
{
    public class ProductSellCommand : ValidateCommand, IRequest<DefaultResponse<Product>>
    {
        public string Id { get; private set; }
        public decimal SoldBy { get; private set; }

        [JsonConstructor]
        public ProductSellCommand(string id, decimal soldBy)
        {
            Id = id;
            SoldBy = soldBy;
        }

        public override async Task ValidateAsync()
        {
            if (!string.IsNullOrWhiteSpace(Id))
                AddNotification("Id", "Id is required.");
            else if (!GuidValidator.IsGuid(Id))
                AddNotification("Id", "Id is not valid.");

            if (SoldBy <= 0)
                AddNotification("SoldBy", "SoldBy is required.");

            await Task.CompletedTask;
        }
    }
}