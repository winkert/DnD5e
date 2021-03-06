﻿using DnD5e.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DnD5e
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            allCharacters = new List<Character>();
            refreshCharacters();
            BindControls();
            BindSpellControls();
            BindEquipmentControls();
            AppLog.WriteLog("Application Initialized");
        }
        #region Fields
        public static List<Character> allCharacters;
        /// <summary>
        /// Integer used to track which item is selected (was selected) in order to save the item.
        /// Default is -1 (no selection)
        /// </summary>
        public int SelectedCharacter = -1;
        public static bool changesMade = false;
        public static bool savingNloading = false;
        private string SaveLocation = Path.GetDirectoryName(Application.ExecutablePath) + "\\characters.bin";
        private Log AppLog = new Log("DnD5e.log");
        private List<Proficiencies> tempProficiencies;
        private List<Spell> tempSpells;
        private List<Equipment> tempEquipment;
        private string tempPrestigeType = "None";
        private bool tempIsCaster = false;
        #endregion

        #region Methods
        private void refreshXPForm()
        {
            if (Application.OpenForms.OfType<XPCalc>().Count() > 0)
            {
                Application.OpenForms.OfType<XPCalc>().Single().refreshList();
            }
        }
        #region Save Load New
        private void refreshSpells()
        {
            list_KnownSpells.DataSource = null;
            list_KnownSpells.DataSource = tempSpells;
        }
        private void refreshCharacters()
        {
            list_Characters.DataSource = null;
            list_Characters.DataSource = allCharacters;
        }
        private void refreshProficiencies()
        {
            list_Proficiencies.DataSource = null;
            list_Proficiencies.DataSource = tempProficiencies;
        }
        private void refreshEquipment()
        {
            list_Equipment.DataSource = null;
            list_Equipment.DataSource = tempEquipment;
        }
        /// <summary>
        /// Sets all fields to their defaults.
        /// </summary>
        private void ResetControls()
        {
            //Go through all of the controls in the character sheet.
            foreach (Control t in tab_CharSheet.Controls)
            {
                if (t is TextBox)
                {
                    TextBox n = (TextBox)t;
                    n.Text = string.Empty;
                }
                else if (t is ComboBox)
                {
                    ComboBox c = (ComboBox)t;
                    c.SelectedIndex = 0;
                }
                else if (t is CheckBox)
                {
                    CheckBox check = (CheckBox)t;
                    check.Checked = false;
                }
                else if (t is RadioButton)
                {
                    RadioButton radio = (RadioButton)t;
                    radio.Checked = false;
                }
            }
            //Need to address the table separately
            foreach (Control t in AbilityTable.Controls)
            {
                if (t is NumericUpDown)
                {
                    NumericUpDown att = (NumericUpDown)t;
                    att.Value = Convert.ToDecimal(0);
                }
            }

            //Clear Skills
            foreach (Control t in grp_Skills.Controls)
            {
                if (t is CheckBox)
                {
                    CheckBox check = (CheckBox)t;
                    check.Checked = false;
                }
            }
            //Empty the Proficiencies list
            tempProficiencies.Clear();
            refreshProficiencies();
            //Fix the labels that might have been changed.
            label_SubRace.Text = "SubRace";
            label_Prestige.Text = "Prestige";
            //Reset Spells tab to enabled and empty it.
            resetSpellsControls();
            tab_CharSpells.Enabled = tempIsCaster;
            tempSpells.Clear();
            refreshSpells();
            //Reset Equipment
            resetEquipmentControls();
            tempEquipment.Clear();
            refreshEquipment();
        }
        /// <summary>
        /// Sets all of the fields in the Spells tab to their defaults.
        /// </summary>
        private void resetSpellsControls()
        {
            foreach (Control c in tab_CharSpells.Controls)
            {
                if (c is TextBox)
                {
                    TextBox t = (TextBox)c;
                    t.Text = string.Empty;
                }
                else if (c is ComboBox)
                {
                    ComboBox b = (ComboBox)c;
                    b.SelectedIndex = 0;
                }
            }

        }
        /// <summary>
        /// Sets all of the fields in the Equipment tab to their defaults.
        /// </summary>
        private void resetEquipmentControls()
        {
            foreach (Control c in tab_CharSpells.Controls)
            {
                if (c is TextBox)
                {
                    TextBox t = (TextBox)c;
                    t.Text = string.Empty;
                }
                else if (c is ComboBox)
                {
                    ComboBox b = (ComboBox)c;
                    b.SelectedIndex = 0;
                }
            }
        }
        /// <summary>
        /// Populates all of the fields to match the selected character.
        /// </summary>
        /// <param name="c"></param>
        private void LoadCharacter(Character c)
        {
            tempEquipment = null;
            tempProficiencies = null;
            tempSpells = null;
            //First the Character sheet
            txt_Name.Text = c.pName;
            combo_Gender.SelectedItem = c.Gender;
            combo_Race.SelectedItem = c.Race;
            combo_SubRace.SelectedItem = c.SubRace;
            combo_Class.SelectedItem = c.Class;
            combo_Prestige.SelectedItem = c.SubClass;
            combo_Allignment.SelectedItem = c.Allignment;
            txt_Background.Text = c.pBackground;
            txt_PlayerHP.Text = c.MaxHitPoints.ToString();
            //Use a generic method in Character to get the attributes
            txt_St.Value = c.getAttribute("Strength");
            txt_Dx.Value = c.getAttribute("Dexterity");
            txt_Cn.Value = c.getAttribute("Constitution");
            txt_In.Value = c.getAttribute("Intelligence");
            txt_Wd.Value = c.getAttribute("Wisdom");
            txt_Ch.Value = c.getAttribute("Charisma");

            //Set the Skills
            foreach (Control s in grp_Skills.Controls)
            {
                if (s is CheckBox)
                {
                    CheckBox check = (CheckBox)s;
                    foreach (Skill sk in c.pSkills)
                    {
                        if (sk.SkillName == check.Text)
                        {
                            check.Checked = sk.isProficient;
                        }
                    }
                }
            }

            //Set the Proficiencies
            LoadProficiencies(ref tempProficiencies, c);
            refreshProficiencies();

            //Spells
            tab_CharSpells.Enabled = c.isSpellCaster;
            tempIsCaster = c.isSpellCaster;
            LoadSpells(ref tempSpells, c);
            refreshSpells();

            //Equipment            
            LoadEquipment(ref tempEquipment, c);
            refreshEquipment();
        }
        /// <summary>
        /// Saves the selected character. This is for adding a new character
        /// </summary>
        /// <param name="c">Selected Character</param>
        private Character SaveCharacter()
        {
            //Attributes are saved in creation
            Character c = new Character(txt_Name.Text, (int)txt_St.Value, (int)txt_Dx.Value, (int)txt_Cn.Value, (int)txt_In.Value, (int)txt_Wd.Value, (int)txt_Ch.Value);
            c.MaxHitPoints = int.Parse(txt_PlayerHP.Text);
            //Save characteristics
            c.setGender(combo_Gender.SelectedItem.ToString());
            c.setRace(combo_Race.SelectedItem.ToString());
            if (combo_SubRace.SelectedItem != null)
            {
                c.setSubRace(combo_SubRace.SelectedItem.ToString());
            }
            else
            {
                c.setSubRace("None");
            }
            c.setClass(combo_Class.SelectedItem.ToString());
            if (combo_Prestige.SelectedItem != null)
            {
                string prestigeclass = combo_Prestige.SelectedItem.ToString();
                c.setSubClass(prestigeclass, tempPrestigeType.ParseEnum<SubClassTypes>());
            }
            else
            {
                c.setSubClass("None", SubClassTypes.None);
            }
            c.setAllignment(combo_Allignment.SelectedItem.ToString());
            c.pBackground = txt_Background.Text;
            //Save skills
            foreach (Control s in grp_Skills.Controls)
            {
                CheckBox check = (CheckBox)s;
                //There is no check here to determine if the name is not spelled the same
                c.pSkills.First(k => k.SkillName != null && k.SkillName == check.Text).isProficient = check.Checked;

            }
            //Save Proficiencies
            c.Proficiencies = tempProficiencies;
            //Save Spells
            c.isSpellCaster = tempIsCaster;
            c.Spells = tempSpells;
            //Save Equipment
            c.Equipment = tempEquipment;
            return c;
        }
        /// <summary>
        /// Saves the selected character. This overwrites an existing character.
        /// </summary>
        /// <param name="c"></param>
        private void SaveCharacter(int c)
        {
            //Need to save attributes and name.
            allCharacters[c].pName = txt_Name.Text;
            allCharacters[c].setAttributes((int)txt_St.Value, (int)txt_Dx.Value, (int)txt_Cn.Value, (int)txt_In.Value, (int)txt_Wd.Value, (int)txt_Ch.Value);
            allCharacters[c].MaxHitPoints = int.Parse(txt_PlayerHP.Text);
            //Save characteristics
            allCharacters[c].setGender(combo_Gender.SelectedItem.ToString());
            allCharacters[c].setRace(combo_Race.SelectedItem.ToString());
            if (combo_SubRace.SelectedItem != null)
            {
                allCharacters[c].setSubRace(combo_SubRace.SelectedItem.ToString());
            }
            else
            {
                allCharacters[c].setSubRace("None");
            }
            allCharacters[c].setClass(combo_Class.SelectedItem.ToString());
            if (combo_Prestige.SelectedItem != null)
            {
                string prestigeclass = combo_Prestige.SelectedItem.ToString();
                allCharacters[c].setSubClass(prestigeclass, tempPrestigeType.ParseEnum<SubClassTypes>());
            }
            else
            {
                allCharacters[c].setSubClass("None", SubClassTypes.None);
            }
            allCharacters[c].setAllignment(combo_Allignment.SelectedItem.ToString());
            allCharacters[c].pBackground = txt_Background.Text;
            //Save skills
            foreach (Control s in grp_Skills.Controls)
            {
                CheckBox check = (CheckBox)s;
                //There is no check here to determine if the name is not spelled the same
                allCharacters[c].pSkills.First(k => k.SkillName != null && k.SkillName == check.Text).isProficient = check.Checked;
            }
            //Save Proficiencies
            SaveProficiencies(tempProficiencies, c);
            //Save Spells
            allCharacters[c].isSpellCaster = tempIsCaster;
            SaveSpells(tempSpells, c);
            //Save Equipment
            SaveEquipment(tempEquipment, c);
        }

        #region Save Parts
        private void SaveProficiencies(List<Proficiencies> prof, int c)
        {
            allCharacters[c].Proficiencies = prof;
        }
        private void SaveSpells(List<Spell> spells, int c)
        {
            allCharacters[c].Spells = spells;
        }
        private void SaveEquipment(List<Equipment> equip, int c)
        {
            allCharacters[c].Equipment = equip;
        }
        //private List<Proficiencies> SaveProficiencies(List<Proficiencies> prof)
        //{
        //    allCharacters[c].Proficiencies = prof;
        //}
        //private List<Spell> SaveSpells(List<Spell> spells)
        //{
        //    allCharacters[c].Spells = spells;
        //}
        //private List<Equipment> SaveEquipment(List<Equipment> equip)
        //{
        //    allCharacters[c].Equipment = equip;
        //}
        #endregion
        #region Load Parts
        private void LoadProficiencies(ref List<Proficiencies> prof, Character c)
        {
            if (prof != null)
            {
                prof.Clear(); 
            }
            else
            {
                prof = new List<Proficiencies>();
            }
            foreach (Proficiencies p in c.Proficiencies)
            {
                prof.Add(p);
            }
        }
        private void LoadSpells(ref List<Spell> spells, Character c)
        {
            if (spells != null)
            {
                spells.Clear();
            }
            else
            {
                spells = new List<Spell>();
            }
            foreach (Spell p in c.Spells)
            {
                spells.Add(p);
            }
        }
        private void LoadEquipment(ref List<Equipment> equip, Character c)
        {
            if (equip != null)
            {
                equip.Clear(); 
            }
            else
            {
                equip = new List<Equipment>();
            }
            foreach (Equipment e in c.Equipment)
            {
                equip.Add(e);
            }
        }
        #endregion
        #endregion
        #region Build Parts
        private Spell createSpell()
        {
            string spellclass;
            string spelllevel;
            if (combo_SpellClass.SelectedItem != null)
            {
                spellclass = (string)combo_SpellClass.SelectedItem;
            }
            else
            {
                spellclass = "None";
            }
            if (combo_SpellLevel.SelectedItem != null)
            {
                spelllevel = (string)combo_SpellLevel.SelectedItem;
            }
            else
            {
                spelllevel = "Cantrip";
            }
            Spell s = new Spell(txt_SpellName.Text, spellclass.ParseEnum<SpellClass>(), spelllevel.ParseEnum<SpellLevel>());
            s.sEffect = txt_SpellEffects.Text;
            s.sComponents = txt_SpellComponents.Text;
            s.sRange = txt_SpellRange.Text;
            s.sDuration = txt_SpellDuration.Text;
            s.sCastTime = txt_SpellCastTime.Text;
            return s;
        }
        private Equipment createEquipment()
        {
            Equipment item;
            decimal value = 0m;
            int pp, gp, ep, sp, cp;
            decimal weight;
            if (!int.TryParse(item_pp.Text, out pp))
            {
                pp = 0;
            }
            if (!int.TryParse(item_gp.Text, out gp))
            {
                gp = 0;
            }
            if (!int.TryParse(item_ep.Text, out ep))
            {
                ep = 0;
            }
            if (!int.TryParse(item_sp.Text, out sp))
            {
                sp = 0;
            }
            if (!int.TryParse(item_cp.Text, out cp))
            {
                cp = 0;
            }
            value += Money.PlatinumToGold(pp) + gp + Money.ElectrumToGold(ep) + Money.SilverToGold(sp) + Money.CopperToGold(cp);
            if(!decimal.TryParse(txt_ItemWeight.Text, out weight))
            {
                weight = 0;
            }
            if (combo_ItemTypes.SelectedItem.ToString().ParseEnum<ItemTypes>() == ItemTypes.Armor)
            {
                int ac;
                if(!int.TryParse(txt_ArmorClass.Text,out ac))
                {
                    ac = 0;
                }
                item = new Armor(txt_ItemName.Text, combo_ArmorType.SelectedItem.ToString().ParseEnum<ArmorTypes>(), ac,value);
            }
            else
            if (combo_ItemTypes.SelectedItem.ToString().ParseEnum<ItemTypes>() == ItemTypes.Weapon)
            {
                string damage = txt_WeaponDamage.Text;
                int bonus = findBonus(damage);
                damage = removeBonus(damage);
                int numDice = Dice.ParseDiceNumber(damage);
                int diceType = Dice.ParseDiceType(damage);
                item = new Weapon(txt_ItemName.Text, combo_WeaponType.SelectedItem.ToString().ParseEnum<WeaponClasses>(), diceType,numDice,bonus,value);
            }
            else
            {
                item = new Equipment(txt_ItemName.Text, value);
            }
            item.Effects = txt_ItemEffects.Text;
            item.Weight = weight;
            return item;
        }
        #endregion
        #region Stat Parsers
        public int findBonus(string s)
        {
            if (s.IndexOf('+') > 0)
            {
                return int.Parse(s.Substring(s.IndexOf('+') + 1, s.Length - s.IndexOf('+') - 1));
            }
            else
            {
                return 0;
            }
        }
        public string removeBonus(string s)
        {
            if (s.IndexOf('+') > 0)
            {
                return s.Substring(0, s.IndexOf('+'));
            }
            else
            {
                return s;
            }
        }
        #endregion
        #region Dynamic Fields
        /// <summary>
        /// Binds the dropdowns to arrays of Enums.
        /// </summary>
        private void BindControls()
        {
            foreach (Control c in tab_CharSheet.Controls)
            {
                if(c is ComboBox)
                {
                    ComboBox box = (ComboBox)c;
                    box.DataSource = null;
                }
            }
            combo_Gender.DataSource =ExtensionMethods.GetEnumNames(typeof(Gender));
            combo_Race.DataSource =ExtensionMethods.GetEnumNames(typeof(Races));
            combo_SubRace.Items.Add(SubRaces.None.GetDescription());
            combo_Class.DataSource =ExtensionMethods.GetEnumNames(typeof(Classes));
            combo_Prestige.Items.Add("None");
            combo_Allignment.DataSource =ExtensionMethods.GetEnumNames(typeof(Allignments));
            combo_ProfType.DataSource =ExtensionMethods.GetEnumNames(typeof(ProficincyTypes));
        }
        /// <summary>
        /// Binds the dropdowns in the Spells tab to arrays of Enums.
        /// </summary>
        private void BindSpellControls()
        {
            foreach (Control c in tab_CharSpells.Controls)
            {
                if (c is ComboBox)
                {
                    ComboBox box = (ComboBox)c;
                    box.DataSource = null;
                }
                combo_SpellClass.DataSource =ExtensionMethods.GetEnumNames(typeof(SpellClass));
                combo_SpellLevel.DataSource =ExtensionMethods.GetEnumNames(typeof(SpellLevel));
            }
        }
        /// <summary>
        /// Binds the dropdowns in the Equipment tab to arrays of Enums.
        /// </summary>
        private void BindEquipmentControls()
        {
            foreach (Control c in tab_CharEquipment.Controls)
            {
                if (c is ComboBox)
                {
                    ComboBox box = (ComboBox)c;
                    box.DataSource = null;
                }
                combo_ItemTypes.DataSource =ExtensionMethods.GetEnumNames(typeof(ItemTypes));
                combo_WeaponType.DataSource =ExtensionMethods.GetEnumNames(typeof(WeaponClasses));
                combo_ArmorType.DataSource =ExtensionMethods.GetEnumNames(typeof(ArmorTypes));
            }
        }
        /// <summary>
        /// Method to dynamically change the SubRace dropdown and label based on the selected Race.
        /// </summary>
        /// <param name="Race">Name of the selected race</param>
        private void BindSubRaces(string Race)
        {
            switch (Race)
            {
                case "Dwarf":
                    ResetSubRace("SubRace", true);
                    combo_SubRace.Items.Add(SubRaces.hillDwarf.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.mountainDwarf.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.None.GetDescription());
                    break;
                case "Elf":
                    ResetSubRace("SubRace", true);
                    combo_SubRace.Items.Add(SubRaces.highElf.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.woodElf.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.darkElf.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.None.GetDescription());
                    break;
                case "Halfling":
                    ResetSubRace("SubRace", true);
                    combo_SubRace.Items.Add(SubRaces.lightfootHalfling.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.stoutHalfling.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.None.GetDescription());
                    break;
                case "Human":
                    ResetSubRace("Ethnicity", true);
                    combo_SubRace.Items.Add(SubRaces.Calishite.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.Chondathan.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.Damaran.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.Illuskan.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.Mulan.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.Rashemi.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.Shou.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.Tethyrian.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.Turami.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.None.GetDescription());
                    break;
                case "Dragonborn":
                    ResetSubRace("Ancestry", true);
                    combo_SubRace.Items.Add(SubRaces.Black.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.Blue.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.Brass.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.Bronze.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.Copper.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.Gold.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.Green.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.Red.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.Silver.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.White.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.None.GetDescription());
                    break;
                case "Gnome":
                    ResetSubRace("SubRace", true);
                    combo_SubRace.Items.Add(SubRaces.rockGnome.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.forestGnome.GetDescription());
                    combo_SubRace.Items.Add(SubRaces.None.GetDescription());
                    break;
                default:
                    ResetSubRace("SubRace", false);
                    combo_SubRace.Items.Add(SubRaces.None.GetDescription());
                    break;
            }
        }
        private void ResetSubRace(string labelName, bool isEnabled)
        {
            label_SubRace.Text = labelName;
            combo_SubRace.Enabled = isEnabled;
            combo_SubRace.Items.Clear();
            combo_SubRace.Items.Add(SubRaces.None.GetDescription());
        }
        private void setPrestige(Classes c)
        {
            switch (c)
            {
                case Classes.Barbarian:
                    combo_Prestige.DataSource =ExtensionMethods.GetEnumNames(typeof(PrimalPaths));
                    tempPrestigeType = "PrimalPaths";
                    label_Prestige.Text = "Primal Path";
                    break;
                case Classes.Bard:
                    combo_Prestige.DataSource =ExtensionMethods.GetEnumNames(typeof(BardColleges));
                    tempPrestigeType = "BardColleges";
                    label_Prestige.Text = "College";
                    break;
                case Classes.Cleric:
                    combo_Prestige.DataSource =ExtensionMethods.GetEnumNames(typeof(DivineDomains));
                    tempPrestigeType = "DivineDomains";
                    label_Prestige.Text = "Domain";
                    break;
                case Classes.Druid:
                    combo_Prestige.DataSource =ExtensionMethods.GetEnumNames(typeof(DruidCircles));
                    tempPrestigeType = "DruidCircles";
                    label_Prestige.Text = "Druid Circle";
                    break;
                case Classes.Fighter:
                    combo_Prestige.DataSource =ExtensionMethods.GetEnumNames(typeof(MartialArchetypes));
                    tempPrestigeType = "MartialArchetypes";
                    label_Prestige.Text = "Archetype";
                    break;
                case Classes.Monk:
                    combo_Prestige.DataSource =ExtensionMethods.GetEnumNames(typeof(MonasticTraditions));
                    tempPrestigeType = "MonasticTraditions";
                    label_Prestige.Text = "Tradition";
                    break;
                case Classes.Paladin:
                    combo_Prestige.DataSource =ExtensionMethods.GetEnumNames(typeof(SacredOaths));
                    tempPrestigeType = "SacredOaths";
                    label_Prestige.Text = "Sacred Oath";
                    break;
                case Classes.Ranger:
                    combo_Prestige.DataSource =ExtensionMethods.GetEnumNames(typeof(RangerArchetypes));
                    tempPrestigeType = "RangerArchetypes";
                    label_Prestige.Text = "Archetype";
                    break;
                case Classes.Rogue:
                    combo_Prestige.DataSource =ExtensionMethods.GetEnumNames(typeof(RoguishArchetypes));
                    tempPrestigeType = "RoguishArchetypes";
                    label_Prestige.Text = "Archetype";
                    break;
                case Classes.Sorcerer:
                    combo_Prestige.DataSource =ExtensionMethods.GetEnumNames(typeof(SorcerousOrigins));
                    tempPrestigeType = "SorcerousOrigins";
                    label_Prestige.Text = "Origin";
                    break;
                case Classes.Warlock:
                    combo_Prestige.DataSource =ExtensionMethods.GetEnumNames(typeof(OtherworldlyPatrons));
                    tempPrestigeType = "OtherworldlyPatrons";
                    label_Prestige.Text = "Patron";
                    break;
                case Classes.Wizard:
                    combo_Prestige.DataSource =ExtensionMethods.GetEnumNames(typeof(ArcaneTraditions));
                    tempPrestigeType = "ArcaneTraditions";
                    label_Prestige.Text = "Tradition";
                    break;
                default:
                    tempPrestigeType = "None";
                    label_Prestige.Text = "Prestige";
                    break;
            }
        }
        private void setEquipment(ItemTypes item)
        {
            switch(item)
            {
                case ItemTypes.Armor:
                    pan_Weapon.Visible = false;
                    pan_Armor.Visible = true;
                    break;
                case ItemTypes.Weapon:
                    pan_Armor.Visible = false;
                    pan_Weapon.Visible = true;
                    break;
                default:
                    pan_Weapon.Visible = false;
                    pan_Armor.Visible = false;
                    break;
            }
        }
        private void displaySpellInfo(Spell s)
        {
            Spell_Name.Text = "Spell Name : " + s.sName;
            Spell_Class_Level.Text = "Spell Level : " + s.getClass() + " " + s.getLevel();
            Spell_Range.Text = "Spell Range : " + s.sRange;
            Spell_CastTime.Text = "Spell Cast Time : " + s.sCastTime;
            Spell_Duration.Text = "Spell Duration : " + s.sDuration;
            Spell_Components.Text = "Spell Components : " + s.sComponents;
            Spell_Effects.Text = "Spell Effects : " + s.sEffect;
        }
        private void hideSpellInfo()
        {
            Spell_Name.Text = "Spell Name : " ;
            Spell_Class_Level.Text = "Spell Level : ";
            Spell_Range.Text = "Spell Range : ";
            Spell_CastTime.Text = "Spell Cast Time : ";
            Spell_Duration.Text = "Spell Duration : ";
            Spell_Components.Text = "Spell Components : ";
            Spell_Effects.Text = "Spell Effects : ";
        }
        private void displayItemInfo(Equipment s)
        {
            Item_Name.Text = s.Name;
            Item_Effects.Text = "Additional Information : " + s.Effects;
            Item_Value.Text = Money.GoldToCoins(s.Value);
        }
        private void hideItemInfo()
        {
            Item_Name.Text = "Item Name : ";
            Item_Effects.Text = "Additional Information : ";
            Item_Value.Text = "Item Value : ";
        }
        #endregion
        #region Validation
        private void checkSpellCasting(Classes c)
        {
            switch (c)
            {
                case Classes.Bard:
                    tempIsCaster = true;
                    break;
                case Classes.Cleric:
                    tempIsCaster = true;
                    break;
                case Classes.Druid:
                    tempIsCaster = true;
                    break;
                case Classes.Paladin:
                    tempIsCaster = true;
                    break;
                case Classes.Ranger:
                    tempIsCaster = true;
                    break;
                case Classes.Sorcerer:
                    tempIsCaster = true;
                    break;
                case Classes.Warlock:
                    tempIsCaster = true;
                    break;
                case Classes.Wizard:
                    tempIsCaster = true;
                    break;
                default:
                    tempIsCaster = false;
                    break;
            }
            tab_CharSpells.Enabled = tempIsCaster;
        }
        private void checkSpellCasting(Classes c, SubClass s)
        {
            switch (c)
            {
                case Classes.Fighter:
                    if(s.GetDescription() == "Eldritch Knight")
                    {
                        tempIsCaster = true;
                    }
                    break;
                case Classes.Monk:
                    if(s.GetDescription() == "Way of the Four Elements")
                    {
                        tempIsCaster = true;
                    }
                    break;
                case Classes.Rogue:
                    if(s.GetDescription() == "Arcane Trickster")
                    {
                        tempIsCaster = true;
                    }
                    break;
                default:
                    break;
            }
            tab_CharSpells.Enabled = tempIsCaster;
        }
        #endregion
        #endregion

        #region Event Handlers
        //Change index events
        private void combo_Race_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubRaces((string)combo_Race.SelectedValue);
        }
        private void combo_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            //The Class has changed. This means that certain things change:
            //1. Spells may or may not be permitted.
            //2. The Prestige Class fields need to change also
            Classes selClass = combo_Class.SelectedItem.ToString().ParseEnum<Classes>();
            checkSpellCasting(selClass);
            setPrestige(selClass);
        }
        private void combo_SubClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Classes selClass = combo_Class.SelectedItem.ToString().ParseEnum<Classes>();
            string selSub = combo_Prestige.SelectedItem.ToString();
            SubClass subC = new SubClass(selClass, selSub);
            checkSpellCasting(selClass, subC);
        }
        private void list_KnownSpells_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedSpell = list_KnownSpells.SelectedIndex;
            if(selectedSpell < 0) { selectedSpell = 0; }
            if (tempSpells.Count > 0)
            {
                displaySpellInfo(tempSpells[selectedSpell]); 
            }
            else
            {
                hideSpellInfo();
            }
        }
        private void list_Equipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItem = list_Equipment.SelectedIndex;
            if(selectedItem < 0) { selectedItem = 0; }
            if (tempEquipment.Count > 0)
            {
                displayItemInfo(tempEquipment[selectedItem]); 
            }
            else
            {
                hideItemInfo();
            }
        }
        private void combo_ItemTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = combo_ItemTypes.SelectedItem.ToString();
            if (selected == string.Empty)
            {
                selected = "None";
            }
            ItemTypes item = selected.ParseEnum<ItemTypes>();
            setEquipment(item);
        }
        private void list_Characters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_Characters.SelectedIndex > -1)
            {
                SelectedCharacter = list_Characters.SelectedIndex;
                LoadCharacter(allCharacters[SelectedCharacter]);
            }
        }
        //Event for general use
        private void txt_Enter_SelectAll(object sender, EventArgs e)
        {
            if (sender is NumericUpDown)
            {
                NumericUpDown field = (NumericUpDown)sender;
                field.Select(0, field.Value.ToString().Length);
            }
            if (sender is TextBox)
            {
                TextBox field = (TextBox)sender;
                field.Select(0, field.Text.Length);
            }
        }
        //Menu events
        private void saveListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Add SaveFileDialog() first to set SaveLocation
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "bin";
            saveFile.Filter = "Character Sets (*.bin)|*.bin";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                SaveLocation = saveFile.FileName;
                allCharacters.serialize(SaveLocation);
                changesMade = false;
                AppLog.WriteLog("Saving " + SaveLocation);
            }
        }
        private void loadListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Add OpenFileDialog() first to set SaveLocation
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "bin";
            openFile.Filter = "Character Sets (*.bin)|*.bin";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                SaveLocation = openFile.FileName;
                allCharacters = SaveLocation.deserialize<Character>();
                savingNloading = true;
                refreshCharacters();
                changesMade = false;
                refreshXPForm();
                AppLog.WriteLog("Loading " + SaveLocation);
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allCharacters.Count > 0 && changesMade)
            {
                //Should ask to save changes.
                DialogResult save = MessageBox.Show("Do you want to save your character list?", "Save before exiting?", MessageBoxButtons.YesNoCancel);
                if (save == DialogResult.No)
                {
                    Close();
                }
                else if (save == DialogResult.Yes)
                {
                    //Add SaveFileDialog() first to set SaveLocation
                    allCharacters.serialize(SaveLocation);
                    AppLog.WriteLog("Saving " + SaveLocation);
                    AppLog.WriteLog("Ending Application");
                    Close();
                }
            }
            else
            {
                AppLog.WriteLog("Ending Application");
                Close();
            }
            
        }
        private void experienceCalculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Application.OpenForms.OfType<XPCalc>().Count() > 0)
            {
                Application.OpenForms.OfType<XPCalc>().First().refreshList();
                Application.OpenForms.OfType<XPCalc>().First().Select();
            }
            else
            {
                XPCalc window = new XPCalc();
                window.Show();
            }

        }
        private void diceRollerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<DiceRoller>().Count() > 0)
            {
                Application.OpenForms.OfType<DiceRoller>().First().Select();
            }
            else
            {
                DiceRoller window = new DiceRoller();
                window.Show();
            }
        }
        private void characterTrackerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<CharTracker>().Count() > 0)
            {
                Application.OpenForms.OfType<CharTracker>().First().Select();
            }
            else
            {
                CharTracker window = new CharTracker();
                window.Show();
            }
        }
        private void combatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<CombatTracking>().Count() > 0)
            {
                Application.OpenForms.OfType<CombatTracking>().First().Select();
            }
            else
            {
                CombatTracking window = new CombatTracking();
                window.Show();
            }
        }
        //Button events
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (allCharacters == null)
            {
                allCharacters = new List<Character>();
            }
            //Add Character to the list of characters if None is selected
            if (SelectedCharacter == -1)
            {
                //Create character based on entered values
                Character newCharacter = SaveCharacter();
                allCharacters.Add(newCharacter);
                refreshXPForm();
            }
            //Update the selected character if there is one selected
            else
            {
                SaveCharacter(SelectedCharacter);
            }
            //Refresh the box so you can see the new character
            refreshCharacters();
            changesMade = true;
        }
        private void btn_Load_Click(object sender, EventArgs e)
        {
            if(list_Characters.SelectedIndex > -1)
            {
                SelectedCharacter = list_Characters.SelectedIndex;
                LoadCharacter(allCharacters[SelectedCharacter]);
            }
            else
            {
                MessageBox.Show("Please select a character from the list.");
            }
        }
        private void btn_New_Click(object sender, EventArgs e)
        {
            SelectedCharacter = -1;
            list_Characters.SelectedIndex = -1;
            ResetControls();
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            SelectedCharacter = list_Characters.SelectedIndex;
            allCharacters.Remove(allCharacters[SelectedCharacter]);
            list_Characters.SelectedIndex = -1;
            refreshCharacters();
            changesMade = true;
            refreshXPForm();
        }
        private void btn_SaveProf_Click(object sender, EventArgs e)
        {
            string type = combo_ProfType.SelectedItem.ToString();
            Proficiencies cProf = new Proficiencies(type.ParseEnum<ProficincyTypes>(), txt_ProfName.Text);
            tempProficiencies.Add(cProf);
            combo_ProfType.SelectedIndex = 0;
            txt_ProfName.Text = string.Empty;
            refreshProficiencies();
        }
        private void btn_DelProf_Click(object sender, EventArgs e)
        {
            if (list_Proficiencies.SelectedIndex > -1)
            {
                tempProficiencies.RemoveAt(list_Proficiencies.SelectedIndex);
                refreshProficiencies();
            }
            else
            {
                MessageBox.Show("Please select a proficiency to delete.");
            }
        }
        private void btn_SaveSpell_Click(object sender, EventArgs e)
        {
            if (tempSpells == null)
            {
                tempSpells = new List<Spell>();
            }
            tempSpells.Add(createSpell());
            refreshSpells();
        }
        private void btn_NewSpell_Click(object sender, EventArgs e)
        {
            resetSpellsControls();
        }
        private void btn_DeleteSpell_Click(object sender, EventArgs e)
        {
            if (list_KnownSpells.SelectedIndex != -1)
            {
                tempSpells.RemoveAt(list_KnownSpells.SelectedIndex);
                refreshSpells();
            }
            else
            {
                MessageBox.Show("Please select a spell to delete.");
            }
        }
        private void btn_SaveItem_Click(object sender, EventArgs e)
        {
            //list_Equipment.Items.Add(createEquipment());
            if (tempEquipment == null)
            {
                tempEquipment = new List<Equipment>();
            }
            tempEquipment.Add(createEquipment());
            refreshEquipment();
        }
        private void btn_DeleteItem_Click(object sender, EventArgs e)
        {
            if (list_Equipment.SelectedIndex != -1)
            {
                //list_Equipment.Items.RemoveAt(list_Equipment.SelectedIndex);
                tempEquipment.RemoveAt(list_Equipment.SelectedIndex);
                refreshEquipment();
            }
            else
            {
                MessageBox.Show("Please select an item to delete from the inventory.");
            }
        }
        
        //Thus far unused event. In theory:
        //When a tab is changed, the required binding and loading of that tab takes place.
        //This moves some of the load time from when the application is started to throughout the runtime.
        //I'm on the fence about this particular thing as it might adversely affect usability.
        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            //string tabName = e.TabPage.Text;
            ////MessageBox.Show(tabName);
            //switch(tabName)
            //{
            //    case "Character Sheet":
            //        break;
            //    case "Equipment":
            //        break;
            //    case "Spells":
            //        BindSpellControls();
            //        break;
            //    case "Player Record":
            //        break;
            //    default:
            //        break;
            //}
        }

        #endregion
    }
}
