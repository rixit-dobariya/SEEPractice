using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\01\\source\\repos\\SEEPractice\\SEEPractice\\App_Data\\Student.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("insert into student2 values(@rollno, @name, @course, @age)",con);
            cmd.Parameters.AddWithValue("name",txtName.Text);
            cmd.Parameters.AddWithValue("rollno", txtRollNo.Text);
            cmd.Parameters.AddWithValue("course", txtCourse.Text);
            cmd.Parameters.AddWithValue("age", txtAge.Text);
            con.Open();
            if (cmd.ExecuteNonQuery() >= 1)
            {
                txtName.Text = "";
                txtRollNo.Text = "";
                txtCourse.Text = "";
                txtAge.Text = "";
                Label1.Text = "Student added successfully!";
            }
            con.Close();
        }
    }
}