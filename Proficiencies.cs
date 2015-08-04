using System;

namespace DnD5e
{
    [Serializable]
    public class Proficiencies
    {
        public Proficiencies()
        {

        }
        public Proficiencies(ProficincyTypes type, string name)
        {
            pType = type;
            pName = name;
        }
        ProficincyTypes pType;
        string pName;

        public override string ToString()
        {
            return pName;
        }
    }

    #region Components
    public enum ProficincyTypes
    {
        Armor = 0,
        Weapon,
        Tool,
        Instrument,
        Vehicle
    }
    
    #endregion
}
