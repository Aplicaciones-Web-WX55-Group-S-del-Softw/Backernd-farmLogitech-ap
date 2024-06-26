using Backend_farmlogitech.Farms.Domain.Model.Aggregates;
using Backend_farmlogitech.Farms.Domain.Model.Queries.Farm;
using Backend_farmlogitech.Farms.Domain.Repositories;
using Backend_farmlogitech.Farms.Domain.Services;
using Backend_farmlogitech.IAM.Domain.Model.Aggregates;

namespace Backend_farmlogitech.Farms.Application.Internal.QueryServices;

public class FarmQueryService(IFarmRepository farmRepository) : IFarmQueryService
{
    public async Task<Farm> Handle(GetFarmByIdQuery query)
    {
        return await farmRepository.FindByIdAsync(query.Id);
    }


    public async Task<IEnumerable<Farm>> Handle(GetFarmByLocationQuery query)
    {
        return await farmRepository.FindByLocationAsync(query.Location);
    }


    public async Task<IEnumerable<Farm>> Handle(GetAllFarmQuery query)
    {
    return await farmRepository.FindByAllFarmAsync();
    }

    public async Task<Farm?> Handle(GetFarmByUserIdQuery query)
    {
        var userAuth= User.UserAuthenticate.UserId;
        return await farmRepository.FindByUserId(userAuth); 
    }
}