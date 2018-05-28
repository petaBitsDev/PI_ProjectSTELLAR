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
        Font _font;
        float _x1;
        float _x2;
        float _y1;
        float _y2;
        float _xMax;
        float _yMax;

        public WindowEvents(RenderWindow Window, Game Game, Resolution resolution, View view)
        {
            _ctx = Game;
            _window = Window;
            _font = _ctx._font;
            _resolution = resolution;
            _view = view;
            _x1 = 0;
            _y1 = 0;
            _x2 = _resolution.X * 0.9f;
            _y2 = resolution.Y * 0.95f;
        }

        public void WindowClosed(object sender, EventArgs e)
        {
            _window.Close();
        }
        
        public void MouseMoved(object sender, EventArgs e)
        {
            if (_ctx.MenuState == 1)
            {
                _xMax = _mapUI._x2y2.X;
                _yMax = _mapUI._x2y2.Y;
            }

            int posX = Mouse.GetPosition(_window).X;
            int posY = Mouse.GetPosition(_window).Y;

            // Right side
            if (posX == (_resolution.X - 1))
            {
                if (CheckCamera(new Vector2f(50, 0)))
                {
                    _x1 += 50;
                    _x2 += 50;
                    _view.Move(new Vector2f(50, 0));
                }
            }
            // Left side
            else if (posX == 0)
            {
                if (CheckCamera(new Vector2f(-50, 0)))
                {
                    _x1 += -50;
                    _x2 += -50;
                    _view.Move(new Vector2f(-50, 0));
                }
            }
            // Up side
            else if (posY == 0)
            {
                if (CheckCamera(new Vector2f(0, -50)))
                {
                    _y1 += -50;
                    _y2 += -50;
                    _view.Move(new Vector2f(0, -50));
                }
            }
            // Bottom side
            else if (posY == (_resolution.Y - 1))
            {
                Console.WriteLine("X = {0}, Y = {1}", _view.Viewport.Height, _view.Viewport.Width);

                if (CheckCamera(new Vector2f(0, 50)))
                {
                    _y1 += 50;
                    _y2 += 50;
                    _view.Move(new Vector2f(0, 50));
                }
            }
        }

        bool CheckCamera( Vector2f move)
        {
            //x1y1
            if (_x1 + move.X < 0 || _y1 + move.Y < 0) return false;
            //x2y1
            else if (_x2 + move.X > _xMax || _y1 + move.Y < 0) return false;
            //x1y2 ne fonctionne pas
            else if (_x1 + move.X < 0 || _y2 + move.Y > _yMax) return false;
            //x2y2 ne fonctionne pas
            else if (_x2 + move.X > _xMax || _y2 + move.Y > _yMax) return false;
            else return true;
        }

        public void MouseWheel(object sender, MouseWheelEventArgs e)
        {
            float delta;
            delta = e.Delta;
            if (delta < 0)
            {
                _view.Zoom(1.06f);
            }
            else
            {
                _view.Zoom(0.94f);
            }
        }

        public void MouseClicked(object sender, EventArgs e)
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                Vector2i pixelPos = Mouse.GetPosition(_window);
                Vector2f worldPos = _window.MapPixelToCoords(pixelPos, _view);
                CheckClic(worldPos.X, worldPos.Y);
            }
        }

        public void CheckClic(float x, float y)
        {
            if (_ctx.MenuState != 0)
            {
                if (CheckUI(Mouse.GetPosition(_window).X, Mouse.GetPosition(_window).Y, _ctx.GameTime)) Console.WriteLine("ui");
                else if (CheckMap(x, y, _window, _ctx._font)) Console.WriteLine("map");
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

        public bool CheckUI(float x, float y, GameTime gameTime)
        {
            if (_ui.CheckTimeBar(x, y, gameTime)) return true;
            else if (_ui.CheckBuildingToBuild(_window, _ctx._resourcesManager)) return true;
            else if (_ui.CheckBuildSelected(_window)) return true;
            else if (_ui.CheckDestroySelected(_window)) return true;
            else return false;
        }

        public View CurrentView => _view;
        public void KeyPressed(object sender, EventArgs e)
        {

            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                SaveGame save = new SaveGame(_ctx._name, _ctx._map, _ctx.GameTime, _ctx._resourcesManager);
                Save.SaveGame(save, _ctx._name);
                Console.WriteLine("Saved");
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.L))
            {
                SaveGame save = Save.LoadGame(_ctx._name);
                _ctx.LoadGame(save);
                Console.WriteLine("Loaded");
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.T))
            {
                List<SaveGameMetadata> list = Save.List();

                foreach (SaveGameMetadata metadata in list)
                {
                    Console.WriteLine("Nom : {0} - Population : {1} - Date : {2}", metadata.Name, metadata.Population, metadata.Date);
                }
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Add))
            {
                _view.Zoom(1.06f);
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Subtract))
            {
                _view.Zoom(-1.06f);
            }
        }

        internal View View => _view;
    }
}
