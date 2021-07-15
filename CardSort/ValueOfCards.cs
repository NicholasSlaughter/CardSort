using System;
using System.Collections.Generic;
using System.Text;

namespace CardSort
{
    //TODO: Add unit testing for Value Of Cards, add check for when their are multiple cards that have the same value including face cards
    public static class ValueOfCards
    {
        public static string Two { get { return "2"; } }
        public static string Three { get { return "3"; } }
        public static string Four { get { return "4"; } }
        public static string Five { get { return "5"; } }
        public static string Six { get { return "6"; } }
        public static string Seven { get { return "7"; } }
        public static string Eight { get { return "8"; } }
        public static string Nine { get { return "9"; } }
        public static string Ten { get { return "10"; } }
        public static string Jack { get { return "j"; } }
        public static string Queen { get { return "q"; } }
        public static string King { get { return "k"; } }
        public static string Ace { get { return "a"; } }
        public static bool Contains(string stringToFind)
        {
            foreach(var prop in typeof(ValueOfCards).GetProperties())
            {
                if(stringToFind == prop.GetMethod.Invoke(typeof(ValueOfCards),null).ToString())
                {
                    return true;
                }
            }
            return false;
        }

        internal static string GetCardName(string valueToFindPropName)
        {
            foreach (var prop in typeof(ValueOfCards).GetProperties())
            {
                //If the value matches the get method of a prop then return the name of that property
                if (valueToFindPropName == prop.GetMethod.Invoke(typeof(ValueOfCards), null).ToString())
                {
                    return prop.Name;
                }
            }

            return string.Empty;
        }

        internal static string GetCardValueByPropName(string propName)
        {
            foreach (var prop in typeof(ValueOfCards).GetProperties())
            {
                //If the value matches the get method of a prop then return the name of that property
                if (propName == prop.Name)
                {
                    return prop.GetMethod.Invoke(typeof(ValueOfCards), null).ToString();
                }
            }

            return string.Empty;
        }
    }
}
