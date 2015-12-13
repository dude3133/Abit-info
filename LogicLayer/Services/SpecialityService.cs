using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DbLayer.Configurations;
using LogicLayer.Mappers;
using LogicLayer.Models;
using LogicLayer.Models.WebAPI;

namespace LogicLayer.Services
{
    public interface ISpecialityService
    {
        Task<IEnumerable<TruncatedSpeciality>> GetSpecialitiesList(PaginationModel page);
        Task<SpecialityReturnModel> GetSpecialityById(int id);
        Task<int> GetSpecialitiesCount();
        Task<IEnumerable<TruncatedSpeciality>> FindSpeciality(string query, int offset, int count);
    }

    public class SpecialityService : ISpecialityService
    {
        private IAbitInfoDbContextProvider _abitInfoDbContextProvider;
        private ITruncatedSpecialityMapper _truncatedSpecialityMapper;
        private ISpecialityReturnModelMapper _specialityReturnModelMapper;

        public SpecialityService(IAbitInfoDbContextProvider abitInfoDbContextProvider,
            ITruncatedSpecialityMapper truncatedSpecialityMapper,
            ISpecialityReturnModelMapper specialityReturnModelMapper)
        {
            _abitInfoDbContextProvider = abitInfoDbContextProvider;
            _truncatedSpecialityMapper = truncatedSpecialityMapper;
            _specialityReturnModelMapper = specialityReturnModelMapper;
        }

        public Task<IEnumerable<TruncatedSpeciality>> GetSpecialitiesList(PaginationModel page)
        {
            throw new NotImplementedException();
        }

        public async Task<SpecialityReturnModel> GetSpecialityById(int id)
        {
            using (var context = _abitInfoDbContextProvider.Context)
            {
                var spec = await context.Specialities.Where(u => u.Id == id).Select(u => new { u, u.Faculty, u.Applicants, u.Subject, u.Subject4, u.Subject5 }).FirstOrDefaultAsync();
                //spec.u.Applicants = spec.Applicants;
                var applicants = await context.Applicants.Where(a => a.Specialities.Any(s => s.Id == id)).Select(ap => new {ap, ap.TestResults}).ToListAsync();

                spec.u.Applicants = applicants.Select(r => r.ap).ToList();
                return _specialityReturnModelMapper.Map(spec.u);
            }
        }

        public async Task<int> GetSpecialitiesCount()
        {
            using (var context = _abitInfoDbContextProvider.Context)
            {
                return await context.Specialities.CountAsync();
            }
        }

        public async Task<IEnumerable<TruncatedSpeciality>> FindSpeciality(string query, int offset, int count)
        {
            using (var context = _abitInfoDbContextProvider.Context)
            {
                var univ = await context.Specialities.OrderBy(u => u.Id)
                            .Where(u => u.Name.Contains(query))
                            .Skip(offset)
                            .Take(count).ToListAsync();
                return univ.Select(u => _truncatedSpecialityMapper.Map(u));
            }
        }
    }
}
