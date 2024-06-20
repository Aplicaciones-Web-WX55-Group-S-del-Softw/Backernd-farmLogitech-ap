namespace Backend_farmlogitech.Monitoring.Domain.Model.Commands.Crops
{
    public record UpdateCropCommand(int Id, string Type, string PlantingDate, int Quantity, int ShedId, int FarmId, int UserId);
}