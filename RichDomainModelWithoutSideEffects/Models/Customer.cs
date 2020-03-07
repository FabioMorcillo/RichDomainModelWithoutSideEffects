using System;

namespace RichDomainModelWithoutSideEffects.Models
{
    public class Customer : Entity
    {
        public string Name { get; private set; }

        public string Language { get; private set; }

        public Customer(string name, string language)
        {
            Id = Guid.NewGuid();

            Name = name;
            Language = language;
        }
    }
}
