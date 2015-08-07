namespace DnD5e
{
    partial class XPCalc
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
            this.grp_PlayInfo = new System.Windows.Forms.GroupBox();
            this.btn_AddToAll = new System.Windows.Forms.Button();
            this.Player_XP = new System.Windows.Forms.Label();
            this.Player_Class = new System.Windows.Forms.Label();
            this.Player_Race = new System.Windows.Forms.Label();
            this.Player_Name = new System.Windows.Forms.Label();
            this.btn_AddXP = new System.Windows.Forms.Button();
            this.txt_XP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grp_PlayInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // combo_Characters
            // 
            this.combo_Characters.FormattingEnabled = true;
            this.combo_Characters.Location = new System.Drawing.Point(112, 33);
            this.combo_Characters.Name = "combo_Characters";
            this.combo_Characters.Size = new System.Drawing.Size(130, 21);
            this.combo_Characters.TabIndex = 0;
            this.combo_Characters.SelectedIndexChanged += new System.EventHandler(this.combo_Characters_SelectedIndexChanged);
            // 
            // grp_PlayInfo
            // 
            this.grp_PlayInfo.Controls.Add(this.btn_AddToAll);
            this.grp_PlayInfo.Controls.Add(this.Player_XP);
            this.grp_PlayInfo.Controls.Add(this.Player_Class);
            this.grp_PlayInfo.Controls.Add(this.Player_Race);
            this.grp_PlayInfo.Controls.Add(this.Player_Name);
            this.grp_PlayInfo.Controls.Add(this.btn_AddXP);
            this.grp_PlayInfo.Controls.Add(this.txt_XP);
            this.grp_PlayInfo.Location = new System.Drawing.Point(12, 60);
            this.grp_PlayInfo.Name = "grp_PlayInfo";
            this.grp_PlayInfo.Size = new System.Drawing.Size(230, 124);
            this.grp_PlayInfo.TabIndex = 1;
            this.grp_PlayInfo.TabStop = false;
            this.grp_PlayInfo.Text = "Player Information";
            // 
            // btn_AddToAll
            // 
            this.btn_AddToAll.Location = new System.Drawing.Point(149, 77);
            this.btn_AddToAll.Name = "btn_AddToAll";
            this.btn_AddToAll.Size = new System.Drawing.Size(75, 23);
            this.btn_AddToAll.TabIndex = 7;
            this.btn_AddToAll.Text = "Add to All";
            this.btn_AddToAll.UseVisualStyleBackColor = true;
            this.btn_AddToAll.Click += new System.EventHandler(this.btn_AddToAll_Click);
            // 
            // Player_XP
            // 
            this.Player_XP.AutoSize = true;
            this.Player_XP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Player_XP.Location = new System.Drawing.Point(6, 73);
            this.Player_XP.Name = "Player_XP";
            this.Player_XP.Size = new System.Drawing.Size(12, 17);
            this.Player_XP.TabIndex = 6;
            this.Player_XP.Text = " ";
            // 
            // Player_Class
            // 
            this.Player_Class.AutoSize = true;
            this.Player_Class.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Player_Class.Location = new System.Drawing.Point(6, 56);
            this.Player_Class.Name = "Player_Class";
            this.Player_Class.Size = new System.Drawing.Size(12, 17);
            this.Player_Class.TabIndex = 4;
            this.Player_Class.Text = " ";
            // 
            // Player_Race
            // 
            this.Player_Race.AutoSize = true;
            this.Player_Race.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Player_Race.Location = new System.Drawing.Point(6, 39);
            this.Player_Race.Name = "Player_Race";
            this.Player_Race.Size = new System.Drawing.Size(12, 17);
            this.Player_Race.TabIndex = 3;
            this.Player_Race.Text = " ";
            // 
            // Player_Name
            // 
            this.Player_Name.AutoSize = true;
            this.Player_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Player_Name.Location = new System.Drawing.Point(6, 22);
            this.Player_Name.Name = "Player_Name";
            this.Player_Name.Size = new System.Drawing.Size(12, 17);
            this.Player_Name.TabIndex = 2;
            this.Player_Name.Text = " ";
            // 
            // btn_AddXP
            // 
            this.btn_AddXP.Location = new System.Drawing.Point(149, 48);
            this.btn_AddXP.Name = "btn_AddXP";
            this.btn_AddXP.Size = new System.Drawing.Size(75, 23);
            this.btn_AddXP.TabIndex = 1;
            this.btn_AddXP.Text = "Add XP";
            this.btn_AddXP.UseVisualStyleBackColor = true;
            this.btn_AddXP.Click += new System.EventHandler(this.btn_AddXP_Click);
            // 
            // txt_XP
            // 
            this.txt_XP.Location = new System.Drawing.Point(149, 22);
            this.txt_XP.Name = "txt_XP";
            this.txt_XP.Size = new System.Drawing.Size(75, 20);
            this.txt_XP.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Character";
            // 
            // XPCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 196);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grp_PlayInfo);
            this.Controls.Add(this.combo_Characters);
            this.Name = "XPCalc";
            this.Text = "Experience Calculator";
            this.grp_PlayInfo.ResumeLayout(false);
            this.grp_PlayInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combo_Characters;
        private System.Windows.Forms.GroupBox grp_PlayInfo;
        private System.Windows.Forms.Button btn_AddXP;
        private System.Windows.Forms.TextBox txt_XP;
        private System.Windows.Forms.Label Player_XP;
        private System.Windows.Forms.Label Player_Class;
        private System.Windows.Forms.Label Player_Race;
        private System.Windows.Forms.Label Player_Name;
        private System.Windows.Forms.Button btn_AddToAll;
        private System.Windows.Forms.Label label1;
    }
}