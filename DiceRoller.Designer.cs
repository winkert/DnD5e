namespace DnD5e
{
    partial class DiceRoller
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.combo_Weapons = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.isTwoHanded = new System.Windows.Forms.CheckBox();
            this.txt_DamageBonus = new System.Windows.Forms.TextBox();
            this.isCritical = new System.Windows.Forms.CheckBox();
            this.btn_RollDamage = new System.Windows.Forms.Button();
            this.list_Rolls = new System.Windows.Forms.ListBox();
            this.btn_ClearRolls = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Initiative = new System.Windows.Forms.Button();
            this.btn_ToHit = new System.Windows.Forms.Button();
            this.btn_SkillCheck = new System.Windows.Forms.Button();
            this.btn_Percent = new System.Windows.Forms.Button();
            this.txt_RollName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Roll = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_MakeRoll = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.combo_Weapons);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.isTwoHanded);
            this.panel1.Controls.Add(this.txt_DamageBonus);
            this.panel1.Controls.Add(this.btn_RollDamage);
            this.panel1.Controls.Add(this.isCritical);
            this.panel1.Location = new System.Drawing.Point(12, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 127);
            this.panel1.TabIndex = 0;
            // 
            // combo_Weapons
            // 
            this.combo_Weapons.FormattingEnabled = true;
            this.combo_Weapons.Location = new System.Drawing.Point(3, 3);
            this.combo_Weapons.Name = "combo_Weapons";
            this.combo_Weapons.Size = new System.Drawing.Size(125, 21);
            this.combo_Weapons.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bonus:";
            // 
            // isTwoHanded
            // 
            this.isTwoHanded.AutoSize = true;
            this.isTwoHanded.Location = new System.Drawing.Point(3, 30);
            this.isTwoHanded.Name = "isTwoHanded";
            this.isTwoHanded.Size = new System.Drawing.Size(125, 17);
            this.isTwoHanded.TabIndex = 1;
            this.isTwoHanded.Text = "Used with two hands";
            this.isTwoHanded.UseVisualStyleBackColor = true;
            // 
            // txt_DamageBonus
            // 
            this.txt_DamageBonus.Location = new System.Drawing.Point(46, 70);
            this.txt_DamageBonus.Name = "txt_DamageBonus";
            this.txt_DamageBonus.Size = new System.Drawing.Size(82, 20);
            this.txt_DamageBonus.TabIndex = 3;
            // 
            // isCritical
            // 
            this.isCritical.AutoSize = true;
            this.isCritical.Location = new System.Drawing.Point(3, 53);
            this.isCritical.Name = "isCritical";
            this.isCritical.Size = new System.Drawing.Size(73, 17);
            this.isCritical.TabIndex = 2;
            this.isCritical.Text = "Critical Hit";
            this.isCritical.UseVisualStyleBackColor = true;
            // 
            // btn_RollDamage
            // 
            this.btn_RollDamage.Location = new System.Drawing.Point(3, 96);
            this.btn_RollDamage.Name = "btn_RollDamage";
            this.btn_RollDamage.Size = new System.Drawing.Size(83, 23);
            this.btn_RollDamage.TabIndex = 4;
            this.btn_RollDamage.Text = "Roll Damage";
            this.btn_RollDamage.UseVisualStyleBackColor = true;
            this.btn_RollDamage.Click += new System.EventHandler(this.btn_RollDamage_Click);
            // 
            // list_Rolls
            // 
            this.list_Rolls.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.list_Rolls.FormattingEnabled = true;
            this.list_Rolls.ItemHeight = 20;
            this.list_Rolls.Location = new System.Drawing.Point(178, 16);
            this.list_Rolls.Name = "list_Rolls";
            this.list_Rolls.Size = new System.Drawing.Size(210, 304);
            this.list_Rolls.TabIndex = 3;
            // 
            // btn_ClearRolls
            // 
            this.btn_ClearRolls.Location = new System.Drawing.Point(305, 327);
            this.btn_ClearRolls.Name = "btn_ClearRolls";
            this.btn_ClearRolls.Size = new System.Drawing.Size(83, 23);
            this.btn_ClearRolls.TabIndex = 4;
            this.btn_ClearRolls.Text = "Clear Rolls";
            this.btn_ClearRolls.UseVisualStyleBackColor = true;
            this.btn_ClearRolls.Click += new System.EventHandler(this.btn_ClearRolls_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_MakeRoll);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txt_Roll);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_RollName);
            this.panel2.Location = new System.Drawing.Point(12, 149);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(160, 87);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btn_Percent);
            this.panel3.Controls.Add(this.btn_SkillCheck);
            this.panel3.Controls.Add(this.btn_ToHit);
            this.panel3.Controls.Add(this.btn_Initiative);
            this.panel3.Location = new System.Drawing.Point(12, 242);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(160, 108);
            this.panel3.TabIndex = 2;
            // 
            // btn_Initiative
            // 
            this.btn_Initiative.Location = new System.Drawing.Point(3, 3);
            this.btn_Initiative.Name = "btn_Initiative";
            this.btn_Initiative.Size = new System.Drawing.Size(73, 46);
            this.btn_Initiative.TabIndex = 0;
            this.btn_Initiative.Text = "Roll Initiative";
            this.btn_Initiative.UseVisualStyleBackColor = true;
            this.btn_Initiative.Click += new System.EventHandler(this.btn_Initiative_Click);
            // 
            // btn_ToHit
            // 
            this.btn_ToHit.Location = new System.Drawing.Point(84, 3);
            this.btn_ToHit.Name = "btn_ToHit";
            this.btn_ToHit.Size = new System.Drawing.Size(73, 46);
            this.btn_ToHit.TabIndex = 1;
            this.btn_ToHit.Text = "Roll To Hit";
            this.btn_ToHit.UseVisualStyleBackColor = true;
            this.btn_ToHit.Click += new System.EventHandler(this.btn_ToHit_Click);
            // 
            // btn_SkillCheck
            // 
            this.btn_SkillCheck.Location = new System.Drawing.Point(3, 55);
            this.btn_SkillCheck.Name = "btn_SkillCheck";
            this.btn_SkillCheck.Size = new System.Drawing.Size(73, 46);
            this.btn_SkillCheck.TabIndex = 2;
            this.btn_SkillCheck.Text = "Roll Skill Check";
            this.btn_SkillCheck.UseVisualStyleBackColor = true;
            this.btn_SkillCheck.Click += new System.EventHandler(this.btn_SkillCheck_Click);
            // 
            // btn_Percent
            // 
            this.btn_Percent.Location = new System.Drawing.Point(84, 55);
            this.btn_Percent.Name = "btn_Percent";
            this.btn_Percent.Size = new System.Drawing.Size(73, 46);
            this.btn_Percent.TabIndex = 3;
            this.btn_Percent.Text = "Roll Percent";
            this.btn_Percent.UseVisualStyleBackColor = true;
            this.btn_Percent.Click += new System.EventHandler(this.btn_Percent_Click);
            // 
            // txt_RollName
            // 
            this.txt_RollName.Location = new System.Drawing.Point(68, 3);
            this.txt_RollName.Name = "txt_RollName";
            this.txt_RollName.Size = new System.Drawing.Size(89, 20);
            this.txt_RollName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Roll Name:";
            // 
            // txt_Roll
            // 
            this.txt_Roll.Location = new System.Drawing.Point(68, 29);
            this.txt_Roll.Name = "txt_Roll";
            this.txt_Roll.Size = new System.Drawing.Size(89, 20);
            this.txt_Roll.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Dice Roll:";
            // 
            // btn_MakeRoll
            // 
            this.btn_MakeRoll.Location = new System.Drawing.Point(82, 55);
            this.btn_MakeRoll.Name = "btn_MakeRoll";
            this.btn_MakeRoll.Size = new System.Drawing.Size(75, 23);
            this.btn_MakeRoll.TabIndex = 2;
            this.btn_MakeRoll.Text = "Roll";
            this.btn_MakeRoll.UseVisualStyleBackColor = true;
            this.btn_MakeRoll.Click += new System.EventHandler(this.btn_MakeRoll_Click);
            // 
            // DiceRoller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 359);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_ClearRolls);
            this.Controls.Add(this.list_Rolls);
            this.Controls.Add(this.panel1);
            this.Name = "DiceRoller";
            this.Text = "Dice Roller";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox combo_Weapons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox isTwoHanded;
        private System.Windows.Forms.TextBox txt_DamageBonus;
        private System.Windows.Forms.CheckBox isCritical;
        private System.Windows.Forms.Button btn_RollDamage;
        private System.Windows.Forms.ListBox list_Rolls;
        private System.Windows.Forms.Button btn_ClearRolls;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Initiative;
        private System.Windows.Forms.Button btn_Percent;
        private System.Windows.Forms.Button btn_SkillCheck;
        private System.Windows.Forms.Button btn_ToHit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_RollName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Roll;
        private System.Windows.Forms.Button btn_MakeRoll;
    }
}