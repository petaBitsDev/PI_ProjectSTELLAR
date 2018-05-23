using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace ProjectStellar
{
    class Cases
    {
        RectangleShape _rec;
        int _x;
        int _y;

        public Cases(RectangleShape rec, int X, int Y)
        {
            _rec = rec;
            _x = X;
            _y = Y;
        }

        public RectangleShape Rec => _rec;

        public int X => _x;

        public int Y => _y;
    }
}
