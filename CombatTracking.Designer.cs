namespace DnD5e
{
    partial class CombatTracking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.combo_Characters = new System.Windows.Forms.ComboBox();
            this.group_Characters = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Initiative = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_CharInitiative = new System.Windows.Forms.Button();
            this.group_Monster = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_XPValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_DexModifier = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_MonsterInitiative = new System.Windows.Forms.Button();
            this.txt_mHP = new System.Windows.Forms.TextBox();
            this.txt_mName = new System.Windows.Forms.TextBox();
            this.combo_mType = new System.Windows.Forms.ComboBox();
            this.combo_mSize = new System.Windows.Forms.ComboBox();
            this.list_Combatants = new System.Windows.Forms.ListBox();
            this.btn_RemoveChar = new System.Windows.Forms.Button();
            this.group_Combat = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_HPChange = new System.Windows.Forms.TextBox();
            this.btn_Heal = new System.Windows.Forms.Button();
            this.btn_Damage = new System.Windows.Forms.Button();
            this.txt_XPGained = new System.Windows.Forms.TextBox();
            this.group_Characters.SuspendLayout();
            this.group_Monster.SuspendLayout();
            this.group_Combat.SuspendLayout();
            this.SuspendLayout();
            // 
            // combo_Characters
            // 
            this.combo_Characters.FormattingEnabled = true;
            this.combo_Characters.Location = new System.Drawing.Point(82, 25);
            this.combo_Characters.Name = "combo_Characters";
            this.combo_Characters.Size = new System.Drawing.Size(196, 21);
            this.combo_Characters.TabIndex = 0;
            // 
            // group_Characters
            // 
            this.group_Characters.Controls.Add(this.label7);
            this.group_Characters.Controls.Add(this.txt_Initiative);
            this.group_Characters.Controls.Add(this.label1);
            this.group_Characters.Controls.Add(this.btn_CharInitiative);
            this.group_Characters.Controls.Add(this.combo_Characters);
            this.group_Characters.Location = new System.Drawing.Point(12, 12);
            this.group_Characters.Name = "group_Characters";
            this.group_Characters.Size = new System.Drawing.Size(290, 91);
            this.group_Characters.TabIndex = 0;
            this.group_Characters.TabStop = false;
            this.group_Characters.Text = "Characters";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(39, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Initiative";
            // 
            // txt_Initiative
            // 
            this.txt_Initiative.Location = new System.Drawing.Point(104, 56);
            this.txt_Initiative.Name = "txt_Initiative";
            this.txt_Initiative.Size = new System.Drawing.Size(84, 20);
            this.txt_Initiative.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Character";
            // 
            // btn_CharInitiative
            // 
            this.btn_CharInitiative.Location = new System.Drawing.Point(194, 52);
            this.btn_CharInitiative.Name = "btn_CharInitiative";
            this.btn_CharInitiative.Size = new System.Drawing.Size(84, 27);
            this.btn_CharInitiative.TabIndex = 2;
            this.btn_CharInitiative.Text = "Roll Initiative";
            this.btn_CharInitiative.UseVisualStyleBackColor = true;
            this.btn_CharInitiative.Click += new System.EventHandler(this.btn_CharInitiative_Click);
            // 
            // group_Monster
            // 
            this.group_Monster.Controls.Add(this.label9);
            this.group_Monster.Controls.Add(this.txt_XPValue);
            this.group_Monster.Controls.Add(this.label6);
            this.group_Monster.Controls.Add(this.txt_DexModifier);
            this.group_Monster.Controls.Add(this.label5);
            this.group_Monster.Controls.Add(this.label4);
            this.group_Monster.Controls.Add(this.label3);
            this.group_Monster.Controls.Add(this.label2);
            this.group_Monster.Controls.Add(this.btn_MonsterInitiative);
            this.group_Monster.Controls.Add(this.txt_mHP);
            this.group_Monster.Controls.Add(this.txt_mName);
            this.group_Monster.Controls.Add(this.combo_mType);
            this.group_Monster.Controls.Add(this.combo_mSize);
            this.group_Monster.Location = new System.Drawing.Point(12, 109);
            this.group_Monster.Name = "group_Monster";
            this.group_Monster.Size = new System.Drawing.Size(290, 179);
            this.group_Monster.TabIndex = 1;
            this.group_Monster.TabStop = false;
            this.group_Monster.Text = "Monsters";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(218, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "XP Value";
            // 
            // txt_XPValue
            // 
            this.txt_XPValue.Location = new System.Drawing.Point(219, 73);
            this.txt_XPValue.Name = "txt_XPValue";
            this.txt_XPValue.Size = new System.Drawing.Size(65, 20);
            this.txt_XPValue.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(6, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Dex Modifier";
            // 
            // txt_DexModifier
            // 
            this.txt_DexModifier.Location = new System.Drawing.Point(93, 128);
            this.txt_DexModifier.Name = "txt_DexModifier";
            this.txt_DexModifier.Size = new System.Drawing.Size(65, 20);
            this.txt_DexModifier.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(8, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Hit Points";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(6, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name";
            // 
            // btn_MonsterInitiative
            // 
            this.btn_MonsterInitiative.Location = new System.Drawing.Point(200, 146);
            this.btn_MonsterInitiative.Name = "btn_MonsterInitiative";
            this.btn_MonsterInitiative.Size = new System.Drawing.Size(84, 27);
            this.btn_MonsterInitiative.TabIndex = 6;
            this.btn_MonsterInitiative.Text = "Roll Initiative";
            this.btn_MonsterInitiative.UseVisualStyleBackColor = true;
            this.btn_MonsterInitiative.Click += new System.EventHandler(this.btn_MonsterInitiative_Click);
            // 
            // txt_mHP
            // 
            this.txt_mHP.Location = new System.Drawing.Point(93, 102);
            this.txt_mHP.Name = "txt_mHP";
            this.txt_mHP.Size = new System.Drawing.Size(65, 20);
            this.txt_mHP.TabIndex = 3;
            // 
            // txt_mName
            // 
            this.txt_mName.Location = new System.Drawing.Point(82, 19);
            this.txt_mName.Name = "txt_mName";
            this.txt_mName.Size = new System.Drawing.Size(202, 20);
            this.txt_mName.TabIndex = 0;
            // 
            // combo_mType
            // 
            this.combo_mType.FormattingEnabled = true;
            this.combo_mType.Location = new System.Drawing.Point(52, 75);
            this.combo_mType.Name = "combo_mType";
            this.combo_mType.Size = new System.Drawing.Size(106, 21);
            this.combo_mType.TabIndex = 2;
            // 
            // combo_mSize
            // 
            this.combo_mSize.FormattingEnabled = true;
            this.combo_mSize.Location = new System.Drawing.Point(52, 44);
            this.combo_mSize.Name = "combo_mSize";
            this.combo_mSize.Size = new System.Drawing.Size(106, 21);
            this.combo_mSize.TabIndex = 1;
            // 
            // list_Combatants
            // 
            this.list_Combatants.FormattingEnabled = true;
            this.list_Combatants.Location = new System.Drawing.Point(308, 38);
            this.list_Combatants.Name = "list_Combatants";
            this.list_Combatants.Size = new System.Drawing.Size(244, 342);
            this.list_Combatants.TabIndex = 3;
            // 
            // btn_RemoveChar
            // 
            this.btn_RemoveChar.Location = new System.Drawing.Point(477, 12);
            this.btn_RemoveChar.Name = "btn_RemoveChar";
            this.btn_RemoveChar.Size = new System.Drawing.Size(75, 23);
            this.btn_RemoveChar.TabIndex = 2;
            this.btn_RemoveChar.Text = "Remove";
            this.btn_RemoveChar.UseVisualStyleBackColor = true;
            this.btn_RemoveChar.Click += new System.EventHandler(this.btn_RemoveChar_Click);
            // 
            // group_Combat
            // 
            this.group_Combat.Controls.Add(this.txt_XPGained);
            this.group_Combat.Controls.Add(this.label8);
            this.group_Combat.Controls.Add(this.txt_HPChange);
            this.group_Combat.Controls.Add(this.btn_Heal);
            this.group_Combat.Controls.Add(this.btn_Damage);
            this.group_Combat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.group_Combat.Location = new System.Drawing.Point(12, 294);
            this.group_Combat.Name = "group_Combat";
            this.group_Combat.Size = new System.Drawing.Size(290, 86);
            this.group_Combat.TabIndex = 4;
            this.group_Combat.TabStop = false;
            this.group_Combat.Text = "Combat";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(108, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "HP Change";
            // 
            // txt_HPChange
            // 
            this.txt_HPChange.Location = new System.Drawing.Point(194, 19);
            this.txt_HPChange.Name = "txt_HPChange";
            this.txt_HPChange.Size = new System.Drawing.Size(90, 20);
            this.txt_HPChange.TabIndex = 17;
            // 
            // btn_Heal
            // 
            this.btn_Heal.Location = new System.Drawing.Point(110, 45);
            this.btn_Heal.Name = "btn_Heal";
            this.btn_Heal.Size = new System.Drawing.Size(84, 27);
            this.btn_Heal.TabIndex = 16;
            this.btn_Heal.Text = "Heal";
            this.btn_Heal.UseVisualStyleBackColor = true;
            this.btn_Heal.Click += new System.EventHandler(this.btn_Heal_Click);
            // 
            // btn_Damage
            // 
            this.btn_Damage.Location = new System.Drawing.Point(200, 45);
            this.btn_Damage.Name = "btn_Damage";
            this.btn_Damage.Size = new System.Drawing.Size(84, 27);
            this.btn_Damage.TabIndex = 15;
            this.btn_Damage.Text = "Add Damage";
            this.btn_Damage.UseVisualStyleBackColor = true;
            this.btn_Damage.Click += new System.EventHandler(this.btn_Damage_Click);
            // 
            // txt_XPGained
            // 
            this.txt_XPGained.BackColor = System.Drawing.SystemColors.Control;
            this.txt_XPGained.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_XPGained.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_XPGained.Location = new System.Drawing.Point(6, 19);
            this.txt_XPGained.Multiline = true;
            this.txt_XPGained.Name = "txt_XPGained";
            this.txt_XPGained.ReadOnly = true;
            this.txt_XPGained.Size = new System.Drawing.Size(96, 53);
            this.txt_XPGained.TabIndex = 18;
            // 
            // CombatTracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 391);
            this.Controls.Add(this.group_Combat);
            this.Controls.Add(this.btn_RemoveChar);
            this.Controls.Add(this.list_Combatants);
            this.Controls.Add(this.group_Monster);
            this.Controls.Add(this.group_Characters);
            this.Name = "CombatTracking";
            this.Text = "Combat Tracking Sheet";
            this.group_Characters.ResumeLayout(false);
            this.group_Characters.PerformLayout();
            this.group_Monster.ResumeLayout(false);
            this.group_Monster.PerformLayout();
            this.group_Combat.ResumeLayout(false);
            this.group_Combat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox combo_Characters;
        private System.Windows.Forms.GroupBox group_Characters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_CharInitiative;
        private System.Windows.Forms.GroupBox group_Monster;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_MonsterInitiative;
        private System.Windows.Forms.TextBox txt_mHP;
        private System.Windows.Forms.TextBox txt_mName;
        private System.Windows.Forms.ComboBox combo_mType;
        private System.Windows.Forms.ComboBox combo_mSize;
        private System.Windows.Forms.ListBox list_Combatants;
        private System.Windows.Forms.Button btn_RemoveChar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Initiative;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_DexModifier;
        private System.Windows.Forms.GroupBox group_Combat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_HPChange;
        private System.Windows.Forms.Button btn_Heal;
        private System.Windows.Forms.Button btn_Damage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_XPValue;
        private System.Windows.Forms.TextBox txt_XPGained;
    }
}