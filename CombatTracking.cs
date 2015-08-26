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
        #endregion
        #region Methods
        private void SetControlsData()
        {
            combo_Characters.DataSource = MainForm.allCharacters;
            combo_mSize.DataSource = GetEnumNames(typeof(MonsterSize));
            combo_mType.DataSource = GetEnumNames(typeof(MonsterType));
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
                Initiative_List.Add(chr.ToString() + " (" + chr.Initiative + ")");
            }
            list_Combatants.DataSource = null;
            list_Combatants.DataSource = Initiative_List;
        }
        private int RollInitiative()
        {
            int init = 20;
            return init.rollDice();
        }
        public string[] GetEnumNames(Type t)
        {
            Array EnumValues = Enum.GetValues(t);
            string[] items = new string[EnumValues.Length];
            int i = 0;
            foreach (Enum e in EnumValues)
            {
                items[i] = e.GetDescription();
                i++;
            }
            return items;
        }
        #endregion
        #region Event Handlers
        private void btn_CharInitiative_Click(object sender, EventArgs e)
        {
            int init;
            if (!int.TryParse(txt_Initiative.Text, out init))
                init = RollInitiative();
            AddCombatant((Character)combo_Characters.SelectedItem, init);
            RefreshCombatList();
        }
        private void btn_MonsterInitiative_Click(object sender, EventArgs e)
        {
            int dexMod;
            if (!int.TryParse(txt_DexModifier.Text, out dexMod))
                dexMod = 0;
            AddCombatant(createMonster(), RollInitiative() + dexMod);
            RefreshCombatList();
        }
        private void btn_RemoveChar_Click(object sender, EventArgs e)
        {
            combat_Actors.RemoveAt(list_Combatants.SelectedIndex);
            RefreshCombatList();
        }
        #endregion
    }
}
