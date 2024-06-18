using Backend_farmlogitech.IAM.Domain.Model.ValueObjects;

namespace Backend_farmlogitech.IAM.Interfaces.REST.Resources;

public record SignUpResource(string Username, string Password, Role Role);