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
                //Build a GroupBox with TextBox and such
                //Set Tag attribute to I for each control. This will allow for dynamic controls
                //Display:
                //Dropdown of Weapons and Armor
                //  - Checkbox for "use Versatile" for weapons which are versatile
                //Dynamic fields:
                //Armor Class
                //Damage
                GroupBox characterBox = new GroupBox();
                Character c = MainForm.allCharacters[i];
                characterBox.Text = c.ToString();
                characterBox.Height = 400;
                characterBox.Width = 200;
                Label Abilities = createLabel("Abilities:", 5, 15, FontStyle.Bold);
                Label cSt = createLabel("Strength: " + c.AttributeString("Strength"), 10, 30);
                Label cDex = createLabel("Dexterity: " + c.AttributeString("Dexterity"), 10, 50);
                Label cCon = createLabel("Constitution: " + c.AttributeString("Constitution"), 10, 70);
                Label cInt = createLabel("Intelligence: " + c.AttributeString("Intelligence"), 10, 90);
                Label cWis = createLabel("Wisdom: " + c.AttributeString("Wisdom"), 10, 110);
                Label cChr = createLabel("Charisma: " + c.AttributeString("Charisma"), 10, 130);

                ///Interesting conundrum:
                ///     A player can use a shield and armor
                ///     A player could use more than one weapon
                ComboBox cArmors = defaultComboBox();
                ComboBox cWeapons = defaultComboBox();



                ComboBox cArmors2 = defaultComboBox();
                ComboBox cWeapons2 = defaultComboBox();

                TextBox ArmorClass = defaultTextbox();
                TextBox WeaponDamage = defaultTextbox();

                cArmors.SelectedIndexChanged += armor_dropdown_IndexChange;
                cArmors.DataSource = c.pEquipment.DefaultIfEmpty().OfType<Armor>().ToList();
                cArmors.Tag = c.getBonus(c.pDexterity).ToString();
                cArmors.Location = new Point(10, 150);

                cWeapons.SelectedIndexChanged += weapon_dropdown_IndexChange;
                cWeapons.DataSource = c.pEquipment.DefaultIfEmpty().OfType<Weapon>().ToList();
                cWeapons.Tag = i.ToString();
                cWeapons.Location = new Point(10, 170);

                ArmorClass.Tag = "pArmor";
                ArmorClass.Location = new Point(10, 195);

                WeaponDamage.Tag = "pWeapon";
                WeaponDamage.Location = new Point(10, 220);

                characterBox.Controls.Add(Abilities);
                characterBox.Controls.Add(cSt);
                characterBox.Controls.Add(cDex);
                characterBox.Controls.Add(cCon);
                characterBox.Controls.Add(cInt);
                characterBox.Controls.Add(cWis);
                characterBox.Controls.Add(cChr);

                characterBox.Controls.Add(cArmors);
                characterBox.Controls.Add(cWeapons);

                characterBox.Controls.Add(ArmorClass);
                characterBox.Controls.Add(WeaponDamage);

                flow_CharTrack.Controls.Add(characterBox);
            }
            addScrollBar();


        }
        /// <summary>
        /// Creates a label as specified in the parameters.
        /// </summary>
        /// <param name="text">Text of the label</param>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        /// <param name="fs">Optional: Font style</param>
        /// <returns>new Label()</returns>
        private Label createLabel(string text, int x, int y, FontStyle fs = FontStyle.Regular)
        {
            Label thisLabel = new Label();
            thisLabel.Text = text;
            thisLabel.Font = new Font(new FontFamily("Palatino Linotype"), 9f, fs);
            thisLabel.Height = 18;
            thisLabel.Width = 185;
            thisLabel.Location = new Point(x, y);
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
        private void addScrollBar()
        {
            VScrollBar scroll = new VScrollBar();
            scroll.Parent = flow_CharTrack;
            scroll.Dock = DockStyle.Right;
        }
        private string findAC(int ac, ArmorTypes armor, int dexMod)
        {
            switch (armor)
            {
                case ArmorTypes.LightArmor:
                    return (ac + dexMod).ToString();
                case ArmorTypes.MediumArmor:
                    if (dexMod > 2)
                        return (ac + 2).ToString();
                    else
                        return (ac + dexMod).ToString();
                default:
                    return ac.ToString();
            }
        }
        #region Event Handles
        private void armor_dropdown_IndexChange(object sender, EventArgs e)
        {
            ComboBox select = (ComboBox)sender;
            Armor selectedArmor = (Armor)select.SelectedItem;
            select.Parent.Controls.Cast<Control>().First(k => (string)k.Tag == "pArmor").Text = "AC: " + findAC(selectedArmor.AC, selectedArmor.Type, int.Parse((string)select.Tag));

        }
        private void weapon_dropdown_IndexChange(object sender, EventArgs e)
        {
            ComboBox select = (ComboBox)sender;
            Weapon selectedWeapon = (Weapon)select.SelectedItem;
            string bonus;
            if(selectedWeapon.WeaponType == WeaponClasses.SimpleRange || selectedWeapon.WeaponType == WeaponClasses.MartialRange)
            {
                Character c = MainForm.allCharacters[int.Parse((string)select.Tag)];
                if (c.getBonus(c.pDexterity) > 0)
                    bonus = "+" + c.getBonus(c.pDexterity).ToString();
                else if (c.getBonus(c.pDexterity) < 0)
                    bonus = c.getBonus(c.pDexterity).ToString();
                else
                    bonus = string.Empty;
            }
            else
            {
                Character c = MainForm.allCharacters[int.Parse((string)select.Tag)];
                if (c.getBonus(c.pStrength) > 0)
                    bonus = "+" + c.getBonus(c.pStrength).ToString();
                else if (c.getBonus(c.pStrength) < 0)
                    bonus = c.getBonus(c.pStrength).ToString();
                else
                    bonus = string.Empty;
            }
            select.Parent.Controls.Cast<Control>().First(k => (string)k.Tag == "pWeapon").Text = "Damage: " + selectedWeapon.Damage() + " " + bonus;

        }
        private void checkbox_CheckStateChange(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
