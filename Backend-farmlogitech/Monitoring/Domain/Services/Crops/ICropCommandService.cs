using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Crops;

namespace Backend_farmlogitech.Monitoring.Domain.Services.Crops;

public interface ICropCommandService
{
    Task<Crop> Handle(CreateCropCommand command); 
    Task<Crop> Handle(UpdateCropCommand command);
    Task<Crop> Handle(DeleteCropCommand command);
    //Task<Crop> Handle(ReadCropCommand command);

}