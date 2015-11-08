using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
