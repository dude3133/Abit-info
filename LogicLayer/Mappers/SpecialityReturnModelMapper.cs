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
        private IApplicantForSpecialityMapper _applicantForSpecialityMaper;
        private ITruncatedSubjectMapper _truncatedSubjectMapper;

        public SpecialityReturnModelMapper(ITruncatedFacultyMapper truncatedFacultyMapper,
            IApplicantForSpecialityMapper applicantForSpecialityMaper,
            ITruncatedSubjectMapper truncatedSubjectMapper)
        {
            _truncatedFacultyMapper = truncatedFacultyMapper;
            _applicantForSpecialityMaper = applicantForSpecialityMaper;
            _truncatedSubjectMapper = truncatedSubjectMapper;
        }

        public SpecialityReturnModel Map(Speciality s)
        {
           
            return new SpecialityReturnModel()
            {
                StateOrder = s.StateOrder,
                LicencedVolume = s.LicencedVolume,
                Type = (SpecialityType)s.Type,
                Name = s.Name,
                Applicants = s.Applicants.Select(a => _applicantForSpecialityMaper.Map(a, s.Subject.Id, s.Subject4.Id, s.Subject5.Id))
                    .OrderByDescending(x => x.Result1+x.Result2+x.Result3).ToList(),
                Id = s.Id,
                Faculty = _truncatedFacultyMapper.Map(s.Faculty),
                Subject1 = s.Subject.Name,
                Subject2 = s.Subject4.Name,
                Subject3 = s.Subject5.Name
            };

        }
    }
}
