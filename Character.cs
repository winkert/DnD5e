using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DnD5e
{

    [Serializable]
    public class Character
    {
        /// <summary>
        /// Character to be used in DnD 5e
        /// </summary>
        /// <param name="n">Character Name</param>
        /// <param name="St">Strength</param>
        /// <param name="Dx">Dexterity</param>
        /// <param name="Cn">Constitution</param>
        /// <param name="In">Intelligence</param>
        /// <param name="Wd">Wisdom</param>
        /// <param name="Ch">Charisma</param>
        public Character(string n, int St, int Dx, int Cn, int In, int Wd, int Ch)
        {
            pName = n;
            pStrength = St;
            pDexterity = Dx;
            pConstitution = Cn;
            pIntelligence = In;
            pWisdom = Wd;
            pCharisma = Ch;
            InitializeSkills();
        }
        public Character()
        {

        }
        #region Fields
        public string pName { get; set; }
        public string Gender { get { return getGender(pGender); } }
        public string Race { get { return getRace(pRace); } }
        public string SubRace { get { return getSubrace(pSubRace); } }
        public string Class { get { return getClass(pClass); } }
        public string SubClass { get { return getSubClass(pPrestige); } }
        public string Allignment { get { return getAllignment(pAllignment); } }
        public string pBackground;
        private Gender pGender;
        private Races pRace;
        private SubRaces pSubRace;
        private Classes pClass;
        private SubClass pPrestige;
        private Allignments pAllignment;
        //Abilities
        public static int pStrength;
        public static int pDexterity;
        public static int pConstitution;
        public static int pIntelligence;
        public static int pWisdom;
        public static int pCharisma;
        //Skills
        public List<Skill> pSkills = new List<Skill>();
        //Proficiencies
        public List<Proficiencies> pProficiencies = new List<Proficiencies>();
        //Spells
        public bool isSpellCaster = false;
        public List<Spell> pSpells = new List<Spell>();
        //Equipment
        public List<Equipment> pEquipment = new List<Equipment>();
        #endregion
        #region Methods
        public override string ToString()
        {
            return pName + ": " + getRace(pRace) + ", " + getClass(pClass);
        }
        private void InitializeSkills()
        {
            pSkills.Add(new Skill("Acrobatics", pDexterity));
            pSkills.Add(new Skill("Animal Handling", pWisdom));
            pSkills.Add(new Skill("Arcana", pIntelligence));
            pSkills.Add(new Skill("Athletics", pStrength));
            pSkills.Add(new Skill("Deception", pCharisma));
            pSkills.Add(new Skill("History", pIntelligence));
            pSkills.Add(new Skill("Insight", pWisdom));
            pSkills.Add(new Skill("Intimidation", pCharisma));
            pSkills.Add(new Skill("Investigation", pIntelligence));
            pSkills.Add(new Skill("Medicine", pWisdom));
            pSkills.Add(new Skill("Nature", pIntelligence));
            pSkills.Add(new Skill("Perception", pWisdom));
            pSkills.Add(new Skill("Performance", pWisdom));
            pSkills.Add(new Skill("Persuasion", pCharisma));
            pSkills.Add(new Skill("Religion", pIntelligence));
            pSkills.Add(new Skill("Insight", pIntelligence));
            pSkills.Add(new Skill("Sleight of Hand", pDexterity));
            pSkills.Add(new Skill("Stealth", pDexterity));
            pSkills.Add(new Skill("Survival", pWisdom));
        }
        #region Enum Methods
        /// <summary>
        /// Set the gender based on the string value entered.
        /// </summary>
        /// <param name="g">Name of the character gender</param>
        public void setGender(string g)
        {
            pGender = g.ParseEnum<Gender>();
        }
        string getGender(Gender g)
        {
            return g.GetDescription();
        }
        /// <summary>
        /// Sets the race based on the string value entered.
        /// </summary>
        /// <param name="r">Name of the character race</param>
        public void setRace(string r)
        {
            pRace = r.ParseEnum<Races>();
        }
        string getRace(Races r)
        {
            return r.GetDescription();
        }
        /// <summary>
        /// Sets the subrace based on the string value entered.
        /// </summary>
        /// <param name="sr">Name of the character subrace</param>
        public void setSubRace(string sr)
        {
            pSubRace = sr.ParseEnum<SubRaces>();
        }
        string getSubrace(SubRaces sr)
        {
            return sr.GetDescription();
        }
        /// <summary>
        /// Sets the class based on the string value entered.
        /// </summary>
        /// <param name="pClass">Name of the character class</param>
        public void setClass(string c)
        {
            pClass = c.ParseEnum<Classes>();
        }
        string getClass(Classes c)
        {
            return c.GetDescription();
        }
        /// <summary>
        /// Sets the subclass based on the string value entered.
        /// </summary>
        /// <param name="c"></param>
        public void setSubClass(string c, SubClassTypes t)
        {
            switch(t)
            {
                case SubClassTypes.PrimalPaths:
                    pPrestige = new SubClass(c.ParseEnum<PrimalPaths>());
                    break;
                case SubClassTypes.BardColleges:
                    pPrestige = new SubClass(c.ParseEnum<BardColleges>());
                    break;
                case SubClassTypes.DivineDomains:
                    pPrestige = new SubClass(c.ParseEnum<DivineDomains>());
                    break;
                case SubClassTypes.DruidCircles:
                    pPrestige = new SubClass(c.ParseEnum<DruidCircles>());
                    break;
                case SubClassTypes.MartialArchetypes:
                    pPrestige = new SubClass(c.ParseEnum<MartialArchetypes>());
                    break;
                case SubClassTypes.MonasticTraditions:
                    pPrestige = new SubClass(c.ParseEnum<MonasticTraditions>());
                    break;
                case SubClassTypes.SacredOaths:
                    pPrestige = new SubClass(c.ParseEnum<SacredOaths>());
                    break;
                case SubClassTypes.RangerArchetypes:
                    pPrestige = new SubClass(c.ParseEnum<RangerArchetypes>());
                    break;
                case SubClassTypes.RoguishArchetypes:
                    pPrestige = new SubClass(c.ParseEnum<RoguishArchetypes>());
                    break;
                case SubClassTypes.SorcerousOrigins:
                    pPrestige = new SubClass(c.ParseEnum<SorcerousOrigins>());
                    break;
                case SubClassTypes.OtherworldlyPatrons:
                    pPrestige = new SubClass(c.ParseEnum<OtherworldlyPatrons>());
                    break;
                case SubClassTypes.ArcaneTraditions:
                    pPrestige = new SubClass(c.ParseEnum<ArcaneTraditions>());
                    break;
                default:
                    pPrestige = new SubClass();
                    break;
            }
        }
        string getSubClass(SubClass c)
        {
            //Because a class/object can be null but an enum/type cannot be null,
            //there needs to be a check here but not in other places.
            if (c != null)
            {
                return c.GetDescription(); 
            }
            else
            {
                return String.Empty;
            }
        }
        /// <summary>
        /// Sets the allignment based on the string value entered.
        /// </summary>
        /// <param name="a">Name of the character allignment</param>
        public void setAllignment(string a)
        {
            pAllignment = a.ParseEnum<Allignments>();
        }
        string getAllignment(Allignments a)
        {
            return a.GetDescription();
        }
        #endregion
        #region Attribute Methods
        /// <summary>
        /// Method to find the ability score modifier based on the ability score.
        /// </summary>
        /// <param name="attributeScore">Attribute score</param>
        /// <returns>Ability modifier score</returns>
        public int getBonus(int attributeScore)
        {
            //The ability modifier is "subtract 10 from the ability score and then divide by 2 (round down)" PHB 13
            decimal i = (attributeScore - 10) / 2;
            int bonus;
            bonus = (int)Math.Floor(i);
            return bonus;
        }
        /// <summary>
        /// Sets the attributes of a character which has already been created.
        /// </summary>
        /// <param name="St">Strength</param>
        /// <param name="Dx">Dexterity</param>
        /// <param name="Cn">Constitution</param>
        /// <param name="In">Intelligence</param>
        /// <param name="Wd">Wisdom</param>
        /// <param name="Ch">Charisma</param>
        public void setAttributes(int St, int Dx, int Cn, int In, int Wd, int Ch)
        {
            pStrength = St;
            pDexterity = Dx;
            pConstitution = Cn;
            pIntelligence = In;
            pWisdom = Wd;
            pCharisma = Ch;
            //I haven't introduced skills just yet so I am not sure how this update will affect them.
        }
        /// <summary>
        /// Gets the selected attribute.
        /// </summary>
        /// <param name="name">Full name of the attribute.</param>
        /// <returns></returns>
        public int getAttribute(string name)
        {
            switch (name)
            {
                case "Strength":
                    return pStrength;
                case "Dexterity":
                    return pDexterity;
                case "Constitution":
                    return pConstitution;
                case "Intelligence":
                    return pIntelligence;
                case "Wisdom":
                    return pWisdom;
                case "Charisma":
                    return pCharisma;
                default:
                    return 0;
            }
        }
        #endregion
        #endregion
    }

    #region Components
    /// <summary>
    /// The gender of the character.
    /// </summary>
    enum Gender
    {
        None = 0,
        Male,
        Female
    }
    /// <summary>
    /// The race of the character.
    /// </summary>
    enum Races
    {
        None = 0,
        Dwarf,
        Elf,
        Halfling,
        Human,
        Dragonborn,
        Gnome,
        [Description("Half-Elf")]
        HalfElf,
        [Description("Half-Orc")]
        HalfOrc,
        Tiefling
    }
    /// <summary>
    /// The subrace of the character. Not all races have subraces.
    /// Due to design, this includes ethnicity (Human) and ancestry (Dragonborn)
    /// </summary>
    enum SubRaces
    {
        //Default
        None = 0,
        //Dwarf
        [Description("Hill Dwarf")]
        hillDwarf,
        [Description("Mountain Dwarf")]
        mountainDwarf,
        //Elf
        [Description("High Elf")]
        highElf,
        [Description("Wood Elf")]
        woodElf,
        [Description("Dark Elf (Drow)")]
        darkElf,
        //Halfling
        [Description("Lightfoot Halfling")]
        lightfootHalfling,
        [Description("Stout Halfling")]
        stoutHalfling,
        //Gnome
        [Description("Forest Gnome")]
        forestGnome,
        [Description("Rock Gnome")]
        rockGnome,
        //Human Ethnicity
        Calishite,
        Chondathan,
        Damaran,
        Illuskan,
        Mulan,
        Rashemi,
        Shou,
        Tethyrian,
        Turami,
        //Dragonborn Ancestry
        Black,
        Blue,
        Brass,
        Bronze,
        Copper,
        Gold,
        Green,
        Red,
        Silver,
        White
    }
    /// <summary>
    /// The class of the character.
    /// </summary>
    public enum Classes
    {
        None = 0,
        Barbarian,
        Bard,
        Cleric,
        Druid,
        Fighter,
        Monk,
        Paladin,
        Ranger,
        Rogue,
        Sorcerer,
        Warlock,
        Wizard
    }
    #region Subclasses
    /// <summary>
    /// In earlier versions of the game, these would be prestige classes.
    /// Each class has their own special paths which become open to players at later levels.
    /// </summary>
    [Serializable]
    public class SubClass
    {
        #region Constructors
        public SubClass()
        {

        }
        public SubClass(Classes c, string enumDesc)
        {
            switch (c)
            {
                case Classes.Barbarian:
                    PrimalPaths p = enumDesc.ParseEnum<PrimalPaths>();
                    description = p.GetDescription();
                    break;
                case Classes.Bard:
                    BardColleges b = enumDesc.ParseEnum<BardColleges>();
                    description = b.GetDescription();
                    break;
                case Classes.Cleric:
                    DivineDomains cl = enumDesc.ParseEnum<DivineDomains>();
                    description = cl.GetDescription();
                    break;
                case Classes.Druid:
                    DruidCircles d = enumDesc.ParseEnum<DruidCircles>();
                    description = d.GetDescription();
                    break;
                case Classes.Fighter:
                    MartialArchetypes f = enumDesc.ParseEnum<MartialArchetypes>();
                    description = f.GetDescription();
                    break;
                case Classes.Monk:
                    MonasticTraditions m = enumDesc.ParseEnum<MonasticTraditions>();
                    description = m.GetDescription();
                    break;
                case Classes.Paladin:
                    SacredOaths pal = enumDesc.ParseEnum<SacredOaths>();
                    description = pal.GetDescription();
                    break;
                case Classes.Ranger:
                    RangerArchetypes rang = enumDesc.ParseEnum<RangerArchetypes>();
                    description = rang.GetDescription();
                    break;
                case Classes.Rogue:
                    RoguishArchetypes r = enumDesc.ParseEnum<RoguishArchetypes>();
                    description = r.GetDescription();
                    break;
                case Classes.Sorcerer:
                    SorcerousOrigins sor = enumDesc.ParseEnum<SorcerousOrigins>();
                    description = sor.GetDescription();
                    break;
                case Classes.Warlock:
                    OtherworldlyPatrons war = enumDesc.ParseEnum<OtherworldlyPatrons>();
                    description = war.GetDescription();
                    break;
                case Classes.Wizard:
                    ArcaneTraditions wiz = enumDesc.ParseEnum<ArcaneTraditions>();
                    description = wiz.GetDescription();
                    break;
                default:
                    description = string.Empty;
                    break;
            }

        }
        public SubClass(PrimalPaths p)
        {
            description = p.GetDescription();
        }
        public SubClass(BardColleges p)
        {
            description = p.GetDescription();
        }
        public SubClass(DivineDomains p)
        {
            description = p.GetDescription();
        }
        public SubClass(DruidCircles p)
        {
            description = p.GetDescription();
        }
        public SubClass(MartialArchetypes p)
        {
            description = p.GetDescription();
        }
        public SubClass(MonasticTraditions p)
        {
            description = p.GetDescription();
        }
        public SubClass(SacredOaths p)
        {
            description = p.GetDescription();
        }
        public SubClass(RangerArchetypes p)
        {
            description = p.GetDescription();
        }
        public SubClass(RoguishArchetypes p)
        {
            description = p.GetDescription();
        }
        public SubClass(SorcerousOrigins p)
        {
            description = p.GetDescription();
        }
        public SubClass(OtherworldlyPatrons p)
        {
            description = p.GetDescription();
        }
        public SubClass(ArcaneTraditions p)
        {
            description = p.GetDescription();
        }
        #endregion
        /// <summary>
        /// The description of the selected subclass.
        /// </summary>
        private string description;
        /// <summary>
        /// Returns the Description attribute of an enum value if that attribute exists. Otherwise, it returns the name.
        /// </summary>
        /// <returns></returns>
        public string GetDescription()
        {
            if (description != null)
            {
                return description;
            }
            else
            {
                return String.Empty;
            }
            
        }

    }
    public enum SubClassTypes
    {
        None = 0,
        PrimalPaths,
        BardColleges,
        DivineDomains,
        DruidCircles,
        MartialArchetypes,
        MonasticTraditions,
        SacredOaths,
        RangerArchetypes,
        RoguishArchetypes,
        SorcerousOrigins,
        OtherworldlyPatrons,
        ArcaneTraditions
    }
    public enum PrimalPaths
    {
        None = 0,
        //Barbarian: Primal Path
        [Description("Path of the Berserker")]
        Berserker,
        [Description("Path of the Totem Warrior")]
        TotemWarrior
    }
    public enum BardColleges
    {
        None = 0,
        //Bard: Bard College
        [Description("College of Lore")]
        Lore,
        [Description("College of Valor")]
        Valor
    }
    public enum DivineDomains
    {
        None = 0,
        //Cleric: Divine Domain
        [Description("Knowledge Domain")]
        Knowledge,
        [Description("Life Domain")]
        Life,
        [Description("Light Domain")]
        Light,
        [Description("Nature Domain")]
        Nature,
        [Description("Tempest Domain")]
        Tempest,
        [Description("Trickery Domain")]
        Trickery,
        [Description("War Domain")]
        War
    }
    public enum DruidCircles
    {
        None = 0,
        //Druid: Druid Circle
        [Description("Circle of the Land")]
        Land,//Arctic, Coast, Desert, Forest, Grassland, Mountain, Swamp, Underdark
        [Description("Circle of the Moon")]
        Moon
    }
    public enum MartialArchetypes
    {
        None = 0,
        //Fighter: Martial Archetype
        [Description("Champion")]
        Champion,
        [Description("Battle Master")]
        BattleMaster,
        [Description("Eldritch Knight")]
        EldritchKnight
    }
    public enum MonasticTraditions
    {
        None = 0,
        //Monk: Monastic Tradition
        [Description("Way of the Open Hands")]
        OpenHands,
        [Description("Way of the Shadow")]
        Shadow,
        [Description("Way of the Four Elements")]
        Elements
    }
    public enum SacredOaths
    {
        None = 0,
        //Paladin: Sacred Oath
        [Description("Oath of Devotion")]
        Devotion,
        [Description("Oath of the Ancients")]
        Ancients,
        [Description("Oath of Vengeance")]
        Vengeance
    }
    public enum RangerArchetypes
    {
        None = 0,
        //Ranger: Ranger Archetype
        [Description("Hunter")]
        Hunter,
        [Description("Beast Master")]
        BeastMaster
    }
    public enum RoguishArchetypes
    {
        None = 0,
        //Rogue: Roguish Archetype
        [Description("Thief")]
        Thief,
        [Description("Assassin")]
        Assassin,
        [Description("Arcane Trickster")]
        Trickster
    }
    public enum SorcerousOrigins
    {
        None = 0,
        //Sorcerer: Sorcerous Origins
        [Description("Draconic Bloodline")]
        Draconic,
        [Description("Wild Magic")]
        Wild
    }
    public enum OtherworldlyPatrons
    {
        None = 0,
        //Warlock: Otherworldly Patron
        [Description("The Archfey")]
        Archfey,
        [Description("The Fiend")]
        Fiend,
        [Description("The Great Old One")]
        GreatOldOne
    }
    public enum ArcaneTraditions
    {
        None = 0,
        //Wizard: Arcane Tradition
        [Description("School of Abjuration")]
        Abjuration,
        [Description("School of Conjuration")]
        Conjuration,
        [Description("School of Divination")]
        Divination,
        [Description("School of Enchantment")]
        Enchantment,
        [Description("School of Evocation")]
        Evocation,
        [Description("School of Illusion")]
        Illusion,
        [Description("School of Necromancy")]
        Necromancy,
        [Description("School of Transmutation")]
        Transmutation
    }
    #endregion
    /// <summary>
    /// The allignment of the character
    /// </summary>
    enum Allignments
    {
        [Description("Chaotic Evil")]
        chaoticEvil = -4,
        [Description("Neutral Evil")]
        neutralEvil = -3,
        [Description("Lawful Evil")]
        lawfulEvil = -2,
        [Description("Chaotic Neutral")]
        chaoticNeutral = -1,
        Neutral = 0,
        [Description("Lawful Neutral")]
        lawfulNeutral = 1,
        [Description("Chaotic Good")]
        chaoticGood = 2,
        [Description("Neutral Good")]
        neutralGood = 3,
        [Description("Lawful Good")]
        lawfulGood = 4,
    }
    #endregion
}

