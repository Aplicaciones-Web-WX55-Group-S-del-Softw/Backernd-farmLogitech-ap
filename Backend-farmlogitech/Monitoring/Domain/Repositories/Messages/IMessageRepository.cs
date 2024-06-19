using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;

namespace Backend_farmlogitech.Monitoring.Domain.Repositories;

public interface IMessageRepository: IBaseRepository<Message>
{
    Task<IEnumerable<Message>> FindByCollaboratorId(int userId);
    Task<IEnumerable<Message>> FindByAllMessage();
    Task<Message> FindByIdx(int id);
    Task<Message> FindByIdAndUserId(int id, int userId);
}