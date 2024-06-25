using Backend_farmlogitech.IAM.Domain.Model.ValueObjects;

namespace Backend_farmlogitech.IAM.Domain.Model.Commands;

public record SignUpCommand(string Username, string Password, Role Role);