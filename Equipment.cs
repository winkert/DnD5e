using System;
using System.ComponentModel;
using DnD5e.Utilities;

namespace DnD5e
{
    #region Classes
    /// <summary>
    /// General Equipment item
    /// </summary>
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
        public decimal Weight;
        public override string ToString()
        {
            return Name + " : " + Money.GoldToCoins(Value);
        }

    }
    /// <summary>
    /// Weapon. A type of Equipment
    /// </summary>
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

        public WeaponClasses WeaponType {get {return wClass;} set {wClass = value;}}

        public override string ToString()
        {
            return Name + " (" + Damage() + ")" + " : " + Money.GoldToCoins(Value);
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
        /// <summary>
        /// Roll damage for this weapon.
        /// </summary>
        /// <returns>Integer representing the damage dealt.</returns>
        public int rollDamage()
        {
            int Roll = Dice.rollDice(wDice, wNumDice);
            Roll += wBonus;
            if(Roll < 0)
            {
                return 0;
            }
            return Roll;
            
        }
    }
    /// <summary>
    /// Armor. A type of Equipment
    /// </summary>
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
        private ArmorTypes aType;
        public int AC;

        public ArmorTypes Type {get {return aType;} set {aType = value;}}

        public override string ToString()
        {
            return Name + " (" + AC + ")" + " : " + Money.GoldToCoins(Value);
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
    /// <summary>
    /// Weapon type.
    /// </summary>
    public struct WeaponType
    {
        string Name;
        public string Damage;
        public string VersitileDamage;
        public bool isVersitile;
        public bool isTwoHanded;
        bool isThrown;
        public WeaponType (string n, string d)
        {
            Name = n;
            Damage = d;
            VersitileDamage = d;
            isVersitile = false;
            isTwoHanded = false;
            isThrown = false;
        }
        public WeaponType(string n, string d, string vd, bool v, bool th, bool t)
        {
            Name = n;
            Damage = d;
            VersitileDamage = vd;
            isVersitile = v;
            isTwoHanded = th;
            isThrown = t;
        }
        public override string ToString()
        {
            return Name;
        }
    }
    #endregion
}
