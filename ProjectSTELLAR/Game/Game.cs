using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace ProjectStellar
{
    public class Game : GameLoop
    {
        public const uint DEFAULT_WINDOW_WIDTH = 800;
        public const uint DEFAULT_WINDOW_HEIGHT = 600;
        public const string WINDOW_TITLE = "Project STELLAR";
        Sprite _backgroundSprite;
        Texture _backgroundTexture = new Texture("./resources/img/83504.png");
        int _state;
        Menu _menu;
        
        public Game(int state) : base(DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT, WINDOW_TITLE, Color.Green)
        {
            //RenderWindow _window = new RenderWindow(new VideoMode(800, 600), "Project Stellar");
            MenuState = state;
        }

        public override void LoadContent()
        {
            DebugUtility.LoadContent();
        }

        public override void Initialize()
        {
           if(MenuState ==0) _menu = new Menu(1280, 720);
            _backgroundSprite = new Sprite(_backgroundTexture);
        }

        public override void Update(GameTime gameTime)
        {
            if(MenuState == 0)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    _menu.Move(Keyboard.Key.Up);
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    _menu.Move(Keyboard.Key.Down);
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Return))
                {
                    if (_menu.SelectedItem == 0)
                    {
                        MenuState = 1;
                    }
                    else if (_menu.SelectedItem == 1)
                    {
                        Window.Close();
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            _backgroundSprite.Draw(Window, RenderStates.Default);
            if (MenuState == 0) _menu.Draw(Window);
            else if (MenuState == 1) Map.RenderGraphics(Window);
        }

        public int MenuState
        {
            get { return _state; }
            set { _state = value; }
        }
    }
}
