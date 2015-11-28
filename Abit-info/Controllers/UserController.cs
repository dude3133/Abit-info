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
    public class UserController : ApiController
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IEnumerable<TruncatedUser> GetAll()
        {
            return  _userService.GetAllUsers();
        }
    }
}
