using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Windows.Input;
using ProjectStellar.Library;

namespace ProjectStellar
{
    public class WindowEvents
    {
        RenderWindow _window;
        Game _ctx;
        MapUI _mapUI;
        UI _ui;
        Resolution _resolution;
        View _view;

        public WindowEvents(RenderWindow Window, Game Game, Resolution resolution, View view)
        {
            _ctx = Game;
            _window = Window;
            _resolution = resolution;
            _view = view;
        }

        public void WindowClosed(object sender, EventArgs e)
        {
            _window.Close();
        }

        public void MouseClicked(object sender, EventArgs e)
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                CheckClic((float)Mouse.GetPosition(_window).X, (float)Mouse.GetPosition(_window).Y);
            }
        }
        
        public void MouseMoved(object sender, EventArgs e)
        {
            int posX = Mouse.GetPosition(_window).X;
            int posY = Mouse.GetPosition(_window).Y;
            Vector2f currentCenter = _view.Center;

            if (posX == (_resolution.X - 1))
            {
                _view.Center = new Vector2f(currentCenter.X + 50, currentCenter.Y);
                _view.Move(new Vector2f(50, 0));
                _window.SetView(_view);
            }
            else if (posX == 0)
            {
                _view.Center = new Vector2f(currentCenter.X - 50, currentCenter.Y);
                _view.Move(new Vector2f(-50, 0));
                _window.SetView(_view);
            }
            else if (posY == 0)
            {
                _view.Center = new Vector2f(currentCenter.X, currentCenter.Y - 50);
                _view.Move(new Vector2f(0, -50));
                _window.SetView(_view);
            }
            else if (posY == (_resolution.Y - 1))
            {
                _view.Center = new Vector2f(currentCenter.X, currentCenter.Y + 50);
                _view.Move(new Vector2f(0, 50));
                _window.SetView(_view);
            }
        }

        public void OnKeyPressed(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Add))
            {
                _view.Zoom(0.94f);
                _view.Center = new Vector2f(_view.Size.X / 2, _view.Size.Y / 2);
                _window.SetView(_view);
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Subtract))
            {
                _view.Zoom(1.06f);
                _view.Center = new Vector2f(_view.Size.X / 2, _view.Size.Y / 2);
                _window.SetView(_view);
            }
        }

        public void MouseWheel(object sender, EventArgs e)
        {
            //int delta;
            //delta = e.Delta;

            //if(delta < 0)
            //{
            //_window.SetView(new View(new Vector2f(), new Vector2f()));
            //}
            //else
            //{
            //    _window.SetView(new View(new Vector2f(), new Vector2f()));
            //}
        }

        public void CheckClic(float x, float y)
        {
            if (_ctx.MenuState != 0)
            {
                if (CheckMap(x, y)) Console.WriteLine("map");
                else if (CheckUI(x, y)) Console.WriteLine("ui");
            }
        }

        public bool CheckMap(float x, float y)
        {
            return (_mapUI.CheckMap(x, y));
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
