using DbLayer.Models;
using LogicLayer.Models;

namespace LogicLayer.Mappers
{
    public interface ITruncatedFacultyMapper
    {
        TruncatedFaculty Map(Faculty f);
    }
    public class TruncatedFacultyMapper : ITruncatedFacultyMapper
    {
        public TruncatedFaculty Map(Faculty f)
        {
            return new TruncatedFaculty()
            {
                Id = f.Id,
                Name = f.Name
            };
        }
    }
}
