namespace AkibasTripItems
{
    partial class Form1
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
            this.ch_money = new System.Windows.Forms.CheckBox();
            this.b_run = new System.Windows.Forms.Button();
            this.ch_weaponatk = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.l_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.ch_clothingdur = new System.Windows.Forms.CheckBox();
            this.ch_fps = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.b_playerstats = new System.Windows.Forms.Button();
            this.b_skills = new System.Windows.Forms.Button();
            this.b_encyclopedia = new System.Windows.Forms.Button();
            this.b_items = new System.Windows.Forms.Button();
            this.ch_invincible = new System.Windows.Forms.CheckBox();
            this.ch_stripping = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ch_money
            // 
            this.ch_money.AutoSize = true;
            this.ch_money.Checked = true;
            this.ch_money.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ch_money.Location = new System.Drawing.Point(12, 35);
            this.ch_money.Name = "ch_money";
            this.ch_money.Size = new System.Drawing.Size(91, 17);
            this.ch_money.TabIndex = 0;
            this.ch_money.Text = "Infinite money";
            this.ch_money.UseVisualStyleBackColor = true;
            // 
            // b_run
            // 
            this.b_run.Location = new System.Drawing.Point(12, 234);
            this.b_run.Name = "b_run";
            this.b_run.Size = new System.Drawing.Size(75, 23);
            this.b_run.TabIndex = 1;
            this.b_run.Text = "Run";
            this.b_run.UseVisualStyleBackColor = true;
            this.b_run.Click += new System.EventHandler(this.b_run_Click);
            // 
            // ch_weaponatk
            // 
            this.ch_weaponatk.AutoSize = true;
            this.ch_weaponatk.Checked = true;
            this.ch_weaponatk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ch_weaponatk.Location = new System.Drawing.Point(12, 58);
            this.ch_weaponatk.Name = "ch_weaponatk";
            this.ch_weaponatk.Size = new System.Drawing.Size(111, 17);
            this.ch_weaponatk.TabIndex = 4;
            this.ch_weaponatk.Text = "Max weapon ATK";
            this.ch_weaponatk.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.l_status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 260);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(304, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // l_status
            // 
            this.l_status.Name = "l_status";
            this.l_status.Size = new System.Drawing.Size(38, 17);
            this.l_status.Text = "status";
            // 
            // ch_clothingdur
            // 
            this.ch_clothingdur.AutoSize = true;
            this.ch_clothingdur.Checked = true;
            this.ch_clothingdur.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ch_clothingdur.Location = new System.Drawing.Point(12, 82);
            this.ch_clothingdur.Name = "ch_clothingdur";
            this.ch_clothingdur.Size = new System.Drawing.Size(130, 17);
            this.ch_clothingdur.TabIndex = 8;
            this.ch_clothingdur.Text = "Max clothing durability";
            this.ch_clothingdur.UseVisualStyleBackColor = true;
            // 
            // ch_fps
            // 
            this.ch_fps.AutoSize = true;
            this.ch_fps.Location = new System.Drawing.Point(12, 12);
            this.ch_fps.Name = "ch_fps";
            this.ch_fps.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ch_fps.Size = new System.Drawing.Size(88, 17);
            this.ch_fps.TabIndex = 9;
            this.ch_fps.Text = "60 FPS hack";
            this.ch_fps.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.b_playerstats);
            this.groupBox1.Controls.Add(this.b_skills);
            this.groupBox1.Controls.Add(this.b_encyclopedia);
            this.groupBox1.Controls.Add(this.b_items);
            this.groupBox1.Location = new System.Drawing.Point(160, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 245);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // b_playerstats
            // 
            this.b_playerstats.Location = new System.Drawing.Point(7, 20);
            this.b_playerstats.Name = "b_playerstats";
            this.b_playerstats.Size = new System.Drawing.Size(119, 23);
            this.b_playerstats.TabIndex = 3;
            this.b_playerstats.Text = "Max player stats";
            this.b_playerstats.UseVisualStyleBackColor = true;
            this.b_playerstats.Click += new System.EventHandler(this.b_playerstats_Click);
            // 
            // b_skills
            // 
            this.b_skills.Location = new System.Drawing.Point(7, 107);
            this.b_skills.Name = "b_skills";
            this.b_skills.Size = new System.Drawing.Size(119, 23);
            this.b_skills.TabIndex = 2;
            this.b_skills.Text = "Max all stripping skills";
            this.b_skills.UseVisualStyleBackColor = true;
            // 
            // b_encyclopedia
            // 
            this.b_encyclopedia.Enabled = false;
            this.b_encyclopedia.Location = new System.Drawing.Point(7, 78);
            this.b_encyclopedia.Name = "b_encyclopedia";
            this.b_encyclopedia.Size = new System.Drawing.Size(119, 23);
            this.b_encyclopedia.TabIndex = 1;
            this.b_encyclopedia.Text = "Fill encyclopedia";
            this.b_encyclopedia.UseVisualStyleBackColor = true;
            // 
            // b_items
            // 
            this.b_items.Enabled = false;
            this.b_items.Location = new System.Drawing.Point(7, 49);
            this.b_items.Name = "b_items";
            this.b_items.Size = new System.Drawing.Size(119, 23);
            this.b_items.TabIndex = 0;
            this.b_items.Text = "Get all items";
            this.b_items.UseVisualStyleBackColor = true;
            // 
            // ch_invincible
            // 
            this.ch_invincible.AutoSize = true;
            this.ch_invincible.Checked = true;
            this.ch_invincible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ch_invincible.Location = new System.Drawing.Point(13, 105);
            this.ch_invincible.Name = "ch_invincible";
            this.ch_invincible.Size = new System.Drawing.Size(108, 17);
            this.ch_invincible.TabIndex = 11;
            this.ch_invincible.Text = "Invincible clothes";
            this.ch_invincible.UseVisualStyleBackColor = true;
            // 
            // ch_stripping
            // 
            this.ch_stripping.AutoSize = true;
            this.ch_stripping.Checked = true;
            this.ch_stripping.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ch_stripping.Location = new System.Drawing.Point(12, 128);
            this.ch_stripping.Name = "ch_stripping";
            this.ch_stripping.Size = new System.Drawing.Size(91, 17);
            this.ch_stripping.TabIndex = 12;
            this.ch_stripping.Text = "Easy stripping";
            this.ch_stripping.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 282);
            this.Controls.Add(this.ch_stripping);
            this.Controls.Add(this.ch_invincible);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ch_fps);
            this.Controls.Add(this.ch_clothingdur);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ch_weaponatk);
            this.Controls.Add(this.b_run);
            this.Controls.Add(this.ch_money);
            this.Name = "Form1";
            this.Text = "Akiba\'sTripItems";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ch_money;
        private System.Windows.Forms.Button b_run;
        private System.Windows.Forms.CheckBox ch_weaponatk;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel l_status;
        private System.Windows.Forms.CheckBox ch_clothingdur;
        private System.Windows.Forms.CheckBox ch_fps;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_skills;
        private System.Windows.Forms.Button b_encyclopedia;
        private System.Windows.Forms.Button b_items;
        private System.Windows.Forms.CheckBox ch_invincible;
        private System.Windows.Forms.Button b_playerstats;
        private System.Windows.Forms.CheckBox ch_stripping;
    }
}

