using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Messages;

namespace Backend_farmlogitech.Monitoring.Domain.Model.Aggregates
{
    public class Message
    {
        public int id { get; private set; }
        public int collaboratorId { get; set; }
        public string description { get; set; }
        public int farmerId { get; set; }
        public int transmitterId { get; set; }

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
            this.collaboratorId = command.collaboratorId;
            this.description = command.description;
            this.farmerId = command.farmerId;
            this.transmitterId = command.transmitterId;
        }
    }
}