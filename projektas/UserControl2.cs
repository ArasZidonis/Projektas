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

namespace projektas
{
    public partial class UserControl2 : UserControl
    {
        public SqlConnection con = new SqlConnection(@"Server=DESKTOP-1VTPF6A\Praktikos;Database=Projektas;Integrated Security=True");
        public UserControl2()
        {
            con.Open();
            InitializeComponent();
            

        }

        private void Populate() {
            button1.Enabled = false;
            listView1.Refresh();
            listView1.Items.Clear();
            SqlCommand cm = new SqlCommand("SELECT * FROM [User] ORDER BY id ", con);
            try
            {
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem it = new ListViewItem(dr["id"].ToString());
                    it.SubItems.Add(dr["name"].ToString());
                    it.SubItems.Add(dr["surname"].ToString());
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                button1.Enabled = true;
            }
            else {
                button1.Enabled = false;
            }
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            Populate();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cm = new SqlCommand("DELETE from [User] where id = @id", con);
            cm.Parameters.AddWithValue("@id", listView1.SelectedItems[0].Text);
            try
            {
               
               cm.ExecuteNonQuery();
                //listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
                Populate();
                listView1.Refresh();


            }
            catch (Exception exc) {
                throw new Exception(exc.Message);
              //  Populate();
              //  listView1.Refresh();
                //  MessageBox.Show("Ivyko klaida....");

            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Populate();
            
        }
    }
    
}
