namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.mainTabPage = new System.Windows.Forms.TabPage();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.startStopButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.georadarCheckBox = new System.Windows.Forms.CheckBox();
            this.gpsCheckBox = new System.Windows.Forms.CheckBox();
            this.photoCheckBox = new System.Windows.Forms.CheckBox();
            this.deviceTabPage = new System.Windows.Forms.TabPage();
            this.georadarLabel = new System.Windows.Forms.Label();
            this.gpsLabel = new System.Windows.Forms.Label();
            this.photoLabel = new System.Windows.Forms.Label();
            this.georadarPeriodGroupBox = new System.Windows.Forms.GroupBox();
            this.georadarPeriodTextBox = new System.Windows.Forms.TextBox();
            this.georadarPeriodMSRadioButton = new System.Windows.Forms.RadioButton();
            this.georadarPeriodMetrRadioButton = new System.Windows.Forms.RadioButton();
            this.gpsPeriodGroupBox = new System.Windows.Forms.GroupBox();
            this.gpsPeriodTextBox = new System.Windows.Forms.TextBox();
            this.gpsPeriodMSRadioButton = new System.Windows.Forms.RadioButton();
            this.gpsPeriodMetrRadioButton = new System.Windows.Forms.RadioButton();
            this.georadarConnectGroupBox = new System.Windows.Forms.GroupBox();
            this.georadarConnectDeviceButton = new System.Windows.Forms.Button();
            this.georadarConnectDeviceRadioButton = new System.Windows.Forms.RadioButton();
            this.georadarConnectEmulatorRadioButton = new System.Windows.Forms.RadioButton();
            this.gpsConnectGroupBox = new System.Windows.Forms.GroupBox();
            this.gpsConnectDeviceButton = new System.Windows.Forms.Button();
            this.gpsConnectDeviceRadioButton = new System.Windows.Forms.RadioButton();
            this.gpsConnectEmulatorRadioButton = new System.Windows.Forms.RadioButton();
            this.photoPeriodGroupBox = new System.Windows.Forms.GroupBox();
            this.photoPeriodTextBox = new System.Windows.Forms.TextBox();
            this.photoPeriodMSRadioButton = new System.Windows.Forms.RadioButton();
            this.photoPeriodMetrRadioButton = new System.Windows.Forms.RadioButton();
            this.photoConnectGroupBox = new System.Windows.Forms.GroupBox();
            this.photoConnectDeviceButton = new System.Windows.Forms.Button();
            this.photoConnectDeviceRadioButton = new System.Windows.Forms.RadioButton();
            this.photoConnectEmulatorRadioButton = new System.Windows.Forms.RadioButton();
            this.dbTabPage = new System.Windows.Forms.TabPage();
            this.extraDBAddButton = new System.Windows.Forms.Button();
            this.extraDBCheckBox = new System.Windows.Forms.CheckBox();
            this.localDBCheckBox = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.mainTabPage.SuspendLayout();
            this.deviceTabPage.SuspendLayout();
            this.georadarPeriodGroupBox.SuspendLayout();
            this.gpsPeriodGroupBox.SuspendLayout();
            this.georadarConnectGroupBox.SuspendLayout();
            this.gpsConnectGroupBox.SuspendLayout();
            this.photoPeriodGroupBox.SuspendLayout();
            this.photoConnectGroupBox.SuspendLayout();
            this.dbTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.mainTabPage);
            this.tabControl.Controls.Add(this.deviceTabPage);
            this.tabControl.Controls.Add(this.dbTabPage);
            this.tabControl.Location = new System.Drawing.Point(9, 8);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(412, 290);
            this.tabControl.TabIndex = 9;
            // 
            // mainTabPage
            // 
            this.mainTabPage.Controls.Add(this.progressBar);
            this.mainTabPage.Controls.Add(this.startStopButton);
            this.mainTabPage.Controls.Add(this.logTextBox);
            this.mainTabPage.Controls.Add(this.georadarCheckBox);
            this.mainTabPage.Controls.Add(this.gpsCheckBox);
            this.mainTabPage.Controls.Add(this.photoCheckBox);
            this.mainTabPage.Location = new System.Drawing.Point(4, 22);
            this.mainTabPage.Name = "mainTabPage";
            this.mainTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainTabPage.Size = new System.Drawing.Size(404, 264);
            this.mainTabPage.TabIndex = 0;
            this.mainTabPage.Text = "Запуск";
            this.mainTabPage.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(104, 84);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(294, 16);
            this.progressBar.TabIndex = 5;
            // 
            // startStopButton
            // 
            this.startStopButton.Location = new System.Drawing.Point(6, 75);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.Size = new System.Drawing.Size(92, 25);
            this.startStopButton.TabIndex = 4;
            this.startStopButton.Text = "Start";
            this.startStopButton.UseVisualStyleBackColor = true;
            this.startStopButton.Click += new System.EventHandler(this.startStopButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.BackColor = System.Drawing.Color.Black;
            this.logTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logTextBox.ForeColor = System.Drawing.Color.White;
            this.logTextBox.Location = new System.Drawing.Point(104, 4);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(294, 74);
            this.logTextBox.TabIndex = 3;
            // 
            // georadarCheckBox
            // 
            this.georadarCheckBox.AutoSize = true;
            this.georadarCheckBox.Checked = true;
            this.georadarCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.georadarCheckBox.Location = new System.Drawing.Point(6, 52);
            this.georadarCheckBox.Name = "georadarCheckBox";
            this.georadarCheckBox.Size = new System.Drawing.Size(74, 17);
            this.georadarCheckBox.TabIndex = 2;
            this.georadarCheckBox.Text = "Георадар";
            this.georadarCheckBox.UseVisualStyleBackColor = true;
            // 
            // gpsCheckBox
            // 
            this.gpsCheckBox.AutoSize = true;
            this.gpsCheckBox.Checked = true;
            this.gpsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gpsCheckBox.Location = new System.Drawing.Point(6, 29);
            this.gpsCheckBox.Name = "gpsCheckBox";
            this.gpsCheckBox.Size = new System.Drawing.Size(48, 17);
            this.gpsCheckBox.TabIndex = 1;
            this.gpsCheckBox.Text = "GPS";
            this.gpsCheckBox.UseVisualStyleBackColor = true;
            // 
            // photoCheckBox
            // 
            this.photoCheckBox.AutoSize = true;
            this.photoCheckBox.Checked = true;
            this.photoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.photoCheckBox.Location = new System.Drawing.Point(6, 6);
            this.photoCheckBox.Name = "photoCheckBox";
            this.photoCheckBox.Size = new System.Drawing.Size(92, 17);
            this.photoCheckBox.TabIndex = 0;
            this.photoCheckBox.Text = "Фотокамера";
            this.photoCheckBox.UseVisualStyleBackColor = true;
            // 
            // deviceTabPage
            // 
            this.deviceTabPage.Controls.Add(this.georadarLabel);
            this.deviceTabPage.Controls.Add(this.gpsLabel);
            this.deviceTabPage.Controls.Add(this.photoLabel);
            this.deviceTabPage.Controls.Add(this.georadarPeriodGroupBox);
            this.deviceTabPage.Controls.Add(this.gpsPeriodGroupBox);
            this.deviceTabPage.Controls.Add(this.georadarConnectGroupBox);
            this.deviceTabPage.Controls.Add(this.gpsConnectGroupBox);
            this.deviceTabPage.Controls.Add(this.photoPeriodGroupBox);
            this.deviceTabPage.Controls.Add(this.photoConnectGroupBox);
            this.deviceTabPage.Location = new System.Drawing.Point(4, 22);
            this.deviceTabPage.Name = "deviceTabPage";
            this.deviceTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.deviceTabPage.Size = new System.Drawing.Size(404, 264);
            this.deviceTabPage.TabIndex = 1;
            this.deviceTabPage.Text = "Настройки устройств";
            this.deviceTabPage.UseVisualStyleBackColor = true;
            // 
            // georadarLabel
            // 
            this.georadarLabel.AutoSize = true;
            this.georadarLabel.Location = new System.Drawing.Point(6, 173);
            this.georadarLabel.Name = "georadarLabel";
            this.georadarLabel.Size = new System.Drawing.Size(55, 13);
            this.georadarLabel.TabIndex = 11;
            this.georadarLabel.Text = "Георадар";
            // 
            // gpsLabel
            // 
            this.gpsLabel.AutoSize = true;
            this.gpsLabel.Location = new System.Drawing.Point(6, 88);
            this.gpsLabel.Name = "gpsLabel";
            this.gpsLabel.Size = new System.Drawing.Size(29, 13);
            this.gpsLabel.TabIndex = 10;
            this.gpsLabel.Text = "GPS";
            // 
            // photoLabel
            // 
            this.photoLabel.AutoSize = true;
            this.photoLabel.Location = new System.Drawing.Point(6, 3);
            this.photoLabel.Name = "photoLabel";
            this.photoLabel.Size = new System.Drawing.Size(73, 13);
            this.photoLabel.TabIndex = 9;
            this.photoLabel.Text = "Фотокамера";
            // 
            // georadarPeriodGroupBox
            // 
            this.georadarPeriodGroupBox.Controls.Add(this.georadarPeriodTextBox);
            this.georadarPeriodGroupBox.Controls.Add(this.georadarPeriodMSRadioButton);
            this.georadarPeriodGroupBox.Controls.Add(this.georadarPeriodMetrRadioButton);
            this.georadarPeriodGroupBox.Location = new System.Drawing.Point(181, 190);
            this.georadarPeriodGroupBox.Name = "georadarPeriodGroupBox";
            this.georadarPeriodGroupBox.Size = new System.Drawing.Size(154, 65);
            this.georadarPeriodGroupBox.TabIndex = 8;
            this.georadarPeriodGroupBox.TabStop = false;
            this.georadarPeriodGroupBox.Text = "Период";
            // 
            // georadarPeriodTextBox
            // 
            this.georadarPeriodTextBox.Location = new System.Drawing.Point(84, 39);
            this.georadarPeriodTextBox.Name = "georadarPeriodTextBox";
            this.georadarPeriodTextBox.Size = new System.Drawing.Size(64, 20);
            this.georadarPeriodTextBox.TabIndex = 2;
            this.georadarPeriodTextBox.Text = "100";
            this.georadarPeriodTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumeralsOnly);
            // 
            // georadarPeriodMSRadioButton
            // 
            this.georadarPeriodMSRadioButton.AutoSize = true;
            this.georadarPeriodMSRadioButton.Checked = true;
            this.georadarPeriodMSRadioButton.Location = new System.Drawing.Point(6, 42);
            this.georadarPeriodMSRadioButton.Name = "georadarPeriodMSRadioButton";
            this.georadarPeriodMSRadioButton.Size = new System.Drawing.Size(39, 17);
            this.georadarPeriodMSRadioButton.TabIndex = 1;
            this.georadarPeriodMSRadioButton.TabStop = true;
            this.georadarPeriodMSRadioButton.Text = "мс";
            this.georadarPeriodMSRadioButton.UseVisualStyleBackColor = true;
            // 
            // georadarPeriodMetrRadioButton
            // 
            this.georadarPeriodMetrRadioButton.AutoSize = true;
            this.georadarPeriodMetrRadioButton.Location = new System.Drawing.Point(6, 19);
            this.georadarPeriodMetrRadioButton.Name = "georadarPeriodMetrRadioButton";
            this.georadarPeriodMetrRadioButton.Size = new System.Drawing.Size(58, 17);
            this.georadarPeriodMetrRadioButton.TabIndex = 0;
            this.georadarPeriodMetrRadioButton.Text = "метры";
            this.georadarPeriodMetrRadioButton.UseVisualStyleBackColor = true;
            // 
            // gpsPeriodGroupBox
            // 
            this.gpsPeriodGroupBox.Controls.Add(this.gpsPeriodTextBox);
            this.gpsPeriodGroupBox.Controls.Add(this.gpsPeriodMSRadioButton);
            this.gpsPeriodGroupBox.Controls.Add(this.gpsPeriodMetrRadioButton);
            this.gpsPeriodGroupBox.Location = new System.Drawing.Point(181, 104);
            this.gpsPeriodGroupBox.Name = "gpsPeriodGroupBox";
            this.gpsPeriodGroupBox.Size = new System.Drawing.Size(154, 65);
            this.gpsPeriodGroupBox.TabIndex = 7;
            this.gpsPeriodGroupBox.TabStop = false;
            this.gpsPeriodGroupBox.Text = "Период";
            // 
            // gpsPeriodTextBox
            // 
            this.gpsPeriodTextBox.Location = new System.Drawing.Point(84, 39);
            this.gpsPeriodTextBox.Name = "gpsPeriodTextBox";
            this.gpsPeriodTextBox.Size = new System.Drawing.Size(64, 20);
            this.gpsPeriodTextBox.TabIndex = 2;
            this.gpsPeriodTextBox.Text = "10";
            this.gpsPeriodTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumeralsOnly);
            // 
            // gpsPeriodMSRadioButton
            // 
            this.gpsPeriodMSRadioButton.AutoSize = true;
            this.gpsPeriodMSRadioButton.Location = new System.Drawing.Point(6, 42);
            this.gpsPeriodMSRadioButton.Name = "gpsPeriodMSRadioButton";
            this.gpsPeriodMSRadioButton.Size = new System.Drawing.Size(39, 17);
            this.gpsPeriodMSRadioButton.TabIndex = 1;
            this.gpsPeriodMSRadioButton.Text = "мс";
            this.gpsPeriodMSRadioButton.UseVisualStyleBackColor = true;
            // 
            // gpsPeriodMetrRadioButton
            // 
            this.gpsPeriodMetrRadioButton.AutoSize = true;
            this.gpsPeriodMetrRadioButton.Checked = true;
            this.gpsPeriodMetrRadioButton.Location = new System.Drawing.Point(6, 19);
            this.gpsPeriodMetrRadioButton.Name = "gpsPeriodMetrRadioButton";
            this.gpsPeriodMetrRadioButton.Size = new System.Drawing.Size(58, 17);
            this.gpsPeriodMetrRadioButton.TabIndex = 0;
            this.gpsPeriodMetrRadioButton.TabStop = true;
            this.gpsPeriodMetrRadioButton.Text = "метры";
            this.gpsPeriodMetrRadioButton.UseVisualStyleBackColor = true;
            // 
            // georadarConnectGroupBox
            // 
            this.georadarConnectGroupBox.Controls.Add(this.georadarConnectDeviceButton);
            this.georadarConnectGroupBox.Controls.Add(this.georadarConnectDeviceRadioButton);
            this.georadarConnectGroupBox.Controls.Add(this.georadarConnectEmulatorRadioButton);
            this.georadarConnectGroupBox.Location = new System.Drawing.Point(34, 189);
            this.georadarConnectGroupBox.Name = "georadarConnectGroupBox";
            this.georadarConnectGroupBox.Size = new System.Drawing.Size(141, 66);
            this.georadarConnectGroupBox.TabIndex = 4;
            this.georadarConnectGroupBox.TabStop = false;
            this.georadarConnectGroupBox.Text = " Подключение";
            // 
            // georadarConnectDeviceButton
            // 
            this.georadarConnectDeviceButton.Location = new System.Drawing.Point(94, 34);
            this.georadarConnectDeviceButton.Name = "georadarConnectDeviceButton";
            this.georadarConnectDeviceButton.Size = new System.Drawing.Size(39, 23);
            this.georadarConnectDeviceButton.TabIndex = 2;
            this.georadarConnectDeviceButton.Text = "...";
            this.georadarConnectDeviceButton.UseVisualStyleBackColor = true;
            // 
            // georadarConnectDeviceRadioButton
            // 
            this.georadarConnectDeviceRadioButton.AutoSize = true;
            this.georadarConnectDeviceRadioButton.Checked = true;
            this.georadarConnectDeviceRadioButton.Location = new System.Drawing.Point(6, 37);
            this.georadarConnectDeviceRadioButton.Name = "georadarConnectDeviceRadioButton";
            this.georadarConnectDeviceRadioButton.Size = new System.Drawing.Size(82, 17);
            this.georadarConnectDeviceRadioButton.TabIndex = 1;
            this.georadarConnectDeviceRadioButton.TabStop = true;
            this.georadarConnectDeviceRadioButton.Text = "устройство";
            this.georadarConnectDeviceRadioButton.UseVisualStyleBackColor = true;
            // 
            // georadarConnectEmulatorRadioButton
            // 
            this.georadarConnectEmulatorRadioButton.AutoSize = true;
            this.georadarConnectEmulatorRadioButton.Location = new System.Drawing.Point(6, 15);
            this.georadarConnectEmulatorRadioButton.Name = "georadarConnectEmulatorRadioButton";
            this.georadarConnectEmulatorRadioButton.Size = new System.Drawing.Size(73, 17);
            this.georadarConnectEmulatorRadioButton.TabIndex = 0;
            this.georadarConnectEmulatorRadioButton.Text = "заглушка";
            this.georadarConnectEmulatorRadioButton.UseVisualStyleBackColor = true;
            // 
            // gpsConnectGroupBox
            // 
            this.gpsConnectGroupBox.Controls.Add(this.gpsConnectDeviceButton);
            this.gpsConnectGroupBox.Controls.Add(this.gpsConnectDeviceRadioButton);
            this.gpsConnectGroupBox.Controls.Add(this.gpsConnectEmulatorRadioButton);
            this.gpsConnectGroupBox.Location = new System.Drawing.Point(34, 104);
            this.gpsConnectGroupBox.Name = "gpsConnectGroupBox";
            this.gpsConnectGroupBox.Size = new System.Drawing.Size(141, 66);
            this.gpsConnectGroupBox.TabIndex = 4;
            this.gpsConnectGroupBox.TabStop = false;
            this.gpsConnectGroupBox.Text = "Подключение";
            // 
            // gpsConnectDeviceButton
            // 
            this.gpsConnectDeviceButton.Location = new System.Drawing.Point(94, 34);
            this.gpsConnectDeviceButton.Name = "gpsConnectDeviceButton";
            this.gpsConnectDeviceButton.Size = new System.Drawing.Size(39, 23);
            this.gpsConnectDeviceButton.TabIndex = 2;
            this.gpsConnectDeviceButton.Text = "...";
            this.gpsConnectDeviceButton.UseVisualStyleBackColor = true;
            // 
            // gpsConnectDeviceRadioButton
            // 
            this.gpsConnectDeviceRadioButton.AutoSize = true;
            this.gpsConnectDeviceRadioButton.Checked = true;
            this.gpsConnectDeviceRadioButton.Location = new System.Drawing.Point(6, 37);
            this.gpsConnectDeviceRadioButton.Name = "gpsConnectDeviceRadioButton";
            this.gpsConnectDeviceRadioButton.Size = new System.Drawing.Size(82, 17);
            this.gpsConnectDeviceRadioButton.TabIndex = 1;
            this.gpsConnectDeviceRadioButton.TabStop = true;
            this.gpsConnectDeviceRadioButton.Text = "устройство";
            this.gpsConnectDeviceRadioButton.UseVisualStyleBackColor = true;
            // 
            // gpsConnectEmulatorRadioButton
            // 
            this.gpsConnectEmulatorRadioButton.AutoSize = true;
            this.gpsConnectEmulatorRadioButton.Location = new System.Drawing.Point(6, 15);
            this.gpsConnectEmulatorRadioButton.Name = "gpsConnectEmulatorRadioButton";
            this.gpsConnectEmulatorRadioButton.Size = new System.Drawing.Size(73, 17);
            this.gpsConnectEmulatorRadioButton.TabIndex = 0;
            this.gpsConnectEmulatorRadioButton.Text = "заглушка";
            this.gpsConnectEmulatorRadioButton.UseVisualStyleBackColor = true;
            // 
            // photoPeriodGroupBox
            // 
            this.photoPeriodGroupBox.Controls.Add(this.photoPeriodTextBox);
            this.photoPeriodGroupBox.Controls.Add(this.photoPeriodMSRadioButton);
            this.photoPeriodGroupBox.Controls.Add(this.photoPeriodMetrRadioButton);
            this.photoPeriodGroupBox.Location = new System.Drawing.Point(181, 20);
            this.photoPeriodGroupBox.Name = "photoPeriodGroupBox";
            this.photoPeriodGroupBox.Size = new System.Drawing.Size(154, 65);
            this.photoPeriodGroupBox.TabIndex = 6;
            this.photoPeriodGroupBox.TabStop = false;
            this.photoPeriodGroupBox.Text = "Период";
            // 
            // photoPeriodTextBox
            // 
            this.photoPeriodTextBox.Location = new System.Drawing.Point(84, 39);
            this.photoPeriodTextBox.Name = "photoPeriodTextBox";
            this.photoPeriodTextBox.Size = new System.Drawing.Size(64, 20);
            this.photoPeriodTextBox.TabIndex = 2;
            this.photoPeriodTextBox.Text = "60000";
            this.photoPeriodTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumeralsOnly);
            // 
            // photoPeriodMSRadioButton
            // 
            this.photoPeriodMSRadioButton.AutoSize = true;
            this.photoPeriodMSRadioButton.Checked = true;
            this.photoPeriodMSRadioButton.Location = new System.Drawing.Point(6, 42);
            this.photoPeriodMSRadioButton.Name = "photoPeriodMSRadioButton";
            this.photoPeriodMSRadioButton.Size = new System.Drawing.Size(39, 17);
            this.photoPeriodMSRadioButton.TabIndex = 1;
            this.photoPeriodMSRadioButton.TabStop = true;
            this.photoPeriodMSRadioButton.Text = "мс";
            this.photoPeriodMSRadioButton.UseVisualStyleBackColor = true;
            // 
            // photoPeriodMetrRadioButton
            // 
            this.photoPeriodMetrRadioButton.AutoSize = true;
            this.photoPeriodMetrRadioButton.Location = new System.Drawing.Point(6, 19);
            this.photoPeriodMetrRadioButton.Name = "photoPeriodMetrRadioButton";
            this.photoPeriodMetrRadioButton.Size = new System.Drawing.Size(58, 17);
            this.photoPeriodMetrRadioButton.TabIndex = 0;
            this.photoPeriodMetrRadioButton.Text = "метры";
            this.photoPeriodMetrRadioButton.UseVisualStyleBackColor = true;
            // 
            // photoConnectGroupBox
            // 
            this.photoConnectGroupBox.Controls.Add(this.photoConnectDeviceButton);
            this.photoConnectGroupBox.Controls.Add(this.photoConnectDeviceRadioButton);
            this.photoConnectGroupBox.Controls.Add(this.photoConnectEmulatorRadioButton);
            this.photoConnectGroupBox.Location = new System.Drawing.Point(34, 19);
            this.photoConnectGroupBox.Name = "photoConnectGroupBox";
            this.photoConnectGroupBox.Size = new System.Drawing.Size(141, 66);
            this.photoConnectGroupBox.TabIndex = 3;
            this.photoConnectGroupBox.TabStop = false;
            this.photoConnectGroupBox.Text = "Подключение";
            // 
            // photoConnectDeviceButton
            // 
            this.photoConnectDeviceButton.Location = new System.Drawing.Point(94, 34);
            this.photoConnectDeviceButton.Name = "photoConnectDeviceButton";
            this.photoConnectDeviceButton.Size = new System.Drawing.Size(39, 23);
            this.photoConnectDeviceButton.TabIndex = 2;
            this.photoConnectDeviceButton.Text = "...";
            this.photoConnectDeviceButton.UseVisualStyleBackColor = true;
            // 
            // photoConnectDeviceRadioButton
            // 
            this.photoConnectDeviceRadioButton.AutoSize = true;
            this.photoConnectDeviceRadioButton.Checked = true;
            this.photoConnectDeviceRadioButton.Location = new System.Drawing.Point(6, 37);
            this.photoConnectDeviceRadioButton.Name = "photoConnectDeviceRadioButton";
            this.photoConnectDeviceRadioButton.Size = new System.Drawing.Size(82, 17);
            this.photoConnectDeviceRadioButton.TabIndex = 1;
            this.photoConnectDeviceRadioButton.TabStop = true;
            this.photoConnectDeviceRadioButton.Text = "устройство";
            this.photoConnectDeviceRadioButton.UseVisualStyleBackColor = true;
            // 
            // photoConnectEmulatorRadioButton
            // 
            this.photoConnectEmulatorRadioButton.AutoSize = true;
            this.photoConnectEmulatorRadioButton.Location = new System.Drawing.Point(6, 15);
            this.photoConnectEmulatorRadioButton.Name = "photoConnectEmulatorRadioButton";
            this.photoConnectEmulatorRadioButton.Size = new System.Drawing.Size(73, 17);
            this.photoConnectEmulatorRadioButton.TabIndex = 0;
            this.photoConnectEmulatorRadioButton.Text = "заглушка";
            this.photoConnectEmulatorRadioButton.UseVisualStyleBackColor = true;
            // 
            // dbTabPage
            // 
            this.dbTabPage.Controls.Add(this.extraDBAddButton);
            this.dbTabPage.Controls.Add(this.extraDBCheckBox);
            this.dbTabPage.Controls.Add(this.localDBCheckBox);
            this.dbTabPage.Location = new System.Drawing.Point(4, 22);
            this.dbTabPage.Name = "dbTabPage";
            this.dbTabPage.Size = new System.Drawing.Size(404, 264);
            this.dbTabPage.TabIndex = 2;
            this.dbTabPage.Text = "Настройка хранения результатов";
            this.dbTabPage.UseVisualStyleBackColor = true;
            // 
            // extraDBAddButton
            // 
            this.extraDBAddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.extraDBAddButton.Location = new System.Drawing.Point(27, 81);
            this.extraDBAddButton.Name = "extraDBAddButton";
            this.extraDBAddButton.Size = new System.Drawing.Size(186, 61);
            this.extraDBAddButton.TabIndex = 2;
            this.extraDBAddButton.Text = "Подключить удаленную БД...";
            this.extraDBAddButton.UseVisualStyleBackColor = true;
            // 
            // extraDBCheckBox
            // 
            this.extraDBCheckBox.AutoSize = true;
            this.extraDBCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.extraDBCheckBox.Location = new System.Drawing.Point(10, 40);
            this.extraDBCheckBox.Margin = new System.Windows.Forms.Padding(10);
            this.extraDBCheckBox.Name = "extraDBCheckBox";
            this.extraDBCheckBox.Size = new System.Drawing.Size(167, 28);
            this.extraDBCheckBox.TabIndex = 1;
            this.extraDBCheckBox.Text = "удалённая БД";
            this.extraDBCheckBox.UseVisualStyleBackColor = true;
            // 
            // localDBCheckBox
            // 
            this.localDBCheckBox.AutoSize = true;
            this.localDBCheckBox.Checked = true;
            this.localDBCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.localDBCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.localDBCheckBox.Location = new System.Drawing.Point(10, 10);
            this.localDBCheckBox.Margin = new System.Windows.Forms.Padding(10);
            this.localDBCheckBox.Name = "localDBCheckBox";
            this.localDBCheckBox.Size = new System.Drawing.Size(165, 28);
            this.localDBCheckBox.TabIndex = 0;
            this.localDBCheckBox.Text = "локальная БД";
            this.localDBCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 303);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "ООП Курсовая";
            this.tabControl.ResumeLayout(false);
            this.mainTabPage.ResumeLayout(false);
            this.mainTabPage.PerformLayout();
            this.deviceTabPage.ResumeLayout(false);
            this.deviceTabPage.PerformLayout();
            this.georadarPeriodGroupBox.ResumeLayout(false);
            this.georadarPeriodGroupBox.PerformLayout();
            this.gpsPeriodGroupBox.ResumeLayout(false);
            this.gpsPeriodGroupBox.PerformLayout();
            this.georadarConnectGroupBox.ResumeLayout(false);
            this.georadarConnectGroupBox.PerformLayout();
            this.gpsConnectGroupBox.ResumeLayout(false);
            this.gpsConnectGroupBox.PerformLayout();
            this.photoPeriodGroupBox.ResumeLayout(false);
            this.photoPeriodGroupBox.PerformLayout();
            this.photoConnectGroupBox.ResumeLayout(false);
            this.photoConnectGroupBox.PerformLayout();
            this.dbTabPage.ResumeLayout(false);
            this.dbTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage mainTabPage;
        private System.Windows.Forms.TabPage deviceTabPage;
        private System.Windows.Forms.GroupBox photoPeriodGroupBox;
        private System.Windows.Forms.TextBox photoPeriodTextBox;
        private System.Windows.Forms.RadioButton photoPeriodMSRadioButton;
        private System.Windows.Forms.RadioButton photoPeriodMetrRadioButton;
        private System.Windows.Forms.GroupBox photoConnectGroupBox;
        private System.Windows.Forms.Button photoConnectDeviceButton;
        private System.Windows.Forms.RadioButton photoConnectDeviceRadioButton;
        private System.Windows.Forms.RadioButton photoConnectEmulatorRadioButton;
        private System.Windows.Forms.TabPage dbTabPage;
        private System.Windows.Forms.Button extraDBAddButton;
        private System.Windows.Forms.CheckBox extraDBCheckBox;
        private System.Windows.Forms.CheckBox localDBCheckBox;
        private System.Windows.Forms.GroupBox georadarConnectGroupBox;
        private System.Windows.Forms.Button georadarConnectDeviceButton;
        private System.Windows.Forms.RadioButton georadarConnectDeviceRadioButton;
        private System.Windows.Forms.RadioButton georadarConnectEmulatorRadioButton;
        private System.Windows.Forms.GroupBox gpsConnectGroupBox;
        private System.Windows.Forms.Button gpsConnectDeviceButton;
        private System.Windows.Forms.RadioButton gpsConnectDeviceRadioButton;
        private System.Windows.Forms.RadioButton gpsConnectEmulatorRadioButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button startStopButton;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.CheckBox georadarCheckBox;
        private System.Windows.Forms.CheckBox gpsCheckBox;
        private System.Windows.Forms.CheckBox photoCheckBox;
        private System.Windows.Forms.Label georadarLabel;
        private System.Windows.Forms.Label gpsLabel;
        private System.Windows.Forms.Label photoLabel;
        private System.Windows.Forms.GroupBox georadarPeriodGroupBox;
        private System.Windows.Forms.TextBox georadarPeriodTextBox;
        private System.Windows.Forms.RadioButton georadarPeriodMSRadioButton;
        private System.Windows.Forms.RadioButton georadarPeriodMetrRadioButton;
        private System.Windows.Forms.GroupBox gpsPeriodGroupBox;
        private System.Windows.Forms.TextBox gpsPeriodTextBox;
        private System.Windows.Forms.RadioButton gpsPeriodMSRadioButton;
        private System.Windows.Forms.RadioButton gpsPeriodMetrRadioButton;

    }
}

