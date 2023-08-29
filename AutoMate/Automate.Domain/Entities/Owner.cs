using Automate.Domain.DomainEvents;
using Automate.Domain.Entities.Base;

namespace Automate.Domain.Entities
{
    public sealed class Owner : AggregateRoot
    {
        public Owner(int id) : base(id)
        {
        }

        private Owner(int id, string firstName, string lastName, string phone, string email, string address, string city, string state, string zipCode, DateTime dateOfBirth)
        : base(id)
        {
            FirstName=firstName;
            LastName=lastName;
            Phone=phone;
            Email=email;
            Address=address;
            City=city;
            State=state;
            ZipCode=zipCode;
            DateOfBirth=dateOfBirth;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public List<Car> Cars { get; set; }

        public static Owner Create(
         int id,
         string firstName,
         string lastName,
         string phone,
         string email,
         string address,
         string city,
         string state,
         string zipCode,
         DateTime dateOfBirth)
        {
            var owner = new Owner(
                id,
                firstName,
                lastName,
                phone,
                email,
                address,
                city,
                state,
                zipCode,
                dateOfBirth);

            owner.RaiseDomainEvent(new OwnerCreatedDomainEvent(id));
            return owner;
        }

    }
}
