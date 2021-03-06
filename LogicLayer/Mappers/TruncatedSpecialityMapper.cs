﻿using DbLayer.Models;
using LogicLayer.Models;

namespace LogicLayer.Mappers
{
    public interface ITruncatedSpecialityMapper
    {
        TruncatedSpeciality Map(Speciality speciality);
    }
    public class TruncatedSpecialityMapper : ITruncatedSpecialityMapper
    {
        public TruncatedSpeciality Map(Speciality speciality)
        {
            return new TruncatedSpeciality()
            {
                Id = speciality.Id,
                Name = speciality.Name,
                LicencedVolume = speciality.LicencedVolume,
                StateOrder = speciality.StateOrder,
                Type = (SpecialityType) speciality.Type
            };
        }
    }
}
