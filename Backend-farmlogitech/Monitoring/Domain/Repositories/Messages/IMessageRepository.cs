using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;

namespace Backend_farmlogitech.Monitoring.Domain.Repositories;

public interface IMessageRepository: IBaseRepository<Message>
{ 
    Task<IEnumerable<Message>> FindAllByCollaboratorId(int collaboratorId);
    Task<IEnumerable<Message>> FindAllByCollaboratorIdAndFarmerId(int collaboratorId, int farmerId);
    Task<IEnumerable<Message>> FindAllMessageByCollaboratorIdAndTransmitterId(int collaboratorId, int transmitterId);
    Task<IEnumerable<Message>> FindAllMessageByFarmerIdAndTransmitterId(int farmerId, int transmitterId);
}


