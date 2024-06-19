using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Animals;

namespace Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;

public class Animal
{
    public int Id { get; set; }
    private string _name;
    private int _age;
    private string _location;
    private string _healthState;
    private int _shedId;

    public int FarmId { get; set; }
    public int UserId { get; set; }


    

    public string Name
    {
        get { return _name; }
        set
        {
            if (value != "pig" && value != "cow" && value != "chicken")
            {
                throw new Exception("Animal must be either 'pig', 'cow', or 'chicken'.");
            }
            _name = value;
        }
    }

    public int Age
    {
        get { return _age; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new Exception("Age must be between 0 and 100.");
            }
            _age = value;
        }
    }

    public string Location
    {
        get { return _location; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Location cannot be null or empty.");
            }
            _location = value;
        }
    }

    public string HealthState
    {
        get { return _healthState; }
        set
        {
            if (value != "sick" && value != "recovering" && value != "healthy")
            {
                throw new Exception("HealthState must be either 'sick', 'recovering', or 'healthy'.");
            }
            _healthState = value;
        }
    }

    public int ShedId
    {
        get { return _shedId; }
        set
        {
            if (value < 1 || value > 3)
            {
                throw new Exception("ShedId must be between 1 and 3.");
            }
            _shedId = value;
        }
    }
    
    
    
    protected Animal()
    {
    }
    
    public Animal(CreateAnimalCommand command)
    {
        this.Name = command.Name;
        this.Age = command.Age;
        this.Location = command.Location;
        this.HealthState = command.HealthState;
        this.ShedId = command.ShedId; 
        this.FarmId = command.FarmId;
        this.UserId = command.UserId;
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
        this.FarmId = command.FarmId;
        this.UserId = command.UserId;
    }
    
    public void Delete(DeleteAnimalCommand command)
    {
        
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