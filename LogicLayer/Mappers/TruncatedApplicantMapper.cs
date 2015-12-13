using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Models;
using LogicLayer.Models;

namespace LogicLayer.Mappers
{
    public interface IApplicantForSpecialityMapper
    {
        ApplicantForSpeciality Map(Applicant applicant, int subject1Id, int subject2Id, int subject3Id);
    }
    public class ApplicantForSpecialityMapper : IApplicantForSpecialityMapper
    {
        private ITruncatedSpecialityMapper _truncatedSpecialitiesMapper;
        private ITruncatedTestResultMapper _truncatedTestMapper;

        public ApplicantForSpecialityMapper(ITruncatedSpecialityMapper truncatedSpecialitiesMapper,
            ITruncatedTestResultMapper truncatedTestMapper)
        {
            _truncatedSpecialitiesMapper = truncatedSpecialitiesMapper;
            _truncatedTestMapper = truncatedTestMapper;
        }
        public ApplicantForSpeciality Map(Applicant applicant, int subject1Id, int subject2Id, int subject3Id)
        {
            return new ApplicantForSpeciality
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
                Suspended = applicant.Suspended,
                Result1 = applicant.TestResults.Where(t => t.SubjectId == subject1Id && t.ApplicantId ==applicant.Id).Select(t => t.Points).SingleOrDefault(),
                Result2 = applicant.TestResults.Where(t => t.SubjectId == subject2Id && t.ApplicantId ==applicant.Id).Select(t => t.Points).SingleOrDefault(),
                Result3 = applicant.TestResults.Where(t => t.SubjectId == subject3Id && t.ApplicantId ==applicant.Id).Select(t => t.Points).SingleOrDefault()
            };
        }
    }
}
