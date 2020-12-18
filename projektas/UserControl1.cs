using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginApp;

namespace projektas
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                string username = textBox1.Text + "." + textBox2.Text;
                string password = textBox2.Text;
                UsersRepository repository = new UsersRepository();
                User user = new User(textBox1.Text, textBox2.Text, username, password, comboBox1.Text);
                repository.Register(user);
                MessageBox.Show("sekmingai sukurta");
            }
            else {
                MessageBox.Show("Reikia uzpildyti visus laukus");
            }
        }
    }
}
