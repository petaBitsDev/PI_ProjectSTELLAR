using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace ProjectStellar
{
    public class NewGame
    {
        readonly uint _resX;
        readonly uint _resY;
        readonly Game _ctx;
        string _name;
        Text _text;

        public NewGame(uint resX, uint resY, Game ctx, Font font)
        {
            _resX = resX;
            _resY = resY;
            _ctx = ctx;
            _name = "";

            _text = new Text("", font)
            {
                Position = new Vector2f(resX / 3 * 2, resY / 3 * 2),
                Color = Color.White
            };
        }

        public void Draw(RenderWindow window)
        {
            _text.DisplayedString = _name;
            _text.Draw(window, RenderStates.Default);
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
