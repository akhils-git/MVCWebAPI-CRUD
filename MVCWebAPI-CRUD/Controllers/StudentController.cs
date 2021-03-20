using MVCWebAPI_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace MVCWebAPI_CRUD.Controllers
{
    public class StudentController : ApiController
    {
        [HttpGet]
        public Student StudentDetails(int id)
        {

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("StudentDetails", connection);
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
            student.Average =Convert.ToDecimal( sqlDataReader["Average"]);
            student.Password = sqlDataReader["Password"].ToString();
            student.CreatedDate =Convert.ToDateTime( sqlDataReader["CreatedDate"]);

            return student;
        }
        [HttpGet]
        public string StudentSave()
        {
            return "Test data";
        }
    }
}
