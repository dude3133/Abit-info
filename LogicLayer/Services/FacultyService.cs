using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Configurations;
using LogicLayer.Mappers;
using LogicLayer.Models;

namespace LogicLayer.Services
{
    public interface IFacultyService
    {
        Task<FacultyReturnModel> GetFacultyById(int id);
    }
    public class FacultyService : IFacultyService
    {
        private IAbitInfoDbContextProvider _abitInfoDbContextProvider;
        private IFacultyReturnModelMapper _facultyReturnModelMapper;

        public FacultyService(IAbitInfoDbContextProvider abitInfoDbContextProvider,
            IFacultyReturnModelMapper facultyReturnModelMapper)
        {
            _abitInfoDbContextProvider = abitInfoDbContextProvider;
            _facultyReturnModelMapper = facultyReturnModelMapper;
        }
        public async Task<FacultyReturnModel> GetFacultyById(int id)
        {
            using (var context =_abitInfoDbContextProvider.Context)
            {
                return _facultyReturnModelMapper.Map((await context.Faculties
                    .Where(f => f.Id == id)
                    .Select(f => new{ f, f.University, f.Specialities})
                    .FirstAsync())
                    .f);
            }
        }
    }
}
