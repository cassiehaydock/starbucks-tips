using System;
using System.Collections.Generic;
using System.Text;

//Cassandra Haydock - 2022
namespace StarbTips
{
    //class workers to hold all the information about an employee relevent to the tip distribution
    public class Workers : IComparable<Workers>
    {
        //All the properties for a worker
        private string name;
        private double hours;
        private double tipsRec;
        private bool distributed;

        //create an empty worker object with just a name
        public Workers(string title)
        {
            name = title;
            hours = 0.0;
            tipsRec = 0.0;
            distributed = false;
        }

        //getters and setter for all properties of a worker
        public string Name
        {
            get => name;
            set => name = value;
        }

        public double Hours
        {
            get => hours;
            set => hours = value;
        }

        public double Tips
        {
            get => tipsRec;
            set => tipsRec = value;
        }

        public bool Distrubuted
        {
            get => distributed;
            set => distributed = value;
        }

        //if needing to compare, compare based on workers name
        public int CompareTo(Workers obj)
        {
            if (obj == null) return 1;
            //A more elegant way to implement the next five lines is:
            return this.name.CompareTo(obj.name);
        }

    }
}
