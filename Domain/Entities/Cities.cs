using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
   public class Cities
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int DistrictID { get; set; }
        public int StateID { get; set; }
        public string CityDescription { get; set; }
        public string Name { get; set; }
    }
}
