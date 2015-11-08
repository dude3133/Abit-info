using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.WebAPI
{
    public class PaginationModel
    {
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}
