using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Models;
using LogicLayer.Models;

namespace LogicLayer.Mappers
{
    public interface ITruncatedApplicantMapper
    {
        TruncatedApplicant Map(Applicant applicant);
    }
    public class TruncatedApplicantMapper : ITruncatedApplicantMapper
    {
        private ITruncatedSpecialityMapper _truncatedSpecialitiesMapper;
        private ITruncatedTestResultMapper _truncatedTestMapper;

        public TruncatedApplicantMapper(ITruncatedSpecialityMapper truncatedSpecialitiesMapper,
            ITruncatedTestResultMapper truncatedTestMapper)
        {
            _truncatedSpecialitiesMapper = truncatedSpecialitiesMapper;
            _truncatedTestMapper = truncatedTestMapper;
        }
        public TruncatedApplicant Map(Applicant applicant)
        {
            return new TruncatedApplicant
            {
                Banned = applicant.Banned,
                Birthdate = applicant.Birthdate,
                Id = applicant.Id,
                Image = applicant.Image,
                Name = applicant.Name,
                Sex = applicant.Sex,
                Surname = applicant.Surname,
                UserName = applicant.UserName,
                PhoneNumber = applicant.PhoneNumber,
                Specialities = applicant.Specialities.Select(s => _truncatedSpecialitiesMapper.Map(s)).ToList(),
                TestResults = applicant.TestResults.Select(t => _truncatedTestMapper.Map(t)).ToList(),
                Suspended = applicant.Suspended
            };
        }
    }
}
