using System;
using System.Collections.Generic;
using System.Text;

namespace CardSort
{
    //Static class that holds face card numerical values
    public static class FaceCardValue
    {
        public static int Jack { get { return 11; } }
        public static int Queen { get { return 12; } }
        public static int King { get { return 13; } }
        public static int Ace { get { return 14; } }

        //Check to see if the string passed in matches any Card Value
        public static bool Contains(string stringToFind)
        {
            foreach (var prop in typeof(FaceCardValue).GetProperties())
            {
                if (stringToFind == prop.GetMethod.Invoke(typeof(ValueOfCards), null).ToString())
                {
                    return true;
                }
            }
            return false;
        }

        //Returns the name of a card given its value
        public static string GetCardName(string valueToFindPropName)
        {
            foreach (var prop in typeof(FaceCardValue).GetProperties())
            {
                //If the value matches the get method of a prop then return the name of that property
                if (valueToFindPropName == prop.GetMethod.Invoke(typeof(ValueOfCards), null).ToString())
                {
                    return prop.Name;
                }
            }

            return string.Empty;
        }

        //Returns the value of a card given its property name
        public static int GetCardValueByPropName(string propName)
        {
            foreach (var prop in typeof(FaceCardValue).GetProperties())
            {
                //If the value matches the get method of a prop then return the name of that property
                if (propName == prop.Name)
                {
                    return Int32.Parse(prop.GetMethod.Invoke(typeof(ValueOfCards), null).ToString());
                }
            }

            return -1;
        }
    }
}
