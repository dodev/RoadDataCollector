using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GUI.Properties;
using Host;
using Configuration;

// TODO: сделать консоль по-больше

namespace GUI
{
    public partial class Form1 : Form
    {
        //objects
        List<TabPage> tabPageBuffer = new List<TabPage>(2);     //to make tabPages invisible
		CollectorHost host = null; // the host
		IConfigurator conf = null;

        //Form initialize
        public Form1()
        {
			conf = new XmlConfigurator(Settings.Default.ConfigurationFilePath);
			conf.Load (); // TODO: показать информацию о том что сейчас идет загрузка конфигурации

			// TODO: Сгенерировать элементы GUI в зависимости от конфигурации
			// напр.: перечислить в списке доступных устройств, только те для которых
			// налични данные в конфигурации

            InitializeComponent();

			host = new CollectorHost (conf);

			// событие которое оповещает о наличие информация для 
			// запис в текстовое поле вывода
			host.OutputPending += HandleOutputPending;

			host.Started += HandleStarted;
			host.Stopped += HandleStopped;

			// При закрывание формы удаляем хост и конфигурацию
			this.FormClosing += HandleFormClosing;
        }

		/// <summary>
		/// Выполняется при начале работы хоста
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
        void HandleStarted (object sender, EventArgs e)
        {
			startStopButton.Text = "Stop";
			progressBar.Value = 1;
			photoCheckBox.Enabled = false;
			gpsCheckBox.Enabled = false;
			georadarCheckBox.Enabled = false;
			tabPageBuffer.Add(tabControl.TabPages[2]);
			tabControl.TabPages.Remove(tabControl.TabPages[2]);
			tabPageBuffer.Add(tabControl.TabPages[1]);
			tabControl.TabPages.Remove(tabControl.TabPages[1]);
        }

		/// <summary>
		/// Выполняется когда хост заканчивает работу
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		void HandleStopped (object sender, EventArgs e)
		{
			startStopButton.Text = "Start";
			progressBar.Value = 0;
			photoCheckBox.Enabled = true;
			gpsCheckBox.Enabled = true;
			georadarCheckBox.Enabled = true;
			tabControl.TabPages.Add(tabPageBuffer[1]);
			tabControl.TabPages.Add(tabPageBuffer[0]);
			tabPageBuffer.Clear();
		}

        void HandleFormClosing (object sender, FormClosingEventArgs e)
        {
			host.Dispose ();
			conf.Dispose ();
        }

        void HandleOutputPending (string displayMe)
        {
			// т.к. мы вызываем этот метод из другого потака
			// мы должны убедится что рабтаем в GUI потока
				this.Invoke ((MethodInvoker)delegate () {
					this.AddLog (displayMe);
				});

        }
        //textbox numerals only
        private void NumeralsOnly(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)))
                if ((e.KeyChar != (char)Keys.Back))
                    if (e.KeyChar == '.' || e.KeyChar == ',')
                        e.KeyChar = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator[0];
                    else
                        e.Handled = true;
        }
        //start/stop button reaction
        private void startStopButton_Click(object sender, EventArgs e)
        {
            if (host.IsRunning) {   
				// устанавливаем хост
				host.Stop (); 

            } else {   
				// TODO: Заполнить conf с текущих настроек из формы
				// GO! GO! GO! запускаме работа хоста
				host.Init ();
				host.Start ();
            }
        }
        #region Publics
        //get device status
        /// <summary>
        /// Возвращает текущий статус устройства
        /// </summary>
        /// <param name="deviceType">1 - фотокамера, 2 - GPS, 3 - георадар</param>
        public bool DeviceStatus(int deviceType)
        {
            switch (deviceType)
            {
                case 1:
                    return photoCheckBox.Checked;
                case 2:
                    return gpsCheckBox.Checked;
                case 3:
                    return georadarCheckBox.Checked;
                default:
                    return false;
            }
        }
        //set device status
        /// <summary>
        /// Устанавливает статус устройства
        /// </summary>
        /// <param name="deviceType">1 - фотокамера, 2 - GPS, 3 - георадар</param>
        /// <param name="deviceStatus">true - активно, false - отключено</param>
        public void SetDeviceStatus(int deviceType, bool deviceStatus)
        {
            switch (deviceType)
            {
                case 1:
                    photoCheckBox.Checked = deviceStatus;
                    break;
                case 2:
                    gpsCheckBox.Checked = deviceStatus;
                    break;
                case 3:
                    georadarCheckBox.Checked = deviceStatus;
                    break;
            }
        }
        //write log
        /// <summary>
        /// Добавляет строку логов в окно вывода
        /// </summary>
        /// <param name="log">строка события, которую надо вывести</param>
        /// <param name="clear">по-умолчанию false, если true - очищает поле вывода</param>
        public void AddLog(string log, bool clear = false)
        {
			if (clear)
				logTextBox.Text = "";
			else
				logTextBox.AppendText (String.Format ("[{0}] {1}{2}", DateTime.Now.ToString ("HH:mm:ss.fff"), log, Environment.NewLine));

			// scroll to bottom
			logTextBox.SelectionStart = logTextBox.Text.Length;
			logTextBox.ScrollToCaret ();
        }
        //progressBarValue
        /// <summary>
        /// Изменяет progressBar
        /// </summary>
        /// <param name="value">новое значение, не может быть больше 100; если 0 - возвращает значение</param>
        public int ProgressBarValue(int value)
        {
            if (value == 0)
                return progressBar.Value;
            if (value > 100)
                value = 100;
            progressBar.Value = value;
            return progressBar.Value;
        }
        //get data base status
        /// <summary>
        /// Сообщает подключена ли БД
        /// </summary>
        /// <param name="dbType">1 - локальная, 2 - внешняя</param>
        public bool DBStatus(int dbType)
        {
            switch (dbType)
            {
                case 1:
                    return localDBCheckBox.Checked;
                case 2:
                    return extraDBCheckBox.Checked;
                default:
                    return false;
            }
        }
        //set data base status
        /// <summary>
        /// Устанавливает подключение БД 
        /// </summary>
        /// <param name="dbType">1 - локальная, 2 - внешняя</param>
        /// <param name="dbStatus">true - подключена, false - отключена</param>
        public void SetDBStatus(int dbType, bool dbStatus)
        {
            switch (dbType)
            {
                case 1:
                    localDBCheckBox.Checked = dbStatus;
                    break;
                case 2:
                    extraDBCheckBox.Checked = dbStatus;
                    break;
            }
        }
        //get device connect status
        /// <summary>
        /// Возвращает текущий статус подключения устройства, true - подключена заглушка
        /// </summary>
        /// <param name="deviceType">1 - фотокамера, 2 - GPS, 3 - георадар</param>
        public bool DeviceConnectStatus(int deviceType)
        {
            switch (deviceType)
            {
                case 1:
                    return photoConnectEmulatorRadioButton.Checked;
                case 2:
                    return gpsConnectEmulatorRadioButton.Checked;
                case 3:
                    return georadarConnectEmulatorRadioButton.Checked;
                default:
                    return false;
            }
        }
        //set device connect status
        /// <summary>
        /// Устанавливает статус подключения устройства (заглушка или устройство)
        /// </summary>
        /// <param name="deviceType">1 - фотокамера, 2 - GPS, 3 - георадар</param>
        /// <param name="deviceStatus">true - заглушка, false - устройство</param>
        public void SetDeviceConnectStatus(int deviceType, bool deviceStatus)
        {
            switch (deviceType)
            {
                case 1:
                    photoConnectEmulatorRadioButton.Checked = deviceStatus;
                    photoConnectDeviceRadioButton.Checked = !deviceStatus;
                    break;
                case 2:
                    gpsConnectEmulatorRadioButton.Checked = deviceStatus;
                    gpsConnectDeviceRadioButton.Checked = !deviceStatus;
                    break;
                case 3:
                    georadarConnectEmulatorRadioButton.Checked = deviceStatus;
                    georadarConnectDeviceRadioButton.Checked = !deviceStatus;
                    break;
            }
        }
        //get device period
        /// <summary>
        /// Возвращает тип единиц измерения периода, true - метры, false - мс
        /// </summary>
        /// <param name="deviceType">1 - фотокамера, 2 - GPS, 3 - георадар</param>
        public bool DevicePeriod(int deviceType)
        {
            switch (deviceType)
            {
                case 1:
                    return photoPeriodMetrRadioButton.Checked;
                case 2:
                    return gpsPeriodMetrRadioButton.Checked;
                case 3:
                    return georadarPeriodMetrRadioButton.Checked;
                default:
                    return false;
            }
        }
        //get period value
        /// <summary>
        /// Возвращает значение периода; при ошибке возвращает -1
        /// </summary>
        /// <param name="deviceType">1 - фотокамера, 2 - GPS, 3 - георадар</param>
        public int DevicePeriodValue(int deviceType)
        {
            switch (deviceType)
            {
                case 1:
                    return int.Parse(photoPeriodTextBox.Text);
                case 2:
                    return int.Parse(gpsPeriodTextBox.Text);
                case 3:
                    return int.Parse(georadarPeriodTextBox.Text);
                default:
                    return -1;
            }
        }
        //set device period status
        /// <summary>
        /// Устанавливает единицы измерения периода
        /// </summary>
        /// <param name="deviceType">1 - фотокамера, 2 - GPS, 3 - георадар</param>
        /// <param name="deviceStatus">true - метры, false - мс</param>
        //public void SetDeviceConnectStatus(int deviceType, bool deviceStatus)
        //{
        //    switch (deviceType)
        //    {
        //        case 1:
        //            photoPeriodMetrRadioButton.Checked = deviceStatus;
        //            photoPeriodMSRadioButton.Checked = !deviceStatus;
        //            break;
        //        case 2:
        //            gpsPeriodMetrRadioButton.Checked = deviceStatus;
        //            gpsPeriodMSRadioButton.Checked = !deviceStatus;
        //            break;
        //        case 3:
        //            georadarPeriodMetrRadioButton.Checked = deviceStatus;
        //            georadarPeriodMSRadioButton.Checked = !deviceStatus;
        //            break;
        //    }
        //}
        //set period value
        /// <summary>
        /// Устанавливает значение периода
        /// </summary>
        /// <param name="deviceType">1 - фотокамера, 2 - GPS, 3 - георадар</param>
        /// <param name="value">значение должно быть больше 0</param>
        public void DevicePeriodValue(int deviceType, int value)
        {
            switch (deviceType)
            {
                case 1:
                    photoPeriodTextBox.Text = value.ToString();
                    break;
                case 2:
                    gpsPeriodTextBox.Text = value.ToString();
                    break;
                case 3:
                    georadarPeriodTextBox.Text = value.ToString();
                    break;
            }
        }
        #endregion
    }
}
