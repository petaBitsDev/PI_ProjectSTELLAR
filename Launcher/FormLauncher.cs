using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectStellar.Library;

namespace ProjectStellar.FormLauncher
{
    public partial class Launcher : Form
    {
        WindowParameters _windowParameters;
        public Launcher()
        {
            InitializeComponent();
            _windowParameters = new WindowParameters();
            _windowParameters.Resolution.X = 1280;
            _windowParameters.Resolution.Y = 720;

        }

        private void FullScreen_CheckedChanged(object sender, EventArgs e)
        {
            if (fullscreen.Checked != _windowParameters.IsFullScreen)
            {
                _windowParameters.IsFullScreen = fullscreen.Checked;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //640 * 360
            //1024 * 576
            //1280 * 720
            //1366 * 768
            //1920 * 1080
            //2560 * 1440
            //3840 * 2160
            Resolution[] allResolutions = new Resolution[8];
            allResolutions[0] = new Resolution() { X = 640, Y = 360 };
            allResolutions[1] = new Resolution() { X = 1024, Y = 576 };
            allResolutions[2] = new Resolution() { X = 1280, Y = 720 };
            allResolutions[3] = new Resolution() { X = 1366, Y = 768 };
            allResolutions[4] = new Resolution() { X = 1920, Y = 1080 };
            allResolutions[5] = new Resolution() { X = 2048, Y = 1280 };
            allResolutions[6] = new Resolution() { X = 2560, Y = 1440 };
            allResolutions[7] = new Resolution() { X = 3840, Y = 2160 };

            for (int i = 0; i < allResolutions.Length; i++)
            {
                if (resolution.SelectedIndex == i)
                {
                    _windowParameters.Resolution.X = allResolutions[i].X;
                    _windowParameters.Resolution.Y = allResolutions[i].Y;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Launch_Click(object sender, EventArgs e)
        {
            Close();
        }

        public WindowParameters Settings => _windowParameters;
    }
}
