using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ForFish
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            Thread.Sleep(10);
            SendKeys.Send("t");
            Thread.Sleep(700);
            SendKeys.Send("7");
            Thread.Sleep(5);
            Cmd(@"D:\C#_Code_Sources\ForFish\ForFish2\bin\Debug\ForFish2.exe");
            Thread.Sleep(5);
            Close();
        }

        void Cmd(string line)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c {line}",
                WindowStyle = ProcessWindowStyle.Hidden
            });
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Location = new Point(0, 0);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                foreach (var process in Process.GetProcessesByName("ForFish"))
                {
                    process.Kill();
                }
            }
        }
    }
}
