using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObserverPattern
{
    public partial class UserForm : Form, IObserver
    {
        WeatherStation station;
        public UserForm(WeatherStation station)
        {
            InitializeComponent();
            this.station = station;
            this.station.Add(this);
            Update();
        }

        public void Update() {
            label2.Text = station.State.ToString();
            label1.Text = station.Degrees.ToString();
            label4.Text = station.Rain.ToString();
            label5.Text = station.Wind.ToString();

        }
     
        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            station.Remove(this);
        }

    }
}
