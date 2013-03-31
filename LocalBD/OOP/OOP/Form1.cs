using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //int[] a = { 2, 3, 4, 512, 21, 321 };
            //MessageBox.Show(Helper.ArrayToString(a));
            //MessageBox.Show(Helper.StringToArray(Helper.ArrayToString(a)).Length.ToString());

            //Point p = new Point(1231, 213);
            //MessageBox.Show(Helper.PointToString(p));
            //MessageBox.Show(Helper.PointToString(532, 32321));
            //MessageBox.Show(Helper.StringToPoint(Helper.PointToString(p)).X.ToString());
            //MessageBox.Show(Helper.StringToPoint(Helper.PointToString(p)).Y.ToString());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'localDataSet.GPSTable' table. You can move, or remove it, as needed.
            this.gPSTableTableAdapter.Fill(this.localDataSet.GPSTable);
            // TODO: This line of code loads data into the 'localDataSet.PhotoTable' table. You can move, or remove it, as needed.
            this.photoTableTableAdapter.Fill(this.localDataSet.PhotoTable);
            // TODO: This line of code loads data into the 'localDataSet.GeoradarTable' table. You can move, or remove it, as needed.
            this.georadarTableTableAdapter.Fill(this.localDataSet.GeoradarTable);
            // TODO: This line of code loads data into the 'localDataSet.MainTable' table. You can move, or remove it, as needed.
            this.mainTableTableAdapter.Fill(this.localDataSet.MainTable);
            // TODO: This line of code loads data into the 'localDataSet.MainTable' table. You can move, or remove it, as needed.
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // TODO: This line of code loads data into the 'localDataSet.GPSTable' table. You can move, or remove it, as needed.
            this.gPSTableTableAdapter.Update(this.localDataSet.GPSTable);
            // TODO: This line of code loads data into the 'localDataSet.PhotoTable' table. You can move, or remove it, as needed.
            this.photoTableTableAdapter.Update(this.localDataSet.PhotoTable);
            // TODO: This line of code loads data into the 'localDataSet.GeoradarTable' table. You can move, or remove it, as needed.
            this.georadarTableTableAdapter.Update(this.localDataSet.GeoradarTable);
            // TODO: This line of code loads data into the 'localDataSet.MainTable' table. You can move, or remove it, as needed.
            this.mainTableTableAdapter.Update(this.localDataSet.MainTable);
            // TODO: This line of code loads data into the 'localDataSet.MainTable' table. You can move, or remove it, as needed.
           
        }
    }
}
