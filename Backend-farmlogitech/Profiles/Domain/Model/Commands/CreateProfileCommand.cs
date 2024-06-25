namespace Backend_farmlogitech.Profiles.Domain.Model.Commands;

public record CreateProfileCommand(string Name, string Email, string Direction, string DocumentNumber, string DocumentType);