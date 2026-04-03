using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExportTool
{
    public partial class ScriptForm : Form
    {
        public SqlScript Script { get; set; }
        private bool _isUpdatingVariables = false;

        public ScriptForm()
        {
            InitializeComponent();
            Script = new SqlScript();
        }

        public ScriptForm(SqlScript script)
        {
            InitializeComponent();
            Script = script;
            nameTextBox.Text = script.Name;
            contentTextBox.Text = script.Content;
            UpdateVariables();
        }

        private void UpdateVariables()
        {
            // 设置标志防止自动触发的选中事件导致光标定位
            _isUpdatingVariables = true;
            
            // 保存当前光标位置和选中状态
            int selectionStart = contentTextBox.SelectionStart;
            int selectionLength = contentTextBox.SelectionLength;
            
            var variables = ExtractVariables(contentTextBox.Text);
            variablesListBox.DataSource = null;
            variablesListBox.DataSource = variables;
            
            // 恢复光标位置和选中状态
            contentTextBox.SelectionStart = selectionStart;
            contentTextBox.SelectionLength = selectionLength;
            contentTextBox.Focus();
            
            // 清除标志
            _isUpdatingVariables = false;
        }

        private List<string> ExtractVariables(string content)
        {
            var variables = new List<string>();
            var matches = Regex.Matches(content, @"\$\{(\w+)(?:=(.*?))?\}");
            foreach (Match match in matches)
            {
                string variable = match.Groups[1].Value;
                if (!variables.Contains(variable))
                {
                    variables.Add(variable);
                }
            }
            return variables;
        }

        private void contentTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateVariables();
        }

        private void variablesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 如果是自动更新变量列表时触发的选中事件，不执行光标定位
            if (_isUpdatingVariables || variablesListBox.SelectedItem == null)
                return;

            string selectedVariable = variablesListBox.SelectedItem.ToString();
            string content = contentTextBox.Text;
            
            // 查找变量的位置，匹配 ${变量名} 或 ${变量名=默认值}
            string pattern = $@"\$\{{{Regex.Escape(selectedVariable)}(?:=.*?)?\}}";
            Match match = Regex.Match(content, pattern);
            
            if (match.Success)
            {
                // 选中并定位到变量
                contentTextBox.Focus();
                contentTextBox.Select(match.Index, match.Length);
                contentTextBox.ScrollToCaret();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Script.Name = nameTextBox.Text;
            Script.Content = contentTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void insertVariableButton_Click(object sender, EventArgs e)
        {
            // 显示一个对话框，让用户输入变量名和默认值
            var inputForm = new Form();
            inputForm.Text = "插入变量";
            inputForm.Size = new System.Drawing.Size(400, 200);
            inputForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            var variableNameLabel = new System.Windows.Forms.Label();
            variableNameLabel.Text = "变量名:";
            variableNameLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            variableNameLabel.Location = new System.Drawing.Point(30, 30);
            variableNameLabel.AutoSize = true;

            var variableNameTextBox = new System.Windows.Forms.TextBox();
            variableNameTextBox.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            variableNameTextBox.Location = new System.Drawing.Point(100, 27);
            variableNameTextBox.Size = new System.Drawing.Size(250, 25);

            var defaultValueLabel = new System.Windows.Forms.Label();
            defaultValueLabel.Text = "默认值:";
            defaultValueLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            defaultValueLabel.Location = new System.Drawing.Point(30, 70);
            defaultValueLabel.AutoSize = true;

            var defaultValueTextBox = new System.Windows.Forms.TextBox();
            defaultValueTextBox.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            defaultValueTextBox.Location = new System.Drawing.Point(100, 67);
            defaultValueTextBox.Size = new System.Drawing.Size(250, 25);

            var okButton = new System.Windows.Forms.Button();
            okButton.Text = "确定";
            okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            okButton.FlatAppearance.BorderSize = 0;
            okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            okButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            okButton.ForeColor = System.Drawing.Color.White;
            okButton.Location = new System.Drawing.Point(150, 110);
            okButton.Size = new System.Drawing.Size(100, 35);
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;

            var cancelButton = new System.Windows.Forms.Button();
            cancelButton.Text = "取消";
            cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cancelButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cancelButton.ForeColor = System.Drawing.Color.Black;
            cancelButton.Location = new System.Drawing.Point(260, 110);
            cancelButton.Size = new System.Drawing.Size(100, 35);
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            inputForm.Controls.Add(variableNameLabel);
            inputForm.Controls.Add(variableNameTextBox);
            inputForm.Controls.Add(defaultValueLabel);
            inputForm.Controls.Add(defaultValueTextBox);
            inputForm.Controls.Add(okButton);
            inputForm.Controls.Add(cancelButton);

            inputForm.AcceptButton = okButton;
            inputForm.CancelButton = cancelButton;

            if (inputForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string variableName = variableNameTextBox.Text.Trim();
                string defaultValue = defaultValueTextBox.Text.Trim();

                if (!string.IsNullOrEmpty(variableName))
                {
                    string variableSyntax = string.IsNullOrEmpty(defaultValue) ? 
                        $"${{{variableName}}}" : 
                        $"${{{variableName}={defaultValue}}}";

                    // 插入到光标位置
                    int selectionStart = contentTextBox.SelectionStart;
                    contentTextBox.Text = contentTextBox.Text.Insert(selectionStart, variableSyntax);
                    contentTextBox.SelectionStart = selectionStart + variableSyntax.Length;
                    contentTextBox.Focus();
                }
            }
        }
    }
}
