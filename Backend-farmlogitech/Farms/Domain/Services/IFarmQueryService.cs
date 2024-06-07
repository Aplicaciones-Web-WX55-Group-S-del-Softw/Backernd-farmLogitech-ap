using Backend_farmlogitech.Farms.Domain.Model.Aggregates;
using Backend_farmlogitech.Farms.Domain.Model.Queries.Farm;

namespace Backend_farmlogitech.Farms.Domain.Services;

public interface IFarmQueryService
{
    Task<Farm> Handle(GetFarmByIdQuery query);
   
    Task<IEnumerable<Farm>> Handle(GetFarmByLocationQuery query);
    
   Task<IEnumerable<Farm>> Handle(GetAllFarmQuery query); /*List*/
 
    
}