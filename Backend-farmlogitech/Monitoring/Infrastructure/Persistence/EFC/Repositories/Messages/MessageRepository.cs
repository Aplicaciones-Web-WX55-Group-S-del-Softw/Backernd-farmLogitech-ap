using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend_farmlogitech.Monitoring.Infrastructure.Persistence.EFC.Repositories.Messages
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Message>> FindAllByCollaboratorId(long collaboratorId)
        {
            return await Context.Set<Message>().Where(m => m.collaboratorId == collaboratorId).ToListAsync();
        }

        public async Task<IEnumerable<Message>> FindAllByCollaboratorIdAndFarmerId(long collaboratorId, long farmerId)
        {
            return await Context.Set<Message>().Where(m => m.collaboratorId == collaboratorId && m.farmerId == farmerId).ToListAsync();
        }

        public async Task<IEnumerable<Message>> FindAllMessageByCollaboratorIdAndTransmitterIdNot(long collaboratorId, long transmitterId)
        {
            return await Context.Set<Message>().Where(m => m.collaboratorId == collaboratorId && m.transmitterId != transmitterId).ToListAsync();
        }

        public async Task<IEnumerable<Message>> FindAllMessageByFarmerIdAndTransmitterIdNot(long farmerId, long transmitterId)
        {
            return await Context.Set<Message>().Where(m => m.farmerId == farmerId && m.transmitterId != transmitterId).ToListAsync();
        }
    }
}