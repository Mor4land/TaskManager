using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Win32;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.Runtime.InteropServices;



namespace TaskManager
{

    public partial class TaskManager : Form
    {

        private string filePath;
        private string settingsPath;
        private Timer alarmTimer;
        private bool isRefreshing = false;
        private string currentFilter = "Все задачи";
        private bool minimizeToTrayEnabled = false;
        private bool isDarkTheme = false;
        public TaskManager()
        {
            InitializeComponent();
            string appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TaskManager");
            if (!Directory.Exists(appDataFolder)) Directory.CreateDirectory(appDataFolder);

            filePath = Path.Combine(appDataFolder, "tasks.json");
            settingsPath = Path.Combine(appDataFolder, "settings.json");

            LoadSettings();
            ApplyTheme(isDarkTheme);

            splitContainer1.SplitterDistance = this.Width - 325;
            dtpDeadline.CustomFormat = "HH:mm | dd-MM-yyyy";
            splitContainer1.Panel2.Enabled = false;

            menuAutoRunEnabled.Click += menuAutoRunEnabled_Click;
            menuAutoRunDisabled.Click += menuAutoRunDisabled_Click;
            menuImportDB.Click += menuImportDB_Click;
            menuExportDB.Click += menuExportDB_Click;
            menuTrayEnabled.Click += menuTrayEnabled_Click;
            menuTrayDisabled.Click += menuTrayDisabled_Click;
            this.Resize += TaskManager_Resize;
            this.StartPosition = FormStartPosition.Manual;
            this.Top = Properties.Settings.Default.WindowX;
            this.Left = Properties.Settings.Default.WindowY;
            int savedX = Properties.Settings.Default.WindowX;
            int savedY = Properties.Settings.Default.WindowY;

            if (savedX <= 0 && savedY <= 0)
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            { 
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(savedX, savedY);
            }
            alarmTimer = new Timer();
            alarmTimer.Interval = 1000;
            alarmTimer.Tick += AlarmTimer_Tick;
            alarmTimer.Start();
            NI.BalloonTipClicked += NI_BallonTipClicked;
            NI.BalloonTipClosed += NI_BalloonTipClosed;
            components.Add(NI);
            ColStatus.ThreeState = true;
            this.FormClosing += TaskManager_FormClosing;
            SetupTrayMenu();
            NI.Icon = this.Icon;
            NI.Text = "TaskManager";
            NI.Visible = true;
            NI.MouseDoubleClick += (s, e) => NI_BallonTipClicked(s, e);
            LoadTasks();
            RefreshGrid();
            btnFilterAll.Enabled = false;
        }
        private List<TaskItem> tasks = new List<TaskItem>();
        private NotifyIcon NI = new NotifyIcon();

        [DllImport("dwmapi.dll", PreserveSig = true)]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        //загрузка
        private void LoadTasks()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string jsonContent = File.ReadAllText(filePath);
                    tasks = JsonSerializer.Deserialize<List<TaskItem>>(jsonContent) ?? new List<TaskItem>();
                    
                    foreach(var t in tasks)
                    {
                        if (string.IsNullOrEmpty(t.Status))
                        {
                            t.Status = t.IsDone ? "Выполнена" : "Новая";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке задач: " + ex.Message);
                }
            }
        }


        // перерисовывет всю таблицу
        private void RefreshGrid()
        {
            // сортировка
            if (isRefreshing) return;
            isRefreshing = true;
            try
            {
                var filteredTasks = tasks.AsEnumerable();

                string selectedNode = currentFilter;

                if (selectedNode == "Активные") 
                {
                    filteredTasks = filteredTasks.Where(t => t.Status == "Активна");
                }
                else if (selectedNode == "Ближайшие") 
                {
                    filteredTasks = filteredTasks.Where(t => !t.IsDone && !string.IsNullOrEmpty(t.Deadline))
                        .OrderBy(t => {
                            DateTime parsed;
                            if (DateTime.TryParseExact(t.Deadline, "dd.MM.yy HH:mm", null, System.Globalization.DateTimeStyles.None, out parsed))
                                return parsed;
                            return DateTime.MaxValue;
                        });
                }
                else if (selectedNode == "Выполненные") 
                {
                    filteredTasks = filteredTasks.Where(t => t.IsDone);
                }
                else 
                {
                    filteredTasks = filteredTasks.OrderBy(t => t.IsDone);
                }

                dgvTasks.Rows.Clear();
                foreach (var task in filteredTasks)
                {
                    int n = dgvTasks.Rows.Add(false, task.Name, task.Priority, task.Deadline);
                    dgvTasks.Rows[n].Tag = task;

                    if (task.Status == "Активна")
                    {
                        dgvTasks.Rows[n].Cells[0].Value = CheckState.Indeterminate;
                    }
                    else if (task.IsDone)
                    {
                        dgvTasks.Rows[n].Cells[0].Value = CheckState.Checked;
                    }
                    else
                    {
                        dgvTasks.Rows[n].Cells[0].Value = CheckState.Unchecked;
                    }

                    ApplyRowStyle(n, task);
                }
            }
            finally
            {
                isRefreshing = false;
            }
        }
        // сохранение
        private void SaveTasks()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                string jsonContent = JsonSerializer.Serialize(tasks, options);
                File.WriteAllText(filePath, jsonContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить: " + ex.Message);
            }
        }

        private void SaveSettings()
        {
            try
            {
                var settings = new { minimizeToTrayEnabled, isDarkTheme };
                string json = JsonSerializer.Serialize(settings);
                File.WriteAllText(settingsPath, json);
            }
            catch { }
        }

        private void LoadSettings()
        {
            try
            {
                if (File.Exists(settingsPath))
                {
                    string json = File.ReadAllText(settingsPath);
                    var settings = JsonSerializer.Deserialize<Dictionary<string, bool>>(json);
                    if (settings != null)
                    {
                        if (settings.ContainsKey("minimizeToTrayEnabled"))
                            minimizeToTrayEnabled = settings["minimizeToTrayEnabled"];
                        if (settings.ContainsKey("isDarkTheme"))
                            isDarkTheme = settings["isDarkTheme"];
                    }
                }
            }
            catch { }
        }

        private void menuThemeWhite_Click(object sender, EventArgs e)
        {
            ApplyTheme(false);
            SaveSettings();
            SaveTasks();
            Restart();


        }
        private void Restart()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.WindowX = this.Location.X;
                Properties.Settings.Default.WindowY = this.Location.Y;
                Properties.Settings.Default.Save();
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                Properties.Settings.Default.WindowX = this.RestoreBounds.X;
                Properties.Settings.Default.WindowY = this.RestoreBounds.Y;
                Properties.Settings.Default.Save();
            }
            Application.Restart();
        }
        private void menuThemeBlack_Click(object sender, EventArgs e)
        {
            ApplyTheme(true);
            SaveSettings();
            Restart();
        }

        private void ApplyTheme(bool dark)
        {
            isDarkTheme = dark;

            Color backColor = dark ? Color.FromArgb(32, 34, 37) : Color.White;
            Color panelColor = dark ? Color.FromArgb(47, 49, 54) : Color.FromArgb(242, 243, 245);
            Color textColor = dark ? Color.White : Color.Black;
            Color gridLineColor = dark ? Color.FromArgb(60, 60, 60) : Color.FromArgb(220, 220, 220);

            this.BackColor = backColor;
            this.ForeColor = textColor;

            int useImmersiveDarkMode = dark ? 1 : 0;
            DwmSetWindowAttribute(this.Handle, 20, ref useImmersiveDarkMode, sizeof(int));

            StyleGrid(dgvTasks, panelColor, textColor, gridLineColor, dark);
            StyleGrid(dgvSubtasks, panelColor, textColor, gridLineColor, dark);

            splitContainer1.Panel1.BackColor = backColor;
            splitContainer1.Panel2.BackColor = panelColor;
            panelFilters.BackColor = backColor;

            foreach (Control ctrl in panelFilters.Controls)
            {
                if (ctrl is Button btn)
                    StyleButton(btn, panelColor, textColor, dark ? Color.Gray : Color.DarkGray);
            }

            txtDetailsName.BackColor = dark ? Color.FromArgb(60, 60, 60) : Color.White;
            txtDetailsName.ForeColor = textColor;
            cmbDetailsPriority.BackColor = dark ? Color.FromArgb(60, 60, 60) : Color.White;
            cmbDetailsPriority.ForeColor = textColor;
        }

        // Вспомогательный метод для красивых кнопок
        private void StyleButton(Button btn, Color back, Color fore, Color border)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = back;
            btn.ForeColor = fore;
            btn.FlatAppearance.BorderColor = border;
        }
        // Вспомогательный метод для таблиц
        private void StyleGrid(DataGridView dgv, Color back, Color fore, Color lines, bool dark)
        {
            dgv.BackgroundColor = back;
            dgv.GridColor = lines;
            dgv.DefaultCellStyle.BackColor = back;
            dgv.DefaultCellStyle.ForeColor = fore;

            // Заголовки (те самые белые/черные пятна)
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = dark ? Color.FromArgb(50, 50, 50) : Color.FromArgb(230, 230, 230);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = fore;
            dgv.RowHeadersDefaultCellStyle.BackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
        }

        //таймер
        private void AlarmTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            for (int i = 0; i < tasks.Count; i++)
            {
                var task = tasks[i];

                if (!task.IsDone && !string.IsNullOrEmpty(task.Deadline))
                {
                    DateTime taskTime;

                    if (DateTime.TryParseExact(task.Deadline, "dd.MM.yy HH:mm",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, 
                        out taskTime))
                    {
                        
                        if (now.Hour == taskTime.Hour &&
                            now.Minute == taskTime.Minute &&
                            now.Date == taskTime.Date &&
                            task.haveDeadline == true)
                        {
                            NI.BalloonTipTitle = task.Name;
                            NI.BalloonTipText = "Кликните чтобы начать задачу";
                            NI.BalloonTipIcon = ToolTipIcon.Info;
                            NI.Icon = this.Icon;
                            NI.Visible = true;
                            NI.ShowBalloonTip(1000);
                            task.haveDeadline = false;
                            SaveTasks();
                        }
                        
                    }
                }
            }
        }

        private void menuAutoRunEnabled_Click(object sender, EventArgs e)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.SetValue("TaskManager", Application.ExecutablePath);
                }
                MessageBox.Show("Автозапуск включен");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка с реестром: " + ex.Message);
            }
        }

        private void menuAutoRunDisabled_Click(object sender, EventArgs e)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.DeleteValue("TaskManager", false);
                }
                MessageBox.Show("Автозапуск выключен.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка с реестром: " + ex.Message);
            }
        }

        private void menuTrayEnabled_Click(object sender, EventArgs e)
        {
            minimizeToTrayEnabled = true;
            SaveSettings();
            MessageBox.Show("Сворачивание в трей включено.");
        }

        private void menuTrayDisabled_Click(object sender, EventArgs e)
        {
            minimizeToTrayEnabled = false;
            SaveSettings();
            MessageBox.Show("Сворачивание в трей выключено.");
        }

        private void TaskManager_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized && minimizeToTrayEnabled)
            {
                this.Hide();
                NI.Visible = true;
            }
        }

        private void TaskManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && minimizeToTrayEnabled)
            {
                e.Cancel = true;
                this.Hide();
                NI.Visible = true;
            }
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.WindowX = this.Location.X;
                Properties.Settings.Default.WindowY = this.Location.Y;
                Properties.Settings.Default.Save();
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                Properties.Settings.Default.WindowX = this.RestoreBounds.X;
                Properties.Settings.Default.WindowY = this.RestoreBounds.Y;
                Properties.Settings.Default.Save();
            }
        }

        private void SetupTrayMenu()
        {
            ContextMenuStrip trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Развернуть", null, (s, e) => NI_BallonTipClicked(s, e));
            trayMenu.Items.Add("-");
            trayMenu.Items.Add("Выход", null, (s, e) => {
                minimizeToTrayEnabled = false;
                this.Close();
            });
            NI.ContextMenuStrip = trayMenu;
        }

        private void menuImportDB_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Json файлы|*.json";
            if (open.ShowDialog() == DialogResult.OK)
            {
                File.Copy(open.FileName, filePath, true);
                LoadTasks();
                RefreshGrid();
                MessageBox.Show("Загружено");
            }
        }

        private void menuExportDB_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Json файлы|*.json";
            if (save.ShowDialog() == DialogResult.OK)
            {
                File.Copy(filePath, save.FileName, true);
                MessageBox.Show("Сохранено");
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            SaveTasks();
            minimizeToTrayEnabled = false;
            Close();
        }

        // Добавление новой задачи
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            addTask addForm = new addTask();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(addForm.TaskNameValue))
                {
                    MessageBox.Show("Название задачи не может быть пустым!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                TaskItem newTask = new TaskItem();
                newTask.Name = addForm.TaskNameValue;
                newTask.Priority = addForm.PriorityValue;
                newTask.Deadline = addForm.DeadlineValue;
                newTask.haveDeadline = addForm.hvDeadline;
                
                foreach(string row in addForm.Subtasks)
                {
                    if (!string.IsNullOrWhiteSpace(row))
                    {
                        newTask.Subtasks.Add(new Subtask { Name = row, IsDone = false });
                    }
                }

                tasks.Add(newTask);
                RefreshGrid();
                SaveTasks();
            }
        }
        private bool isPopulatingSubtasks = false;
        
        // Выбор задачи
        private void dgvTasks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count > 0)
            {
                splitContainer1.Panel2.Enabled = true;
                
                TaskItem task = (TaskItem)dgvTasks.SelectedRows[0].Tag;
                if (task != null)
                {
                    txtDetailsName.Text = task.Name;
                    cmbDetailsPriority.Text = task.Priority;
                    cbAlarm.Checked = task.haveDeadline;

                    DateTime deadline;
                    if (!string.IsNullOrEmpty(task.Deadline) &&
                        DateTime.TryParseExact(task.Deadline, "dd.MM.yy HH:mm",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out deadline))
                    {
                        dtpDeadline.Value = deadline;
                    }

                    isPopulatingSubtasks = true;
                    dgvSubtasks.Rows.Clear();
                    foreach (var sub in task.Subtasks)
                    {
                        dgvSubtasks.Rows.Add(sub.IsDone, sub.Name);
                    }
                    isPopulatingSubtasks = false;
                }
            }
            else
            {
                splitContainer1.Panel2.Enabled = false;
                txtDetailsName.Text = "";
                cmbDetailsPriority.SelectedIndex = -1;
                cbAlarm.Checked = false;
                dgvSubtasks.Rows.Clear();
            }
        }

        //проверка на выполнение
        private void dgvTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                TaskItem task = (TaskItem)dgvTasks.Rows[e.RowIndex].Tag;
                if (task != null)
                {
                    task.IsDone = !task.IsDone;
                    bool hasDoneSub = false;
                    foreach(var s in task.Subtasks) if(s.IsDone) hasDoneSub = true;
                    task.Status = task.IsDone ? "Выполнена" : (hasDoneSub ? "Активна" : "Новая");
                    RefreshGrid();
                    SaveTasks();
                }
            }
        }
        private void dgvTasks_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isRefreshing) return;
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                TaskItem task = (TaskItem)dgvTasks.Rows[e.RowIndex].Tag;
                if (task != null)
                {
                    bool isDone = (bool)dgvTasks.Rows[e.RowIndex].Cells[0].Value;
                    task.IsDone = isDone;
                    SaveTasks();
                }
            }
        }

        private void ApplyRowStyle(int rowIndex, TaskItem task)
        {
            if (rowIndex < 0 || rowIndex >= dgvTasks.Rows.Count) return;
            
            DataGridViewRow row = dgvTasks.Rows[rowIndex];
            
            
            var priorityCell = row.Cells[2];
            if (task.Priority == "Высокая") priorityCell.Style.ForeColor = Color.Red;
            else if (task.Priority == "Средняя") priorityCell.Style.ForeColor = Color.Orange;
            else if (task.Priority == "Низкая") priorityCell.Style.ForeColor = Color.Green;

            
            if (task.IsDone || task.Status == "Выполнена")
            {
                row.DefaultCellStyle.Font = new Font(dgvTasks.Font, FontStyle.Strikeout);
                row.DefaultCellStyle.ForeColor = Color.Gray;
                row.DefaultCellStyle.BackColor = isDarkTheme ? Color.FromArgb(45, 45, 48) : Color.White;
            }
            else if (task.Status == "Активна")
            {
                row.DefaultCellStyle.Font = new Font(dgvTasks.Font, FontStyle.Bold);
                row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                row.DefaultCellStyle.BackColor = isDarkTheme ? Color.FromArgb(45, 45, 48) : Color.White;
            }
            else
            {
                row.DefaultCellStyle.Font = new Font(dgvTasks.Font, FontStyle.Regular);
                row.DefaultCellStyle.ForeColor = isDarkTheme ? Color.White : Color.Black;
                row.DefaultCellStyle.BackColor = isDarkTheme ? Color.FromArgb(45, 45, 48) : Color.White;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count > 0)
            {
                int index = dgvTasks.SelectedRows[0].Index;
                TaskItem targetTask = (TaskItem)dgvTasks.Rows[index].Tag;
                try
                {
                    DialogResult result = MessageBox.Show(
                            "Вы уверены, что хотите удалить задачу?",
                            "Подтвердите",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information
                            );
                    if (result == DialogResult.Yes)
                    {
                        tasks.Remove(targetTask);
                        RefreshGrid();
                        SaveTasks();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show(
                    $"Вы должны выбрать задачу!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count > 0)
            {
                try
                {
                    TaskItem task = (TaskItem)dgvTasks.SelectedRows[0].Tag;
                    if (task == null) return;

                    task.Name = txtDetailsName.Text;
                    task.Priority = cmbDetailsPriority.Text;
                    task.haveDeadline = cbAlarm.Checked;

                    if (cbAlarm.Checked)
                    {
                        task.Deadline = dtpDeadline.Value.ToString("dd.MM.yy HH:mm");
                    }
                    else
                    {
                        task.Deadline = "";
                    }

                    task.Subtasks.Clear();
                    bool hasSubtasks = false;
                    bool allSubtasksDone = true;
                    bool anySubtasksDone = false;

                    foreach (DataGridViewRow row in dgvSubtasks.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string subName = row.Cells[1].Value?.ToString();
                        if (!string.IsNullOrWhiteSpace(subName))
                        {
                            hasSubtasks = true;
                            bool isSubDone = Convert.ToBoolean(row.Cells[0].Value);

                            if (!isSubDone)
                            {
                                allSubtasksDone = false;
                            }
                            else 
                            {
                                anySubtasksDone = true;
                            }

                            Subtask newSubtask = new Subtask();
                            newSubtask.Name = subName;
                            newSubtask.IsDone = isSubDone;
                            task.Subtasks.Add(newSubtask);
                        }
                    }

                    if (hasSubtasks)
                    {
                        if (allSubtasksDone)
                        {
                            task.IsDone = true;
                            task.Status = "Выполнена";
                        }
                        else if (anySubtasksDone && !task.IsDone)
                        {
                            task.Status = "Активна";
                        }
                        else if (!task.IsDone)
                        {
                            task.Status = "Новая";
                        }
                    }

                    RefreshGrid();
                    SaveTasks();
                }
                catch (Exception ex)
                {
                   MessageBox.Show(
                   $"Ошибка при сохранении: {ex.Message}",
                   "Ошибка",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void dgvSubtasks_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvSubtasks.IsCurrentCellDirty && dgvSubtasks.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvSubtasks.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvSubtasks_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isPopulatingSubtasks) return;
            
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                if (dgvTasks.SelectedRows.Count == 0) return;
                
                TaskItem task = (TaskItem)dgvTasks.SelectedRows[0].Tag;
                if (task == null) return;

                bool hasSubtasks = false;
                bool allSubtasksDone = true;
                bool anySubtasksDone = false;

                foreach (DataGridViewRow row in dgvSubtasks.Rows)
                {
                    if (row.IsNewRow) continue;
                    string subName = row.Cells[1].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(subName))
                    {
                        hasSubtasks = true;
                        bool isSubDone = Convert.ToBoolean(row.Cells[0].Value);
                        if (!isSubDone)
                            allSubtasksDone = false;
                        else
                            anySubtasksDone = true;
                    }
                }

                if (hasSubtasks)
                {
                    string expectedStatus = allSubtasksDone ? "Выполнена" : (anySubtasksDone ? "Активна" : "Новая");
                    if (task.Status != expectedStatus)
                    {
                        this.BeginInvoke(new Action(() => btnSave_Click(null, EventArgs.Empty)));
                    }
                }
            }
        }

        private void btnAddTaskIcon_Click(object sender, EventArgs e)
        {
            btnAddTask_Click(sender, e); 
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                currentFilter = btn.Text;
                btn.Enabled = false;
                foreach (Control ctrl in btn.Parent.Controls)
                {
                    if (ctrl is Button otherbin) 
                    {
                        otherbin.Enabled = (otherbin != btn);
                    }
                }
                    RefreshGrid();
                
            }
        }
        private void NI_BalloonTipClosed(Object sender, EventArgs e)
        {
            NI.Visible = false;
        }

        private void NI_BallonTipClicked(object sender, EventArgs e)
        {
            this.Show();
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            this.Activate();
            this.BringToFront();
            this.TopMost = true;
            this.TopMost = false;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TaskManager_Load(object sender, EventArgs e)
        {

        }
    }
}