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
    public partial class UserControl7 : UserControl
    {
        public SqlConnection con = new SqlConnection(@"Server=DESKTOP-1VTPF6A\Praktikos;Database=Projektas;Integrated Security=True");
        public UserControl7()
        {
            con.Open();
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserControl7_Load(object sender, EventArgs e)
        {
            Populate();
            this.groupsTableAdapter.Fill(this.projektasDataSet.Groups);
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
            int fid;
            string id;
            bool parseOK = Int32.
                TryParse(comboBox1.SelectedValue.ToString(), out fid);
            id = listView1.SelectedItems[0].Text;
            SqlCommand cm = new SqlCommand("UPDATE [subject] SET group_id = @group_id where id = @id", con);
            cm.Parameters.AddWithValue("@id", id);
            cm.Parameters.AddWithValue("@group_id", fid);
            try
            {

                cm.ExecuteNonQuery();
                Populate();
                MessageBox.Show("Prideta prie mokomo dalyko");


            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);


            }
        }
    }
}
