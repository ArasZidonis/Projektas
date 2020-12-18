using LoginApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projektas
{
    public partial class Form1 : Form
    {
        public static User LoggedInUser;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsersRepository repository = new UsersRepository();
            try
            {
                Form1.LoggedInUser = repository.Login(Username.Text, Password.Text);
                this.Hide();
                Form2 fc = new Form2();
                fc.Show();



            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void Username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
