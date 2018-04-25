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
        public const uint DEFAULT_WINDOW_WIDTH = 1280;
        public const uint DEFAULT_WINDOW_HEIGHT = 720;
        public const string WINDOW_TITLE = "Project STELLAR";
        Sprite _backgroundSprite;
        Texture _backgroundTexture = new Texture("./resources/img/menuBG.png");
        public Texture[] _menuTextures = new Texture[4];
        public Texture[] _buildingsTextures = new Texture[4];
        public int _state;
        Menu _menu;
        uint _windowX;
        uint _windowY;
        Map _ctx;
        UI _ui;
        Font _font;

        public Game(int state, uint windowX, uint windowY, bool isFullscreen) : base(windowX, windowY, isFullscreen, WINDOW_TITLE, Color.Green)
        {
            //RenderWindow _window = new RenderWindow(new VideoMode(800, 600), "Project Stellar");
            MenuState = state;
            _windowX = windowX;
            _windowY = windowY;
        }

        public override void LoadContent()
        {
            DebugUtility.LoadContent();
            _menuTextures[0] = new Texture("./resources/img/menuPlay.png");
            _menuTextures[1] = new Texture("./resources/img/menuQuit.png");
            _menuTextures[2] = new Texture("./resources/img/menuPlayActif.png");
            _menuTextures[3] = new Texture("./resources/img/menuQuitActif.png");

            _buildingsTextures[0] = new Texture("./resources/img/fireStation.png");
            _buildingsTextures[1] = new Texture("./resources/img/hut.png");
            _buildingsTextures[2] = new Texture("./resources/img/flat.png");
            _buildingsTextures[3] = new Texture("./resources/img/house.png");

            _font = new Font("./resources/fonts/arial.ttf");
        }

        public override void Initialize()
        {
            _menu = new Menu(_windowX, _windowY, this);
            _backgroundSprite = new Sprite(_backgroundTexture);
            _ui = new UI();
        }

        public override void Update(GameTime gameTime)
        {
            if (_state == 0) _menu.CheckMouse(Window);
            else if (_state == 1); // game
        }

        public override void Draw(GameTime gameTime)
        {
            Map map = new Map(20, 20);
            MapUI mapUI = new MapUI(this, map, 20, 20);
            _backgroundSprite.Draw(Window, RenderStates.Default);
            if (MenuState == 0) _menu.Draw(Window);
            else if (MenuState == 1)
            {
                mapUI.RenderGraphics(Window);
                _ui.Draw(Window, _font, gameTime.InGameTime);
            }
        }

        public int MenuState
        {
            get { return _state; }
            set { _state = value; }
        }
    }
}
