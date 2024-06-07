using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Crops;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Crops;
using Backend_farmlogitech.Monitoring.Domain.Services.Crops;

namespace Backend_farmlogitech.Monitoring.Application.Internal.Crops.QueryServices;

public class CropQueryService : ICropQueryService
{
    private ICropRepository _cropRepository;
    public async Task<Crop> Handle(GetCropByIdQuery query)
    {
        return await _cropRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Crop>> Handle(GetAllCropsQuery query)
    {
        return await _cropRepository.FindByAllCropAsync(); 
    }
}