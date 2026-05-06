namespace TaskManager
{
    partial class TaskManager
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskManager));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.btnFilterCompleted = new System.Windows.Forms.Button();
            this.btnFilterUpcoming = new System.Windows.Forms.Button();
            this.btnFilterActive = new System.Windows.Forms.Button();
            this.btnFilterAll = new System.Windows.Forms.Button();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuImportDB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportDB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAutoRun = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAutoRunEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAutoRunDisabled = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTray = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTrayEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTrayDisabled = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThemeWhite = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThemeBlack = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.btnAddTaskIcon = new System.Windows.Forms.ToolStripButton();
            this.lblSpacing = new System.Windows.Forms.ToolStripLabel();
            this.btnAddTaskText = new System.Windows.Forms.ToolStripLabel();
            this.imglist1 = new System.Windows.Forms.ImageList(this.components);
            this.nameRightPanel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.ColStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDeadline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvSubtasks = new System.Windows.Forms.DataGridView();
            this.SubtaskStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SubtaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpDeadline = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAlarm = new System.Windows.Forms.CheckBox();
            this.txtDetailsName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDetailsPriority = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelFilters.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubtasks)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 479);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1137, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panelFilters
            // 
            this.panelFilters.Controls.Add(this.btnFilterCompleted);
            this.panelFilters.Controls.Add(this.btnFilterUpcoming);
            this.panelFilters.Controls.Add(this.btnFilterActive);
            this.panelFilters.Controls.Add(this.btnFilterAll);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelFilters.Location = new System.Drawing.Point(0, 0);
            this.panelFilters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Padding = new System.Windows.Forms.Padding(0, 37, 0, 0);
            this.panelFilters.Size = new System.Drawing.Size(175, 473);
            this.panelFilters.TabIndex = 3;
            // 
            // btnFilterCompleted
            // 
            this.btnFilterCompleted.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFilterCompleted.Location = new System.Drawing.Point(0, 148);
            this.btnFilterCompleted.Margin = new System.Windows.Forms.Padding(4);
            this.btnFilterCompleted.Name = "btnFilterCompleted";
            this.btnFilterCompleted.Size = new System.Drawing.Size(175, 37);
            this.btnFilterCompleted.TabIndex = 3;
            this.btnFilterCompleted.TabStop = false;
            this.btnFilterCompleted.Text = "Выполненные";
            this.btnFilterCompleted.UseVisualStyleBackColor = true;
            this.btnFilterCompleted.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnFilterUpcoming
            // 
            this.btnFilterUpcoming.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFilterUpcoming.Location = new System.Drawing.Point(0, 111);
            this.btnFilterUpcoming.Margin = new System.Windows.Forms.Padding(4);
            this.btnFilterUpcoming.Name = "btnFilterUpcoming";
            this.btnFilterUpcoming.Size = new System.Drawing.Size(175, 37);
            this.btnFilterUpcoming.TabIndex = 2;
            this.btnFilterUpcoming.TabStop = false;
            this.btnFilterUpcoming.Text = "Ближайшие";
            this.btnFilterUpcoming.UseVisualStyleBackColor = true;
            this.btnFilterUpcoming.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnFilterActive
            // 
            this.btnFilterActive.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFilterActive.Location = new System.Drawing.Point(0, 74);
            this.btnFilterActive.Margin = new System.Windows.Forms.Padding(4);
            this.btnFilterActive.Name = "btnFilterActive";
            this.btnFilterActive.Size = new System.Drawing.Size(175, 37);
            this.btnFilterActive.TabIndex = 1;
            this.btnFilterActive.TabStop = false;
            this.btnFilterActive.Text = "Активные";
            this.btnFilterActive.UseVisualStyleBackColor = true;
            this.btnFilterActive.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnFilterAll
            // 
            this.btnFilterAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFilterAll.Location = new System.Drawing.Point(0, 37);
            this.btnFilterAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnFilterAll.Name = "btnFilterAll";
            this.btnFilterAll.Size = new System.Drawing.Size(175, 37);
            this.btnFilterAll.TabIndex = 0;
            this.btnFilterAll.TabStop = false;
            this.btnFilterAll.Text = "Все задачи";
            this.btnFilterAll.UseCompatibleTextRendering = true;
            this.btnFilterAll.UseVisualStyleBackColor = true;
            this.btnFilterAll.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // menuMain
            // 
            this.menuMain.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuTools,
            this.menuTheme});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuMain.Size = new System.Drawing.Size(1137, 28);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuMain";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuImportDB,
            this.menuExportDB,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(59, 24);
            this.menuFile.Text = "Файл";
            // 
            // menuImportDB
            // 
            this.menuImportDB.Name = "menuImportDB";
            this.menuImportDB.Size = new System.Drawing.Size(171, 26);
            this.menuImportDB.Text = "Импорт БД";
            // 
            // menuExportDB
            // 
            this.menuExportDB.Name = "menuExportDB";
            this.menuExportDB.Size = new System.Drawing.Size(171, 26);
            this.menuExportDB.Text = "Экспорт БД";
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(171, 26);
            this.menuExit.Text = "Выход";
            this.menuExit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAutoRun,
            this.menuTray});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(117, 24);
            this.menuTools.Text = "Инструменты";
            // 
            // menuAutoRun
            // 
            this.menuAutoRun.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAutoRunEnabled,
            this.menuAutoRunDisabled});
            this.menuAutoRun.Name = "menuAutoRun";
            this.menuAutoRun.Size = new System.Drawing.Size(204, 26);
            this.menuAutoRun.Text = "Автозапуск";
            // 
            // menuAutoRunEnabled
            // 
            this.menuAutoRunEnabled.Name = "menuAutoRunEnabled";
            this.menuAutoRunEnabled.Size = new System.Drawing.Size(164, 26);
            this.menuAutoRunEnabled.Text = "Включен";
            // 
            // menuAutoRunDisabled
            // 
            this.menuAutoRunDisabled.Name = "menuAutoRunDisabled";
            this.menuAutoRunDisabled.Size = new System.Drawing.Size(164, 26);
            this.menuAutoRunDisabled.Text = "Выключен";
            // 
            // menuTray
            // 
            this.menuTray.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTrayEnabled,
            this.menuTrayDisabled});
            this.menuTray.Name = "menuTray";
            this.menuTray.Size = new System.Drawing.Size(204, 26);
            this.menuTray.Text = "Свернуть в трей";
            // 
            // menuTrayEnabled
            // 
            this.menuTrayEnabled.Name = "menuTrayEnabled";
            this.menuTrayEnabled.Size = new System.Drawing.Size(173, 26);
            this.menuTrayEnabled.Text = "Включено";
            // 
            // menuTrayDisabled
            // 
            this.menuTrayDisabled.Name = "menuTrayDisabled";
            this.menuTrayDisabled.Size = new System.Drawing.Size(173, 26);
            this.menuTrayDisabled.Text = "Выключено";
            // 
            // menuTheme
            // 
            this.menuTheme.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuThemeWhite,
            this.menuThemeBlack});
            this.menuTheme.Name = "menuTheme";
            this.menuTheme.Size = new System.Drawing.Size(58, 24);
            this.menuTheme.Text = "Тема";
            // 
            // menuThemeWhite
            // 
            this.menuThemeWhite.Name = "menuThemeWhite";
            this.menuThemeWhite.Size = new System.Drawing.Size(147, 26);
            this.menuThemeWhite.Text = "Светлая";
            this.menuThemeWhite.Click += new System.EventHandler(this.menuThemeWhite_Click);
            // 
            // menuThemeBlack
            // 
            this.menuThemeBlack.Name = "menuThemeBlack";
            this.menuThemeBlack.Size = new System.Drawing.Size(147, 26);
            this.menuThemeBlack.Text = "Тёмная";
            this.menuThemeBlack.Click += new System.EventHandler(this.menuThemeBlack_Click);
            // 
            // toolStripMain
            // 
            this.toolStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddTaskIcon,
            this.lblSpacing,
            this.btnAddTaskText});
            this.toolStripMain.Location = new System.Drawing.Point(0, 30);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripMain.Size = new System.Drawing.Size(158, 27);
            this.toolStripMain.TabIndex = 1;
            this.toolStripMain.Text = "toolStripMain";
            // 
            // btnAddTaskIcon
            // 
            this.btnAddTaskIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddTaskIcon.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTaskIcon.Image")));
            this.btnAddTaskIcon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddTaskIcon.Name = "btnAddTaskIcon";
            this.btnAddTaskIcon.Size = new System.Drawing.Size(29, 24);
            this.btnAddTaskIcon.Click += new System.EventHandler(this.btnAddTaskIcon_Click);
            // 
            // lblSpacing
            // 
            this.lblSpacing.Name = "lblSpacing";
            this.lblSpacing.Size = new System.Drawing.Size(0, 24);
            // 
            // btnAddTaskText
            // 
            this.btnAddTaskText.Name = "btnAddTaskText";
            this.btnAddTaskText.Size = new System.Drawing.Size(126, 24);
            this.btnAddTaskText.Text = "Добавить задачу";
            this.btnAddTaskText.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // imglist1
            // 
            this.imglist1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist1.ImageStream")));
            this.imglist1.TransparentColor = System.Drawing.Color.Transparent;
            this.imglist1.Images.SetKeyName(0, "free-icon-plus-4604818.png");
            // 
            // nameRightPanel
            // 
            this.nameRightPanel.AutoSize = true;
            this.nameRightPanel.Location = new System.Drawing.Point(5, 0);
            this.nameRightPanel.Name = "nameRightPanel";
            this.nameRightPanel.Size = new System.Drawing.Size(106, 16);
            this.nameRightPanel.TabIndex = 5;
            this.nameRightPanel.Text = "Детали задачи";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvTasks);
            this.splitContainer1.Panel1.Controls.Add(this.panelFilters);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel2.Controls.Add(this.dgvSubtasks);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.nameRightPanel);
            this.splitContainer1.Panel2.Controls.Add(this.dtpDeadline);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.cbAlarm);
            this.splitContainer1.Panel2.Controls.Add(this.txtDetailsName);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.cmbDetailsPriority);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Enabled = false;
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Panel2MinSize = 200;
            this.splitContainer1.Size = new System.Drawing.Size(1137, 473);
            this.splitContainer1.SplitterDistance = 857;
            this.splitContainer1.TabIndex = 17;
            // 
            // dgvTasks
            // 
            this.dgvTasks.AccessibleName = "dgvTasks";
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColStatus,
            this.ColName,
            this.ColPriority,
            this.ColDeadline});
            this.dgvTasks.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTasks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTasks.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvTasks.Location = new System.Drawing.Point(175, 0);
            this.dgvTasks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.RowHeadersWidth = 51;
            this.dgvTasks.RowTemplate.Height = 24;
            this.dgvTasks.Size = new System.Drawing.Size(682, 473);
            this.dgvTasks.TabIndex = 4;
            this.dgvTasks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTasks_CellContentClick);
            this.dgvTasks.SelectionChanged += new System.EventHandler(this.dgvTasks_SelectionChanged);
            // 
            // ColStatus
            // 
            this.ColStatus.FillWeight = 21.39038F;
            this.ColStatus.HeaderText = "";
            this.ColStatus.MinimumWidth = 6;
            this.ColStatus.Name = "ColStatus";
            this.ColStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColStatus.ToolTipText = "Выполнение задачи";
            // 
            // ColName
            // 
            this.ColName.FillWeight = 126.2032F;
            this.ColName.HeaderText = "Задача";
            this.ColName.MinimumWidth = 6;
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            this.ColName.ToolTipText = "Название задачи";
            // 
            // ColPriority
            // 
            this.ColPriority.FillWeight = 126.2032F;
            this.ColPriority.HeaderText = "Сложность";
            this.ColPriority.MinimumWidth = 6;
            this.ColPriority.Name = "ColPriority";
            this.ColPriority.ReadOnly = true;
            this.ColPriority.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColPriority.ToolTipText = "Сложность выполнения задачи";
            // 
            // ColDeadline
            // 
            this.ColDeadline.FillWeight = 126.2032F;
            this.ColDeadline.HeaderText = "Срок";
            this.ColDeadline.MinimumWidth = 6;
            this.ColDeadline.Name = "ColDeadline";
            this.ColDeadline.ReadOnly = true;
            this.ColDeadline.ToolTipText = "Срок выполнения задачи";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(279, 369);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 23);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvSubtasks
            // 
            this.dgvSubtasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubtasks.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSubtasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubtasks.ColumnHeadersVisible = false;
            this.dgvSubtasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubtaskStatus,
            this.SubtaskName});
            this.dgvSubtasks.Location = new System.Drawing.Point(8, 100);
            this.dgvSubtasks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSubtasks.Name = "dgvSubtasks";
            this.dgvSubtasks.RowHeadersVisible = false;
            this.dgvSubtasks.RowHeadersWidth = 51;
            this.dgvSubtasks.RowTemplate.Height = 24;
            this.dgvSubtasks.Size = new System.Drawing.Size(351, 114);
            this.dgvSubtasks.TabIndex = 12;
            this.dgvSubtasks.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubtasks_CellValueChanged);
            this.dgvSubtasks.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvSubtasks_CurrentCellDirtyStateChanged);
            // 
            // SubtaskStatus
            // 
            this.SubtaskStatus.FillWeight = 20F;
            this.SubtaskStatus.HeaderText = "";
            this.SubtaskStatus.MinimumWidth = 6;
            this.SubtaskStatus.Name = "SubtaskStatus";
            // 
            // SubtaskName
            // 
            this.SubtaskName.HeaderText = "Подзадача";
            this.SubtaskName.MinimumWidth = 6;
            this.SubtaskName.Name = "SubtaskName";
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(161, 369);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpDeadline
            // 
            this.dtpDeadline.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpDeadline.CalendarTitleForeColor = System.Drawing.Color.AliceBlue;
            this.dtpDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDeadline.Location = new System.Drawing.Point(199, 256);
            this.dtpDeadline.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDeadline.Name = "dtpDeadline";
            this.dtpDeadline.Size = new System.Drawing.Size(159, 22);
            this.dtpDeadline.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Название:";
            // 
            // cbAlarm
            // 
            this.cbAlarm.AutoSize = true;
            this.cbAlarm.BackColor = System.Drawing.SystemColors.Window;
            this.cbAlarm.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbAlarm.Location = new System.Drawing.Point(8, 256);
            this.cbAlarm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbAlarm.Name = "cbAlarm";
            this.cbAlarm.Size = new System.Drawing.Size(166, 20);
            this.cbAlarm.TabIndex = 13;
            this.cbAlarm.Text = "Включить будильник";
            this.cbAlarm.UseVisualStyleBackColor = false;
            // 
            // txtDetailsName
            // 
            this.txtDetailsName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetailsName.Location = new System.Drawing.Point(7, 50);
            this.txtDetailsName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDetailsName.Name = "txtDetailsName";
            this.txtDetailsName.Size = new System.Drawing.Size(351, 22);
            this.txtDetailsName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Подзадачи:";
            // 
            // cmbDetailsPriority
            // 
            this.cmbDetailsPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDetailsPriority.FormattingEnabled = true;
            this.cmbDetailsPriority.Items.AddRange(new object[] {
            "Высокая",
            "Средняя",
            "Низкая"});
            this.cmbDetailsPriority.Location = new System.Drawing.Point(199, 219);
            this.cmbDetailsPriority.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDetailsPriority.Name = "cmbDetailsPriority";
            this.cmbDetailsPriority.Size = new System.Drawing.Size(159, 24);
            this.cmbDetailsPriority.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Сложность:";
            // 
            // TaskManager
            // 
            this.AccessibleName = "TaskManager";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 501);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TaskManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = " TaskManager";
            this.Load += new System.EventHandler(this.TaskManager_Load);
            this.panelFilters.ResumeLayout(false);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubtasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuImportDB;
        private System.Windows.Forms.ToolStripMenuItem menuExportDB;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuAutoRun;
        private System.Windows.Forms.ToolStripMenuItem menuAutoRunEnabled;
        private System.Windows.Forms.ToolStripMenuItem menuAutoRunDisabled;
        private System.Windows.Forms.ToolStripMenuItem menuTray;
        private System.Windows.Forms.ToolStripMenuItem menuTrayEnabled;
        private System.Windows.Forms.ToolStripMenuItem menuTrayDisabled;
        private System.Windows.Forms.ToolStripMenuItem menuTheme;
        private System.Windows.Forms.ToolStripMenuItem menuThemeWhite;
        private System.Windows.Forms.ToolStripMenuItem menuThemeBlack;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripLabel btnAddTaskText;
        private System.Windows.Forms.ToolStripButton btnAddTaskIcon;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Button btnFilterAll;
        private System.Windows.Forms.Button btnFilterActive;
        private System.Windows.Forms.Button btnFilterUpcoming;
        private System.Windows.Forms.Button btnFilterCompleted;
        private System.Windows.Forms.ToolStripLabel lblSpacing;
        private System.Windows.Forms.ImageList imglist1;
        private System.Windows.Forms.Label nameRightPanel;

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDeadline;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvSubtasks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SubtaskStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubtaskName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpDeadline;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbAlarm;
        private System.Windows.Forms.TextBox txtDetailsName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDetailsPriority;
        private System.Windows.Forms.Label label3;
    }
}

