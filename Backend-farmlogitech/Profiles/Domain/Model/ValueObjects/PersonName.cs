namespace Backend_farmlogitech.Profiles.Domain.Model.ValueObjects
{
    public class PersonName
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public PersonName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be null or blank", nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be null or blank", nameof(lastName));

            FirstName = firstName;
            LastName = lastName;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}