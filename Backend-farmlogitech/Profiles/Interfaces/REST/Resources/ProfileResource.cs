namespace Backend_farmlogitech.Profiles.Interfaces.REST.Resources;

public record ProfileResource(int Id, string Name, string Email, string Direction, string DocumentNumber, string DocumentType, int UserId, int Role);