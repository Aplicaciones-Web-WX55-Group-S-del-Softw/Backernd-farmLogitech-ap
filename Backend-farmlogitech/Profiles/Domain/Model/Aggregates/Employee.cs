using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend_farmlogitech.Profiles.Domain.Model.Commands;

namespace Backend_farmlogitech.Profiles.Domain.Model.Aggregates
{
    public class Employee
{
    private string _name;
    private string _phone;
    private string _username;
    private string _password;
    private string _position;
    private int _farmId;
    private int _id;

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Name cannot be null or empty.");
            }
            _name = value;
        }
    }

    public string Phone
    {
        get { return _phone; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Phone cannot be null or empty.");
            }
            _phone = value;
        }
    }

    public string Username
    {
        get { return _username; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Username cannot be null or empty.");
            }
            _username = value;
        }
    }

    public string Password
    {
        get { return _password; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Password cannot be null or empty.");
            }
            _password = value;
        }
    }

    public string Position
    {
        get { return _position; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Position cant be null.");
            }
            _position = value;
        }
    }

    public int FarmId
    {
        get { return _farmId; }
        set
        {
            if (value < 1)
            {
                throw new Exception("FarmId must be greater than 0.");
            }
            _farmId = value;
        }
    }

    public int Id
    {
        get { return _id; }
        set
        {
            if (value < 1)
            {
                throw new Exception("Id must be greater than 0.");
            }
            _id = value;
        }
    }

        
        public Employee()
        {
        }

        public Employee(string name, string phone, string username, string password, string position, int farmId)
        {
            Name = name;
            Phone = phone;
            Username = username;
            Password = password;
            Position = position;
            FarmId = farmId;
        }
        
        public Employee(CreateEmployeeCommand command)
        {
            this.Name = command.Name;
            this.Phone = command.Phone;
            this.Username = command.Username;
            this.Password = command.Password;
            this.Position = command.Position;
        }
    }
}