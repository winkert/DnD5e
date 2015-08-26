using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnD5e
{
    public partial class CharTracker : Form
    {
        public CharTracker()
        {
            InitializeComponent();
            LoadCharacters();
        }

        private void LoadCharacters()
        {
            for (int i = 0; i < MainForm.allCharacters.Count; i++)
            {
                Character c = MainForm.allCharacters[i];
                #region Create Controls
                GroupBox characterBox = new GroupBox();
                FlowLayoutPanel innerSet = new FlowLayoutPanel();

                Label Abilities = createLabel("Abilities:", FontStyle.Bold);
                Label cSt = createLabel("Strength: " + c.AttributeString("Strength"));
                Label cDex = createLabel("Dexterity: " + c.AttributeString("Dexterity"));
                Label cCon = createLabel("Constitution: " + c.AttributeString("Constitution"));
                Label cInt = createLabel("Intelligence: " + c.AttributeString("Intelligence"));
                Label cWis = createLabel("Wisdom: " + c.AttributeString("Wisdom"));
                Label cChr = createLabel("Charisma: " + c.AttributeString("Charisma"));

                ComboBox cArmors = defaultComboBox();
                ComboBox cWeapons = defaultComboBox();

                CheckBox hasShield = new CheckBox();
                CheckBox hasWeapons = new CheckBox();

                ComboBox cArmors2 = defaultComboBox();
                ComboBox cWeapons2 = defaultComboBox();

                Label ArmorClass = createLabel(FontStyle.Bold);
                Label WeaponDamage = createLabel(FontStyle.Bold);
                #endregion
                #region Define Controls
                characterBox.Text = c.ToString();
                characterBox.Height = 400;
                characterBox.Width = 200;

                innerSet.AutoScroll = true;
                innerSet.FlowDirection = FlowDirection.TopDown;
                innerSet.AutoSize = true;
                innerSet.WrapContents = false;
                innerSet.Location = new Point(10, 15);
                innerSet.Margin = new Padding(10);
                innerSet.Dock = DockStyle.Fill;

                cArmors.SelectedIndexChanged += armor_dropdown_IndexChange;
                cArmors.DataSource = c.Equipment.DefaultIfEmpty().OfType<Armor>().ToList();
                cArmors.Tag = c.getBonus(c.pDexterity).ToString();
                cArmors.Name = "Armor";

                cWeapons.SelectedIndexChanged += weapon_dropdown_IndexChange;
                cWeapons.DataSource = c.Equipment.DefaultIfEmpty().OfType<Weapon>().ToList();
                cWeapons.Tag = i.ToString();
                cWeapons.Name = "First_Weapon";

                hasShield.Checked = false;
                hasShield.CheckStateChanged += checkbox_CheckStateChange;
                hasShield.Tag = "shield";
                hasShield.Text = "Shield";

                hasWeapons.Checked = false;
                hasWeapons.CheckStateChanged += checkbox_CheckStateChange;
                hasWeapons.Tag = "weapon";
                hasWeapons.Text = "Two Weapons";

                cArmors2.Visible = false;
                cArmors2.Tag = c.getBonus(c.pDexterity).ToString();
                cArmors2.Name = "Shield_Combo";
                cArmors2.DataSource = c.Equipment.DefaultIfEmpty().OfType<Armor>().ToList();

                cWeapons2.Visible = false;
                cWeapons2.Tag = i.ToString();
                cWeapons2.Name = "Second_Weapon";
                cWeapons2.SelectedIndexChanged += weapon_dropdown_IndexChange;
                cWeapons2.DataSource = c.Equipment.DefaultIfEmpty().OfType<Weapon>().ToList();

                ArmorClass.Tag = "pArmor";
                WeaponDamage.Tag = "pWeapon";
                #endregion
                #region Add Controls
                innerSet.Controls.Add(Abilities);
                innerSet.Controls.Add(cSt);
                innerSet.Controls.Add(cDex);
                innerSet.Controls.Add(cCon);
                innerSet.Controls.Add(cInt);
                innerSet.Controls.Add(cWis);
                innerSet.Controls.Add(cChr);

                innerSet.Controls.Add(cArmors);
                innerSet.Controls.Add(cWeapons);

                innerSet.Controls.Add(hasShield);
                innerSet.Controls.Add(hasWeapons);
                innerSet.Controls.Add(cArmors2);
                innerSet.Controls.Add(cWeapons2);

                innerSet.Controls.Add(ArmorClass);
                innerSet.Controls.Add(WeaponDamage);

                if (c.isSpellCaster)
                {
                    ListBox spellList = new ListBox();
                    TextBox spellInfo = defaultTextbox();
                    spellList.Width = 125;
                    spellList.DataSource = c.Spells;
                    spellList.SelectedIndexChanged += spellList_IndexChange;
                    spellInfo.Name = "SpellInfo";
                    innerSet.Controls.Add(spellList);
                    innerSet.Controls.Add(spellInfo);
                }

                characterBox.Controls.Add(innerSet);
                flow_CharTrack.Controls.Add(characterBox);
                #endregion
            }


        }
        /// <summary>
        /// Creates a label as specified in the parameters.
        /// </summary>
        /// <param name="text">Text of the label</param>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        /// <param name="fs">Optional: Font style</param>
        /// <returns>new Label()</returns>
        private Label createLabel(string text, FontStyle fs = FontStyle.Regular)
        {
            Label thisLabel = new Label();
            thisLabel.Text = text;
            thisLabel.Font = new Font(new FontFamily("Palatino Linotype"), 9.5f, fs);
            thisLabel.Height = 18;
            thisLabel.Width = 185;
            thisLabel.Tag = null;
            return thisLabel;
        }
        private Label createLabel(FontStyle fs = FontStyle.Regular)
        {
            Label thisLabel = new Label();
            thisLabel.Font = new Font(new FontFamily("Palatino Linotype"), 9.5f, fs);
            thisLabel.Height = 18;
            thisLabel.Width = 185;
            thisLabel.Tag = null;
            return thisLabel;
        }
        /// <summary>
        /// Creates a default text box.
        /// </summary>
        /// <returns>new TextBox()</returns>
        private TextBox defaultTextbox()
        {
            TextBox text = new TextBox();
            text.ReadOnly = true;
            text.BorderStyle = BorderStyle.None;
            text.BackColor = Color.WhiteSmoke;
            text.Multiline = true;
            text.Width = 125;
            text.Height = 30;
            text.ScrollBars = ScrollBars.Vertical;
            text.Font = new Font(new FontFamily("Palatino Linotype"),10f);
            return text;
        }
        /// <summary>
        /// Creates a default combo box
        /// </summary>
        /// <returns>new ComboBox()</returns>
        private ComboBox defaultComboBox()
        {
            ComboBox combo = new ComboBox();
            combo.Width = 125;
            combo.DropDownWidth = 150;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            return combo;
        }
        private int findAC(int ac, ArmorTypes armor, int dexMod)
        {
            switch (armor)
            {
                case ArmorTypes.LightArmor:
                    return (ac + dexMod);
                case ArmorTypes.MediumArmor:
                    if (dexMod > 2)
                        return (ac + 2);
                    else
                        return (ac + dexMod);
                default:
                    return ac;
            }
        }
        private string findDamageBonus(int strMod, int dexMod, WeaponClasses weapon)
        {
            string bonus;
            if (weapon == WeaponClasses.SimpleRange || weapon == WeaponClasses.MartialRange)
            {
                if (dexMod > 0)
                    bonus = "+" + dexMod.ToString();
                else if (dexMod < 0)
                    bonus = dexMod.ToString();
                else
                    bonus = string.Empty;
            }
            else
            {
                if (strMod > 0)
                    bonus = "+" + strMod.ToString();
                else if (strMod < 0)
                    bonus = strMod.ToString();
                else
                    bonus = string.Empty;
            }
            return bonus;
        }
        #region Event Handles
        private void armor_dropdown_IndexChange(object sender, EventArgs e)
        {
            ComboBox select = (ComboBox)sender;
            Armor selectedArmor = (Armor)select.SelectedItem;
            int totalAC;
            CheckBox shield = (CheckBox)select.Parent.Controls.Cast<Control>().First(k => k.Tag.ToString() == "shield");
            if(shield.Checked)
            {
                ComboBox armor1 = (ComboBox)select.Parent.Controls.Cast<Control>().First(k => k.Name == "Armor");
                ComboBox armor2 = (ComboBox)select.Parent.Controls.Cast<Control>().First(k => k.Name == "Shield_Combo");
                Armor selArmor = (Armor)armor1.SelectedItem;
                Armor selShield = (Armor)armor2.SelectedItem;
                totalAC = findAC(selArmor.AC, selArmor.Type, int.Parse(armor1.Tag.ToString()));
                totalAC += findAC(selShield.AC, selShield.Type, int.Parse(armor2.Tag.ToString()));
            }
            else
            {
                totalAC = findAC(selectedArmor.AC, selectedArmor.Type, int.Parse(select.Tag.ToString()));
            }
            select.Parent.Controls.Cast<Control>().First(k => k.Tag.ToString() == "pArmor").Text = "AC: " + totalAC.ToString();
        }
        private void weapon_dropdown_IndexChange(object sender, EventArgs e)
        {
            ComboBox select = (ComboBox)sender;
            Weapon selectedWeapon = (Weapon)select.SelectedItem;
            Character c = MainForm.allCharacters[int.Parse(select.Tag.ToString())];
            CheckBox dual = (CheckBox)select.Parent.Controls.Cast<Control>().First(k => k.Tag.ToString() == "weapon");
            if(dual.Checked)
            {
                ComboBox weapon1 = (ComboBox)select.Parent.Controls.Cast<Control>().First(k => k.Name == "First_Weapon");
                ComboBox weapon2 = (ComboBox)select.Parent.Controls.Cast<Control>().First(k => k.Name == "Second_Weapon");
                Weapon selWeapon1 = (Weapon)weapon1.SelectedItem;
                Weapon selWeapon2 = (Weapon)weapon2.SelectedItem;
                string damage1 = selWeapon1.Damage() + " " + findDamageBonus(c.getBonus(c.pStrength), c.getBonus(c.pDexterity), selWeapon1.WeaponType);
                string damage2 = selWeapon2.Damage() + " " + findDamageBonus(c.getBonus(c.pStrength), c.getBonus(c.pDexterity), selWeapon2.WeaponType);
                select.Parent.Controls.Cast<Control>().First(k => k.Tag.ToString() == "pWeapon").Text = "Damage: " + damage1 + ", " + damage2;
            }
            else
            {
                string bonus;
                bonus = findDamageBonus(c.getBonus(c.pStrength), c.getBonus(c.pDexterity), selectedWeapon.WeaponType);
                select.Parent.Controls.Cast<Control>().First(k => k.Tag.ToString() == "pWeapon").Text = "Damage: " + selectedWeapon.Damage() + " " + bonus;
            }
        }
        private void checkbox_CheckStateChange(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if((string)box.Tag == "shield")
            {
                //Name = "Shield_Combo"
                box.Parent.Controls.Cast<Control>().First(k => k.Name == "Shield_Combo").Visible = box.Checked;
                box.Parent.Controls.Cast<Control>().First(k => k.Tag.ToString() == "pArmor").Text = string.Empty;
            }
            else
            {
                //Name = "Second_Weapon"
                box.Parent.Controls.Cast<Control>().First(k => k.Name == "Second_Weapon").Visible = box.Checked;
                box.Parent.Controls.Cast<Control>().First(k => k.Tag.ToString() == "pWeapon").Text = string.Empty;
            }
        }
        private void spellList_IndexChange(object sender, EventArgs e)
        {
            ListBox s = (ListBox)sender;
            Spell spell = (Spell)s.SelectedItem;
            s.Parent.Controls.Cast<Control>().First(k => k.Name == "SpellInfo").Text = spell.sEffect;
        }
        #endregion
    }
}
