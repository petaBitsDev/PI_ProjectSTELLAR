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
        //Vector2f _upLeftViewCoordinates;
        //Vector2f _downrightViewCoordinates;

        public WindowEvents(RenderWindow Window, Game Game, Resolution resolution, View view)
        {
            _ctx = Game;
            _window = Window;
            _font = _ctx._font;
            _resolution = resolution;
            _view = view;
            //_upLeftViewCoordinates = new Vector2f(0, 0);
            _x1 = 0;
            _y1 = 0;
            _x2 = _resolution.X * 0.9f;
            _y2 = resolution.Y * 0.95f;
        }

        public void WindowClosed(object sender, EventArgs e)
        {
            _window.Close();
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
        
        public void MouseMoved(object sender, EventArgs e)
        {
            if (_ctx.MenuState == 1)
            {
                _xMax = _mapUI._x2y2.X;
                _yMax = _mapUI._x2y2.Y;
                //_downrightViewCoordinates = new Vector2f(_mapUI._x2y2.X, _mapUI._x2y2.Y);

            }
            int posX = Mouse.GetPosition(_window).X;
            int posY = Mouse.GetPosition(_window).Y;
            Vector2f currentCenter = _view.Center;

            // Right side
            if (posX == (_resolution.X - 1))
            {
                //for(int i = 0; i < 20; i++)
                //{
                //    for(int j = 0; j < 20; j++)
                //    {
                //        if (_ctx._drawUI.MapUI.MapSprites[j, 20].GetGlobalBounds().Contains(Mouse.GetPosition(_window).X, Mouse.GetPosition(_window).Y))
                //        {
                //            _view.Center = new Vector2f(currentCenter.X, currentCenter.Y);
                //            _window.SetView(_view);
                //        }
                //    }
                //}

                //_view.Center = new Vector2f(currentCenter.X + 50, currentCenter.Y);
                if (CheckCamera(new Vector2f(50, 0)))
                {
                    //_upLeftViewCoordinates.X += 50;
                    //_downrightViewCoordinates.X += 50;
                    _x1 += 50;
                    _x2 += 50;
                    _view.Move(new Vector2f(50, 0));
                    _view.Viewport = new FloatRect(0, 0, 0.9f, 0.95f);
                }
                //_window.SetView(_view);
            }
            // Left side
            else if (posX == 0)
            {
                //for (int i = 0; i < 20; i++)
                //{
                //    for (int j = 0; j < 20; j++)
                //    {
                //        if (_mapUI.MapSprites[j, 0].GetGlobalBounds().Contains(Mouse.GetPosition(_window).X, Mouse.GetPosition(_window).Y))
                //        {
                //            _view.Center = new Vector2f(currentCenter.X, currentCenter.Y);
                //            _window.SetView(_view);
                //        }
                //    }
                //}

                //_view.Center = new Vector2f(currentCenter.X - 50, currentCenter.Y);
                if (CheckCamera(new Vector2f(-50, 0)))
                {
                    _x1 += -50;
                    _x2 += -50;
                    //_upLeftViewCoordinates.X += -50;
                    //_downrightViewCoordinates.X += -50;
                    _view.Move(new Vector2f(-50, 0));
                    _view.Viewport = new FloatRect(0, 0, 0.9f, 0.95f);
                }
                //_window.SetView(_view);
            }
            // Up side
            else if (posY == 0)
            {
                //for (int i = 0; i < 20; i++)
                //{
                //    for (int j = 0; j < 20; j++)
                //    {
                //        if (_mapUI.MapSprites[0, i].GetGlobalBounds().Contains(Mouse.GetPosition(_window).X, Mouse.GetPosition(_window).Y))
                //        {
                //            _view.Center = new Vector2f(currentCenter.X, currentCenter.Y);
                //            _window.SetView(_view);
                //        }
                //    }
                //}

                //_view.Center = new Vector2f(currentCenter.X, currentCenter.Y - 50);
                if (CheckCamera(new Vector2f(0, -50)))
                {
                    _y1 += -50;
                    _y2 += -50;
                    //_upLeftViewCoordinates.Y += -50;
                    //_downrightViewCoordinates.Y += -50;
                    _view.Move(new Vector2f(0, -50));
                    _view.Viewport = new FloatRect(0, 0, 0.9f, 0.95f);
                }
                //_window.SetView(_view);
            }
            // Bottom side
            else if (posY == (_resolution.Y - 1))
            {
                //for (int i = 0; i < 20; i++)
                //{
                //    for (int j = 0; j < 20; j++)
                //    {
                //        if (_mapUI.MapSprites[20, i].GetGlobalBounds().Contains(Mouse.GetPosition(_window).X, Mouse.GetPosition(_window).Y))
                //        {
                //            _view.Center = new Vector2f(currentCenter.X, currentCenter.Y);
                //            _window.SetView(_view);
                //        }
                //    }
                //}

                //Console.WriteLine("x1 = {0}, x2 = {1} \0 y1 = {2}, y2 = {3}", _view.Viewport.Left, _view.Viewport.Width, _view.Viewport.Top, _view.Viewport.Height);
                Console.WriteLine("X = {0}, Y = {1}", _view.Viewport.Height, _view.Viewport.Width);

                if (CheckCamera(new Vector2f(0, 50)))
                {
                    //_view.Center = new Vector2f(currentCenter.X, currentCenter.Y + 50);
                    _y1 += 50;
                    _y2 += 50;
                    //_upLeftViewCoordinates.Y += 50;
                    //_downrightViewCoordinates.Y += 50;
                    _view.Move(new Vector2f(0, 50));
                    _view.Viewport = new FloatRect(0, 0, 0.9f, 0.95f);
                }
                //_window.SetView(_view);
            }
        }

        bool CheckCamera( Vector2f move)
        {
            //float xMax = (float)_resolution.X * 0.9f;
            //float yMax = (float)_resolution.Y * 0.95f;
            //Vector2f x1y1 = new Vector2f(view.Center.X - view.Size.X / 2, view.Center.Y - view.Size.Y / 2);
            //Vector2f x2y2 = new Vector2f(view.Center.X + view.Size.X / 2, view.Center.Y + view.Size.Y / 2);

            //x1y1
            if (_x1 + move.X < 0 || _y1 + move.Y < 0) return false;
            //x2y1
            else if (_x2 + move.X > _xMax || _y1 + move.Y < 0) return false;
            //x1y2 ne fonctionne pas
            else if (_x1 + move.X < 0 || _y2 + move.Y > _yMax) return false;
            //x2y2 ne fonctionne pas
            else if (_x2 + move.X > _xMax || _y2 + move.Y > _yMax) return false;
            else return true;


            //if (0 <= view.Viewport.Left + move.X && view.Viewport.Left + move.X <= xMax / 2)
            //{
            //    if (0 <= view.Viewport.Left + move.X)
            //}
        }

        public void MouseWheel(object sender, MouseWheelEventArgs e)
        {
            float delta;
            delta = e.Delta;
            if (delta < 0)
            {
                _view.Zoom(1.06f);
                //_view.Center = new Vector2f(_view.Size.X / 2, _view.Size.Y / 2);
                //_window.SetView(_view);
            }
            else
            {
                _view.Zoom(0.94f);
                //_view.Center = new Vector2f(_view.Size.X / 2, _view.Size.Y / 2);
                //_window.SetView(_view);
            }
        }

        public void CheckClic(float x, float y)
        {
            if (_ctx.MenuState != 0)
            {
                if (CheckUI(x, y, _ctx.GameTime)) Console.WriteLine("ui");
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
            else if (_ui.CheckBuildingToBuild(x, y, _ctx._resourcesManager)) return true;
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

                //for (int i = 0; i < list.Count; i++)
                //{
                //    Console.WriteLine("Nom : {0} - Population : {1} - Date : {2}", list[i].Name, list[i].Population, list[i].Date);
                //}
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Add))
            {
                _view.Zoom(1.06f);
                //_view.Center = new Vector2f(_view.Size.X / 2, _view.Size.Y / 2);
                _window.SetView(_view);
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Subtract))
            {
                _view.Zoom(-1.06f);
                //_view.Center = new Vector2f(_view.Size.X / 2, _view.Size.Y / 2);
                _window.SetView(_view);
            }
        }

        internal View View => _view;
    }
}
