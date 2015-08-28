using DnD5e.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DnD5e
{
    #region Class
    /// <summary>
    /// Character Spell.
    /// </summary>
    [Serializable]
    public class Spell
    {

        public Spell(string name, SpellClass c, SpellLevel l)
        {
            sName = name;
            sClass = c;
            sLevel = l;
        }
        public Spell()
        {

        }
        public string sName;
        SpellClass sClass;
        SpellLevel sLevel;
        public string sCastTime;
        public string sRange;
        public string sComponents;
        public string sDuration;
        public string sEffect;
        public override string ToString()
        {
            return sName + " (" + sLevel.GetDescription() + "; " + sClass.GetDescription() + ")";
        }
        public string getClass()
        {
            return sClass.GetDescription();
        }
        public string getLevel()
        {
            return sLevel.GetDescription();
        }

    }
    #endregion
    #region Components
    public enum SpellClass
    {
        None = 0,
        Bard,
        Cleric,
        Druid,
        Ki,
        Paladin,
        Ranger,
        Sorcerer,
        Warlock,
        Wizard
    }
    public enum SpellLevel
    {
        Cantrip = 0,
        [Description("1st Level")]
        FirstLevel,
        [Description("2nd Level")]
        SecondLevel,
        [Description("3rd Level")]
        ThirdLevel,
        [Description("4th Level")]
        FourthLevel,
        [Description("5th Level")]
        FifthLevel,
        [Description("6th Level")]
        SixthLevel,
        [Description("7th Level")]
        SeventhLevel,
        [Description("8th Level")]
        EighthLevel,
        [Description("9th Level")]
        NinthLevel
    }
    #endregion
}
