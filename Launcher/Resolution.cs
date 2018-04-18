using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.FormLauncher
{
    public class Resolution
    {
        uint _x;
        uint _y;

        public Resolution()
        {
        }

        public uint X
        {
            get { return _x; }
            set { _x = value; }
        }

        public uint Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }
}
