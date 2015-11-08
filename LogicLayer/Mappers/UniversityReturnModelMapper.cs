using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Models;
using LogicLayer.Models;

namespace LogicLayer.Mappers
{
    public interface IUniversityReturnModelMapper
    {
        UniversityReturnModel Map(University university);
    }
    public class UniversityReturnModelMapper : IUniversityReturnModelMapper
    {
        private ITruncatedFacultyMapper _truncatedFacultyMapper;

        public UniversityReturnModelMapper(ITruncatedFacultyMapper truncatedFaculty)
        {
            _truncatedFacultyMapper = truncatedFaculty;
        }
        public UniversityReturnModel Map(University university)
        {
            return new UniversityReturnModel
            {
                Id = university.Id,
                Name = university.Name,
                Faculties = university.Faculties.Select(f => _truncatedFacultyMapper.Map(f)).ToList()
            };
        }
    }
}
