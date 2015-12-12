using System;
using System.Collections.Generic;
using System.Linq;
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

        public SpecialityReturnModelMapper(ITruncatedFacultyMapper truncatedFacultyMapper,
            ITruncatedApplicantMapper truncatedApplicantMaper)
        {
            _truncatedFacultyMapper = truncatedFacultyMapper;
            _truncatedApplicantMaper = truncatedApplicantMaper;
        }
        public SpecialityReturnModel Map(Speciality s)
        {
            return new SpecialityReturnModel()
            {
                StateOrder = s.StateOrder,
                Name = s.Name,
                Applicants =  s.Applicants.Select(a => _truncatedApplicantMaper.Map(a)).ToList(),
                Id = s.Id,
                Faculty = _truncatedFacultyMapper.Map(s.Faculty)
            };
        }
    }
}
