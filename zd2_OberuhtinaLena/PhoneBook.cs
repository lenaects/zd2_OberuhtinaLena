using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd2_OberuhtinaLena
{
    class PhoneBook
    {
        private List<Contact> contact;

        public PhoneBook ()
        {
            contact = new List<Contact>();
        }

        public void Dobav (Contact contacts)
        {
            contact.Add(contacts);
        }

        public void Remove (string name)
        {
            contact.RemoveAll(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<Contact> Get ()
        {
            return contact;
        }

        public List<Contact> Poisc (string name)
        {
            return contact.FindAll(c => c.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
