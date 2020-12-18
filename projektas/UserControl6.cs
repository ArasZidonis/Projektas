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
    public partial class UserControl6 : UserControl
    {
        public SqlConnection con = new SqlConnection(@"Server=DESKTOP-1VTPF6A\Praktikos;Database=Projektas;Integrated Security=True");
        public UserControl6()
        {
            con.Open();
            InitializeComponent();
            
        }
        private void Populate()
        {

            listView1.Refresh();
            listView1.Items.Clear();
            SqlCommand cm = new SqlCommand("SELECT * FROM [User] WHERE type = 'Mokytojas' ORDER BY id ", con);
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

        private void UserControl6_Load(object sender, EventArgs e)
        {
            Populate();
            this.subjectTableAdapter.Fill(this.projektasDataSet.Subject);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int fid;
            string id;
            bool parseOK = Int32.
                TryParse(comboBox1.SelectedValue.ToString(), out fid);
            id = listView1.SelectedItems[0].Text;
            SqlCommand cm = new SqlCommand("UPDATE [Subject] SET teacher_id = @teacher_id where id = @id", con);
            cm.Parameters.AddWithValue("@teacher_id", id);
            cm.Parameters.AddWithValue("@id", fid);
            try
            {

                cm.ExecuteNonQuery();
                Populate();
                MessageBox.Show("Prideta prie mokomo dalyko");


            }
            catch (Exception exc)
            {
                exc.GetBaseException();


            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
