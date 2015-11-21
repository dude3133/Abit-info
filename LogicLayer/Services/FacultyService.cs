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

        Task<IEnumerable<TruncatedFaculty>> GeFacultiesList(int id, int count, int offset);
    }
    public class FacultyService : IFacultyService
    {
        private IAbitInfoDbContextProvider _abitInfoDbContextProvider;
        private IFacultyReturnModelMapper _facultyReturnModelMapper;
        private ITruncatedFacultyMapper _truncatedFacultyMapper;

        public FacultyService(IAbitInfoDbContextProvider abitInfoDbContextProvider,
            IFacultyReturnModelMapper facultyReturnModelMapper,
            ITruncatedFacultyMapper truncatedFacultyMapper)
        {
            _abitInfoDbContextProvider = abitInfoDbContextProvider;
            _facultyReturnModelMapper = facultyReturnModelMapper;
            _truncatedFacultyMapper = truncatedFacultyMapper;
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


        public async Task<IEnumerable<TruncatedFaculty>> GeFacultiesList(int id, int count, int offset)
        {
            using (var context = _abitInfoDbContextProvider.Context)
            {
                var faculties = await context.Faculties.Where(f => f.UniversityId == id)
                    .OrderBy(u => u.Id).Skip(offset).Take(count).ToListAsync();
                return faculties.Select(f => _truncatedFacultyMapper.Map(f)).ToList();
            }
        }
    }
}
