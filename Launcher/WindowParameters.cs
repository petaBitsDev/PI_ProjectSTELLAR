using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.FormLauncher
{
    public class WindowParameters
    {
        Resolution _resolution;
        bool _fullscreen;

        public WindowParameters()
        {
            _resolution = new Resolution();
        }

        public bool IsFullScreen
        {
            get { return _fullscreen; }
            set { _fullscreen = value; }
        }

        public Resolution Resolution => _resolution;
    }
}
