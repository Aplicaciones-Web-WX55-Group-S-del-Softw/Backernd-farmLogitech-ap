using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Animals;

namespace Backend_farmlogitech.Monitoring.Domain.Services.Animals;

public interface IAnimalCommandService
{
    Task<Animal> Handle(CreateAnimalCommand command);
    Task<Animal> Handle(UpdateAnimalCommand command);
    Task<Animal> Handle(DeleteAnimalCommand command);
    //Task<Animal> Handle(ReadAnimalCommand command);
}