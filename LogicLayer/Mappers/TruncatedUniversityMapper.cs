﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Models;
using LogicLayer.Models;

namespace LogicLayer.Mappers
{
    public interface ITruncatedSubjectMapper
    {
        TruncatedSubject Map(Subject university);
    }
    public class TruncatedSubjectMapper : ITruncatedSubjectMapper
    {
        public TruncatedSubject Map(Subject university)
        {
            return new TruncatedSubject()
            {
                Id = university.Id,
                Name = university.Name
            };
        }
    }
}
