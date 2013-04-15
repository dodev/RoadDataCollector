using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            var boundary = "------------------------" + DateTime.Now.Ticks;
            var newLine = Environment.NewLine;
            var propFormat = "--" + boundary + newLine +
                    "Content-Disposition: form-data; name=\"{0}\"" + newLine + newLine +
                    "{1}" + newLine;
            var fileHeaderFormat = "--" + boundary + newLine +
                                    "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"" + newLine;

            var req = (HttpWebRequest)HttpWebRequest.Create("http://yup.dev-forge.ru");
            req.Method = WebRequestMethods.Http.Post;
            req.ContentType = "multipart/form-data; boundary=" + boundary;
            req.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.1.4) Gecko/20091016 Firefox/3.5.4 GTB6 (.NET CLR 3.5.30729)";
            req.Timeout = 10000;


            string array = textBox4.Text;
            string x = textBox2.Text;
            string y = textBox3.Text;

            byte[] file = File.ReadAllBytes(textBox5.Text);
            string encoded_file = Convert.ToBase64String(file);
            string ext = System.IO.Path.GetExtension(openFileDialog1.FileName).ToLower();
            if (ext == "jpg") ext = "jpeg";
            string content_type = "Content-Type: image/"+ext;

            string postData = "image=" + encoded_file + "&gps_x=" + x + "&gps_y=" + y + "&geo_data=" + array;

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            using (var reqStream = req.GetRequestStream()) 
            {
                var reqWriter = new StreamWriter(reqStream);
                var tmp = string.Format(fileHeaderFormat, "image", System.IO.Path.GetFileName(textBox5.Text)) + 
                    content_type + newLine + newLine + encoded_file + newLine + newLine;
                reqWriter.Write(tmp);
                tmp = string.Format(propFormat, "gps_x", x);
                reqWriter.Write(tmp);
                tmp = string.Format(propFormat, "gps_y", y);
                reqWriter.Write(tmp);
                tmp = string.Format(propFormat, "geo_data", array);
                reqWriter.Write(tmp);
                reqWriter.Write("--" + boundary + "--");
                reqWriter.Flush();
            }

            var res = req.GetResponse();
            using (var resStream = res.GetResponseStream())
            {
                var reader = new StreamReader(resStream);
                var data = reader.ReadToEnd();
                MessageBox.Show("Данные дошли, сервер ответил " + ((HttpWebResponse)res).StatusDescription,
                    "Всё очень, очень хорошо.",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox5.Text = openFileDialog1.FileName;
            }
        }

        private void generate_array()
        {
            int Min = 0;
            int Max = 32000;
            int[] arr = new int[516]; 

            Random randNum = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = randNum.Next(Min, Max);
            }

            textBox4.Text = "[" + String.Join(",", arr.Select(p => p.ToString()).ToArray()) + "]";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            generate_array();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            generate_array();
        }
    }
}
