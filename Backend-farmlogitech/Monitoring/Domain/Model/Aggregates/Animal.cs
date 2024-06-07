using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Animals;

namespace Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;

public class Animal
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Location { get; set; }
    public string HealthState { get; set; }
    public int ShedId { get; set; }
    
    protected Animal()
    {
        this.Name = string.Empty;
        this.Age = 0;
        this.Location = string.Empty;
        this.HealthState = string.Empty;
        this.ShedId = 0; 

    }
    
    public Animal(CreateAnimalCommand command)
    {
        this.Name = command.Name;
        this.Age = command.Age;
        this.Location = command.Location;
        this.HealthState = command.HealthState;
        this.ShedId = command.ShedId; 
    }

    public Animal(string name)
    {
        Name = name;
    }


    public void Update(UpdateAnimalCommand command)
    {
        this.Name = command.Name;
        this.Age = command.Age;
        this.Location = command.Location;
        this.HealthState = command.HealthState;
        this.ShedId = command.ShedId;
    }
    
    public void Delete(DeleteAnimalCommand command)
    {
        this.Name = string.Empty;
        this.Age = 0;
        this.Location = string.Empty;
        this.HealthState = string.Empty;
        this.ShedId = 0;
    }
    
    public void Read(ReadAnimalCommand command)
    {
        this.Name = command.Name;
        this.Age = command.Age;
        this.Location = command.Location;
        this.HealthState = command.HealthState;
        this.ShedId = command.ShedId;
    }
    
    
}