using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrategyApplication
{
    public partial class Form1 : Form
    {

        private List<Process> currentList;
        private OS current;
        private IStrategy scheduler;

        public Form1()
        {
            InitializeComponent();

            createArray(10, 70, 15);
            timer1.Interval = 3000;
            timer1.Tick += Timer1_Tick;
            trackBar.Maximum = 100;
            trackBar.Minimum = 0;
        }

        public Form1()
        {
            throw new System.NotImplementedException();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (rbFCFS.Checked || rbSkanD.Checked || rbSSTF.Checked)
            {
                timer1.Start();
                btnStart.Enabled = false;
                button1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Strategy not selected");
            }

        }
        private void AddProcessesToList(List<Process> processestopopulate)
        {
            lbProcesses.Items.Clear();

            foreach (var item in processestopopulate)
            {
                lbProcesses.Items.Add(item.id);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            currentList = current.ResetScheduling(currentList);
            AddProcessesToList(currentList);
            trackBar.Value = current.ProcessToBeRemoved;
            tbCurrOperation.Text = current.ProcessToBeRemoved.ToString();
            //createLabel();

        }

        private void rbSkanD_CheckedChanged(object sender, EventArgs e)
        {
            scheduler = new SCAN_Disk_Elevator();
            current = new OS(scheduler);
        }

        private void rbFCFS_CheckedChanged(object sender, EventArgs e)
        {
            scheduler = new FCFS();
            current = new OS(scheduler);
        }

        private void rbSSTF_CheckedChanged(object sender, EventArgs e)
        {
            scheduler = new SSTF();
            current = new OS(scheduler);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            button1.Enabled = false;
            btnStart.Enabled = true;
        }

        private void createArray(int min, int max, int count)
        {
            currentList = new List<Process>();
            Random rand = new Random();
            int[] resultIds = new int[count];
            List<int> idsInOrder = new List<int>();

            int[] resultSeekTimes = new int[count];
            List<int> seekTimesInOrder = new List<int>();


            for (var x = min; x < max; x++)
            {
                idsInOrder.Add(x);
                seekTimesInOrder.Add(x + 5);
            }
            for (var x = 0; x < count; x++)
            {
                var randomIndex = rand.Next(0, idsInOrder.Count);
                var randomIndexS = rand.Next(0, seekTimesInOrder.Count);
                resultIds[x] = idsInOrder[randomIndex];
                resultSeekTimes[x] = seekTimesInOrder[randomIndexS];

                idsInOrder.RemoveAt(randomIndex);
                seekTimesInOrder.RemoveAt(randomIndexS);
            }

            for (int i = 0; i < count; i++)
            {
                currentList.Add(new Process(resultIds[i], resultSeekTimes[i]));
            }
            AddProcessesToList(currentList);
        }

        //private void createLabel()
        //{
        //    Label l = new Label();

        //    // Set the location of the Label
        //    l.Location = new Point(50, trackBar.Value + 307);
        //    MessageBox.Show(trackBar.Value.ToString());
        //    l.Text = "Hello World!";
        //    l.BackColor = Color.Green;
        //    this.Controls.Add(l);

        //}
    }
}