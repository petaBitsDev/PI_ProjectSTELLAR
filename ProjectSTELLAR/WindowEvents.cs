using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using ProjectStellar.Library;

namespace ProjectStellar
{
    public class WindowEvents
    {
        RenderWindow _window;
        Game _ctx;
        MapUI _mapUI;
        UI _ui;


        public WindowEvents(RenderWindow Window, Game Game)
        {
            _ctx = Game;
            _window = Window;
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

        public void CheckClic(float x, float y)
        {
            if (_ctx.MenuState != 0)
            {
                if (CheckMap(x, y)) Console.WriteLine("map");
                else if (CheckUI(x, y, _ctx.GameTime)) Console.WriteLine("ui");
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
