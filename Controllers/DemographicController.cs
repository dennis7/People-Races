using People_Races.DataAccess;
using People_Races.Models;
using People_Races.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace People_Races.Controllers
{
    public class DemographicController : ApiController
    {
        // GET: api/Demographic
        //6. Build a basic API endpoint that returns a JSON document with the following pieces of information, 
        //based on the list of people:
        //a.Number of people
        //b.Average, Min and Max Age
        //c.Count of the number of people in each race
        public DemographicViewModel Get()
        {
            DemographicViewModel vm = new DemographicViewModel();
            try
            {
                var people = DataContext.GetInstance().People;
                vm.people = people != null ? people.Count : 0;
                vm.age.min = people != null ? people.Min(x => x.Age) : 0;
                vm.age.max = people != null ? people.Max(x => x.Age) : 0;
                vm.age.average = people != null ? Math.Round(people.Average(x => x.Age),2) : 0;
                var races = Helper.GetPersonTypes();
                if(races != null && races.Count > 0 && people != null && people.Count > 0)
                {
                  vm.races = races.ToDictionary(x => x.Name, x => people.Count(p => p.GetType().Name == x.Name));
                }
                return vm;
            }
            catch
            {
                return vm;
            }

        }

    
    }
}
