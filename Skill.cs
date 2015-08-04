using System;

namespace DnD5e
{
    /// <summary>
    /// Character skill.
    /// </summary>
    [Serializable]
    public class Skill
    {
        public string SkillName;
        public bool isProficient = false;
        public int SkillBonus;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sName">Skill Name</param>
        /// <param name="AttLevel">Associated attribute/ability score</param>
        public Skill(string sName, int AttLevel)
        {
            SkillName = sName;
            isProficient = false;
            decimal i = (AttLevel - 10) / 2;
            SkillBonus = (int)Math.Floor(i);
        }
        public Skill ()
        {

        }
        public void makeProficient()
        {
            isProficient = true;
            SkillBonus += 2;
        }
        public void refreshSkill(int newAttLevel)
        {
            decimal i = (newAttLevel - 10) / 2;
            if (isProficient)
            {
                SkillBonus = (int)Math.Floor(i) + 2;
            }
            else
            {
                SkillBonus = (int)Math.Floor(i);
            }
        }
    }
}
