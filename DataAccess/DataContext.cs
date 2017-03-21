using People_Races.Models;
using People_Races.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace People_Races.DataAccess
{
    public class DataContext
    {
        private static DataContext _dataContext;
        public IList<Person> People { get; set; }

        private DataContext()
        {

        }

        public static DataContext GetInstance()
        {
            if(_dataContext == null){
                _dataContext = new DataContext();
            }
            return _dataContext;
        }



    }
}