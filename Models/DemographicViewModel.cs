using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace People_Races.Models
{
    public class DemographicViewModel
    {
        public DemographicViewModel()
        {
            age = new AgeViewModel();
            races = new Dictionary<string, int>();
        }
        public int people { get; set; }        
        public AgeViewModel age { get; set; }
        public Dictionary<string,int> races { get; set; }
    }

    public class AgeViewModel
    {
        public int min { get; set; }
        public int max { get; set; }
        public double average { get; set; }
    }

}