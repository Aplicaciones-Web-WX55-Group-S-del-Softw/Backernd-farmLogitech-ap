using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Messages;

namespace Backend_farmlogitech.Monitoring.Domain.Model.Aggregates
{
    public class Message
    {
        public long id { get; private set; }
        public long collaboratorId { get; set; }
        public string description { get; set; }
        public long farmerId { get; set; }
        public long transmitterId { get; set; }

        protected Message()
        {
            this.id = 0;
            this.collaboratorId = 0;
            this.description = string.Empty;
            this.farmerId = 0;
            this.transmitterId = 0;
        }

        public Message(CreateMessageCommand command)
        {
            this.id = command.id;
            this.collaboratorId = command.collaboratorId;
            this.description = command.description;
            this.farmerId = command.farmerId;
            this.transmitterId = command.transmitterId;
        }

        public void Update(UpdateMessageCommand command)
        {
            this.collaboratorId = command.collaboratorId;
            this.description = command.description;
            this.farmerId = command.farmerId;
            this.transmitterId = command.transmitterId;
        }
    }
}