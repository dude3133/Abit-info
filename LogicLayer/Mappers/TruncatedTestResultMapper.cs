using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Models;
using LogicLayer.Models;

namespace LogicLayer.Mappers
{
    public interface ITruncatedTestResultMapper
    {
        TruncatedTestResult Map(TestResult f);
    }
    public class TruncatedTestResultMapper : ITruncatedTestResultMapper
    {
        public TruncatedTestResult Map(TestResult f)
        {
            return new TruncatedTestResult()
            {
                Id = f.Id,
                Subject = f.Subject,
                ApplicantId = f.ApplicantId,
                Points = f.Points,
                SubjectId = f.SubjectId
            };
        }
    }
}
