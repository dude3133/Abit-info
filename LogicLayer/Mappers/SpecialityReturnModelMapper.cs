using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Models;
using LogicLayer.Models;

namespace LogicLayer.Mappers
{
    public interface ISpecialityReturnModelMapper
    {
        SpecialityReturnModel Map(Speciality s);
    }

    public class SpecialityReturnModelMapper : ISpecialityReturnModelMapper
    {
        private ITruncatedFacultyMapper _truncatedFacultyMapper;
        private ITruncatedApplicantMapper _truncatedApplicantMaper;
        private ITruncatedSubjectMapper _truncatedSubjectMapper;

        public SpecialityReturnModelMapper(ITruncatedFacultyMapper truncatedFacultyMapper,
            ITruncatedApplicantMapper truncatedApplicantMaper,
            ITruncatedSubjectMapper truncatedSubjectMapper)
        {
            _truncatedFacultyMapper = truncatedFacultyMapper;
            _truncatedApplicantMaper = truncatedApplicantMaper;
            _truncatedSubjectMapper = truncatedSubjectMapper;
        }

        public SpecialityReturnModel Map(Speciality s)
        {
           
            return new SpecialityReturnModel()
            {
                StateOrder = s.StateOrder,
                Name = s.Name,
                Applicants = s.Applicants.Select(a => _truncatedApplicantMaper.Map(a)).ToList(),
                Id = s.Id,
                Faculty = _truncatedFacultyMapper.Map(s.Faculty),
                Subjects = new List<TruncatedSubject>
                {
                    _truncatedSubjectMapper.Map(s.Subject),
                    _truncatedSubjectMapper.Map(s.Subject4),
                    _truncatedSubjectMapper.Map(s.Subject5)
                }
            };

        }
    }
}