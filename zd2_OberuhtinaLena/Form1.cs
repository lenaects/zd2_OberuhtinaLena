using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace zd2_OberuhtinaLena
{
    public partial class Form1 :Form
    {
        PhoneBook phoneboook;
        public Form1 ()
        {
            InitializeComponent();
            phoneboook = new PhoneBook();
            Loadfile();
        }
        private void Loadfile()
        {
            try
            {
                if (File.Exists("cont.txt"))
                {
                    PhoneBookLoader.Load(phoneboook, "cont.txt");
                    Obnov();


                } 
                else MessageBox.Show("Файл не найден");
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
        private void Obnov ()
        { 
            listBox1.Items.Clear();
                    foreach (var contact in phoneboook.Get())
                    {
                        listBox1.Items.Add(contact.Name + " " + contact.Phone);
                    }

        }
        private void Form1_Load (object sender, EventArgs e)
        {
            
        }

        private void button1_Click (object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string phone = textBox2.Text;
            if(name==""||phone.Length!=13) MessageBox.Show("поля пусты или телефон введен не коректно");                          
            else
            {
                Contact contact = new Contact { Name = name, Phone = phone };
                phoneboook.Dobav(contact);
                MessageBox.Show("Контакт добавлен и сохранен в файл");
                PhoneBookLoader.Save(phoneboook, "cont.txt");

                Obnov();

            }
        }

        private void button2_Click (object sender, EventArgs e)
        {
            string name = textBox3.Text;
            if (name == "")
                MessageBox.Show("поле пустое");
            else
            {
                List<Contact> poisc = phoneboook.Poisc(name);                
                foreach (var contact in poisc)
                    MessageBox.Show(contact.Name + " " + contact.Phone,"Найдены:");
            }
        }

        private void button3_Click (object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
                MessageBox.Show("Ничего не выбрано");
            else
            {
                string contacts = listBox1.SelectedItem.ToString();
                string[] contmas = contacts.Split(' ');
                string name = contmas[0].Trim();
                MessageBox.Show("Контакт удален и изменения сохраненны в файле"); 
                phoneboook.Remove(name);
                PhoneBookLoader.Save(phoneboook, "cont.txt");                              
                Obnov();
                

            }
        }

        private void button4_Click (object sender, EventArgs e)
        {
            Close();
        }
    }
}
