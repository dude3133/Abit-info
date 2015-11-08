using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LogicLayer.Models;
using LogicLayer.Services;

namespace AbitInfo.Controllers
{
    public class FacultyController : ApiController
    {
        private IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }
        [HttpGet]
        public async Task<FacultyReturnModel> Get(int id)
        {
            return await _facultyService.GetFacultyById(id);
        }
    }
}
