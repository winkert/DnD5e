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
        public Monster(string name, MonsterSize s, MonsterType mt)
        {
            pName = name;
            setRace("Monster");
            mSize = s;
            mType = mt;
        }
        MonsterSize mSize;
        MonsterType mType;

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
