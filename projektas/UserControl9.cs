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
    public partial class UserControl9 : UserControl
    {
        public SqlConnection con = new SqlConnection(@"Server=DESKTOP-1VTPF6A\Praktikos;Database=Projektas;Integrated Security=True");

        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;


        public UserControl9()
        {
            InitializeComponent();
        }

        private void UserControl9_Load(object sender, EventArgs e)
        {
            con.Open();

         
           

            listView1.Refresh();
            listView1.Items.Clear();
            SqlCommand cm = new SqlCommand("select Subject.name, Grade.grade from [Grade] " +
                "INNER JOIN Subject ON grade.subject_id=subject.id WHERE grade.student_id = @student_id", con);
            UsersRepository repository = new UsersRepository();
            string student_id = repository.GetUserId(Form1.LoggedInUser.GetUserName());

            cm.Parameters.AddWithValue("@student_id", student_id);
            try
            {
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem it = new ListViewItem(dr["name"].ToString());
                    it.SubItems.Add(dr["grade"].ToString());
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
    }
}
