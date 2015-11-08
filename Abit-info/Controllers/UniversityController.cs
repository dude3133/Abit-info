using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using LogicLayer.Models;
using LogicLayer.Models.WebAPI;
using LogicLayer.Services;

namespace AbitInfo.Controllers
{
    public class UniversityController : ApiController
    {
        private IUniversityService _universityService;

        public UniversityController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        [HttpGet]
        public Task<IEnumerable<TruncatedUniversity>> Get(int offset,
            int count)
        {
            return _universityService.GetUniversitiesList(new PaginationModel { Count = count, Offset = offset});
        }

        public async Task<UniversityReturnModel> Get(int id)
        {
            return await _universityService.GetUniversityById(id);
        }

        [Route("api/university/getCount")]
        public async Task<int> Get()
        {
            return await _universityService.GetUniversitiesCount();
        }

        [Route("api/university/search")]
        public async Task<IEnumerable<TruncatedUniversity>> Get(string query,
            int offset, int count)
        {
            return await _universityService.FindUniversity(query, offset, count);
        }
    }
}
