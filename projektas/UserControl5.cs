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
    public partial class UserControl5 : UserControl   
    {
        public SqlConnection con = new SqlConnection(@"Server=DESKTOP-1VTPF6A\Praktikos;Database=Projektas;Integrated Security=True");
        public UserControl5()
        {
            con.Open();
            InitializeComponent();
        }
        private void Populate()
        {

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

        private void UserControl5_Load(object sender, EventArgs e)
        {
            Populate();
            this.groupsTableAdapter.Fill(this.projektasDataSet.Groups);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int fid;
            string id;
            bool parseOK = Int32.
                TryParse(comboBox1.SelectedValue.ToString(), out fid);
            id = listView1.SelectedItems[0].Text;
            SqlCommand cm = new SqlCommand("UPDATE [User] SET group_id = @group_ID where id = @id", con);
            cm.Parameters.AddWithValue("@id", id);
            cm.Parameters.AddWithValue("@group_id", fid);
            try
            {

                cm.ExecuteNonQuery();
                Populate();
                MessageBox.Show("Prideta prie grupes");


            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);


            }

        }
    }
}
