namespace ExportTool
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            // 释放等待计时器
            if (disposing)
            {
                if (waitTimer != null)
                {
                    waitTimer.Stop();
                    waitTimer.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.connectionGroupBox = new System.Windows.Forms.GroupBox();
            this.deleteConnectionButton = new System.Windows.Forms.Button();
            this.editConnectionButton = new System.Windows.Forms.Button();
            this.addConnectionButton = new System.Windows.Forms.Button();
            this.connectionListBox = new System.Windows.Forms.ListBox();
            this.scriptGroupBox = new System.Windows.Forms.GroupBox();
            this.deleteScriptButton = new System.Windows.Forms.Button();
            this.editScriptButton = new System.Windows.Forms.Button();
            this.addScriptButton = new System.Windows.Forms.Button();
            this.scriptListBox = new System.Windows.Forms.ListBox();
            this.variableGroupBox = new System.Windows.Forms.GroupBox();
            this.variablePanel = new System.Windows.Forms.Panel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.queryButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pageInfoLabel = new System.Windows.Forms.Label();
            this.firstPageButton = new System.Windows.Forms.Button();
            this.prevPageButton = new System.Windows.Forms.Button();
            this.nextPageButton = new System.Windows.Forms.Button();
            this.lastPageButton = new System.Windows.Forms.Button();
            this.waitIndicator = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.maskPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.connectionGroupBox.SuspendLayout();
            this.scriptGroupBox.SuspendLayout();
            this.variableGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1000, 600);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.connectionGroupBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.scriptGroupBox);
            this.splitContainer2.Size = new System.Drawing.Size(1000, 250);
            this.splitContainer2.SplitterDistance = 350;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.TabStop = false;
            // 
            // connectionGroupBox
            // 
            this.connectionGroupBox.Controls.Add(this.deleteConnectionButton);
            this.connectionGroupBox.Controls.Add(this.editConnectionButton);
            this.connectionGroupBox.Controls.Add(this.addConnectionButton);
            this.connectionGroupBox.Controls.Add(this.connectionListBox);
            this.connectionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionGroupBox.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionGroupBox.Location = new System.Drawing.Point(0, 0);
            this.connectionGroupBox.Name = "connectionGroupBox";
            this.connectionGroupBox.Size = new System.Drawing.Size(350, 250);
            this.connectionGroupBox.TabIndex = 0;
            this.connectionGroupBox.TabStop = false;
            this.connectionGroupBox.Text = "数据库连接";
            // 
            // deleteConnectionButton
            // 
            this.deleteConnectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteConnectionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.deleteConnectionButton.FlatAppearance.BorderSize = 0;
            this.deleteConnectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteConnectionButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteConnectionButton.ForeColor = System.Drawing.Color.White;
            this.deleteConnectionButton.Location = new System.Drawing.Point(250, 200);
            this.deleteConnectionButton.Name = "deleteConnectionButton";
            this.deleteConnectionButton.Size = new System.Drawing.Size(80, 30);
            this.deleteConnectionButton.TabIndex = 3;
            this.deleteConnectionButton.Text = "删除";
            this.deleteConnectionButton.UseVisualStyleBackColor = false;
            this.deleteConnectionButton.Click += new System.EventHandler(this.deleteConnectionButton_Click);
            // 
            // editConnectionButton
            // 
            this.editConnectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editConnectionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.editConnectionButton.FlatAppearance.BorderSize = 0;
            this.editConnectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editConnectionButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editConnectionButton.ForeColor = System.Drawing.Color.White;
            this.editConnectionButton.Location = new System.Drawing.Point(164, 200);
            this.editConnectionButton.Name = "editConnectionButton";
            this.editConnectionButton.Size = new System.Drawing.Size(80, 30);
            this.editConnectionButton.TabIndex = 2;
            this.editConnectionButton.Text = "编辑";
            this.editConnectionButton.UseVisualStyleBackColor = false;
            this.editConnectionButton.Click += new System.EventHandler(this.editConnectionButton_Click);
            // 
            // addConnectionButton
            // 
            this.addConnectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addConnectionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.addConnectionButton.FlatAppearance.BorderSize = 0;
            this.addConnectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addConnectionButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addConnectionButton.ForeColor = System.Drawing.Color.White;
            this.addConnectionButton.Location = new System.Drawing.Point(78, 200);
            this.addConnectionButton.Name = "addConnectionButton";
            this.addConnectionButton.Size = new System.Drawing.Size(80, 30);
            this.addConnectionButton.TabIndex = 1;
            this.addConnectionButton.Text = "添加";
            this.addConnectionButton.UseVisualStyleBackColor = false;
            this.addConnectionButton.Click += new System.EventHandler(this.addConnectionButton_Click);
            // 
            // connectionListBox
            // 
            this.connectionListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectionListBox.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionListBox.FormattingEnabled = true;
            this.connectionListBox.ItemHeight = 17;
            this.connectionListBox.Location = new System.Drawing.Point(15, 25);
            this.connectionListBox.Name = "connectionListBox";
            this.connectionListBox.Size = new System.Drawing.Size(315, 174);
            this.connectionListBox.TabIndex = 0;
            // 
            // scriptGroupBox
            // 
            this.scriptGroupBox.Controls.Add(this.deleteScriptButton);
            this.scriptGroupBox.Controls.Add(this.editScriptButton);
            this.scriptGroupBox.Controls.Add(this.addScriptButton);
            this.scriptGroupBox.Controls.Add(this.scriptListBox);
            this.scriptGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptGroupBox.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scriptGroupBox.Location = new System.Drawing.Point(0, 0);
            this.scriptGroupBox.Name = "scriptGroupBox";
            this.scriptGroupBox.Size = new System.Drawing.Size(644, 250);
            this.scriptGroupBox.TabIndex = 0;
            this.scriptGroupBox.TabStop = false;
            this.scriptGroupBox.Text = "SQL脚本";
            // 
            // deleteScriptButton
            // 
            this.deleteScriptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteScriptButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.deleteScriptButton.FlatAppearance.BorderSize = 0;
            this.deleteScriptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteScriptButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteScriptButton.ForeColor = System.Drawing.Color.White;
            this.deleteScriptButton.Location = new System.Drawing.Point(554, 200);
            this.deleteScriptButton.Name = "deleteScriptButton";
            this.deleteScriptButton.Size = new System.Drawing.Size(80, 30);
            this.deleteScriptButton.TabIndex = 3;
            this.deleteScriptButton.Text = "删除";
            this.deleteScriptButton.UseVisualStyleBackColor = false;
            this.deleteScriptButton.Click += new System.EventHandler(this.deleteScriptButton_Click);
            // 
            // editScriptButton
            // 
            this.editScriptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editScriptButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.editScriptButton.FlatAppearance.BorderSize = 0;
            this.editScriptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editScriptButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editScriptButton.ForeColor = System.Drawing.Color.White;
            this.editScriptButton.Location = new System.Drawing.Point(468, 200);
            this.editScriptButton.Name = "editScriptButton";
            this.editScriptButton.Size = new System.Drawing.Size(80, 30);
            this.editScriptButton.TabIndex = 2;
            this.editScriptButton.Text = "编辑";
            this.editScriptButton.UseVisualStyleBackColor = false;
            this.editScriptButton.Click += new System.EventHandler(this.editScriptButton_Click);
            // 
            // addScriptButton
            // 
            this.addScriptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addScriptButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.addScriptButton.FlatAppearance.BorderSize = 0;
            this.addScriptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addScriptButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addScriptButton.ForeColor = System.Drawing.Color.White;
            this.addScriptButton.Location = new System.Drawing.Point(382, 200);
            this.addScriptButton.Name = "addScriptButton";
            this.addScriptButton.Size = new System.Drawing.Size(80, 30);
            this.addScriptButton.TabIndex = 1;
            this.addScriptButton.Text = "添加";
            this.addScriptButton.UseVisualStyleBackColor = false;
            this.addScriptButton.Click += new System.EventHandler(this.addScriptButton_Click);
            // 
            // scriptListBox
            // 
            this.scriptListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptListBox.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scriptListBox.FormattingEnabled = true;
            this.scriptListBox.ItemHeight = 17;
            this.scriptListBox.Location = new System.Drawing.Point(15, 25);
            this.scriptListBox.Name = "scriptListBox";
            this.scriptListBox.Size = new System.Drawing.Size(619, 174);
            this.scriptListBox.TabIndex = 0;
            this.scriptListBox.SelectedIndexChanged += new System.EventHandler(this.scriptListBox_SelectedIndexChanged);
            // 
            // variableGroupBox
            // 
            this.variableGroupBox.Controls.Add(this.variablePanel);
            this.variableGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.variableGroupBox.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variableGroupBox.Location = new System.Drawing.Point(0, 0);
            this.variableGroupBox.Name = "variableGroupBox";
            this.variableGroupBox.Size = new System.Drawing.Size(350, 344);
            this.variableGroupBox.TabIndex = 0;
            this.variableGroupBox.TabStop = false;
            this.variableGroupBox.Text = "变量";
            // 
            // variablePanel
            // 
            this.variablePanel.AutoScroll = true;
            this.variablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.variablePanel.Location = new System.Drawing.Point(3, 22);
            this.variablePanel.Name = "variablePanel";
            this.variablePanel.Size = new System.Drawing.Size(344, 319);
            this.variablePanel.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.variableGroupBox);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dataGridView);
            this.splitContainer3.Panel2.Controls.Add(this.queryButton);
            this.splitContainer3.Panel2.Controls.Add(this.exportButton);
            this.splitContainer3.Panel2.Controls.Add(this.pageInfoLabel);
            this.splitContainer3.Panel2.Controls.Add(this.firstPageButton);
            this.splitContainer3.Panel2.Controls.Add(this.prevPageButton);
            this.splitContainer3.Panel2.Controls.Add(this.nextPageButton);
            this.splitContainer3.Panel2.Controls.Add(this.lastPageButton);
            this.splitContainer3.Panel2.Controls.Add(this.waitIndicator);
            this.splitContainer3.Size = new System.Drawing.Size(1000, 344);
            this.splitContainer3.SplitterDistance = 350;
            this.splitContainer3.SplitterWidth = 6;
            this.splitContainer3.TabIndex = 0;
            this.splitContainer3.TabStop = false;
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(10, 10);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(628, 280);
            this.dataGridView.TabIndex = 0;
            // 
            // queryButton
            // 
            this.queryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.queryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.queryButton.FlatAppearance.BorderSize = 0;
            this.queryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.queryButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queryButton.ForeColor = System.Drawing.Color.White;
            this.queryButton.Location = new System.Drawing.Point(10, 300);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(120, 35);
            this.queryButton.TabIndex = 1;
            this.queryButton.Text = "执行查询";
            this.queryButton.UseVisualStyleBackColor = false;
            this.queryButton.Click += new System.EventHandler(this.queryButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.exportButton.FlatAppearance.BorderSize = 0;
            this.exportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportButton.ForeColor = System.Drawing.Color.White;
            this.exportButton.Location = new System.Drawing.Point(528, 300);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(110, 35);
            this.exportButton.TabIndex = 8;
            this.exportButton.Text = "导出Excel";
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // pageInfoLabel
            // 
            this.pageInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pageInfoLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageInfoLabel.Location = new System.Drawing.Point(140, 308);
            this.pageInfoLabel.Name = "pageInfoLabel";
            this.pageInfoLabel.Size = new System.Drawing.Size(130, 20);
            this.pageInfoLabel.TabIndex = 3;
            this.pageInfoLabel.Text = "第 1 页，共 0 页";
            this.pageInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // firstPageButton
            // 
            this.firstPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.firstPageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.firstPageButton.FlatAppearance.BorderSize = 0;
            this.firstPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.firstPageButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstPageButton.ForeColor = System.Drawing.Color.Black;
            this.firstPageButton.Location = new System.Drawing.Point(276, 300);
            this.firstPageButton.Name = "firstPageButton";
            this.firstPageButton.Size = new System.Drawing.Size(60, 35);
            this.firstPageButton.TabIndex = 4;
            this.firstPageButton.Text = "首页";
            this.firstPageButton.UseVisualStyleBackColor = false;
            this.firstPageButton.Click += new System.EventHandler(this.firstPageButton_Click);
            // 
            // prevPageButton
            // 
            this.prevPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prevPageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.prevPageButton.FlatAppearance.BorderSize = 0;
            this.prevPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevPageButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevPageButton.ForeColor = System.Drawing.Color.Black;
            this.prevPageButton.Location = new System.Drawing.Point(342, 300);
            this.prevPageButton.Name = "prevPageButton";
            this.prevPageButton.Size = new System.Drawing.Size(60, 35);
            this.prevPageButton.TabIndex = 5;
            this.prevPageButton.Text = "上一页";
            this.prevPageButton.UseVisualStyleBackColor = false;
            this.prevPageButton.Click += new System.EventHandler(this.prevPageButton_Click);
            // 
            // nextPageButton
            // 
            this.nextPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nextPageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.nextPageButton.FlatAppearance.BorderSize = 0;
            this.nextPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextPageButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextPageButton.ForeColor = System.Drawing.Color.Black;
            this.nextPageButton.Location = new System.Drawing.Point(408, 300);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(60, 35);
            this.nextPageButton.TabIndex = 6;
            this.nextPageButton.Text = "下一页";
            this.nextPageButton.UseVisualStyleBackColor = false;
            this.nextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // lastPageButton
            // 
            this.lastPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lastPageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.lastPageButton.FlatAppearance.BorderSize = 0;
            this.lastPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lastPageButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastPageButton.ForeColor = System.Drawing.Color.Black;
            this.lastPageButton.Location = new System.Drawing.Point(474, 300);
            this.lastPageButton.Name = "lastPageButton";
            this.lastPageButton.Size = new System.Drawing.Size(60, 35);
            this.lastPageButton.TabIndex = 7;
            this.lastPageButton.Text = "末页";
            this.lastPageButton.UseVisualStyleBackColor = false;
            this.lastPageButton.Click += new System.EventHandler(this.lastPageButton_Click);
            // 
            // waitIndicator
            // 
            this.waitIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.waitIndicator.Location = new System.Drawing.Point(600, 10);
            this.waitIndicator.Name = "waitIndicator";
            this.waitIndicator.Size = new System.Drawing.Size(30, 30);
            this.waitIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.waitIndicator.TabIndex = 6;
            this.waitIndicator.TabStop = false;
            this.waitIndicator.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar.Location = new System.Drawing.Point(300, 300);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(400, 12);
            this.progressBar.TabIndex = 7;
            this.progressBar.Visible = false;
            this.progressBar.ForeColor = System.Drawing.Color.Blue;
            this.progressBar.BackColor = System.Drawing.Color.LightGray;
            // 
            // maskPanel
            // 
            this.maskPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.maskPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maskPanel.Location = new System.Drawing.Point(0, 0);
            this.maskPanel.Name = "maskPanel";
            this.maskPanel.Size = new System.Drawing.Size(1000, 622);
            this.maskPanel.TabIndex = 8;
            this.maskPanel.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 600);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1000, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(129, 17);
            this.toolStripStatusLabel1.Text = "就绪 - 等待操作";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 622);
            this.Controls.Add(this.maskPanel);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.progressBar);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "数据库查询导出工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.connectionGroupBox.ResumeLayout(false);
            this.scriptGroupBox.ResumeLayout(false);
            this.variableGroupBox.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox connectionGroupBox;
        private System.Windows.Forms.Button deleteConnectionButton;
        private System.Windows.Forms.Button editConnectionButton;
        private System.Windows.Forms.Button addConnectionButton;
        private System.Windows.Forms.ListBox connectionListBox;
        private System.Windows.Forms.GroupBox scriptGroupBox;
        private System.Windows.Forms.Button deleteScriptButton;
        private System.Windows.Forms.Button editScriptButton;
        private System.Windows.Forms.Button addScriptButton;
        private System.Windows.Forms.ListBox scriptListBox;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox variableGroupBox;
        private System.Windows.Forms.Panel variablePanel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button queryButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label pageInfoLabel;
        private System.Windows.Forms.Button firstPageButton;
        private System.Windows.Forms.Button prevPageButton;
        private System.Windows.Forms.Button nextPageButton;
        private System.Windows.Forms.Button lastPageButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox waitIndicator;
    }
}
