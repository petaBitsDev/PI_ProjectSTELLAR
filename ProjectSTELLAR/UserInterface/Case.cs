using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace ProjectStellar
{
    class Case
    {
        FloatRect _rec;
        uint _x;
        uint _y;

        public Case(FloatRect rec, uint X, uint Y)
        {
            _rec = new FloatRect(rec.Left * 32, rec.Top * 32, rec.Width, rec.Height);
            _x = X;
            _y = Y;
        }

        public FloatRect Rec => _rec;

        public bool Contains(int x, int y)
        {
            return _rec.Contains(x, y);
        }

        public int X => (int)_x;

        public int Y => (int)_y;
    }
}
