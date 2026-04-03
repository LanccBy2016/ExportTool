namespace ExportTool
{
    partial class ScriptForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.scriptGroupBox = new System.Windows.Forms.GroupBox();
            this.contentTextBox = new System.Windows.Forms.TextBox();
            this.contentLabel = new System.Windows.Forms.Label();
            this.variablesGroupBox = new System.Windows.Forms.GroupBox();
            this.insertVariableButton = new System.Windows.Forms.Button();
            this.variablesListBox = new System.Windows.Forms.ListBox();
            this.variablesLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.scriptGroupBox.SuspendLayout();
            this.variablesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(20, 20);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(80, 20);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "脚本名称:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(100, 17);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(620, 27);
            this.nameTextBox.TabIndex = 1;
            // 
            // scriptGroupBox
            // 
            this.scriptGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptGroupBox.Controls.Add(this.contentTextBox);
            this.scriptGroupBox.Controls.Add(this.contentLabel);
            this.scriptGroupBox.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scriptGroupBox.Location = new System.Drawing.Point(20, 60);
            this.scriptGroupBox.Name = "scriptGroupBox";
            this.scriptGroupBox.Size = new System.Drawing.Size(460, 380);
            this.scriptGroupBox.TabIndex = 2;
            this.scriptGroupBox.TabStop = false;
            this.scriptGroupBox.Text = "脚本内容";
            // 
            // contentTextBox
            // 
            this.contentTextBox.AcceptsReturn = true;
            this.contentTextBox.AcceptsTab = true;
            this.contentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentTextBox.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentTextBox.Location = new System.Drawing.Point(20, 50);
            this.contentTextBox.Multiline = true;
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.contentTextBox.Size = new System.Drawing.Size(420, 310);
            this.contentTextBox.TabIndex = 1;
            this.contentTextBox.TextChanged += new System.EventHandler(this.contentTextBox_TextChanged);
            this.contentTextBox.WordWrap = false;
            this.contentTextBox.MaxLength = int.MaxValue;
            this.contentTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // contentLabel
            // 
            this.contentLabel.AutoSize = true;
            this.contentLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentLabel.Location = new System.Drawing.Point(20, 30);
            this.contentLabel.Name = "contentLabel";
            this.contentLabel.Size = new System.Drawing.Size(44, 17);
            this.contentLabel.TabIndex = 0;
            this.contentLabel.Text = "SQL:";
            // 
            // variablesGroupBox
            // 
            this.variablesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.variablesGroupBox.Controls.Add(this.insertVariableButton);
            this.variablesGroupBox.Controls.Add(this.variablesListBox);
            this.variablesGroupBox.Controls.Add(this.variablesLabel);
            this.variablesGroupBox.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variablesGroupBox.Location = new System.Drawing.Point(500, 60);
            this.variablesGroupBox.Name = "variablesGroupBox";
            this.variablesGroupBox.Size = new System.Drawing.Size(220, 380);
            this.variablesGroupBox.TabIndex = 3;
            this.variablesGroupBox.TabStop = false;
            this.variablesGroupBox.Text = "变量管理";
            // 
            // insertVariableButton
            // 
            this.insertVariableButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.insertVariableButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.insertVariableButton.FlatAppearance.BorderSize = 0;
            this.insertVariableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.insertVariableButton.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertVariableButton.ForeColor = System.Drawing.Color.White;
            this.insertVariableButton.Location = new System.Drawing.Point(20, 320);
            this.insertVariableButton.Name = "insertVariableButton";
            this.insertVariableButton.Size = new System.Drawing.Size(180, 40);
            this.insertVariableButton.TabIndex = 2;
            this.insertVariableButton.Text = "快捷插入变量";
            this.insertVariableButton.UseVisualStyleBackColor = false;
            this.insertVariableButton.Click += new System.EventHandler(this.insertVariableButton_Click);
            // 
            // variablesListBox
            // 
            this.variablesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.variablesListBox.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variablesListBox.FormattingEnabled = true;
            this.variablesListBox.ItemHeight = 20;
            this.variablesListBox.Location = new System.Drawing.Point(20, 70);
            this.variablesListBox.Name = "variablesListBox";
            this.variablesListBox.Size = new System.Drawing.Size(180, 244);
            this.variablesListBox.TabIndex = 1;
            this.variablesListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.variablesListBox.SelectedIndexChanged += new System.EventHandler(this.variablesListBox_SelectedIndexChanged);
            // 
            // variablesLabel
            // 
            this.variablesLabel.AutoSize = true;
            this.variablesLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variablesLabel.Location = new System.Drawing.Point(20, 30);
            this.variablesLabel.Name = "variablesLabel";
            this.variablesLabel.Size = new System.Drawing.Size(80, 17);
            this.variablesLabel.TabIndex = 0;
            this.variablesLabel.Text = "已识别变量:";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.okButton.FlatAppearance.BorderSize = 0;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.ForeColor = System.Drawing.Color.White;
            this.okButton.Location = new System.Drawing.Point(520, 460);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 40);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.Black;
            this.cancelButton.Location = new System.Drawing.Point(630, 460);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 40);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 520);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.variablesGroupBox);
            this.Controls.Add(this.scriptGroupBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.MinimumSize = new System.Drawing.Size(756, 559);
            this.Name = "ScriptForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SQL脚本编辑";
            this.scriptGroupBox.ResumeLayout(false);
            this.scriptGroupBox.PerformLayout();
            this.variablesGroupBox.ResumeLayout(false);
            this.variablesGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.GroupBox scriptGroupBox;
        private System.Windows.Forms.TextBox contentTextBox;
        private System.Windows.Forms.Label contentLabel;
        private System.Windows.Forms.GroupBox variablesGroupBox;
        private System.Windows.Forms.Button insertVariableButton;
        private System.Windows.Forms.ListBox variablesListBox;
        private System.Windows.Forms.Label variablesLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
