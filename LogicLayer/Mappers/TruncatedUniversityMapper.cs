using DbLayer.Models;
using LogicLayer.Models;

namespace LogicLayer.Mappers
{
    public interface ITruncatedUniversityMapper
    {
        TruncatedUniversity Map(University university);
    }
    public class TruncatedUniversityMapper : ITruncatedUniversityMapper
    {
        public TruncatedUniversity Map(University university)
        {
            return new TruncatedUniversity()
            {
                Id = university.Id,
                Name = university.Name
            };
        }
    }
}
