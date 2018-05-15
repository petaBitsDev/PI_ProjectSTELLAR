using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace ProjectStellar
{
    public class WindowEvents
    {
        RenderWindow _window;
        Game _ctx;
        MapUI _mapUI;
        UI _ui;
        Font _font;

        public WindowEvents(RenderWindow Window, Game Game)
        {
            _ctx = Game;
            _window = Window;
            _font = _ctx._font;
        }

        public void WindowClosed(object sender, EventArgs e)
        {
            _window.Close();
        }

        public void MouseClicked(object sender, EventArgs e)
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {

                CheckClic((float)Mouse.GetPosition(_window).X, (float)Mouse.GetPosition(_window).Y, _window, _font);
            }
        }

        public void CheckClic(float x, float y, RenderWindow window, Font font)
        {
            if (_ctx.MenuState != 0)
            {
                if (CheckMap(x, y, window, font)) Console.WriteLine("map");
                else if (CheckUI(x, y)) Console.WriteLine("ui");
            }
        }

        public bool CheckMap(float x, float y, RenderWindow window, Font font)
        {
            return (_mapUI.CheckMap(x, y, window, font));
        }

        public MapUI MapUI
        {
            set { _mapUI = value; }
        }

        public UI UI
        {
            set { _ui = value; }
        }

        public bool CheckUI(float x, float y)
        {
            if (_ui.CheckTimeBar(x, y)) return true;
            else if (_ui.CheckBuildingToBuild(x, y)) return true;
            else if (_ui.CheckBuildSelected(_window)) return true;
            else if (_ui.CheckDestroySelected(_window)) return true;
            else return false;
        }


    }
}
