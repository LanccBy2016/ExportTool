using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportTool
{
    public partial class MainForm : Form
    {
        private List<DatabaseConnection> connections = new List<DatabaseConnection>();
        private List<SqlScript> scripts = new List<SqlScript>();
        private string dataDirectory;
        private string connectionsFile;
        private string scriptsFile;
        private DataTable fullDataTable;
        private int currentPage = 1;
        private const int pageSize = 100;
        private System.Windows.Forms.Timer waitTimer;
        private System.Windows.Forms.Panel maskPanel;

        public MainForm()
        {
            InitializeComponent();
            dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
            if (!Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }
            connectionsFile = Path.Combine(dataDirectory, "connections.json");
            scriptsFile = Path.Combine(dataDirectory, "scripts.json");
            
            // 初始化等待计时器
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100;
            waitTimer.Tick += new System.EventHandler(this.waitTimer_Tick);
            
            LoadConnections();
            LoadScripts();
        }



        private void UpdateStatus(string message)
        {
            toolStripStatusLabel1.Text = message;
        }

        private void ShowWaitIndicator(bool show)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(ShowWaitIndicator), show);
                return;
            }
            
            // 控制蒙板显示
            if (maskPanel != null)
            {
                maskPanel.Visible = show;
                // 确保蒙板在所有控件的前面，除了等待指示器
                if (show)
                {
                    maskPanel.BringToFront();
                }
            }
            
            // 使用ProgressBar作为等待指示器
            if (progressBar != null)
            {
                progressBar.Style = ProgressBarStyle.Marquee;
                progressBar.MarqueeAnimationSpeed = 30;
                progressBar.Visible = show;
                // 确保控件在最前面
                if (show)
                {
                    // 调整progressBar的位置到页面正中间
                    progressBar.Left = (this.ClientSize.Width - progressBar.Width) / 2;
                    progressBar.Top = (this.ClientSize.Height - progressBar.Height) / 2;
                    progressBar.BringToFront();
                }
            }
        }

        private void waitTimer_Tick(object sender, EventArgs e)
        {
            // 动画GIF会自动播放，不需要手动旋转
        }

        private void LoadConnections()
        {
            if (File.Exists(connectionsFile))
            {
                try
                {
                    var json = File.ReadAllText(connectionsFile);
                    connections = JsonHelper.Deserialize<List<DatabaseConnection>>(json);
                    connectionListBox.DataSource = connections;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载连接失败: " + ex.Message);
                }
            }
        }

        private void SaveConnections()
        {
            try
            {
                var json = JsonHelper.SerializeIndented(connections);
                File.WriteAllText(connectionsFile, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存连接失败: " + ex.Message);
            }
        }

        private void LoadScripts()
        {
            if (File.Exists(scriptsFile))
            {
                try
                {
                    var json = File.ReadAllText(scriptsFile);
                    scripts = JsonHelper.Deserialize<List<SqlScript>>(json);
                    scriptListBox.DataSource = scripts;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载脚本失败: " + ex.Message);
                }
            }
        }

        private void SaveScripts()
        {
            try
            {
                var json = JsonHelper.SerializeIndented(scripts);
                File.WriteAllText(scriptsFile, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存脚本失败: " + ex.Message);
            }
        }

        private void addConnectionButton_Click(object sender, EventArgs e)
        {
            var form = new ConnectionForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                connections.Add(form.Connection);
                connectionListBox.DataSource = null;
                connectionListBox.DataSource = connections;
                SaveConnections();
            }
        }

        private void editConnectionButton_Click(object sender, EventArgs e)
        {
            if (connectionListBox.SelectedItem != null)
            {
                var connection = (DatabaseConnection)connectionListBox.SelectedItem;
                var form = new ConnectionForm(connection);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var index = connections.IndexOf(connection);
                    connections[index] = form.Connection;
                    connectionListBox.DataSource = null;
                    connectionListBox.DataSource = connections;
                    SaveConnections();
                }
            }
        }

        private void deleteConnectionButton_Click(object sender, EventArgs e)
        {
            if (connectionListBox.SelectedItem != null)
            {
                if (MessageBox.Show("确定要删除这个连接吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    connections.Remove((DatabaseConnection)connectionListBox.SelectedItem);
                    connectionListBox.DataSource = null;
                    connectionListBox.DataSource = connections;
                    SaveConnections();
                }
            }
        }

        private void addScriptButton_Click(object sender, EventArgs e)
        {
            var form = new ScriptForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                scripts.Add(form.Script);
                scriptListBox.DataSource = null;
                scriptListBox.DataSource = scripts;
                SaveScripts();
            }
        }

        private void editScriptButton_Click(object sender, EventArgs e)
        {
            if (scriptListBox.SelectedItem != null)
            {
                var script = (SqlScript)scriptListBox.SelectedItem;
                var form = new ScriptForm(script);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var index = scripts.IndexOf(script);
                    scripts[index] = form.Script;
                    scriptListBox.DataSource = null;
                    scriptListBox.DataSource = scripts;
                    SaveScripts();
                }
            }
        }

        private void deleteScriptButton_Click(object sender, EventArgs e)
        {
            if (scriptListBox.SelectedItem != null)
            {
                if (MessageBox.Show("确定要删除这个脚本吗?", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    scripts.Remove((SqlScript)scriptListBox.SelectedItem);
                    scriptListBox.DataSource = null;
                    scriptListBox.DataSource = scripts;
                    SaveScripts();
                }
            }
        }

        private void scriptListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateVariablePanel();
        }

        private void UpdateVariablePanel()
        {
            variablePanel.Controls.Clear();
            if (scriptListBox.SelectedItem != null)
            {
                var script = (SqlScript)scriptListBox.SelectedItem;
                int y = 10;
                foreach (var variable in script.GetVariables())
                {
                    var label = new Label();
                    label.Text = variable.Name + ":";
                    label.Location = new Point(10, y);
                    label.Size = new Size(100, 20);
                    variablePanel.Controls.Add(label);

                    var textBox = new TextBox();
                    textBox.Name = "var_" + variable.Name;
                    textBox.Location = new Point(110, y);
                    textBox.Size = new Size(200, 20);
                    textBox.Text = variable.DefaultValue;
                    variablePanel.Controls.Add(textBox);

                    y += 30;
                }
            }
        }

        private async void queryButton_Click(object sender, EventArgs e)
        {
            if (connectionListBox.SelectedItem == null)
            {
                MessageBox.Show("请选择一个数据库连接");
                return;
            }

            if (scriptListBox.SelectedItem == null)
            {
                MessageBox.Show("请选择一个SQL脚本");
                return;
            }

            var connection = (DatabaseConnection)connectionListBox.SelectedItem;
            var script = (SqlScript)scriptListBox.SelectedItem;

            // 验证连接信息
            if (string.IsNullOrEmpty(connection.Server) || string.IsNullOrEmpty(connection.Database) || string.IsNullOrEmpty(connection.Username))
            {
                MessageBox.Show("数据库连接信息不完整");
                return;
            }

            string sql = script.Content;

            foreach (var variable in script.GetVariables())
            {
                var textBox = variablePanel.Controls.Find("var_" + variable.Name, false).FirstOrDefault() as TextBox;
                if (textBox != null)
                {
                    sql = sql.Replace("${" + variable.Name + (string.IsNullOrEmpty(variable.DefaultValue) ? "" : "=" + variable.DefaultValue) + "}", textBox.Text);
                }
            }

            try
            {
                UpdateStatus("正在执行查询...");
                ShowWaitIndicator(true);
                queryButton.Enabled = false;
                exportButton.Enabled = false;
                firstPageButton.Enabled = false;
                prevPageButton.Enabled = false;
                nextPageButton.Enabled = false;
                lastPageButton.Enabled = false;

                // 异步执行查询
                DataTable resultTable = await Task.Run(() =>
                {
                    using (var conn = connection.CreateConnection())
                    {
                        conn.Open();
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = sql;
                            var table = new DataTable();
                            if (connection.Type == DatabaseConnection.DatabaseType.SqlServer)
                            {
                                using (var adapter = new System.Data.SqlClient.SqlDataAdapter((System.Data.SqlClient.SqlCommand)cmd))
                                {
                                    adapter.Fill(table);
                                }
                            }
                            else
                            {
                                using (var adapter = new MySqlConnector.MySqlDataAdapter((MySqlConnector.MySqlCommand)cmd))
                                {
                                    adapter.Fill(table);
                                }
                            }
                            return table;
                        }
                    }
                });

                // 释放之前的DataTable，避免内存泄漏
                if (fullDataTable != null)
                {
                    fullDataTable.Dispose();
                    fullDataTable = null;
                }

                // 赋值新的DataTable
                fullDataTable = resultTable;
                currentPage = 1;
                ShowCurrentPage();
                UpdateStatus(string.Format("查询完成，共 {0} 条记录", fullDataTable.Rows.Count));
            }
            catch (Exception ex)
            {
                // 详细记录错误信息
                string errorMessage = $"查询失败: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMessage += $"\n内部错误: {ex.InnerException.Message}";
                }
                MessageBox.Show(errorMessage);
                UpdateStatus("查询失败");
            }
            finally
            {
                ShowWaitIndicator(false);
                queryButton.Enabled = true;
                exportButton.Enabled = true;
                if (fullDataTable != null && fullDataTable.Rows.Count > 0)
                {
                    int totalPages = (fullDataTable.Rows.Count + pageSize - 1) / pageSize;
                    firstPageButton.Enabled = currentPage > 1;
                    prevPageButton.Enabled = currentPage > 1;
                    nextPageButton.Enabled = currentPage < totalPages;
                    lastPageButton.Enabled = currentPage < totalPages;
                }
            }
        }

        private void ShowCurrentPage()
        {
            if (fullDataTable == null || fullDataTable.Rows.Count == 0)
            {
                dataGridView.DataSource = null;
                pageInfoLabel.Text = "第 0 页，共 0 页";
                firstPageButton.Enabled = false;
                prevPageButton.Enabled = false;
                nextPageButton.Enabled = false;
                lastPageButton.Enabled = false;
                return;
            }

            int totalPages = (fullDataTable.Rows.Count + pageSize - 1) / pageSize;
            int startIndex = (currentPage - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, fullDataTable.Rows.Count);

            DataTable pageTable = new DataTable();
            pageTable.Columns.Add("行号", typeof(int));
            foreach (DataColumn col in fullDataTable.Columns)
            {
                pageTable.Columns.Add(col.ColumnName, col.DataType);
            }
            
            for (int i = startIndex; i < endIndex; i++)
            {
                DataRow newRow = pageTable.NewRow();
                newRow["行号"] = i + 1;
                for (int j = 0; j < fullDataTable.Columns.Count; j++)
                {
                    newRow[j + 1] = fullDataTable.Rows[i][j];
                }
                pageTable.Rows.Add(newRow);
            }

            dataGridView.DataSource = pageTable;
            dataGridView.Columns["行号"].ReadOnly = true;
            dataGridView.Columns["行号"].Width = 60;
            dataGridView.Columns["行号"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["行号"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            pageInfoLabel.Text = $"第 {currentPage} 页，共 {totalPages} 页";
            firstPageButton.Enabled = currentPage > 1;
            prevPageButton.Enabled = currentPage > 1;
            nextPageButton.Enabled = currentPage < totalPages;
            lastPageButton.Enabled = currentPage < totalPages;
        }

        private void firstPageButton_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage = 1;
                ShowCurrentPage();
            }
        }

        private void lastPageButton_Click(object sender, EventArgs e)
        {
            if (fullDataTable != null)
            {
                int totalPages = (fullDataTable.Rows.Count + pageSize - 1) / pageSize;
                if (currentPage < totalPages)
                {
                    currentPage = totalPages;
                    ShowCurrentPage();
                }
            }
        }

        private void prevPageButton_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                ShowCurrentPage();
            }
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            if (fullDataTable != null)
            {
                int totalPages = (fullDataTable.Rows.Count + pageSize - 1) / pageSize;
                if (currentPage < totalPages)
                {
                    currentPage++;
                    ShowCurrentPage();
                }
            }
        }

        private async void exportButton_Click(object sender, EventArgs e)
        {
            if (fullDataTable == null || fullDataTable.Rows.Count == 0)
            {
                MessageBox.Show("请先执行查询获取数据");
                return;
            }

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel文件 (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "保存Excel文件";
                saveFileDialog.RestoreDirectory = true;
                
                // 设置默认文件名为脚本名称+时间戳
                if (scriptListBox.SelectedItem != null)
                {
                    var script = (SqlScript)scriptListBox.SelectedItem;
                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    saveFileDialog.FileName = $"{script.Name}_{timestamp}.xlsx";
                }
                
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        UpdateStatus("正在导出Excel文件...");
                        ShowWaitIndicator(true);
                        string filePath = saveFileDialog.FileName;
                        
                        queryButton.Enabled = false;
                        exportButton.Enabled = false;
                        firstPageButton.Enabled = false;
                        prevPageButton.Enabled = false;
                        nextPageButton.Enabled = false;
                        lastPageButton.Enabled = false;
                        
                        // 异步导出
                        await Task.Run(() =>
                        {
                            var exporter = new ExcelExporter();
                            exporter.Export(filePath, fullDataTable);
                        });
                        
                        if (File.Exists(filePath))
                        {
                            UpdateStatus("导出完成");
                        }
                        else
                        {
                            MessageBox.Show("导出失败：文件未创建");
                            UpdateStatus("导出失败");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("导出失败: " + ex.Message);
                        UpdateStatus("导出失败");
                    }
                    finally
                    {
                        ShowWaitIndicator(false);
                        queryButton.Enabled = true;
                        exportButton.Enabled = true;
                        if (fullDataTable != null && fullDataTable.Rows.Count > 0)
                        {
                            int totalPages = (fullDataTable.Rows.Count + pageSize - 1) / pageSize;
                            firstPageButton.Enabled = currentPage > 1;
                            prevPageButton.Enabled = currentPage > 1;
                            nextPageButton.Enabled = currentPage < totalPages;
                            lastPageButton.Enabled = currentPage < totalPages;
                        }
                    }
                }
            }
        }
    }
}
