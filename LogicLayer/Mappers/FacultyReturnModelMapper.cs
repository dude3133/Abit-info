using System.Linq;
using DbLayer.Models;
using LogicLayer.Models;

namespace LogicLayer.Mappers
{
    public interface IFacultyReturnModelMapper
    {
        FacultyReturnModel Map(Faculty faculty);
    }
    public class FacultyReturnModelMapper : IFacultyReturnModelMapper
    {
        private ITruncatedUniversityMapper _truncatedUniversityMapper;
        private ITruncatedSpecialityMapper _truncatedSpecialityMapper;

        public FacultyReturnModelMapper(ITruncatedSpecialityMapper truncatedSpecialityMapper,
            ITruncatedUniversityMapper truncatedUniversityMapper)
        {
            _truncatedUniversityMapper = truncatedUniversityMapper;
            _truncatedSpecialityMapper = truncatedSpecialityMapper;
        }

        public FacultyReturnModel Map(Faculty faculty)
        {
            return new FacultyReturnModel()
            {
                Id = faculty.Id,
                Name = faculty.Name,
                Specialities = faculty.Specialities.Select(s => _truncatedSpecialityMapper.Map(s)).ToList(),
                University = _truncatedUniversityMapper.Map(faculty.University),
                UniversityId = faculty.UniversityId
            };
        }
    }
}
