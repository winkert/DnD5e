using DnD5e.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DnD5e
{
    public partial class CombatTracking : Form
    {
        public CombatTracking()
        {
            InitializeComponent();
            SetControlsData();
        }
        #region Fields
        private List<Character> combat_Actors = new List<Character>();
        private List<string> Initiative_List = new List<string>();
        private int SelectedCombatant = -1;
        #endregion
        #region Methods
        private void SetControlsData()
        {
            combo_Characters.DataSource = MainForm.allCharacters;
            combo_mSize.DataSource = ExtensionMethods.GetEnumNames(typeof(MonsterSize));
            combo_mType.DataSource =ExtensionMethods.GetEnumNames(typeof(MonsterType));
            list_Combatants.DataSource = Initiative_List;
        }
        private Monster createMonster()
        {
            //invalid argument exception
            Monster m = new Monster(txt_mName.Text, combo_mSize.SelectedItem.ToString().ParseEnum<MonsterSize>(), combo_mType.SelectedItem.ToString().ParseEnum<MonsterType>());
            m.setHP(txt_mHP.Text);
            return m;
        }
        private void AddCombatant(Character c, int init)
        {
            c.Initiative = init;
            combat_Actors.Add(c);
            combat_Actors = combat_Actors.OrderBy(i => i.Initiative).Distinct().ToList();
        }
        private void RefreshCombatList()
        {
            Initiative_List.Clear();
            foreach (Character chr in combat_Actors)
            {
                Initiative_List.Add(chr.Initiative + " : " + chr.ToString() + "  (" + chr.HitPoints.ToString() +  "hp )");
            }
            list_Combatants.DataSource = null;
            list_Combatants.DataSource = Initiative_List;
            list_Combatants.SelectedIndex = SelectedCombatant;
        }
        private int RollInitiative()
        {
            int init = 20;
            return Dice.rollDice(init);
        }
        
        #endregion
        #region Event Handlers
        private void btn_CharInitiative_Click(object sender, EventArgs e)
        {
            int init;
            if (!int.TryParse(txt_Initiative.Text, out init))
                init = RollInitiative();
            AddCombatant((Character)combo_Characters.SelectedItem, init);
            SelectedCombatant = -1;
            RefreshCombatList();
        }
        private void btn_MonsterInitiative_Click(object sender, EventArgs e)
        {
            int dexMod;
            if (!int.TryParse(txt_DexModifier.Text, out dexMod))
                dexMod = 0;
            AddCombatant(createMonster(), RollInitiative() + dexMod);
            SelectedCombatant = -1;
            RefreshCombatList();
        }
        private void btn_RemoveChar_Click(object sender, EventArgs e)
        {
            combat_Actors.RemoveAt(list_Combatants.SelectedIndex);
            SelectedCombatant = -1;
            RefreshCombatList();
        }
        private void btn_Damage_Click(object sender, EventArgs e)
        {
            SelectedCombatant = list_Combatants.SelectedIndex;
            int hp;
            if(int.TryParse(txt_HPChange.Text,out hp))
            {
                combat_Actors[SelectedCombatant].setHP((combat_Actors[SelectedCombatant].HitPoints - hp).ToString());
            }
            else //Roll Dice
            {
                int dType = Dice.ParseDiceType(txt_HPChange.Text);
                int dNum = Dice.ParseDiceNumber(txt_HPChange.Text);
                int dBonus = Dice.findBonus(txt_HPChange.Text);
                combat_Actors[SelectedCombatant].setHP((combat_Actors[SelectedCombatant].HitPoints - (Dice.rollDice(dType,dNum) + dBonus)).ToString());
            }
            if(combat_Actors[SelectedCombatant].HitPoints < 1)
            {
                combat_Actors.RemoveAt(SelectedCombatant);
            }
            RefreshCombatList();
        }
        private void btn_Heal_Click(object sender, EventArgs e)
        {
            SelectedCombatant = list_Combatants.SelectedIndex;
            int hp;
            if (int.TryParse(txt_HPChange.Text, out hp))
            {
                combat_Actors[SelectedCombatant].setHP((combat_Actors[SelectedCombatant].HitPoints + hp).ToString());
            }
            else //Roll Dice
            {
                int dType = Dice.ParseDiceType(txt_HPChange.Text);
                int dNum = Dice.ParseDiceNumber(txt_HPChange.Text);
                int dBonus = Dice.findBonus(txt_HPChange.Text);
                combat_Actors[SelectedCombatant].setHP((combat_Actors[SelectedCombatant].HitPoints + (Dice.rollDice(dType,dNum) + dBonus)).ToString());
            }
            if (combat_Actors[SelectedCombatant].HitPoints > combat_Actors[SelectedCombatant].MaxHitPoints)
            {
                combat_Actors[SelectedCombatant].setHP(combat_Actors[SelectedCombatant].MaxHitPoints.ToString());
            }
            RefreshCombatList();
        }
        #endregion


    }
}
