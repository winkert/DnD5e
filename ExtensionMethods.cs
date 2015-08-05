﻿using System;
using System.ComponentModel;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace DnD5e
{
    public static class ExtensionMethods
    {
        #region Serialization Methods
        /// <summary>
        /// Serialize the character to an xml file specified.
        /// </summary>
        /// <param name="fileLoc">Absolute location of destination</param>
        public static void serialize(this List<Character> c, string fileLoc)
        {

            using (Stream FileStream = File.Create(fileLoc))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(FileStream, c);
            }
        }
        /// <summary>
        /// Deserialize a character from a string defining a url.
        /// </summary>
        /// <returns></returns>
        public static List<Character> deserialize(this string fileLoc)
        {

            using (Stream FileStream = File.OpenRead(fileLoc))
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                try
                {
                    return (List<Character>)deserializer.Deserialize(FileStream);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Unable to load the file due to an error.");
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
        #endregion
        #region Money Methods
        //Copper = 1/100 gold
        //Silver = 1/10 gold
        //Electrum = 1/2 gold
        //Gold = 1 gold
        //Platinum = 10 gold
        public static decimal CopperToGold(this int coin)
        {
            return (decimal)coin/100;
        }
        public static decimal SilverToGold(this int coin)
        {
            return (decimal)coin/10;
        }
        public static decimal ElectrumToGold(this int coin)
        {
            return (decimal)coin/2;
        }
        public static decimal PlatinumToGold(this int coin)
        {
            return (decimal)coin * 10;
        }
        /// <summary>
        /// Converts the value of an item (as gp) into the components.
        /// </summary>
        /// <returns></returns>
        public static string GoldToCoins(this decimal gold)
        {
            decimal amountLeft = gold;
            string coppers = "";
            string silvers = "";
            string electrums = "";
            string golds = "";
            string platinums = "";
            if(amountLeft >= 10)
            {
                int platinumCoins = (int)Math.Floor(Math.Floor(amountLeft) / 10m);
                platinums = platinumCoins.ToString() + " pp ";
                amountLeft -= platinumCoins * 10m;

            }
            if(amountLeft >= 1)
            {
                int goldCoins = (int)Math.Floor(amountLeft);
                golds = goldCoins.ToString() + " gp ";
                amountLeft -= goldCoins;
            }
            if(amountLeft > 0)
            {
                int electrumCoins = (int)Math.Floor(amountLeft * 2m);
                electrums = electrumCoins.ToString() + " ep ";
                amountLeft -= electrumCoins / 2m;
            }
            if(amountLeft > 0)
            {
                int silverCoins = (int)Math.Floor(amountLeft * 10m);
                silvers = silverCoins.ToString() + " sp ";
                amountLeft -= silverCoins / 10m;
            }
            if(amountLeft > 0)
            {
                int copperCoins = (int)Math.Floor(amountLeft * 100m);
                coppers = copperCoins.ToString() + " cp ";
                amountLeft -= copperCoins / 100m;
            }
            if(amountLeft > 0)
            {
                MessageBox.Show("Remainder: " + amountLeft);
            }
            string values = platinums + golds + electrums + silvers + coppers;
            return values.Trim();
        }
        #endregion
    }
}
