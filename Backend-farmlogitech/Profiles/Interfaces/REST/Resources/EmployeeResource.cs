namespace Backend_farmlogitech.Profiles.Interfaces.REST.Resources;

public record EmployeeResource(int Id, string Name, string Phone, string Username, string Password, string Position, int FarmId);