using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Shed;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Sheds;
using Backend_farmlogitech.Monitoring.Domain.Services.Sheds;

namespace Backend_farmlogitech.Monitoring.Application.Internal.Sheds.QueryServices;

public class ShedQueryService :IShedQueryService
{
    private readonly IShedRepository _shedRepository;

    public ShedQueryService(IShedRepository shedRepository)
    {
        this._shedRepository = shedRepository;
    }

    public async Task<IEnumerable<Shed>> Handle(GetAllShedQuery query)
    {
        return await _shedRepository.FindByAllShedAsync();
    }

    public async Task<Shed> Handle(GetShedByIdQuery query)
    {
        return await _shedRepository.FindShedById(query.Id);
    }
}