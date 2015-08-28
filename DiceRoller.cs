using DnD5e.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DnD5e
{
    public partial class DiceRoller : Form
    {
        public DiceRoller()
        {
            InitializeComponent();
            WeaponInitialization();
            combo_Weapons.DataSource = Weapons;
            RefreshRolls();
        }
        public static List<WeaponType> Weapons = new List<WeaponType>();
        public static List<string> Rolls = new List<string>();
        #region Methods
        private void RefreshRolls()
        {
            list_Rolls.DataSource = null;
            list_Rolls.DataSource = Rolls;
        }
        private void WeaponInitialization()
        {
            Weapons.Add(new WeaponType("club", "1d4", "", false, false, false));
            Weapons.Add(new WeaponType("dagger", "1d4", "", false, false, true));
            Weapons.Add(new WeaponType("great club", "1d8", "", false, true, false));
            Weapons.Add(new WeaponType("handaxe", "1d6", "", false, false, true));
            Weapons.Add(new WeaponType("javelin", "1d6", "", false, false, true));
            Weapons.Add(new WeaponType("light hammer", "1d4", "", false, false, true));
            Weapons.Add(new WeaponType("mace", "1d6", "", false, false, false));
            Weapons.Add(new WeaponType("quarterstaff", "1d6", "1d8", true, false, false));
            Weapons.Add(new WeaponType("sickle", "1d4", "", false, false, false));
            Weapons.Add(new WeaponType("spear", "1d6", "1d8", true, false, true));
            Weapons.Add(new WeaponType("light crossbow", "1d8", "", false, false, false));
            Weapons.Add(new WeaponType("dart", "1d4", "", false, false, true));
            Weapons.Add(new WeaponType("shortbow", "1d6", "", false, true, false));
            Weapons.Add(new WeaponType("sling", "1d4", "", false, false, false));
            Weapons.Add(new WeaponType("battleaxe", "1d8", "1d10", true, false, false));
            Weapons.Add(new WeaponType("flail", "1d8", "", false, false, false));
            Weapons.Add(new WeaponType("glaive", "1d10", "", false, true, false));
            Weapons.Add(new WeaponType("greataxe", "1d12", "", false, true, false));
            Weapons.Add(new WeaponType("greatsword", "2d6", "", false, true, false));
            Weapons.Add(new WeaponType("halberd", "1d10", "", false, true, false));
            Weapons.Add(new WeaponType("lance", "1d12", "", false, true, false));
            Weapons.Add(new WeaponType("longsword", "1d8", "1d10", true, false, false));
            Weapons.Add(new WeaponType("maul", "2d6", "", false, true, false));
            Weapons.Add(new WeaponType("morningstar", "1d8", "", false, false, false));
            Weapons.Add(new WeaponType("pike", "1d10", "", false, true, false));
            Weapons.Add(new WeaponType("rapier", "1d8", "", false, false, false));
            Weapons.Add(new WeaponType("scimitar", "1d6", "", false, false, false));
            Weapons.Add(new WeaponType("shortsword", "1d6", "", false, false, false));
            Weapons.Add(new WeaponType("trident", "1d6", "1d8", true, false, true));
            Weapons.Add(new WeaponType("warpick", "1d8", "", false, false, false));
            Weapons.Add(new WeaponType("warhammer", "1d8", "1d10", true, false, false));
            Weapons.Add(new WeaponType("whip", "1d4", "", false, false, false));
            Weapons.Add(new WeaponType("blowgun", "1d1", "", false, false, false));
            Weapons.Add(new WeaponType("hand crossbow", "1d6", "", false, false, false));
            Weapons.Add(new WeaponType("heavy crossbow", "1d10", "", false, true, false));
            Weapons.Add(new WeaponType("longbow", "1d8", "", false, true, false));
            Weapons.Add(new WeaponType("net", "0d0", "", false, false, true));
        }
        private int rollDamage(WeaponType w)
        {
            int DamageDiceType;
            int DamageDiceNumber;
            if(w.isVersitile && isTwoHanded.Checked)
            {
                DamageDiceType = Dice.ParseDiceType(w.VersitileDamage);
                DamageDiceNumber = Dice.ParseDiceNumber(w.VersitileDamage);
            }
            else
            {
                DamageDiceType = Dice.ParseDiceType(w.Damage);
                DamageDiceNumber = Dice.ParseDiceNumber(w.Damage);
            }
            return Dice.rollDice(DamageDiceType, DamageDiceNumber);
        }
        #endregion
        #region Even Handlers
        private void btn_RollDamage_Click(object sender, EventArgs e)
        {
            int DamageRoll = rollDamage(Weapons[combo_Weapons.SelectedIndex]);
            //MessageBox.Show(DamageRoll.ToString());
            if(isCritical.Checked)
            {
                DamageRoll += rollDamage(Weapons[combo_Weapons.SelectedIndex]);
            }
            if(txt_DamageBonus.Text != string.Empty)
            {
                int bonus;
                if(!int.TryParse(txt_DamageBonus.Text, out bonus))
                {
                    bonus = 0;
                }
                DamageRoll += bonus;
            }
            string thisRoll = Weapons[combo_Weapons.SelectedIndex].ToString() + " : " + DamageRoll.ToString();
            Rolls.Add(thisRoll);
            RefreshRolls();
        }
        private void btn_ClearRolls_Click(object sender, EventArgs e)
        {
            Rolls.Clear();
            RefreshRolls();
        }
        private void btn_MakeRoll_Click(object sender, EventArgs e)
        {
            if(txt_Roll.Text == string.Empty)
            {
                MessageBox.Show("Please enter a roll.");
                return;
            }
            string name;
            string roll;
            if (txt_RollName.Text == string.Empty)
            {
                name = txt_Roll.Text;
            }
            else
            {
                name = txt_RollName.Text;
            }
            int diceNum = Dice.ParseDiceNumber(txt_Roll.Text);
            int diceType = Dice.ParseDiceType(txt_Roll.Text);
            int result = Dice.rollDice(diceType,diceNum);
            roll = name + " : " + result.ToString();
            Rolls.Add(roll);
            RefreshRolls();

        }
        private void btn_Initiative_Click(object sender, EventArgs e)
        {
            string roll;
            int d = 6;
            roll = "Initiative: " + Dice.rollDice(d, 1).ToString();
            Rolls.Add(roll);
            RefreshRolls();
        }
        private void btn_ToHit_Click(object sender, EventArgs e)
        {
            string roll;
            roll = "To Hit Roll: " + Dice.rollDice(20, 1).ToString();
            Rolls.Add(roll);
            RefreshRolls();
        }
        private void btn_SkillCheck_Click(object sender, EventArgs e)
        {
            string roll;
            roll = "Skill Check Roll: " + Dice.rollDice(20, 1).ToString();
            Rolls.Add(roll);
            RefreshRolls();
        }
        private void btn_Percent_Click(object sender, EventArgs e)
        {
            string roll;
            roll = "Percent: " + Dice.rollDice(100, 1).ToString() + "%";
            Rolls.Add(roll);
            RefreshRolls();
        }
        #endregion
    }
}
