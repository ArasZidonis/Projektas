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
    public partial class UserControl8 : UserControl
    {
        public SqlConnection con = new SqlConnection(@"Server=DESKTOP-1VTPF6A\Praktikos;Database=Projektas;Integrated Security=True");

        DataTable dt2;
        SqlDataAdapter da2;
        DataSet ds2;
        public UserControl8()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void BindData()
        {
            UsersRepository repository = new UsersRepository();
            string teacher_id = repository.GetUserId(Form1.LoggedInUser.GetUserName());


            con.Open();
            SqlCommand cmd = new SqlCommand("select name, group_id from subject where teacher_id=@teacher_id", con);
            da2 = new SqlDataAdapter(cmd);
            DataSet ds2 = new DataSet();
            cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
            da2.Fill(ds2);
            comboBox1.DataSource = ds2.Tables[0];
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "group_id";
            comboBox1.Enabled = true;
            this.comboBox1.SelectedIndex = -1;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserControl8_Load(object sender, EventArgs e)
        {
            BindData();
        }
        private void Populate(int id)
        {
            con.Open();
            listView1.Refresh();
            listView1.Items.Clear();
            SqlCommand cm = new SqlCommand("SELECT * FROM [User] where group_id = @group_id ORDER BY id ", con);
            cm.Parameters.AddWithValue("@group_id", id);
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
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int fid;
            bool parseOK = Int32.TryParse(comboBox1.SelectedValue.ToString(), out fid);
            Populate(fid);
        }
    }
}
