using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Windows.Forms;

namespace zd2_OberuhtinaLena
{
    class PhoneBookLoader
    {
        public static void Load (PhoneBook phonebook, string fileName )
        {
            using (StreamReader rd = new StreamReader(fileName))
            {
                string line;
                while ((line = rd.ReadLine()) != null)
                {
                    string[] contactDetails = line.Split(' ');
                    if (contactDetails.Length >= 2)
                    {
                        string name = contactDetails[0].Trim();
                        string phone = contactDetails[1].Trim();
                        phonebook.Dobav(new Contact { Name = name, Phone = phone });
                    }
                }
            }
        }
        public static void Save (PhoneBook phoneBook, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var contact in phoneBook.Get())
                {
                    writer.WriteLine(contact.Name + " " + contact.Phone);
                }
            }
        }
    }
}
