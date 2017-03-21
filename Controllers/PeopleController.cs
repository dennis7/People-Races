using People_Races.DataAccess;
using People_Races.Models;
using People_Races.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace People_Races.Controllers
{
    public class PeopleController : Controller
    {
        // 5. Build a webpage that shows a drop down list of races. 
        // When the user selects a race, the page should reload to show all the people, 
        // in a list or table, in that race whose age is even, ordered by age. 
        // Show their name, age and height.
        public ActionResult Index(string race)
        {
            IList<Person> people = new List<Person>();
            try
            {
                var races = Helper.GetPersonTypes();
                people = DataContext.GetInstance().People;

                ViewBag.SelectedRace = race;
                var raceList = races.Select(s => new SelectListItem { Text= s.Name, Value = s.Name }).ToList();
                if (!string.IsNullOrWhiteSpace(race))
                {
                    var selected = raceList.Where(x => x.Value.ToLower().Equals(race.ToLower())).FirstOrDefault();
                    selected.Selected = true;
                    people = people.Where(x => x.GetType().Name.ToLower().Equals(race.ToLower())).ToList();
                    people = people.Where(x => x.Age % 2 == 0).OrderBy(x=>x.Age).ToList();
                }
                ViewBag.Races = raceList;
                ViewBag.PeopleCount = people != null ? people.Count() : 0;
                return View(people);
            }
            catch (Exception)
            {
                ViewBag.Races = new List<SelectListItem>();
                ViewBag.PeopleCount = people != null ? people.Count() : 0;
                return View(people);
            }
           
        }

    }
}