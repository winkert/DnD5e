using DnD5e.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DnD5e
{
    [Serializable]
    public class Monster: Character
    {
        public Monster ()
        {
            setRace("Monster");
        }
        public Monster(string name, MonsterSize s, MonsterType mt, int xp)
        {
            pName = name;
            setRace("Monster");
            mSize = s;
            mType = mt;
            xpValue = xp;
        }
        private MonsterSize mSize;
        private MonsterType mType;
        public int xpValue { get; set; }

        public override string ToString()
        {
            return pName + "(" + mSize.GetDescription() + " " + mType.GetDescription() + ")";
        }
    }

    public enum MonsterType
    {
        None = 0,
        Humanoid,
        Beast,
        Undead,
        Fey,
        Dragon,
        Aberration,
        Celestial,
        Constuct,
        Elemental,
        Fiend,
        Giant,
        Monstrocity,
        Ooze,
        Plant

    }
    public enum MonsterSize
    {
        None = 0,
        Tiny,
        Small, 
        Medium,
        Large,
        Huge,
        Gargantuan
    }
}
