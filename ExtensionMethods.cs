using System;
using System.ComponentModel;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace DnD5e.Utilities
{
    public static class ExtensionMethods
    {
        #region Serialization Methods
        /// <summary>
        /// Serialize the character to an xml file specified.
        /// </summary>
        /// <param name="fileLoc">Absolute location of destination</param>
        public static void serialize<T>(this List<T> c, string fileLoc)
        {

            using (Stream FileStream = File.Create(fileLoc))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(FileStream, c);
            }
        }
        /// <summary>
        /// Deserialize a serializable object from a string defining a url.
        /// </summary>
        /// <returns></returns>
        public static List<T> deserialize<T>(this string fileLoc) where T : class
        {

            using (Stream FileStream = File.OpenRead(fileLoc))
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                try
                {
                    return (List<T>)deserializer.Deserialize(FileStream);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Unable to load the file due to an error." + "/r/n" + e.Message);
                    throw;
                }
            }

        }
        #endregion
        #region Enum Methods
        /// <summary>
        /// Returns the Description attribute of an enum value if that attribute exists. Otherwise, it returns the name.
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns>String</returns>
        public static string GetDescription(this Enum enumValue)
        {
            object[] attr = enumValue.GetType().GetField(enumValue.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attr.Length > 0
               ? ((DescriptionAttribute)attr[0]).Description
               : enumValue.ToString();
        }
        /// <summary>
        /// Returns an Enum with the description of the string. Otherwise it returns an Enum with the name of the string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stringVal"></param>
        /// <param name="defaultValue"></param>
        /// <returns>Enum</returns>
        public static T ParseEnum<T>(this string stringVal)
        {
            Type type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            System.Reflection.MemberInfo[] fields = type.GetFields();
            foreach (var field in fields)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0 && attributes[0].Description == stringVal)
                {
                    return (T)Enum.Parse(typeof(T), field.Name);
                }
            }
            return (T)Enum.Parse(typeof(T), stringVal);
        }
        /// <summary>
        /// Method to get the description or names of an enum.
        /// </summary>
        /// <param name="t">typeof(T)</param>
        /// <returns>Array of Descriptions or Names of the Enums</returns>
        public static string[] GetEnumNames(Type t)
        {
            Array EnumValues = Enum.GetValues(t);
            string[] items = new string[EnumValues.Length];
            int i = 0;
            foreach (Enum e in EnumValues)
            {
                items[i] = e.GetDescription();
                i++;
            }
            return items;
        }
        #endregion
    }
    public static class Money
    {
        //Copper = 1/100 gold
        //Silver = 1/10 gold
        //Electrum = 1/2 gold
        //Gold = 1 gold
        //Platinum = 10 gold
        public static decimal CopperToGold(int coin)
        {
            return (decimal)coin / 100;
        }
        public static decimal SilverToGold(int coin)
        {
            return (decimal)coin / 10;
        }
        public static decimal ElectrumToGold(int coin)
        {
            return (decimal)coin / 2;
        }
        public static decimal PlatinumToGold(int coin)
        {
            return (decimal)coin * 10;
        }
        /// <summary>
        /// Converts the value of an item (as gp) into the components.
        /// </summary>
        /// <returns></returns>
        public static string GoldToCoins(decimal gold)
        {
            decimal amountLeft = gold;
            string coppers = "";
            string silvers = "";
            string electrums = "";
            string golds = "";
            string platinums = "";
            if (amountLeft >= 10)
            {
                int platinumCoins = (int)Math.Floor(Math.Floor(amountLeft) / 10m);
                platinums = platinumCoins.ToString() + " pp ";
                amountLeft -= platinumCoins * 10m;

            }
            if (amountLeft >= 1)
            {
                int goldCoins = (int)Math.Floor(amountLeft);
                golds = goldCoins.ToString() + " gp ";
                amountLeft -= goldCoins;
            }
            if (amountLeft > 0)
            {
                int electrumCoins = (int)Math.Floor(amountLeft * 2m);
                electrums = electrumCoins.ToString() + " ep ";
                amountLeft -= electrumCoins / 2m;
            }
            if (amountLeft > 0)
            {
                int silverCoins = (int)Math.Floor(amountLeft * 10m);
                silvers = silverCoins.ToString() + " sp ";
                amountLeft -= silverCoins / 10m;
            }
            if (amountLeft > 0)
            {
                int copperCoins = (int)Math.Floor(amountLeft * 100m);
                coppers = copperCoins.ToString() + " cp ";
                amountLeft -= copperCoins / 100m;
            }
            if (amountLeft > 0)
            {
                MessageBox.Show("Remainder: " + amountLeft);
            }
            string values = platinums + golds + electrums + silvers + coppers;
            return values.Trim();
        }
    }
    public static class Dice
    {
        /// <summary>
        /// Parses a string in the format of "1d6" into the type of dice rolled.
        /// </summary>
        /// <returns>Integer representing the type of dice. if error, returns 0.</returns>
        public static int ParseDiceType(string roll)
        {
            string theRoll = string.Empty;
            char[] testers = { '+', '-' };
            if (roll.IndexOfAny(testers) > 1)
            {
                theRoll = roll.Substring(0, roll.IndexOfAny(testers));
            }
            else
            {
                theRoll = roll;
            }
            int toD = theRoll.ToLower().IndexOf('d');
            int len = theRoll.Length;
            if (toD < 1)
            {
                return 0;
            }
            int result;
            //debug            MessageBox.Show(theRoll.Substring(toD + 1, len - (toD + 1)));
            if (int.TryParse(theRoll.Substring(toD + 1, len - (toD + 1)), out result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        /// Parses a string in the format of "1d6" into the number of dice rolled.
        /// </summary>
        /// <returns>Integer representing the number of dice. if error, returns 0.</returns>
        public static int ParseDiceNumber(string roll)
        {
            string theRoll = string.Empty;
            char[] testers = { '+', '-' };
            if (roll.IndexOfAny(testers) > 1)
            {
                theRoll = roll.Substring(0, roll.IndexOfAny(testers));
            }
            else
            {
                theRoll = roll;
            }
            int toD = theRoll.ToLower().IndexOf('d');
            if (toD < 1)
            {
                return 0;
            }
            int result;
            if (int.TryParse(theRoll.Substring(0, toD), out result))
            {
                return result;
            }
            return 0;
        }
        /// <summary>
        /// Rolls a set of dice.
        /// </summary>
        /// <param name="d">The dice type rolled (e.g. 6 sided, 8 sided, etc).</param>
        /// <param name="numD">The number of dice rolled.</param>
        /// <returns>new int()</returns>
        public static int rollDice(int d, int numD = 1)
        {
            Random rndRoll = new Random();
            int Roll = 0;
            for (int i = 0; i < numD; i++)
            {
                Roll += rndRoll.Next(1, d);
            }
            return Roll;
        }
        public static int findBonus(string s)
        {
            if (s.IndexOf('+') > 0)
            {
                return int.Parse(s.Substring(s.IndexOf('+') + 1, s.Length - s.IndexOf('+') - 1));
            }
            else
            {
                return 0;
            }
        }
        public static string removeBonus(string s)
        {
            if (s.IndexOf('+') > 0)
            {
                return s.Substring(0, s.IndexOf('+'));
            }
            else
            {
                return s;
            }
        }
    }

}
