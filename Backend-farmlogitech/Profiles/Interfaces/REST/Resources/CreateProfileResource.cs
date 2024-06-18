namespace Backend_farmlogitech.Profiles.Interfaces.REST.Resources;

public record CreateProfileResource(string Name, string Email, string Direction, string DocumentNumber, string DocumentType, int UserId);