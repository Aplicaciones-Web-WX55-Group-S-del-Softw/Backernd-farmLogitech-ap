using System.Text.Json.Serialization;
using Backend_farmlogitech.IAM.Domain.Model.ValueObjects;

namespace Backend_farmlogitech.IAM.Domain.Model.Aggregates;

public class User(string username, string passwordHash, Role role)
{
    public User() : this(string.Empty, string.Empty, Role.FARMER) { }

    public int Id { get;  }

    public string Username { get; private set; } = username;

    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;

    public Role Role { get; private set; } = role;

    public User UpdateUsername(string username)
    {
        Username = username;
        return this;
    }

    public User UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }

    public User UpdateRole(Role role)
    {
        Role = role;
        return this;
    }
}