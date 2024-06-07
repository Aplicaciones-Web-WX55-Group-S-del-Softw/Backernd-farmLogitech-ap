using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Animals;

namespace Backend_farmlogitech.Monitoring.Domain.Services.Animals;

public interface IAnimalQueryService
{
    Task <Animal> Handle(GetAnimalByIdQuery query);
    Task <IEnumerable<Animal>> Handle(GetAllAnimalsQuery query);
    Task <Animal> Handle(GetAnimalByShedIdQuery query);

 
}