using Backend_farmlogitech.IAM.Domain.Model.Commands;
using Backend_farmlogitech.IAM.Interfaces.REST.Resources;

namespace Backend_farmlogitech.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}