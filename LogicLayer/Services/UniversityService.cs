using System;
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

        public async Task<UniversityReturnModel> GetUniversityById(int id)
        {
            using (var context = _abitInfoDbContextProvider.Context)
            {
                var univ = await context.Universities.Where(u => u.Id == id).Select(u => new {u,u.Faculties}).FirstOrDefaultAsync();
                return _specialityReturnModelMapper.Map(univ.u);
            }
        }

        public async Task<IEnumerable<TruncatedUniversity>> GetUniversitiesList(PaginationModel page)
        {
            using (var context = _abitInfoDbContextProvider.Context)
            {
                var univ = await context.Universities.OrderBy(u => u.Id).Skip(page.Offset).Take(page.Count).ToListAsync();
                return univ.Select(u => _truncatedSpecialityMapper.Map(u)).ToList();
            }
        }


        public async Task<int> GetUniversitiesCount()
        {
            using (var context = _abitInfoDbContextProvider.Context)
            {
                return await context.Universities.CountAsync();
            }
        }


        public async Task<IEnumerable<TruncatedUniversity>> FindUniversity(string query, int offset, int count)
        {
            using (var context = _abitInfoDbContextProvider.Context)
            {
                var univ = await context.Universities.OrderBy(u => u.Id)
                            .Where(u => u.Name.Contains(query))
                            .Skip(offset)
                            .Take(count).ToListAsync();
                return univ.Select(u => _truncatedSpecialityMapper.Map(u));
            }
        }

        public Task<IEnumerable<TruncatedSpeciality>> GetSpecialitiesList(PaginationModel page)
        {
            throw new NotImplementedException();
        }

        public async Task<SpecialityReturnModel> GetSpecialityById(int id)
        {
            using (var context = _abitInfoDbContextProvider.Context)
            {
                var spec = await context.Specialities.Where(u => u.Id == id).Select(u => new { u, u.Faculty }).FirstOrDefaultAsync();
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
