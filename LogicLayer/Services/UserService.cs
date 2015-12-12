using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Configurations;
using DbLayer.Models;
using LogicLayer.Mappers;
using LogicLayer.Models;

namespace LogicLayer.Services
{
    public interface IUserService
    {
        IEnumerable<TruncatedUser> GetAllUsers();
        bool Apply(string userId, int specialityId);
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


        public bool Apply(string userId, int specialityId)
        {
            using (var context = _abitInfoDbContextProvider.Context)
            {
                return context.Apply(new Applicant { Id = userId }, new Speciality { Id = specialityId });
            }
        }
    }
}
