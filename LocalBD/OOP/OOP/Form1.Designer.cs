namespace OOP
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
            this.components = new System.ComponentModel.Container();
            this.localDataSet = new OOP.LocalDataSet();
            this.localDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.MainGPSDGV = new System.Windows.Forms.DataGridView();
            this.GPSDGV = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.MainPhotoDGV = new System.Windows.Forms.DataGridView();
            this.PhotoDGV = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.MainGeoradarDGV = new System.Windows.Forms.DataGridView();
            this.GeoradarDGV = new System.Windows.Forms.DataGridView();
            this.mainTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainTableTableAdapter = new OOP.LocalDataSetTableAdapters.MainTableTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.georadarTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.georadarTableTableAdapter = new OOP.LocalDataSetTableAdapters.GeoradarTableTableAdapter();
            this.photoTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.photoTableTableAdapter = new OOP.LocalDataSetTableAdapters.PhotoTableTableAdapter();
            this.dataStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataArrayDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gPSTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gPSTableTableAdapter = new OOP.LocalDataSetTableAdapters.GPSTableTableAdapter();
            this.dataCoordinatesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.localDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localDataSetBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainGPSDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPSDGV)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPhotoDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoDGV)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainGeoradarDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeoradarDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.georadarTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gPSTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // localDataSet
            // 
            this.localDataSet.DataSetName = "LocalDataSet";
            this.localDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // localDataSetBindingSource
            // 
            this.localDataSetBindingSource.DataSource = this.localDataSet;
            this.localDataSetBindingSource.Position = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(594, 508);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.MainGPSDGV);
            this.tabPage1.Controls.Add(this.GPSDGV);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(586, 482);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "GPSPage";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // MainGPSDGV
            // 
            this.MainGPSDGV.AutoGenerateColumns = false;
            this.MainGPSDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainGPSDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn});
            this.MainGPSDGV.DataSource = this.mainTableBindingSource;
            this.MainGPSDGV.Location = new System.Drawing.Point(6, 254);
            this.MainGPSDGV.Name = "MainGPSDGV";
            this.MainGPSDGV.Size = new System.Drawing.Size(571, 222);
            this.MainGPSDGV.TabIndex = 1;
            // 
            // GPSDGV
            // 
            this.GPSDGV.AutoGenerateColumns = false;
            this.GPSDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GPSDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataCoordinatesDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn1});
            this.GPSDGV.DataSource = this.gPSTableBindingSource;
            this.GPSDGV.Location = new System.Drawing.Point(6, 6);
            this.GPSDGV.Name = "GPSDGV";
            this.GPSDGV.Size = new System.Drawing.Size(571, 242);
            this.GPSDGV.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.MainPhotoDGV);
            this.tabPage2.Controls.Add(this.PhotoDGV);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(586, 482);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "PhotoPage";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainPhotoDGV
            // 
            this.MainPhotoDGV.AutoGenerateColumns = false;
            this.MainPhotoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainPhotoDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn3});
            this.MainPhotoDGV.DataSource = this.mainTableBindingSource;
            this.MainPhotoDGV.Location = new System.Drawing.Point(6, 254);
            this.MainPhotoDGV.Name = "MainPhotoDGV";
            this.MainPhotoDGV.Size = new System.Drawing.Size(571, 222);
            this.MainPhotoDGV.TabIndex = 3;
            // 
            // PhotoDGV
            // 
            this.PhotoDGV.AutoGenerateColumns = false;
            this.PhotoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PhotoDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataStringDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn1,
            this.iDDataGridViewTextBoxColumn2});
            this.PhotoDGV.DataSource = this.photoTableBindingSource;
            this.PhotoDGV.Location = new System.Drawing.Point(6, 6);
            this.PhotoDGV.Name = "PhotoDGV";
            this.PhotoDGV.Size = new System.Drawing.Size(571, 222);
            this.PhotoDGV.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.MainGeoradarDGV);
            this.tabPage3.Controls.Add(this.GeoradarDGV);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(586, 482);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "GeoradarPage";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // MainGeoradarDGV
            // 
            this.MainGeoradarDGV.AutoGenerateColumns = false;
            this.MainGeoradarDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainGeoradarDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn5});
            this.MainGeoradarDGV.DataSource = this.mainTableBindingSource;
            this.MainGeoradarDGV.Location = new System.Drawing.Point(6, 254);
            this.MainGeoradarDGV.Name = "MainGeoradarDGV";
            this.MainGeoradarDGV.Size = new System.Drawing.Size(571, 222);
            this.MainGeoradarDGV.TabIndex = 5;
            // 
            // GeoradarDGV
            // 
            this.GeoradarDGV.AutoGenerateColumns = false;
            this.GeoradarDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GeoradarDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataArrayDataGridViewTextBoxColumn1,
            this.dateDataGridViewTextBoxColumn2,
            this.iDDataGridViewTextBoxColumn4});
            this.GeoradarDGV.DataSource = this.georadarTableBindingSource;
            this.GeoradarDGV.Location = new System.Drawing.Point(6, 6);
            this.GeoradarDGV.Name = "GeoradarDGV";
            this.GeoradarDGV.Size = new System.Drawing.Size(571, 222);
            this.GeoradarDGV.TabIndex = 4;
            // 
            // mainTableBindingSource
            // 
            this.mainTableBindingSource.DataMember = "MainTable";
            this.mainTableBindingSource.DataSource = this.localDataSetBindingSource;
            // 
            // mainTableTableAdapter
            // 
            this.mainTableTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // georadarTableBindingSource
            // 
            this.georadarTableBindingSource.DataMember = "GeoradarTable";
            this.georadarTableBindingSource.DataSource = this.localDataSetBindingSource;
            // 
            // georadarTableTableAdapter
            // 
            this.georadarTableTableAdapter.ClearBeforeFill = true;
            // 
            // photoTableBindingSource
            // 
            this.photoTableBindingSource.DataMember = "PhotoTable";
            this.photoTableBindingSource.DataSource = this.localDataSetBindingSource;
            // 
            // photoTableTableAdapter
            // 
            this.photoTableTableAdapter.ClearBeforeFill = true;
            // 
            // dataStringDataGridViewTextBoxColumn
            // 
            this.dataStringDataGridViewTextBoxColumn.DataPropertyName = "dataString";
            this.dataStringDataGridViewTextBoxColumn.HeaderText = "dataString";
            this.dataStringDataGridViewTextBoxColumn.Name = "dataStringDataGridViewTextBoxColumn";
            // 
            // dateDataGridViewTextBoxColumn1
            // 
            this.dateDataGridViewTextBoxColumn1.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn1.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn1.Name = "dateDataGridViewTextBoxColumn1";
            // 
            // iDDataGridViewTextBoxColumn2
            // 
            this.iDDataGridViewTextBoxColumn2.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn2.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn2.Name = "iDDataGridViewTextBoxColumn2";
            // 
            // iDDataGridViewTextBoxColumn3
            // 
            this.iDDataGridViewTextBoxColumn3.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn3.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn3.Name = "iDDataGridViewTextBoxColumn3";
            // 
            // dataArrayDataGridViewTextBoxColumn1
            // 
            this.dataArrayDataGridViewTextBoxColumn1.DataPropertyName = "dataArray";
            this.dataArrayDataGridViewTextBoxColumn1.HeaderText = "dataArray";
            this.dataArrayDataGridViewTextBoxColumn1.Name = "dataArrayDataGridViewTextBoxColumn1";
            // 
            // dateDataGridViewTextBoxColumn2
            // 
            this.dateDataGridViewTextBoxColumn2.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn2.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn2.Name = "dateDataGridViewTextBoxColumn2";
            // 
            // iDDataGridViewTextBoxColumn4
            // 
            this.iDDataGridViewTextBoxColumn4.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn4.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn4.Name = "iDDataGridViewTextBoxColumn4";
            // 
            // iDDataGridViewTextBoxColumn5
            // 
            this.iDDataGridViewTextBoxColumn5.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn5.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn5.Name = "iDDataGridViewTextBoxColumn5";
            // 
            // gPSTableBindingSource
            // 
            this.gPSTableBindingSource.DataMember = "GPSTable";
            this.gPSTableBindingSource.DataSource = this.localDataSetBindingSource;
            // 
            // gPSTableTableAdapter
            // 
            this.gPSTableTableAdapter.ClearBeforeFill = true;
            // 
            // dataCoordinatesDataGridViewTextBoxColumn
            // 
            this.dataCoordinatesDataGridViewTextBoxColumn.DataPropertyName = "dataCoordinates";
            this.dataCoordinatesDataGridViewTextBoxColumn.HeaderText = "dataCoordinates";
            this.dataCoordinatesDataGridViewTextBoxColumn.Name = "dataCoordinatesDataGridViewTextBoxColumn";
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            // 
            // iDDataGridViewTextBoxColumn1
            // 
            this.iDDataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn1.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn1.Name = "iDDataGridViewTextBoxColumn1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 532);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.localDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localDataSetBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainGPSDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPSDGV)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainPhotoDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoDGV)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainGeoradarDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeoradarDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.georadarTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gPSTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LocalDataSet localDataSet;
        private System.Windows.Forms.BindingSource localDataSetBindingSource;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView MainGPSDGV;
        private System.Windows.Forms.DataGridView GPSDGV;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView MainPhotoDGV;
        private System.Windows.Forms.DataGridView PhotoDGV;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView MainGeoradarDGV;
        private System.Windows.Forms.DataGridView GeoradarDGV;
        private System.Windows.Forms.BindingSource mainTableBindingSource;
        private LocalDataSetTableAdapters.MainTableTableAdapter mainTableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource georadarTableBindingSource;
        private LocalDataSetTableAdapters.GeoradarTableTableAdapter georadarTableTableAdapter;
        private System.Windows.Forms.BindingSource photoTableBindingSource;
        private LocalDataSetTableAdapters.PhotoTableTableAdapter photoTableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataArrayDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn4;
        private System.Windows.Forms.BindingSource gPSTableBindingSource;
        private LocalDataSetTableAdapters.GPSTableTableAdapter gPSTableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataCoordinatesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
    }
}

