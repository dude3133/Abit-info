using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Configurations;
using LogicLayer.Mappers;
using LogicLayer.Models;

namespace LogicLayer.Services
{
    public interface IUserService
    {
        IEnumerable<TruncatedUser> GetAllUsers();
    }
    public class UserService : IUserService
    {
        private IAbitInfoDbContextProvider _abitInfoDbContextProvider;
        private ITruncatedUserMapper _truncatedUserMapper;

        public UserService(IAbitInfoDbContextProvider abitInfoDbContextProvider,
            //IUserReturnModelMapper facultyReturnModelMapper,
            ITruncatedUserMapper truncatedUserMapper)
        {
            _abitInfoDbContextProvider = abitInfoDbContextProvider;
            //_facultyReturnModelMapper = facultyReturnModelMapper;
            _truncatedUserMapper = truncatedUserMapper;
        }

        public IEnumerable<TruncatedUser> GetAllUsers()
        {
            using (var context = _abitInfoDbContextProvider.Context)
            {
                return (context.Applicants.ToList().Select(u => _truncatedUserMapper.Map(u)));
            }
        }
    }
}
