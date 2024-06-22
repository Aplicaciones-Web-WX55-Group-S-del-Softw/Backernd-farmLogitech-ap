using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Farms.Domain.Model.Aggregates;

namespace Backend_farmlogitech.Farms.Domain.Repositories;

public interface IFarmRepository: IBaseRepository<Farm>
{

   
    Task<IEnumerable<Farm>> FindByLocationAsync(string location);
 
    Task<IEnumerable<Farm>> FindByAllFarmAsync();
   
    
    Task<Farm?> FindByUserId(int id);
    Task<Farm?> GetFarmByUserId(int id);
  
}