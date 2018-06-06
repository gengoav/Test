using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadacha.Models
{
    public class eqpm
    {
        private DbContext context;

        public int id { get; set; }

        public int equipmentType { get; set; }

        public string name { get; set; }
    }
}
