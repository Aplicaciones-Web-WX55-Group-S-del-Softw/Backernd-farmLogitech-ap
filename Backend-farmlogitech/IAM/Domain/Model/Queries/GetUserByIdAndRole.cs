using Backend_farmlogitech.IAM.Domain.Model.ValueObjects;
namespace Backend_farmlogitech.IAM.Domain.Model.Queries;

public record GetUserByIdAndRole(int Id, Role role);