using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Attendees { get; set; }
        public string ContactEmail { get; set; }

        public int Id { get; }

        private static int _nextId = 1;

        public Event()
        {
            Id = _nextId;
            _nextId++;
        }

        public Event(string name, string description, string location, int attendees, string contactEmail) : this()
        {
            Name = name;
            Description = description;
            Location = location;
            Attendees = attendees;
            ContactEmail = contactEmail;

        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
