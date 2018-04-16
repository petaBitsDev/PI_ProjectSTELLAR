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
        Texture _backgroundTexture = new Texture("./resources/img/83504.png");
        public Texture[] _menuTextures = new Texture[4];
        public int _state;
        Menu _menu;

        public Game() : base(DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT, WINDOW_TITLE, Color.Green)
        {

        }

        public override void LoadContent()
        {
            DebugUtility.LoadContent();
            _menuTextures[0] = new Texture("./resources/img/play.png");
            _menuTextures[1] = new Texture("./resources/img/exit.png");
            _menuTextures[2] = new Texture("./resources/img/play2.png");
            _menuTextures[3] = new Texture("./resources/img/exit2.png");
        }

        public override void Initialize()
        {
            _menu = new Menu(1280, 720, this);
            _backgroundSprite = new Sprite(_backgroundTexture);
        }

        public override void Update(GameTime gameTime)
        {
            _menu.CheckMouse(Window);

        }

        public override void Draw(GameTime gameTime)
        {
            _backgroundSprite.Draw(Window, RenderStates.Default);
            if (_state == 0) _menu.Draw(Window);
        }
    }
}
