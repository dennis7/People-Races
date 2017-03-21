using People_Races.DataAccess;
using People_Races.Models;
using People_Races.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace People_Races.App_Start
{
    public class PeopleConfig
    {
    
        public static void InitPeople(int count)
        {
            var personFactory = new PersonFactory();
            List<Person> people = new List<Person>();
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                var newPerson = personFactory.CreatePerson();
                if (newPerson != null)
                {
                    people.Add(newPerson);
                }
            }
            DataContext.GetInstance().People = people;
        }

        //4. Write a loop to add 1 year to each person’s age
        public static void UpdatePeopleAge()
        {
            if(DataContext.GetInstance() != null && DataContext.GetInstance().People != null)
            DataContext.GetInstance().People.Select(c => { c.Age = c.Age + 1; return c; }).ToList();
        }
    }
}