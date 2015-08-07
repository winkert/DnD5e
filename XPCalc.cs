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
    public partial class XPCalc : Form
    {
        public XPCalc()
        {
            InitializeComponent();
            refreshList();
        }
        private int selectedChar = -1;
        #region Methods
        public void refreshList()
        {
            combo_Characters.DataSource = null;
            combo_Characters.DataSource = MainForm.allCharacters;
        }
        #endregion
        #region Event Handlers
        private void btn_AddXP_Click(object sender, EventArgs e)
        {
            int xpAdded;
            if(txt_XP.Text == string.Empty)
            {
                MessageBox.Show("Please enter a value in the text box.");
                return;
            }
            if(int.TryParse(txt_XP.Text, out xpAdded))
            {
                MainForm.allCharacters[selectedChar].AddXP(xpAdded);
                Player_XP.Text = MainForm.allCharacters[selectedChar].Experience + " (" + MainForm.allCharacters[selectedChar].Level + ")";
            }
            else
            {
                MessageBox.Show("Please enter an integer value in the text box.");
                return;
            }
            MainForm.changesMade = true;
            txt_XP.Text = string.Empty;
        }
        private void combo_Characters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Characters.SelectedItem.ToString() != null)
            {
                selectedChar = combo_Characters.SelectedIndex;
                Player_Name.Text = MainForm.allCharacters[selectedChar].pName;
                Player_Race.Text = MainForm.allCharacters[selectedChar].Race;
                Player_Class.Text = MainForm.allCharacters[selectedChar].Class;
                Player_XP.Text = MainForm.allCharacters[selectedChar].Experience + " (" + MainForm.allCharacters[selectedChar].Level + ")";
            }
        }
        private void btn_AddToAll_Click(object sender, EventArgs e)
        {
            int xpAdded;
            if (txt_XP.Text == string.Empty)
            {
                MessageBox.Show("Please enter a value in the text box.");
                return;
            }
            if (int.TryParse(txt_XP.Text, out xpAdded))
            {
                foreach(Character c in MainForm.allCharacters)
                {
                    c.AddXP(xpAdded);
                }

                Player_XP.Text = MainForm.allCharacters[selectedChar].Experience + " (" + MainForm.allCharacters[selectedChar].Level + ")";
            }
            else
            {
                MessageBox.Show("Please enter an integer value in the text box.");
                return;
            }
            MainForm.changesMade = true;
            txt_XP.Text = string.Empty;
        }
        #endregion
    }
}
