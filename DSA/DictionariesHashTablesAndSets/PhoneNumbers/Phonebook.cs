namespace PhoneNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Phonebook
    {
        private IDictionary<string, Contact> contactsByName;
        private IDictionary<string, List<string>> contactsByTown;

        public Phonebook()
        {
            this.contactsByName = new Dictionary<string, Contact>();
            this.contactsByTown = new Dictionary<string, List<string>>();
        }

        public void Add(string phoneNumbers)
        {
            var contacts = phoneNumbers.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            var newContact = new Contact();

            var name = contacts[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (name.Length)
            {
                case 1: 
                    newContact.NickName = name[0];
                    break;
                case 2:
                    newContact.FirstName = name[0];
                    newContact.NickName = name[1];
                    break;
                case 3:
                    newContact.FirstName = name[0];
                    newContact.MiddleName = name[1];
                    newContact.LastName = name[2];
                    break;
                default:
                    throw new ArgumentException();
            }

            newContact.Town = contacts[1];
            newContact.PhoneNumber = contacts[2];

            var fullName = string.Join(" ", name);
            this.contactsByName.Add(fullName, newContact);
            if (!this.contactsByTown.ContainsKey(newContact.Town))
            {
                this.contactsByTown[newContact.Town] = new List<string>();
            }

            this.contactsByTown[newContact.Town].Add(fullName);
        }

        public ICollection<Contact> Find(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return this.contactsByName.Values;
            }

            var result = this.contactsByName
                    .Where(pair => pair.Key.Contains(name))
                    .Select(p => p.Value)
                    .ToList();

            return result;
        }

        public ICollection<Contact> Find(string name, string town)
        {
            var allContactsInTown = this.contactsByTown
                                .Where(pair => pair.Key.Contains(town))
                                .SelectMany(p => p.Value.Where(n => n.Contains(name)).ToList())
                                .ToList();
            ICollection<Contact> result = new List<Contact>();
            foreach (var contact in allContactsInTown)
            {
                var matchedCoonatct = this.contactsByName[contact];
                result.Add(matchedCoonatct);
            }

            return result;
        }
    }
}
