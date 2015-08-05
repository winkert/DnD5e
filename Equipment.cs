using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DnD5e
{
    #region Classes
    [Serializable]
    public class Equipment
    {
        public Equipment()
        {

        }
        public Equipment(string name, decimal value)
        {
            Name = name;
            Value = value;
        }

        public string Name;
        public string Effects;
        /// <summary>
        /// The Value of the item in gold pieces.
        /// </summary>
        public decimal Value;
        public override string ToString()
        {
            return Name + " : " + Value.GoldToCoins();
        }

    }

    [Serializable]
    public class Weapon : Equipment
    {
        public Weapon()
        {

        }
        public Weapon(string name, WeaponClasses wclass, int dice, int ndice, int b, decimal value)
        {
            Name = name;
            wClass = wclass;
            wNumDice = ndice;
            wDice = dice;
            wBonus = b;
            Value = value;
        }
        WeaponClasses wClass;
        int wNumDice;
        int wDice;
        int wBonus;
        public override string ToString()
        {
            return Name + " (" + Damage() + ")" + " : " + Value.GoldToCoins();
        }
        public string Damage()
        {
            string bonus = string.Empty;
            if(wBonus > 0)
            {
                bonus = " +" + wBonus;
            }
            else if(wBonus < 0)
            {
                bonus = " -" + wBonus;
            }
            return wNumDice + "D" + wDice + bonus;
        }

    }

    [Serializable]
    public class Armor : Equipment
    {
        public Armor()
        {

        }
        public Armor(string name, ArmorTypes atype, int aclass, decimal value)
        {
            Name = name;
            aType = atype;
            AC = aclass;
            Value = value;
        }
        ArmorTypes aType;
        int AC;
        public override string ToString()
        {
            return Name + " (" + AC + ")" + " : " + Value.GoldToCoins();
        }
    }
    #endregion
    #region Components
    public enum ArmorTypes
    {
        None = 0,
        [Description("Light Armor")]
        LightArmor,
        [Description("Medium Armor")]
        MediumArmor,
        [Description("Heavy Armor")]
        HeavyArmor,
        Shield
    }
    public enum WeaponClasses
    {
        None = 0,
        [Description("Simple Melee Weapon")]
        SimpleWeapon,
        [Description("Martial Melee Weapon")]
        MartialWeapon,
        [Description("Simple Range Weapon")]
        SimpleRange,
        [Description("Martial Range Weapon")]
        MartialRange
    }
    public enum WeaponType
    {
        None = 0
    }
    public enum ItemTypes
    {
        None = 0,
        Weapon,
        Armor,
        Potion, 
        Gear,
        Trinket,
        Valuable
    }
    #endregion
}
