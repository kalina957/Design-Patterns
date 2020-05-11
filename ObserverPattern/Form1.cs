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
    public enum Weather { Sunny, Clear, Rainy }
    public partial class Form1 : Form
    {
        WeatherStation station;
        public Form1()
        {
            InitializeComponent();
            station = new WeatherStation();
            comboBox1.DataSource = Enum.GetValues(typeof(Weather));

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            station.State = (Weather)comboBox1.SelectedItem;
            station.Degrees = tbDegrees.Text;
            station.Rain = tbRain.Text;
            station.Wind = tbWind.Text;
            UserForm user = new UserForm(station);
            user.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            station.State = (Weather)comboBox1.SelectedItem;
            station.Degrees = tbDegrees.Text.ToString();
            station.Rain = tbRain.Text.ToString();
            station.Wind = tbWind.Text.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
