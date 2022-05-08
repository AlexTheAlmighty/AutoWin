using System.Drawing;
using System.Windows.Forms;

namespace AutoKey
{
    partial class AutoWinWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoWinWindow));
            this.IsEnabledCheckbox = new System.Windows.Forms.CheckBox();
            this.RemoveSelectedBtn = new System.Windows.Forms.Button();
            this.MoveBar = new System.Windows.Forms.Button();
            this.Minimize = new System.Windows.Forms.Button();
            this.AdditionBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RunAtStartupChkBox = new System.Windows.Forms.CheckBox();
            this.alphaBlendTextBox1 = new ZBobb.AlphaBlendTextBox();
            this.ApplicationListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // IsEnabledCheckbox
            // 
            this.IsEnabledCheckbox.AutoSize = true;
            this.IsEnabledCheckbox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.IsEnabledCheckbox.Checked = true;
            this.IsEnabledCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsEnabledCheckbox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.IsEnabledCheckbox.Location = new System.Drawing.Point(25, 42);
            this.IsEnabledCheckbox.Name = "IsEnabledCheckbox";
            this.IsEnabledCheckbox.Size = new System.Drawing.Size(103, 17);
            this.IsEnabledCheckbox.TabIndex = 0;
            this.IsEnabledCheckbox.Text = "Enable AutoWin";
            this.IsEnabledCheckbox.UseVisualStyleBackColor = false;
            this.IsEnabledCheckbox.CheckedChanged += new System.EventHandler(this.EnabledCheckbox_CheckedChanged);
            // 
            // RemoveSelectedBtn
            // 
            this.RemoveSelectedBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.RemoveSelectedBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RemoveSelectedBtn.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveSelectedBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.RemoveSelectedBtn.Location = new System.Drawing.Point(243, 215);
            this.RemoveSelectedBtn.Name = "RemoveSelectedBtn";
            this.RemoveSelectedBtn.Size = new System.Drawing.Size(200, 35);
            this.RemoveSelectedBtn.TabIndex = 2;
            this.RemoveSelectedBtn.Text = "Remove Selected";
            this.RemoveSelectedBtn.UseVisualStyleBackColor = false;
            this.RemoveSelectedBtn.Click += new System.EventHandler(this.RemoveSelectedBtn_Click);
            // 
            // MoveBar
            // 
            this.MoveBar.BackColor = System.Drawing.Color.Transparent;
            this.MoveBar.BackgroundImage = global::AutoKey.Properties.Resources.backgroundtest11;
            this.MoveBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MoveBar.FlatAppearance.BorderSize = 0;
            this.MoveBar.ForeColor = System.Drawing.Color.Transparent;
            this.MoveBar.Location = new System.Drawing.Point(-10, -10);
            this.MoveBar.Name = "MoveBar";
            this.MoveBar.Size = new System.Drawing.Size(528, 46);
            this.MoveBar.TabIndex = 4;
            this.MoveBar.TabStop = false;
            this.MoveBar.UseVisualStyleBackColor = false;
            this.MoveBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveBar_MouseDown);
            // 
            // Minimize
            // 
            this.Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Minimize.BackColor = System.Drawing.Color.DimGray;
            this.Minimize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Minimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Minimize.Location = new System.Drawing.Point(441, 4);
            this.Minimize.Margin = new System.Windows.Forms.Padding(0);
            this.Minimize.Name = "Minimize";
            this.Minimize.Padding = new System.Windows.Forms.Padding(1);
            this.Minimize.Size = new System.Drawing.Size(23, 19);
            this.Minimize.TabIndex = 5;
            this.Minimize.Text = "-";
            this.Minimize.UseVisualStyleBackColor = false;
            this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // AdditionBox
            // 
            this.AdditionBox.Location = new System.Drawing.Point(243, 180);
            this.AdditionBox.MaxLength = 256;
            this.AdditionBox.Name = "AdditionBox";
            this.AdditionBox.Size = new System.Drawing.Size(141, 20);
            this.AdditionBox.TabIndex = 6;
            this.AdditionBox.WordWrap = false;
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddButton.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AddButton.Location = new System.Drawing.Point(391, 170);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(52, 39);
            this.AddButton.TabIndex = 7;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bauhaus 93", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "Auto Windows Key Disabler";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveBar_MouseDown);
            // 
            // RunAtStartupChkBox
            // 
            this.RunAtStartupChkBox.AutoSize = true;
            this.RunAtStartupChkBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RunAtStartupChkBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.RunAtStartupChkBox.Location = new System.Drawing.Point(25, 58);
            this.RunAtStartupChkBox.Name = "RunAtStartupChkBox";
            this.RunAtStartupChkBox.Size = new System.Drawing.Size(93, 17);
            this.RunAtStartupChkBox.TabIndex = 10;
            this.RunAtStartupChkBox.Text = "Run at startup";
            this.RunAtStartupChkBox.UseVisualStyleBackColor = false;
            this.RunAtStartupChkBox.CheckedChanged += new System.EventHandler(this.RunAtStartupChkBox_CheckedChanged);
            // 
            // alphaBlendTextBox1
            // 
            this.alphaBlendTextBox1.BackAlpha = 10;
            this.alphaBlendTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.alphaBlendTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alphaBlendTextBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alphaBlendTextBox1.ForeColor = System.Drawing.SystemColors.Menu;
            this.alphaBlendTextBox1.Location = new System.Drawing.Point(243, 58);
            this.alphaBlendTextBox1.Multiline = true;
            this.alphaBlendTextBox1.Name = "alphaBlendTextBox1";
            this.alphaBlendTextBox1.Size = new System.Drawing.Size(200, 76);
            this.alphaBlendTextBox1.TabIndex = 12;
            this.alphaBlendTextBox1.Text = "This will stop the windows key from executing while any application from the list" +
    " is in the foreground.";
            // 
            // ApplicationListBox
            // 
            this.ApplicationListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ApplicationListBox.CausesValidation = false;
            this.ApplicationListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ApplicationListBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationListBox.ForeColor = System.Drawing.SystemColors.Menu;
            this.ApplicationListBox.FormattingEnabled = true;
            this.ApplicationListBox.ItemHeight = 20;
            this.ApplicationListBox.Items.AddRange(new object[] {
            "World of Warcraft",
            "Valorant",
            "League of Legends",
            "Diablo",
            "LostArk",
            "Fortnite",
            "Counter-Strike",
            "Path of Exile",
            "test",
            "testtt",
            "testtt33434"});
            this.ApplicationListBox.Location = new System.Drawing.Point(25, 81);
            this.ApplicationListBox.Name = "ApplicationListBox";
            this.ApplicationListBox.Size = new System.Drawing.Size(188, 184);
            this.ApplicationListBox.TabIndex = 13;
            // 
            // AutoWinWindow
            // 
            this.AcceptButton = this.AddButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = global::AutoKey.Properties.Resources.backgroundtest11;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(465, 276);
            this.Controls.Add(this.ApplicationListBox);
            this.Controls.Add(this.alphaBlendTextBox1);
            this.Controls.Add(this.RunAtStartupChkBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.AdditionBox);
            this.Controls.Add(this.Minimize);
            this.Controls.Add(this.MoveBar);
            this.Controls.Add(this.RemoveSelectedBtn);
            this.Controls.Add(this.IsEnabledCheckbox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutoWinWindow";
            this.Text = "Automatic Windows Key Disable";
            this.TransparencyKey = System.Drawing.Color.IndianRed;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox IsEnabledCheckbox;
        private System.Windows.Forms.Button RemoveSelectedBtn;
        private Button MoveBar;
        private Button Minimize;
        private TextBox AdditionBox;
        private Button AddButton;
        private Label label1;
        private CheckBox RunAtStartupChkBox;
        private ZBobb.AlphaBlendTextBox alphaBlendTextBox1;
        private ListBox ApplicationListBox;
    }
}

