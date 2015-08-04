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
        public Equipment(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name;
        public string Effects;
        public string Value;
        public override string ToString()
        {
            return Name;
        }
    }

    [Serializable]
    public class Weapon : Equipment
    {
        public Weapon()
        {

        }
        public Weapon(string name, WeaponClasses wclass, int dice, int ndice, int b, string effects)
        {
            Name = name;
            wClass = wclass;
            wNumDice = ndice;
            wDice = dice;
            wBonus = b;
            Effects = effects;
        }
        WeaponClasses wClass;
        int wNumDice;
        int wDice;
        int wBonus;
        public override string ToString()
        {
            return Name + " (" + Damage() + ")";
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
        public Armor(string name, ArmorTypes atype, int aclass, int b, string effects)
        {
            Name = name;
            aType = atype;
            AC = aclass;
            aBonus = b;
            Effects = effects;
        }
        ArmorTypes aType;
        int AC;
        int aBonus;
        public override string ToString()
        {
            return Name + " (" + AC + ")";
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
        [Description("Simple Weapon")]
        SimpleWeapon,
        [Description("Martial Weapon")]
        MartialWeapon
    }
    #endregion
}
