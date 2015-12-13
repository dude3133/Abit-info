using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LogicLayer.Models;
using LogicLayer.Models.WebAPI;
using LogicLayer.Services;
using Microsoft.AspNet.Identity;

namespace AbitInfo.Controllers
{
    public class SpecialityController : ApiController
    {
        private ISpecialityService _specialityService;

        public SpecialityController(ISpecialityService specialityService)
        {
            _specialityService = specialityService;
        }
        [HttpGet]
        public async Task<SpecialityReturnModel> Get(int id)
        {
            return await _specialityService.GetSpecialityById(id);
        }
        [HttpGet]
        public Task<IEnumerable<TruncatedSpeciality>> Get(int id, int offset,
            int count)
        {
            return _specialityService.GetSpecialitiesList(new PaginationModel {Count = count, Offset = offset});
        }

        [HttpGet]
        public Task<IEnumerable<TruncatedSpeciality>> Get(string q, int count)
        {
            return _specialityService.FindSpeciality(q,0,count);
        }

        [HttpPost]
        public Task<bool> Post(ApplyBindingModel model)
        {
            var userId = User.Identity.GetUserId();
            return _specialityService.Apply(model.UserName, model.Id);
        }

        
    }
    public class ApplyBindingModel
    {
       public string UserName { get; set; }
       public string UserId { get; set; }
       public int Id { get; set; }
    }
}
