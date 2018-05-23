﻿using System;
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
        Texture _backgroundTexture = new Texture("./resources/img/backg.png");
        public Texture[] _menuTextures = new Texture[8];
        public Texture[] _buildingsTextures = new Texture[4];
        public Texture[] _uiTextures = new Texture[20];
        int _state;
        Menu _menu;
        Resolution _resolution;
        internal Font _font;
        internal Map _map;
        public BuildingFactory _buildingFactory;
        public DrawUI _drawUI;
        ExperienceManager _experienceManager;
        internal ResourcesManager _resourcesManager;
        CityHelper _cityHelper;
        MapUI _mapUI;
        WindowEvents _windowEvents;
        bool _areResourcesUpdated;
        internal string _name = "test";
        View _view;
        Vector2f _center;

        public Game(int state, Resolution resolution, bool isFullscreen) : base(resolution, isFullscreen, WINDOW_TITLE, Color.Green)
        {
            MenuState = state;
            _resolution = resolution;
        }

        public override void LoadContent()
        {
            DebugUtility.LoadContent();
            _menuTextures[0] = new Texture("./resources/img/menuNewgame.png");
            _menuTextures[1] = new Texture("./resources/img/menuLoadgame.png");
            _menuTextures[2] = new Texture("./resources/img/menuQuit.png");
            _menuTextures[3] = new Texture("./resources/img/menuNewActif.png");
            _menuTextures[4] = new Texture("./resources/img/menuLoadActif.png");
            _menuTextures[5] = new Texture("./resources/img/menuQuitActif.png");
            _menuTextures[6] = new Texture("./resources/img/menuPlay.png");
            _menuTextures[7] = new Texture("./resources/img/menuPlayActif.png");

            _buildingsTextures[0] = new Texture("./resources/img/fireStation.png");
            _buildingsTextures[1] = new Texture("./resources/img/hut.png");
            _buildingsTextures[2] = new Texture("./resources/img/immeuble.png");
            _buildingsTextures[3] = new Texture("./resources/img/house.png");
            _buildingsTextures[4] = new Texture("./resources/img/powerPlant.png");
            _buildingsTextures[5] = new Texture("./resources/img/pumpingStation.png");
            _buildingsTextures[6] = new Texture("./resources/img/capitol.png");
            _buildingsTextures[7] = new Texture("./resources/img/capitol64.png");
            _buildingsTextures[8] = new Texture("./resources/img/fire-station.png");
            _buildingsTextures[9] = new Texture("./resources/img/hospital.png");
            _buildingsTextures[10] = new Texture("./resources/img/police.png");
            _buildingsTextures[11] = new Texture("./resources/img/observatory.png");
            _buildingsTextures[12] = new Texture("./resources/img/woodIndustry.png");
            _buildingsTextures[13] = new Texture("./resources/img/cave.png");
            _buildingsTextures[14] = new Texture("./resources/img/crucible.png");
            _buildingsTextures[15] = new Texture("./resources/img/warehouse.png");

            _uiTextures[0] = new Texture("./resources/img/play-button.png");
            _uiTextures[1] = new Texture("./resources/img/pause-symbol.png");
            _uiTextures[2] = new Texture("./resources/img/fast-forward.png");
            _uiTextures[3] = new Texture("./resources/img/crane.png");
            _uiTextures[4] = new Texture("./resources/img/trucking.png");
            _uiTextures[5] = new Texture("./resources/img/dollar.png");
            _uiTextures[6] = new Texture("./resources/img/radiation.png");
            _uiTextures[7] = new Texture("./resources/img/wood.png");
            _uiTextures[8] = new Texture("./resources/img/anvil.png");
            _uiTextures[9] = new Texture("./resources/img/rock.png");
            _uiTextures[10] = new Texture("./resources/img/drop.png");
            _uiTextures[11] = new Texture("./resources/img/light.png");
            _uiTextures[12] = new Texture("./resources/img/angry.png");
            _uiTextures[13] = new Texture("./resources/img/confused.png");
            _uiTextures[14] = new Texture("./resources/img/smile.png");
            _uiTextures[15] = new Texture("./resources/img/navbar.png");
            _uiTextures[16] = new Texture("./resources/img/ffWhite.png");
            _uiTextures[17] = new Texture("./resources/img/PauseButtonWhite.png");
            _uiTextures[18] = new Texture("./resources/img/PlayButtonWhite.png");
            _uiTextures[19] = new Texture("./resources/img/settings.png");

            _font = new Font("./resources/fonts/OrchestraofStrings.otf");
        }

        public override void Initialize(GameTime gameTime)
        {
            _backgroundSprite = new Sprite(_backgroundTexture);
            _map = new Map(30, 30);
            _resourcesManager = new ResourcesManager(_map);
            _buildingFactory = new BuildingFactory(_map, _resourcesManager);
            _experienceManager = new ExperienceManager(_resourcesManager);
            _cityHelper = new CityHelper(_map);
            _cityHelper.CreateListBuilding();

            _center = new Vector2f(_resolution.X / 2, _resolution.Y / 2);
            _view = new View(_center, new Vector2f(_resolution.X, _resolution.Y));
            _menu = new Menu(_resolution.X, _resolution.Y, this, _view);
            Window.SetView(_view);
            _windowEvents = new WindowEvents(Window, this, _resolution, _view);
            Window.MouseWheelMoved += _windowEvents.MouseWheel;
            //Window.MouseMoved += _windowEvents.MouseMoved;
            Window.Closed += _windowEvents.WindowClosed;
            Window.MouseButtonPressed += _windowEvents.MouseClicked;
            Window.KeyPressed += _windowEvents.KeyPressed;
        }

        public override void Update(GameTime gameTime)
        {

            if (_state == 0) _menu.CheckMouse(Window);
            else if (_state == 1)
            {
                if (gameTime.InGameTime.Minute == 00 && _areResourcesUpdated == false)
                {
                    _resourcesManager.NbResources["population"] += 10;
                    _experienceManager.CheckLevel();
                    //Console.WriteLine("--------------------------------------");
                    //Console.WriteLine("Pop: {0}", _resourcesManager.NbResources["population"]);
                    //Console.WriteLine("lvl : {0}", _experienceManager.CheckLevel());
                    //Console.WriteLine("{0}%", _experienceManager.GetPercentage());

                    _resourcesManager.UpdateResources();
                    _areResourcesUpdated = true;
                }
                else if (gameTime.InGameTime.Minute != 00 && _areResourcesUpdated == true) _areResourcesUpdated = false;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            _backgroundSprite.Draw(Window, RenderStates.Default);
            if (MenuState == 0) _menu.Draw(Window);
            else if (MenuState == 1)
            {
                if (_drawUI == null) _drawUI = new DrawUI(this, _map, 30, 30, _resolution, gameTime, _resourcesManager, _cityHelper.ListBuilding, _experienceManager);
                Window.Clear(Color.Black);
                _drawUI.RenderGraphics(Window, _font, GameTime, _resourcesManager);
                _windowEvents.MapUI = _drawUI.MapUI;
                _windowEvents.UI = _drawUI.UI;
            }
            else if (MenuState == 2)
            {
                //load game
            }
        }

        internal void LoadGame(SaveGame save)
        {
            GameTime = save.GameTime;
            _map = save.Map;
            _resourcesManager = save.ResourcesManager;
            _drawUI.UpdateMap(save.Map);
            _buildingFactory.Map = save.Map;
        }

        public int MenuState
        {
            get { return _state; }
            set { _state = value; }
        }
    }
}
