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

        public WindowEvents(RenderWindow Window, Game Game, Resolution resolution, View view)
        {
            _ctx = Game;
            _window = Window;
            _font = _ctx._font;
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
                for(int i = 0; i < 20; i++)
                {
                    for(int j = 0; j < 20; j++)
                    {
                        if (_ctx._drawUI.MapUI.MapSprites[j, 20].GetGlobalBounds().Contains(Mouse.GetPosition(_window).X, Mouse.GetPosition(_window).Y))
                        {
                            _view.Center = new Vector2f(currentCenter.X, currentCenter.Y);
                            _window.SetView(_view);
                        }
                    }
                }
                _view.Center = new Vector2f(currentCenter.X + 50, currentCenter.Y);
                _view.Move(new Vector2f(50, 0));
                _window.SetView(_view);
            }
            else if (posX == 0)
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (_mapUI.MapSprites[j, 0].GetGlobalBounds().Contains(Mouse.GetPosition(_window).X, Mouse.GetPosition(_window).Y))
                        {
                            _view.Center = new Vector2f(currentCenter.X, currentCenter.Y);
                            _window.SetView(_view);
                        }
                    }
                }

                _view.Center = new Vector2f(currentCenter.X - 50, currentCenter.Y);
                _view.Move(new Vector2f(-50, 0));
                _window.SetView(_view);
            }
            else if (posY == 0)
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (_mapUI.MapSprites[0, i].GetGlobalBounds().Contains(Mouse.GetPosition(_window).X, Mouse.GetPosition(_window).Y))
                        {
                            _view.Center = new Vector2f(currentCenter.X, currentCenter.Y);
                            _window.SetView(_view);
                        }
                    }
                }

                _view.Center = new Vector2f(currentCenter.X, currentCenter.Y - 50);
                _view.Move(new Vector2f(0, -50));
                _window.SetView(_view);
            }
            else if (posY == (_resolution.Y - 1))
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (_mapUI.MapSprites[20, i].GetGlobalBounds().Contains(Mouse.GetPosition(_window).X, Mouse.GetPosition(_window).Y))
                        {
                            _view.Center = new Vector2f(currentCenter.X, currentCenter.Y);
                            _window.SetView(_view);
                        }
                    }
                }

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
                if (CheckMap(x, y, _window, _ctx._font)) Console.WriteLine("map");
                else if (CheckUI(x, y, _ctx.GameTime)) Console.WriteLine("ui");
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
        }
    }
}
