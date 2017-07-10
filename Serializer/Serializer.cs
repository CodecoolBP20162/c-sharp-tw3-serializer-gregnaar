using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serializer
{
    public partial class SerializerForm : Form
    {
        public SerializerForm()
        {
            InitializeComponent();
        }

        private void SerializerForm_Load(object sender, EventArgs e)
        {
            Person person = Person.Deserialize();
            RefreshPerson(person);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                Person person = new Person(txtName.Text, txtAddress.Text, txtPhone.Text);
                person.Serialize();
                MessageBox.Show("Person saved!");
            }
            
        }

        private bool ValidateData()
        {
            if (!Regex.IsMatch(txtName.Text, @"^([A-Za-z]*\s*)+$"))
            {
                MessageBox.Show("The name is invalid (only alphabetical characters are allowed)");
                return false;
            }
                

            if (!Regex.IsMatch(txtAddress.Text, @"^\d{4}.[a-zA-Z]+$"))
            {
                MessageBox.Show("The address is not valid.");
                return false;
            }
                

            if (!Regex.IsMatch(txtPhone.Text, @"^0\d\s\d{2}\s\d{3}\s\d{4}$"))
            {
                MessageBox.Show("The phone number is not a valid phone number");
                return false;
            }

            else
            {
                return true;
            }
                
            
        }

        public void RefreshPerson(Person person)
        {
            txtName.Text = person.Name;
            txtAddress.Text = person.Address;
            txtPhone.Text = person.Phone;
        }
    }
}
