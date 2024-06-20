namespace Backend_farmlogitech.Profiles.Domain.Model.Commands;

public record CreateEmployeeCommand(string Name, string Phone, string Username, string Password, string Position, int FarmId);