using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Models;

namespace LogicLayer.Models
{
    public class TruncatedTestResult
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public string ApplicantId { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
