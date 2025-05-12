using Microsoft.Data.SqlClient;
using System.Data;

namespace SEEPractice.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public int Age { get; set; }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01\source\repos\SEEPractice\SEEPractice\App_Data\Student.mdf;Integrated Security=True");

        public List<Student> GetStudents(int id)
        {
            string query = "select * from student2";
            List<Student> students = new List<Student>();
            if (id != 0)
            {
                query = "select * from student2 where Id=" + id;
            }
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            con.Close();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                Student student = new Student();
                student.Id = (int)dr["Id"];
                student.RollNo = (int)dr["rollno"];
                student.Name = (string)dr["name"];
                student.Course = (string)dr["course"];
                student.Age = (int)dr["age"];

                students.Add(student);
            }
            return students;
        }
        public bool insert(Student obj)
        {
            bool result;
            SqlCommand cmd = new SqlCommand("insert into student2 values(@rollno, @name, @course, @age)",con);
            cmd.Parameters.AddWithValue("name",obj.Name);
            cmd.Parameters.AddWithValue("age",obj.Age);
            cmd.Parameters.AddWithValue("course",obj.Course);
            cmd.Parameters.AddWithValue("rollno",obj.RollNo);
            con.Open();
            if (cmd.ExecuteNonQuery() >= 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            con.Close();

            return result;
        }
        public bool update(Student obj)
        {
            bool result;
            SqlCommand cmd = new SqlCommand("update student2 set rollno=@rollno, name=@name, course=@course, age=@age where Id=@id", con);
            cmd.Parameters.AddWithValue("name", obj.Name);
            cmd.Parameters.AddWithValue("age", obj.Age);
            cmd.Parameters.AddWithValue("course", obj.Course);
            cmd.Parameters.AddWithValue("rollno", obj.RollNo);
            cmd.Parameters.AddWithValue("id", obj.Id);
            con.Open();
            if (cmd.ExecuteNonQuery() >= 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            con.Close();

            return result;
        }
        public bool delete(int id)
        {
            bool result;
            SqlCommand cmd = new SqlCommand("delete from student2 where Id=@id", con);
            cmd.Parameters.AddWithValue("id",id);
            con.Open();
            if (cmd.ExecuteNonQuery() >= 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            con.Close();

            return result;
        }
    }
}
