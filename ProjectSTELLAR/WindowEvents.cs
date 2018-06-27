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
            Vector2i pixelPos = Mouse.GetPosition(_window);
            Vector2f worldPos = _window.MapPixelToCoords(pixelPos, View);

            RectangleShape rec = new RectangleShape();
            rec.OutlineColor = new Color(Color.Transparent);
            rec.OutlineThickness = 3.0f;
            rec.FillColor = new Color(253, 254, 254);
            rec.Size = new Vector2f(32 * 8, 32 * 4);

            int posX = Mouse.GetPosition(_window).X;
            int posY = Mouse.GetPosition(_window).Y;

            if (_ctx.MenuState == 1)
            {
                if (!Equals(_mapUI, null))
                {
                    _xMax = _mapUI._x2y2.X;
                    _yMax = _mapUI._x2y2.Y;
                    if (!Equals(_ui.MouseSprite, null))
                    {
                        _ui.MouseSprite.Position = new Vector2f(Mouse.GetPosition(_window).X, Mouse.GetPosition(_window).Y);
                    }
                }
            }

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
            //In Game
            if (_ctx.MenuState == 1)
            {
                if (delta < 0)
                {
                    _view.Zoom(1.06f);
                }
                else
                {
                    _view.Zoom(0.94f);
                }
            }
            //Load Menu
            else if (_ctx.MenuState == 2)
            {
                _ctx._menuLoadGame.Scroll(delta);
            }
        }

        public void MouseClicked(object sender, EventArgs e)
        {
            // Jeu
            if (_ctx.MenuState == 1)
            {
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    if (_ui.SettingsSelected)
                    {
                        _ctx._map.ChosenBuilding = null;
                        _window.SetMouseCursorVisible(true);
                        _ui.MouseSprite = null;
                        if (_ui.SelectedItem == 0)
                        {
                            SaveGame save = new SaveGame(_ctx._name, _ctx._map, _ctx.GameTime, _ctx._resourcesManager, _ctx._experienceManager, _ctx._satisfactionManager);
                            Save.SaveGame(save, _ctx._name);
                            //Console.WriteLine("Saved");

                            _ctx.GameTime.TimeScale = 60f;
                            _ui.SettingsSelected = false;
                        }
                        else if (_ui.SelectedItem == 1)
                        {
                            _ui.SettingsSelected = false;
                            _ctx.MenuState = 0;
                        }
                        else if (_ui.SelectedItem == 2) _window.Close();
                    }

                    Vector2i pixelPos = Mouse.GetPosition(_window);
                    Vector2f worldPos = _window.MapPixelToCoords(pixelPos, _view);

                    if (CheckUI(Mouse.GetPosition(_window).X, Mouse.GetPosition(_window).Y, _ctx.GameTime)) Console.WriteLine("ui");
                    else if (_mapUI.CheckMap(worldPos.X, worldPos.Y, _window, _ctx._font)) Console.WriteLine("map");
                }

                if (Mouse.IsButtonPressed(Mouse.Button.Right))
                {
                    _window.SetMouseCursorVisible(true);
                    _ui.MouseSprite = null;
                    _ui.Map.ChosenBuilding = null;
                }
            }
            // Menu principal
            else if (_ctx.MenuState == 0 && Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                _ctx._menu.CheckMouse(_window);
                Console.WriteLine("Principal");
            }
            // Menu chargement de sauvegarde
            else if (_ctx.MenuState == 2 && Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                _ctx._menuLoadGame.CheckMouse(Mouse.GetPosition(_window).X, Mouse.GetPosition(_window).Y, _window);
                Console.WriteLine("Load");
            }
            // Menu création nouvelle partie
            else if (_ctx.MenuState == 3 && Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                 _ctx.NewGame.CheckButtons(Mouse.GetPosition(_window).X, Mouse.GetPosition(_window).Y);
                Console.WriteLine("New");
            }
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
            if (_ctx.MenuState == 1)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                {
                    SaveGame save = new SaveGame(_ctx._name, _ctx._map, _ctx.GameTime, _ctx._resourcesManager, _ctx._experienceManager, _ctx._satisfactionManager);
                    Save.SaveGame(save, _ctx._name);
                    //Console.WriteLine("Saved");
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.L))
                {
                    SaveGame save = Save.LoadGame(_ctx._name);
                    _ctx.LoadGame(save);
                    //Console.WriteLine("Loaded");
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
                    _view.Zoom(0.94f);
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Subtract))
                {
                    _view.Zoom(1.06f);
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                {
                    _ui.DrawInGameMenu(_window, _font, _ctx.GameTime);
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                {
                    _ctx._resourcesManager.NbResources["nbPeople"] += 500;
                }
            }
            else if (_ctx.MenuState == 3)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.BackSpace))
                {
                    if (_ctx.NewGame.Name.Length > 0)
                        _ctx.NewGame.Name = _ctx.NewGame.Name.Remove(_ctx.NewGame.Name.Length - 1);
                }
            }
        }

        internal View View => _view;

        public void TextEntered(object sender, TextEventArgs e)
        {
            if (_ctx.MenuState == 3)
            {
                if ((e.Unicode[0] > 30 && (e.Unicode[0] < 128 || e.Unicode[0] > 159)))
                {
                    _ctx.NewGame.Name += e.Unicode;
                }
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                if (!_ui.SettingsSelected)
                    _ui.SettingsSelected = true;
                else
                {
                    _ui.SettingsSelected = false;
                    _ctx.GameTime.TimeScale = 60f;
                }
            }
        }
    }
}