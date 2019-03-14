using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stopwatch
{
    public partial class Stopwatch : Form
    {
        TimeSpan span = TimeSpan.Zero; //Отсчитываемый интервал
        DateTime startTime;
        public Stopwatch()
        {
            InitializeComponent();
            launchButton.ForeColor = Color.FromArgb(30, 144, 255);
            resetButton.ForeColor = Color.FromArgb(30, 144, 255);
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                span += DateTime.Now - startTime; //К интервалу добавляется время между последним запуском и настоящим моментом
                resetButton.Enabled = true;
                launchButton.BackColor = Color.White;
                launchButton.ForeColor = Color.FromArgb(30, 144, 255);
            }

            else
            {
                startTime = DateTime.Now;
                resetButton.Enabled = false;
                launchButton.BackColor = Color.FromArgb(30, 144, 255);
                launchButton.ForeColor = Color.White;
            }
            timer1.Enabled = !timer1.Enabled;
            launchButton.Text = timer1.Enabled ? "Pause" : "Continue";
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            span = TimeSpan.Zero; //При нажатии кнопки сброса интервал обнуляется, т.к. отсчёт начинается заново
            spanLabel.Text = "00:00:000";
            launchButton.Text = "Start";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan newSpan = span + (DateTime.Now - startTime); //текущий интервал суммируется с временем ожидания
            spanLabel.Text = newSpan.Minutes.ToString("00") + ":" + newSpan.Seconds.ToString("00") + ":" + newSpan.Milliseconds.ToString("000");
        }
    }
}
