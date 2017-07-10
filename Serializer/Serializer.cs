using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            Person person = new Person(txtName.Text, txtAddress.Text, txtPhone.Text);
            person.Serialize();
            MessageBox.Show("Person saved!");
        }

        public void RefreshPerson(Person person)
        {
            txtName.Text = person.Name;
            txtAddress.Text = person.Address;
            txtPhone.Text = person.Phone;
        }
    }
}
