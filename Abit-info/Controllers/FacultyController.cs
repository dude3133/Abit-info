using System.Collections.Generic;
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
        [HttpGet]
        public Task<IEnumerable<TruncatedFaculty>> Get(int id,int offset,
            int count)
        {
            return _facultyService.GeFacultiesList(id, count, offset);
        }
    }
}
