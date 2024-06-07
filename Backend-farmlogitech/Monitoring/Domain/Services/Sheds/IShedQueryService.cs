using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Shed;

namespace Backend_farmlogitech.Monitoring.Domain.Services.Sheds;

public interface IShedQueryService
{
    Task<IEnumerable<Shed>> Handle(GetAllShedQuery query);
    Task<Shed> Handle(GetShedByIdQuery query);

}