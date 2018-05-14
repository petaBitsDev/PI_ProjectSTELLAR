using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using ProjectStellar.Library;

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
        public Texture[] _uiTextures = new Texture[8];
        int _state;
        Menu _menu;
        Resolution _resolution;
        Font _font;
        Map _map;
        public BuildingFactory _buildingFactory;
        DrawUI _drawUI;
        ResourcesManager _resourcesManager;
        CityHelper _cityHelper;
        MapUI _mapUI;
        WindowEvents _windowEvents;

        public Game(int state, Resolution resolution, bool isFullscreen) : base(resolution, isFullscreen, WINDOW_TITLE, Color.Green)
        {
            MenuState = state;
            _resolution = resolution;
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
            _buildingsTextures[2] = new Texture("./resources/img/immeuble.png");
            _buildingsTextures[3] = new Texture("./resources/img/house.png");

            _uiTextures[0] = new Texture("./resources/img/play-button.png");
            _uiTextures[1] = new Texture("./resources/img/pause-symbol.png");
            _uiTextures[2] = new Texture("./resources/img/fast-forward.png");
            _uiTextures[3] = new Texture("./resources/img/crane.png");
            _uiTextures[4] = new Texture("./resources/img/trucking.png");
            _uiTextures[5] = new Texture("./resources/img/dollar.png");
            _uiTextures[6] = new Texture("./resources/img/radiation.png");
            _uiTextures[7] = new Texture("./resources/img/wood.png");

            _font = new Font("./resources/fonts/arial.ttf");
        }

        public override void Initialize()
        {
            _menu = new Menu(_resolution.X, _resolution.Y, this);
            _backgroundSprite = new Sprite(_backgroundTexture);
            _map = new Map(20, 20);
            _resourcesManager = new ResourcesManager(_map);
            _buildingFactory = new BuildingFactory(_map, _resourcesManager);
            _cityHelper = new CityHelper(_map);
            _cityHelper.CreateListBuilding();

            _windowEvents = new WindowEvents(Window, this);
            Window.Closed += _windowEvents.WindowClosed;
            Window.MouseButtonPressed += _windowEvents.MouseClicked;
        }

        public override void Update(GameTime gameTime)
        {
            if (_state == 0) _menu.CheckMouse(Window);
            else if (_state == 1)
            {
                if(gameTime.InGameTime.Minute == 00)
                {
                   // _resourcesManager.UpdateResources();
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {

            _backgroundSprite.Draw(Window, RenderStates.Default);
            if (MenuState == 0) _menu.Draw(Window);
            else if (MenuState == 1)
            {
                if (_drawUI == null) _drawUI = new DrawUI(this, _map, 20, 20, _resolution, gameTime, _resourcesManager, _cityHelper.ListBuilding);
                _drawUI.RenderGraphics(Window, _font);
                _windowEvents.MapUI = _drawUI.MapUI;
                _windowEvents.UI = _drawUI.UI;
            }
        }

        public int MenuState
        {
            get { return _state; }
            set { _state = value; }
        }
    }
}
