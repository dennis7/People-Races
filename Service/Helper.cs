using People_Races.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace People_Races.Service
{
    public class Helper
    {
        public static List<Type> GetPersonTypes()
        {
            try
            {
                var items =
                        from assembly in AppDomain.CurrentDomain.GetAssemblies()
                        from type in assembly.GetTypes()
                        where type.IsSubclassOf(typeof(Person))
                        select type;
                return items.ToList();
            }
            catch (Exception)
            {
                return new List<Type>();
            }
        }
           
    }
}