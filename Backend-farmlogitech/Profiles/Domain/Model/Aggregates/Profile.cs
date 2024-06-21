using Backend_farmlogitech.Profiles.Domain.Model.Commands;

namespace Backend_farmlogitech.Profiles.Domain.Model.Aggregates;

public partial class Profile
{
    public int id { get; set; } 
    public string name { get;  set; } 
    public string email { get;  set; }
    public string direction { get;  set; }
    public string documentNumber { get;  set; }
    public string documentType { get;  set; }
    public int userId { get;  set; }
    
    public int role { get; set; }

    public Profile()
    {
    }

    public Profile(int id, string name, string email, string direction, string documentNumber, string documentType, int userId)
    {
        this.id = id;
        this.name = name;
        this.email = email;
        this.direction = direction;
        this.documentNumber = documentNumber;
        this.documentType = documentType;
        this.userId = userId;
    }

    public Profile(CreateProfileCommand command)
    {
        this.name = command.Name;
        this.email = command.Email;
        this.direction = command.Direction;
        this.documentNumber = command.DocumentNumber;
        this.documentType = command.DocumentType;
    }
} 