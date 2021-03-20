using System;
using System.Collections.Generic;
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
        public string StudentDetails()
        {
            return "Test data";
        }
        [HttpGet]
        public string StudentSave()
        {
            return "Test data";
        }
    }
}
