using Domain.Commands.Responses;
using Domain.Models;
using Domain.Validators;
using MediatR;
using System.Text.Json.Serialization;

namespace Domain.Commands.Requests
{
    public class ProductUpdateCommand : ValidateCommand, IRequest<DefaultResponse>
    {
        [JsonConstructor]
        public ProductUpdateCommand(string id, string description, Room room, Brand brand, decimal originalValue, decimal saleValue, decimal? soldBy, bool active, DateTime? soldDate)
        {
            Id = id;
            Description = description;
            Room = room;
            Brand = brand;
            OriginalValue = originalValue;
            SaleValue = saleValue;
            SoldBy = soldBy;
            Active = active;
            SoldDate = soldDate;
        }

        public string Id { get; private set; }
        public string Description { get; private set; }
        public Room Room { get; private set; }
        public Brand Brand { get; private set; }
        public decimal OriginalValue { get; private set; }
        public decimal SaleValue { get; private set; }
        public decimal? SoldBy { get; private set; }
        public bool Active { get; private set; }
        public DateTime? SoldDate { get; private set; }

        public override async Task ValidateAsync()
        {
            if (string.IsNullOrWhiteSpace(Id))
                AddNotification("Id", "Id is required.");
            else if (!GuidValidator.IsGuid(Id))
                AddNotification("Id", "Id is not valid.");

            if (string.IsNullOrWhiteSpace(Description))
                AddNotification("Description", "Description is required.");

            if (Room == null)
                AddNotification("Room", "Room is required.");
            else
            {
                if (string.IsNullOrWhiteSpace(Room.Id))
                    AddNotification("Room.Id", "Id Room is required.");
                else if (!GuidValidator.IsGuid(Room.Id))
                    AddNotification("Room.Id", "Id Room is not valid.");

                if (string.IsNullOrWhiteSpace(Room.Description))
                    AddNotification("Room.Description", "Description Room is required.");
            }

            if (Brand == null)
                AddNotification("Brand", "Brand is required.");
            else
            {
                if (string.IsNullOrWhiteSpace(Brand.Id))
                    AddNotification("Brand.Id", "Id Brand is required.");
                else if (!GuidValidator.IsGuid(Brand.Id))
                    AddNotification("Brand.Id", "Id Brand is required.");

                if (string.IsNullOrWhiteSpace(Brand.Description))
                    AddNotification("Brand.Description", "Description Brand is required.");
            }

            if (OriginalValue <= 0)
                AddNotification("OriginalValue", "OriginalValue is required.");

            await Task.CompletedTask;
        }
    }
}