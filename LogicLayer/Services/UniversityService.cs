﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Configurations;
using LogicLayer.Mappers;
using LogicLayer.Models;
using LogicLayer.Models.WebAPI;

namespace LogicLayer.Services
{
    public interface IUniversityService
    {
        Task<IEnumerable<TruncatedUniversity>> GetUniversitiesList(PaginationModel page);
        Task<UniversityReturnModel> GetUniversityById(int id);
        Task<int> GetUniversitiesCount();
    }

    public class UniversityService : IUniversityService
    {
        private IAbitInfoDbContextProvider _abitInfoDbContextProvider;
        private ITruncatedUniversityMapper _truncatedUniversityMapper;
        private IUniversityReturnModelMapper _universityReturnModelMapper;

        public UniversityService(IAbitInfoDbContextProvider abitInfoDbContextProvider,
            ITruncatedUniversityMapper truncatedUniversityMapper,
            IUniversityReturnModelMapper universityReturnModel)
        {
            _abitInfoDbContextProvider = abitInfoDbContextProvider;
            _truncatedUniversityMapper = truncatedUniversityMapper;
            _universityReturnModelMapper = universityReturnModel;
        }

        public async Task<UniversityReturnModel> GetUniversityById(int id)
        {
            using (var context = _abitInfoDbContextProvider.Context)
            {
                var univ = await context.Universities.Where(u => u.Id == id).Select(u => new {u,u.Faculties}).FirstOrDefaultAsync();
                return _universityReturnModelMapper.Map(univ.u);
            }
        }

        public async Task<IEnumerable<TruncatedUniversity>> GetUniversitiesList(PaginationModel page)
        {
            using (var context = _abitInfoDbContextProvider.Context)
            {
                var univ = await context.Universities.OrderBy(u => u.Id).Skip(page.Offset).Take(page.Count).ToListAsync();
                return univ.Select(u => _truncatedUniversityMapper.Map(u)).ToList();
            }
        }


        public async Task<int> GetUniversitiesCount()
        {
            using (var context = _abitInfoDbContextProvider.Context)
            {
                return await context.Universities.CountAsync();
            }
        }
    }
}
