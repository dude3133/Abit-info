using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Models;
using LogicLayer.Models;

namespace LogicLayer.Mappers
{
    public interface ITruncatedUserMapper
    {
        TruncatedUser Map(Applicant applicant);
    }
    public class TruncatedUserMapper : ITruncatedUserMapper
    {
        public TruncatedUser Map(Applicant applicant)
        {
            return new TruncatedUser
            {
                Banned = applicant.Banned,
                Email = applicant.Email,
                Birthdate = applicant.Birthdate,
                Id = applicant.Id,
                Image = applicant.Image,
                Name = applicant.Name,
                Sex = applicant.Sex,
                Surname = applicant.Surname,
                UserName = applicant.UserName
            };
        }
    }
}
