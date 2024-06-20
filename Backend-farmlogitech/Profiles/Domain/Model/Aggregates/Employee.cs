using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend_farmlogitech.Profiles.Domain.Model.Commands;

namespace Backend_farmlogitech.Profiles.Domain.Model.Aggregates
{
    public class Employee
    {
        
        public string Name { get; private set; }

        
        public string Phone { get; private set; }

       
        public string Username { get; private set; }

       
        public string Password { get; private set; }

        
        public string Position { get; private set; }

       
        public int FarmId { get; private set; }

        
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