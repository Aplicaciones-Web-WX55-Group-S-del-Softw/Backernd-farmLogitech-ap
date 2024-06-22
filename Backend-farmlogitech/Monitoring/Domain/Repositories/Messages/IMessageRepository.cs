using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;

namespace Backend_farmlogitech.Monitoring.Domain.Repositories;

public interface IMessageRepository: IBaseRepository<Message>
{ 
    Task<IEnumerable<Message>> FindAllByCollaboratorId(long collaboratorId);
    Task<IEnumerable<Message>> FindAllByCollaboratorIdAndFarmerId(long collaboratorId, long farmerId);
    Task<IEnumerable<Message>> FindAllMessageByCollaboratorIdAndTransmitterIdNot(long collaboratorId, long transmitterId);
    Task<IEnumerable<Message>> FindAllMessageByFarmerIdAndTransmitterIdNot(long farmerId, long transmitterId);
}
