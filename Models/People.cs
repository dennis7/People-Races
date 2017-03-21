using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace People_Races.Models
{
    //1. Update the class structure, to implement the following races: Angles, Saxons, Jutes and Asians
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public abstract double Height { get; }
        public override string ToString()
        {
            return "My name is '" + Name + "' and I am " + Age + " years old.";
        }
    }

    //2. Implement a way of getting the height for a person based on the following logic: 
    // For Angles and Saxons, Height = (1.5 + (Age * 0.45)) 
    // For Jutes, Height = ((age * 1.6) / 2) 
    // For Asians, Height = (1.7 + ((age + 2) * 0.23))
    public class Angle : Person
    {
        public override double Height
        {
            get
            {
                return Math.Round((1.5 + (Age * 0.45)), 2);
            }
        }
    }
    public class Saxon : Person
    {
        public override double Height
        {
            get
            {
                return Math.Round((1.5 + (Age * 0.45)), 2);
            }
        }
    }
    public class Jute : Person
    {
        public override double Height
        {
            get
            {
                return Math.Round(((Age * 1.6) / 2), 2);
            }
        }
    }
    public class Asian : Person
    {
        public override double Height
        {
            get
            {
                return Math.Round((1.7 + ((Age + 2) * 0.23)), 2);
            }
        }
    }
}