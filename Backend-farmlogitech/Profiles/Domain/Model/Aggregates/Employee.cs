using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend_farmlogitech.Profiles.Domain.Model.Commands;

namespace Backend_farmlogitech.Profiles.Domain.Model.Aggregates
{
    public class Employee
    {
        
        public string Name { get;  set; }

        
        public string Phone { get;  set; }

       
        public string Username { get;  set; }

       
        public string Password { get;  set; }

        
        public string Position { get;  set; }

       
        public int FarmId { get;  set; }

        
        public int Id { get; set; }
        
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
            this.FarmId = command.FarmId;
        }
    }
}