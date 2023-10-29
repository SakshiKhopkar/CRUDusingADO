using System.Data.SqlClient;

namespace CRUDusingADO.Models
{
    public class StudentDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public StudentDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConection"));
        }
        public List<Student> GetStudent()
        {
            List<Student> students = new List<Student>();
            string qry = "select * from student1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student student = new Student();
                    student.RollNo = Convert.ToInt32(dr["rollno"]);
                    student.Name = dr["name"].ToString();
                    student.Percentage = Convert.ToDouble(dr["percentage"]);
                    student.City = dr["city"].ToString();


                    students.Add(student);
                }
            }
            con.Close();
            return students;
        }
        public Student GetStudentByRollNo(int RollNo)
        {
            Student student = new Student();
            string qry = "select * from Student1 where rollno=@RollNo";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@RollNo", RollNo);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    student.RollNo = Convert.ToInt32(dr["rollno"]);
                    student.Name = dr["name"].ToString();
                    student.Percentage = Convert.ToDouble(dr["percentage"]);
                    student.City = dr["city"].ToString();


                }
            }
            con.Close();
            return student;
        }
        public int AddStudent(Student student)
        {
            int result = 0;
            string qry = "insert into student1 values(@name,@percentage,@city)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@percentage",student.Percentage);
            cmd.Parameters.AddWithValue("@city", student.City);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateStudent(Student student)
        {
            int result = 0;
            string qry = "update Student1 set name=@name,percentage=@percentage,city=@city where rollno=@rollno";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@percentage", student.Percentage);
            cmd.Parameters.AddWithValue("@city", student.City);
            cmd.Parameters.AddWithValue("@rollno", student.RollNo);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteStudent(int rollNo)
        {
            int result = 0;
            string qry = "delete from student1 where rollno=@rollno";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@rollno", rollNo);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
