using MVCWebAPI_CRUD.Models;
using MVCWebAPI_CRUD.ProjectConstents;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MVCWebAPI_CRUD.Controllers
{
    public class StudentController : ApiController
    {
        [System.Web.Http.HttpGet]
        public Student StudentDetails(int id)
        {

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(StoredProcedures.StudentDetails, connection);
            command.Parameters.AddWithValue("ID", id);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            sqlDataReader.Read();

            Student student = new Student();

            student.ID = Convert.ToInt32(sqlDataReader["ID"]);
            student.Name = sqlDataReader["Name"].ToString();
            student.Malayalam = sqlDataReader["Malayalam"].ToString();
            student.English = sqlDataReader["English"].ToString();
            student.Hindi = sqlDataReader["Hindi"].ToString();
            student.Email = sqlDataReader["Email"].ToString();
            student.Total = Convert.ToInt32(sqlDataReader["Total"]);
            student.Average = Convert.ToDecimal(sqlDataReader["Average"]);
            student.Password = sqlDataReader["Password"].ToString();
            student.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);

            return student;
        }
        [System.Web.Http.HttpPost]
        public int StudentSave(Student student)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(StoredProcedures.StudentSave, connection);
            command.Parameters.AddWithValue("Name", student.Name);
            command.Parameters.AddWithValue("Password", RandomString(5, false) );
            command.Parameters.AddWithValue("Malayalam", student.Malayalam);
            command.Parameters.AddWithValue("English", student.English);
            command.Parameters.AddWithValue("Hindi", student.Hindi);
            command.Parameters.AddWithValue("Email", student.Email);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            return 4;
        }

        public string RandomString(int size, bool lowerCase = false)
        {
            Random _random = new Random();
            var builder = new StringBuilder(size);

            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}
