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

        public SpecialityReturnModelMapper(ITruncatedFacultyMapper truncatedFacultyMapper)
        {
            _truncatedFacultyMapper = truncatedFacultyMapper;
        }
        public SpecialityReturnModel Map(Speciality s)
        {
            return new SpecialityReturnModel()
            {
                StateOrder = s.StateOrder,
                Id = s.Id,
                Faculty = _truncatedFacultyMapper.Map(s.Faculty)
            };
        }
    }
}
