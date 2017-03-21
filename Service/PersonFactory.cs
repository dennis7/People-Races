using People_Races.DataAccess;
using People_Races.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace People_Races.Service
{
    public class PersonFactory
    {
        private static int _id = 0;

        private static List<Type> _races;

        private Random _rnd;
        public PersonFactory()
        {
            try
            {
                _races = Helper.GetPersonTypes();
                _rnd = new Random();
            }
            catch (Exception)
            {
                _races = new List<Type>();
            }
        }
        
        //3. Update the loop that creates people, so that it randomly creates different races of person.
        public Person CreatePerson()
        {
            try
            {
                if (_races != null)
                {                  
                    int r = _rnd.Next(_races.Count());
                    var race = _races[r];
                    Person instance = (Person)Activator.CreateInstance(race);
                    _id = _id + 1;
                    instance.Id = _id;
                    instance.Name = "Person #" + _id.ToString();
                    instance.Age = _rnd.Next(1, 99);
                    return instance;
                }
            }
            catch(Exception)
            {
               
            }
            return null;
        }


    }
}