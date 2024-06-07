using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Sheds;

namespace Backend_farmlogitech.Monitoring.Domain.Services.Sheds;

public interface IShedCommandService
{
    Task<Shed> Handle(CreateShedCommand command);

}