namespace DnD5e
{
    partial class CharTracker
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
            this.flow_CharTrack = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flow_CharTrack
            // 
            this.flow_CharTrack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow_CharTrack.Location = new System.Drawing.Point(0, 0);
            this.flow_CharTrack.Name = "flow_CharTrack";
            this.flow_CharTrack.Size = new System.Drawing.Size(714, 636);
            this.flow_CharTrack.TabIndex = 0;
            // 
            // CharTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(714, 636);
            this.Controls.Add(this.flow_CharTrack);
            this.Name = "CharTracker";
            this.Text = "Character Tracking";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flow_CharTrack;
    }
}