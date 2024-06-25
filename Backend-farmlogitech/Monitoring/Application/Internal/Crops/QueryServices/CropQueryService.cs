using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Crops;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Crops;
using Backend_farmlogitech.Monitoring.Domain.Services.Crops;

namespace Backend_farmlogitech.Monitoring.Application.Internal.Crops.QueryServices;

public class CropQueryService : ICropQueryService
{
    private ICropRepository _cropRepository;

    public CropQueryService(ICropRepository cropRepository)
    {
        _cropRepository = cropRepository;
    }

    public async Task<Crop> Handle(GetCropByIdQuery query)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        var crop = await _cropRepository.FindByIdAsync(query.Id);

        if (crop == null)
        {
            throw new Exception($"No crop found with id {query.Id}");
        }

        return crop;
    }

    public async Task<IEnumerable<Crop>> Handle(GetAllCropsQuery query)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        var crops = await _cropRepository.FindByAllCropAsync();

        if (crops == null || !crops.Any())
        {
            throw new Exception("No crops found.");
        }

        return crops;
    }
}