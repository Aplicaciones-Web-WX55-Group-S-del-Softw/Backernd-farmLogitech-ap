using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Crops;

namespace Backend_farmlogitech.Monitoring.Domain.Services.Crops;

public interface ICropQueryService
{
    Task<Crop> Handle(GetCropByIdQuery query);
    Task<IEnumerable<Crop>> Handle(GetAllCropsQuery query);
}