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

        public async Task<IEnumerable<Message>> FindByCollaboratorId(int collaboratorId)
        {
            return await Context.Set<Message>().Where(m => m.CollaboratorId == collaboratorId).ToListAsync();
        }

        public async Task<IEnumerable<Message>> FindByAllMessage()
        {
            return await Context.Set<Message>().ToListAsync();
        }

        public async Task<Message> FindByIdx(int id)
        {
            return await Context.Set<Message>().FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}