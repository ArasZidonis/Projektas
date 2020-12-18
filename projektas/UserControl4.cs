using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LoginApp;

namespace projektas
{
    public partial class UserControl4 : UserControl
    {
        public SqlConnection con = new SqlConnection(@"Server=DESKTOP-1VTPF6A\Praktikos;Database=Projektas;Integrated Security=True");
        public UserControl4()
        {
            con.Open();
            InitializeComponent();
            
        }

        private void UserControl4_Load(object sender, EventArgs e)
        {
            Populate();
        }
        private void Populate()
        {
            
            listView1.Refresh();
            listView1.Items.Clear();
            SqlCommand cm = new SqlCommand("SELECT * FROM [Subject] ORDER BY id ", con);
            try
            {
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem it = new ListViewItem(dr["id"].ToString());
                    it.SubItems.Add(dr["name"].ToString());
                    listView1.Items.Add(it);
                }
                dr.Close();
                dr.Dispose();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                string subject = textBox1.Text;
                UsersRepository repository = new UsersRepository();
                repository.InsertSubject(subject);
                Populate();
                MessageBox.Show("sekmingai pridetas naujas destomas dalykas");
            }
            else
            {
                MessageBox.Show("Neivestas naujo destomo dalyko pavadinimas");
            }
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cm = new SqlCommand("DELETE from [Subject] where id = @id", con);
            cm.Parameters.AddWithValue("@id", listView1.SelectedItems[0].Text);
            try
            {

                cm.ExecuteNonQuery();
                Populate();
                listView1.Refresh();


            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}
