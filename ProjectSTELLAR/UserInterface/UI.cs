using System;
using System.Globalization;
using System.Collections.Generic;
using System.Threading;
using SFML.Graphics;
using SFML.System;
using ProjectStellar.Library;
using SFML.Window;

namespace ProjectStellar
{
    public class UI
    {
        CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
        Game _ctx;
        DrawUI _drawUIctx;
        Map _mapCtx;
        GameTime _gameTime;
        Resolution _resolution;
        BuildingChoice[] _buildingChoices;
        ResourcesManager _resourcesManager;
        ExperienceManager _experienceManager;
        List<SpaceMenu> _menus = new List<SpaceMenu>();
        FireType _fireType;
        View _view;
        ExplorationShips _ship;
        DateTime _undisposedTime;
        Dictionary<Building, RectangleShape> _recs = new Dictionary<Building, RectangleShape>();
        List<Sprite> _spriteMenu = new List<Sprite>();
        List<Sprite> _spriteMenuActif = new List<Sprite>();
        RectangleShape[] _availabilities = new RectangleShape[4];
        Dictionary<Sprite, String> _sprites;
        Dictionary<Sprite, BuildingType> _buildingTypeSprites;
        Dictionary<Sprite, BuildingType> _tab1Sprite;
        Dictionary<Sprite, BuildingType> _tab2Sprite;
        Dictionary<Sprite, BuildingType> _tab3Sprite;
        Building _activeSpaceStation;
        Sprite _spriteSelected;
        Sprite _play;
        Sprite _pause;
        Sprite _fastForward;
        Sprite _navbarSprite;
        Sprite _exitButton;
        Sprite _settingsButton;
        Sprite _coinSprite;
        Sprite _woodSprite;
        Sprite _pollutionSprite;
        Sprite _buildButton;
        CircleShape buildCircle;
        RectangleShape _habitationTab;
        RectangleShape _publicTab;
        RectangleShape _ressourcesTab;
        Sprite _destroyButton;
        Sprite _flatSprite;
        Sprite _hutSprite;
        Sprite _houseSprite;
        Sprite _waterSprite;
        Sprite _electricitySprite;
        Sprite _metalSprite;
        Sprite _rockSprite;
        Sprite _smileSprite;
        Sprite _angrySprite;
        Sprite _confusedSprite;
        Sprite _powerPlant;
        Sprite _pumpingStation;
        Sprite _cityHall;
        Sprite _fireStation;
        Sprite _hospital;
        Sprite _police;
        Sprite _spaceStation;
        Sprite _sawMill;
        Sprite _metalMine;
        Sprite _oreMine;
        Sprite _warehouse;
        Sprite _people;
        Sprite _lockSprite;
        Sprite validation;
        Sprite woodChosen;
        Sprite wood;
        Sprite metal;
        Sprite metalChosen;
        Sprite rock;
        Sprite rockChosen;
        Sprite _shop;
        Sprite _factory;
        Sprite _park;
        Sprite _satisfaction;
        Sprite _next;
        Sprite _return;
        Sprite _return2;
        RectangleShape _expBar;
        RectangleShape _expBarFilled;
        RectangleShape _rectangleTimeBar;
        readonly Sprite[] _menu = new Sprite[4];
        readonly Sprite[] _menuActif = new Sprite[4];
        Sprite _saveButton;
        Sprite _saveButtonActive;
        Sprite _quitButton;
        Sprite _quitButtonActive;
        Sprite _returnButton;
        Sprite _returnButtonActive;
        Sprite _mouseSprite;
        Sprite _sendButton;
        Sprite _sendActifButton;
        Sprite _meteors;
        RectangleShape _musicSlider;
        RectangleShape _musicCursor;
        Sprite _helpButton;
        Sprite _helpButtonActive;
        Text _musicText;
        Text _SFXText;
        RectangleShape _SFXSlider;
        RectangleShape _SFXCursor;
        Map _map;

        uint _width;
        uint _height;
        uint _boxSize = 32;
        private bool _buildSelected;
        private bool _habitationTabSelected;
        private bool _publicTabSelected;
        private bool _ressourcesTabSelected;
        private bool _destroySelected;
        private bool _tab1Selected;
        private bool _tab2Selected;
        private bool _tab3Selected;
        private string _buildingSelected;
        bool _settingsSelected;
        bool _exitSelected;
        int _selectedIndex;
        bool _helpSelected;
        bool _hovering;
        private bool _menuON;
        List<bool> _tab;
        int _tabActif;
        int _choiceMade;
        string _resource;
        bool _sent;
        int _nbDestroyedBuildings;
        Clock _meteorWait;

        public UI(Game ctx, Resolution resolution, Map context, DrawUI drawUI, uint width, uint height, GameTime gameTime, ResourcesManager resourcesManager, ExperienceManager experienceManager, FireType fireType)
        {
            _sprites = new Dictionary<Sprite, string>();
            _buildingTypeSprites = new Dictionary<Sprite, BuildingType>();
            _tab1Sprite = new Dictionary<Sprite, BuildingType>();
            _tab2Sprite = new Dictionary<Sprite, BuildingType>();
            _tab3Sprite = new Dictionary<Sprite, BuildingType>();
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
            _ctx = ctx;
            _drawUIctx = drawUI;
            _mapCtx = context;
            _height = height;
            _width = width;
            _resolution = resolution;
            _drawUIctx = drawUI;
            _buildSelected = false;
            _gameTime = gameTime;
            _buildingChoices = new BuildingChoice[16];
            _resourcesManager = resourcesManager;
            _fireType = fireType;
            _tab1Selected = true;
            _tab2Selected = false;
            _tab3Selected = false;
            _experienceManager = experienceManager;
            _tab = new List<bool>();
            _tab.Add(false);
            _tab.Add(false);
            _tab.Add(false);
            _tab.Add(false);
            _tabActif = 0;

            _map = context;

            

            //TIME BAR
            _play = new Sprite(_ctx._uiTextures[18])
            {
                Position = new Vector2f(30, _resolution.Y - 2 * 15 - 10 + 7),
                Scale = new Vector2f(0.5f, 0.5f),
                Color = new Color(Color.Black)
            };

            _pause = new Sprite(_ctx._uiTextures[17])
            {
                Position = new Vector2f(15, _resolution.Y - 2 * 15 - 10 + 7),
                Scale = new Vector2f(0.5f, 0.5f),
                Color = new Color(Color.Black)
            };

            _fastForward = new Sprite(_ctx._uiTextures[16])
            {
                Position = new Vector2f(50, _resolution.Y - 2 * 15 - 10 + 7),
                Scale = new Vector2f(0.5f, 0.5f),
                Color = new Color(Color.Black)
            };

            _rectangleTimeBar = new RectangleShape()
            {
                FillColor = Color.Transparent,
                Size = new Vector2f(_resolution.X - _boxSize * 4 + 10, _boxSize),
                Position = new Vector2f(0, _resolution.Y - _boxSize)
            };

            //UI BUTTONS
            _buildButton = new Sprite(_ctx._uiTextures[3]);
            _destroyButton = new Sprite(_ctx._uiTextures[33]);

            _settingsButton = new Sprite(_ctx._uiTextures[21])
            {
                Scale = new Vector2f(0.8f, 0.8f)
            };
            _exitButton = new Sprite(_ctx._uiTextures[22]);

            _saveButton = new Sprite(_ctx._menuTextures[2])
            {
                Position = new Vector2f(_resolution.X / 2 - _boxSize * 7, _boxSize * 2),
                Scale = new Vector2f(0.3f, 0.3f)
            };
            _menu[0] = _saveButton;

            _saveButtonActive = new Sprite(_ctx._menuTextures[7])
            {
                Position = new Vector2f(_resolution.X / 2 - _boxSize * 7, _boxSize * 2),
                Scale = new Vector2f(0.3f, 0.3f)
            };
            _menuActif[0] = _saveButtonActive;

            _returnButton = new Sprite(_ctx._menuTextures[4])
            {
                Position = new Vector2f(_resolution.X / 2 - _boxSize * 7, _boxSize * 6),
                Scale = new Vector2f(0.3f, 0.3f)
            };
            _menu[1] = _returnButton;

            _returnButtonActive = new Sprite(_ctx._menuTextures[9])
            {
                Position = new Vector2f(_resolution.X / 2 - _boxSize * 7, _boxSize * 6),
                Scale = new Vector2f(0.3f, 0.3f)
            };
            _menuActif[1] = _returnButtonActive;

            _helpButton = new Sprite(_ctx._menuTextures[13])
            {
                Position = new Vector2f(_resolution.X / 2 - _boxSize * 7, _boxSize * 10),
                Scale = new Vector2f(0.3f, 0.3f)
            };
            _menu[2] = _helpButton;

            _helpButtonActive = new Sprite(_ctx._menuTextures[14])
            {

                Position = new Vector2f(_resolution.X / 2 - _boxSize * 7, _boxSize * 10),
                Scale = new Vector2f(0.3f, 0.3f)
            };
            _menuActif[2] = _helpButtonActive;

            _quitButton = new Sprite(_ctx._menuTextures[3])
            {
                Position = new Vector2f(_resolution.X / 2 - _boxSize * 7, _boxSize * 14),
                Scale = new Vector2f(0.3f, 0.3f)
            };
            _menu[3] = _quitButton;

            _quitButtonActive = new Sprite(_ctx._menuTextures[8])
            {
                Position = new Vector2f(_resolution.X / 2 - _boxSize * 7, _boxSize * 14),
                Scale = new Vector2f(0.3f, 0.3f)
            };
            _menuActif[3] = _quitButtonActive;

            _sendButton = new Sprite(_ctx._uiTextures[24]);
            _sendActifButton = new Sprite(_ctx._uiTextures[25]);

            _return = new Sprite(_ctx._menuTextures[16]);
            _next = new Sprite(_ctx._menuTextures[15]);
            _return2 = new Sprite(_ctx._menuTextures[17]);
       
            //XP BAR
            _expBar = new RectangleShape()
            {
                Size = new Vector2f(200-25, 30),
                Position = new Vector2f(resolution.X - 200, _resolution.Y - 2 * 15 - 20 -31),
                OutlineThickness = 1.0f,
                OutlineColor = new Color(Color.Black)
            };

            _expBarFilled = new RectangleShape(_expBar)
            {
                FillColor = Color.Blue
            };

            //RESOURCES
            _coinSprite = new Sprite(_ctx._uiTextures[5])
            {
                Position = new Vector2f(150 + 15, _resolution.Y - 2 * 15 - 8),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _woodSprite = new Sprite(_ctx._uiTextures[7])
            {
                Position = new Vector2f(350 + 45 + 5 + 5, _resolution.Y - 2 * 15 - 10 + 1),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _rockSprite = new Sprite(_ctx._uiTextures[9])
            {
                Position = new Vector2f(350 + 45 + 5 + 5+ 110, _resolution.Y - 2 * 15 - 10 + 1),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _metalSprite = new Sprite(_ctx._uiTextures[8])
            {
                Position = new Vector2f(350 + 45 + 5 + 5 + 110 + 110, _resolution.Y - 2 * 15 - 10 + 1),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _electricitySprite = new Sprite(_ctx._uiTextures[11])
            {
                Position = new Vector2f(350 + 45 + 5 + 5 + 110 + 110 + 110, _resolution.Y - 2 * 15 - 10 + 1),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _waterSprite = new Sprite(_ctx._uiTextures[10])
            {
                Position = new Vector2f(350 + 45 + 5 + 5 + 110 + 110 + 110 + 110, _resolution.Y - 2 * 15 - 10 + 1),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _pollutionSprite = new Sprite(_ctx._uiTextures[6])
            {
                Position = new Vector2f(350 + 45 + 5 + 5 + 110 + 110 + 110 + 110 + 110, _resolution.Y - 2 * 15 - 10 + 1),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _people = new Sprite(_ctx._uiTextures[23])
            {
                Position = new Vector2f(350, _resolution.Y - 2 * 15 - 8),
                Scale = new Vector2f(0.4f,0.4f),
                Color = new Color(71,153,74)
            };

            _satisfaction = new Sprite(_ctx._uiTextures[12])
            {
                Position = new Vector2f(350 - 30, _resolution.Y - 2 * 15 - 8),
                Scale = new Vector2f(0.4f, 0.4f)
            };

            _angrySprite = new Sprite(_ctx._uiTextures[12]);
            _smileSprite = new Sprite(_ctx._uiTextures[14]);
            _confusedSprite = new Sprite(_ctx._uiTextures[13]);
            _navbarSprite = new Sprite(_ctx._uiTextures[15]);
            validation = new Sprite(_ctx._uiTextures[32]);
            woodChosen = new Sprite(_ctx._uiTextures[29]);
            wood = new Sprite(_ctx._uiTextures[28]);
            metal = new Sprite(_ctx._uiTextures[26]);
            metalChosen = new Sprite(_ctx._uiTextures[27]);
            rock = new Sprite(_ctx._uiTextures[30]);
            rockChosen = new Sprite(_ctx._uiTextures[31]);
            _spriteMenu.Add(wood);
            _spriteMenu.Add(metal);
            _spriteMenu.Add(rock);
            _spriteMenuActif.Add(woodChosen);
            _spriteMenuActif.Add(metalChosen);
            _spriteMenuActif.Add(rockChosen);

            //HABITATIONS
            _hutSprite = new Sprite(_ctx._buildingsTextures[1])
            {
                Position = new Vector2f(300, _resolution.Y - 2 * 50 - 45)
            };

            _houseSprite = new Sprite(_ctx._buildingsTextures[3])
            {
                Position = new Vector2f(_hutSprite.Position.X + _hutSprite.GetGlobalBounds().Width*2 + _boxSize, _hutSprite.Position.Y)

            };

            _flatSprite = new Sprite(_ctx._buildingsTextures[2])
            {
                Position = new Vector2f(_houseSprite.Position.X + _hutSprite.GetGlobalBounds().Width * 2 + _boxSize, _houseSprite.Position.Y),
                Scale = new Vector2f(0.5f, 0.5f)
            };


            //PUBLIC BUILDINGS
            _cityHall = new Sprite(_ctx._buildingsTextures[21])
            {
                Position = new Vector2f(300, _resolution.Y - 2 * 50 - 45)
            };

            _fireStation = new Sprite(_ctx._buildingsTextures[8])
            {
                Position = new Vector2f(_cityHall.Position.X + _cityHall.GetGlobalBounds().Width + _boxSize, _cityHall.Position.Y)
            };

            _hospital = new Sprite(_ctx._buildingsTextures[20])
            {
                Position = new Vector2f(_fireStation.Position.X + _fireStation.GetGlobalBounds().Width + _boxSize, _fireStation.Position.Y)
            };

            _police = new Sprite(_ctx._buildingsTextures[10])
            {
                Position = new Vector2f(_hospital.Position.X + _hospital.GetGlobalBounds().Width + _boxSize, _hospital.Position.Y)
            };

            _spaceStation = new Sprite(_ctx._buildingsTextures[22])
            {
                Position = new Vector2f(_police.Position.X + _police.GetGlobalBounds().Width + _boxSize, _police.Position.Y)
            };

            _warehouse = new Sprite(_ctx._buildingsTextures[15])
            {
                Position = new Vector2f(_spaceStation.Position.X + _spaceStation.GetGlobalBounds().Width + _boxSize, _spaceStation.Position.Y)
            };
           
            _park = new Sprite(_ctx._buildingsTextures[19])
            {
                Position = new Vector2f(_warehouse.Position.X + _warehouse.GetGlobalBounds().Width + _boxSize, _warehouse.Position.Y)
            };

            //RESOURCES BUILDINGS
            _sawMill = new Sprite(_ctx._buildingsTextures[12])
            {
                Position = new Vector2f(300, _resolution.Y - 2 * 50 - 45)
            };

            _oreMine = new Sprite(_ctx._buildingsTextures[13])
            {
                Position = new Vector2f(_sawMill.Position.X + _sawMill.GetGlobalBounds().Width + _boxSize, _sawMill.Position.Y)
            };

            _metalMine = new Sprite(_ctx._buildingsTextures[14])
            {
                Position = new Vector2f(_oreMine.Position.X + _oreMine.GetGlobalBounds().Width + _boxSize, _oreMine.Position.Y)
            };

            _powerPlant = new Sprite(_ctx._buildingsTextures[4])
            {
                Position = new Vector2f(_metalMine.Position.X + _metalMine.GetGlobalBounds().Width + _boxSize, _metalMine.Position.Y)
            };

            _pumpingStation = new Sprite(_ctx._buildingsTextures[5])
            {
                Position = new Vector2f(_powerPlant.Position.X + _powerPlant.GetGlobalBounds().Width + _boxSize, _powerPlant.Position.Y)
            };

            _shop = new Sprite(_ctx._buildingsTextures[17])
            {
                Position = new Vector2f(_pumpingStation.Position.X + _pumpingStation.GetGlobalBounds().Width + _boxSize, _pumpingStation.Position.Y)
            };

            _factory = new Sprite(_ctx._buildingsTextures[18])
            {
                Position = new Vector2f(_shop.Position.X + _shop.GetGlobalBounds().Width + _boxSize, _shop.Position.Y)
            };

            _lockSprite = new Sprite(_ctx._buildingsTextures[16])
            {
                //Scale = new Vector2f(0.5f, 0.5f)
            };

            _tab1Sprite.Add(_hutSprite, _mapCtx.BuildingTypes[5]);
            _tab1Sprite.Add(_houseSprite, _mapCtx.BuildingTypes[4]);
            _tab1Sprite.Add(_flatSprite, _mapCtx.BuildingTypes[2]);

            // publique
            _tab2Sprite.Add(_cityHall, _mapCtx.BuildingTypes[0]);
            _tab2Sprite.Add(_fireStation, _mapCtx.BuildingTypes[1]);
            _tab2Sprite.Add(_hospital, _mapCtx.BuildingTypes[3]);
            _tab2Sprite.Add(_police, _mapCtx.BuildingTypes[8]);
            _tab2Sprite.Add(_spaceStation, _mapCtx.BuildingTypes[12]);
            _tab2Sprite.Add(_warehouse, _mapCtx.BuildingTypes[13]);
            _tab2Sprite.Add(_park, _mapCtx.BuildingTypes[16]);

            // ressources
            _tab3Sprite.Add(_sawMill, _mapCtx.BuildingTypes[11]);
            _tab3Sprite.Add(_oreMine, _mapCtx.BuildingTypes[7]);
            _tab3Sprite.Add(_powerPlant, _mapCtx.BuildingTypes[9]);
            _tab3Sprite.Add(_metalMine, _mapCtx.BuildingTypes[6]);
            _tab3Sprite.Add(_pumpingStation, _mapCtx.BuildingTypes[10]);
            _tab3Sprite.Add(_shop, _mapCtx.BuildingTypes[15]);
            _tab3Sprite.Add(_factory, _mapCtx.BuildingTypes[14]);

            _mouseSprite = new Sprite();
            _mouseSprite = null;

            _meteors = new Sprite(_ctx._uiTextures[34]);

            _musicSlider = new RectangleShape()
            {
                Size = new Vector2f(400, 30),
                FillColor = new Color(48, 48, 48),
                OutlineColor = Color.White,
                OutlineThickness = 2
            };
            _musicSlider.Position = new Vector2f((resolution.X / 2) - (_musicSlider.Size.X / 2), resolution.Y / 5 * 4);

            _musicCursor = new RectangleShape()
            {
                Size = new Vector2f(2, _musicSlider.Size.Y),
                FillColor = Color.Yellow
            };
            _musicCursor.Position = new Vector2f(_musicSlider.Position.X + (_musicSlider.Size.X / 2) - (_musicCursor.Size.X / 2), _musicSlider.Position.Y);

            _musicText = new Text("Music Volume", _ctx._font);
            _musicText.CharacterSize = 30;
            _musicText.Position = new Vector2f(_musicSlider.Position.X - 200, _musicSlider.Position.Y - 5);

            _SFXSlider = new RectangleShape(_musicSlider);
            _SFXSlider.Position = new Vector2f(_SFXSlider.Position.X, _SFXSlider.Position.Y + 40);

            _SFXCursor = new RectangleShape(_musicCursor);
            _SFXCursor.Position = new Vector2f(_SFXCursor.Position.X, _SFXSlider.Position.Y);

            _SFXText = new Text("SFX  Volume", _ctx._font);
            _SFXText.CharacterSize = 30;
            _SFXText.Position = new Vector2f(_SFXSlider.Position.X - 200, _SFXSlider.Position.Y - 5);

        }

        internal bool IsTab1Active
        {
            get { return _tab1Selected; }
            set { _tab1Selected = value; }
        }

        internal bool IsTab2Active
        {
            get { return _tab2Selected; }
            set { _tab2Selected = value; }
        }

        internal bool IsTab3Active
        {
            get { return _tab3Selected; }
            set { _tab3Selected = value; }
        }
        //public uint Width => _width;

        //public uint Height => _height;

        /// <summary>
        /// Draws the resources bar.
        /// </summary>
        /// <param name="window">The window.</param>
        //public void DrawResourcesBar(RenderWindow window, Font font, Dictionary<string, int> resources, float satisfaction)
        //{
        //    RectangleShape rec = new RectangleShape();
        //    rec.FillColor = new Color(30, 40, 40);
        //    rec.Size = new Vector2f(_boxSize * 5, _resolution.Y);
        //    rec.Position = new Vector2f(_resolution.X - _boxSize * 4 - 5, 0);

        //    rec.Draw(window, RenderStates.Default);

        //    //Displays Coins Sprite and number of coins
        //    _coinSprite.Draw(window, RenderStates.Default);
        //    Text nbCoins = new Text(resources["coins"].ToString(), font);
        //    nbCoins.Position = new Vector2f(_resolution.X - _boxSize * 2 - 17, _boxSize * 3 + 2);
        //    nbCoins.Color = Color.White;
        //    nbCoins.CharacterSize = 16;
        //    nbCoins.Style = Text.Styles.Bold;
        //    nbCoins.Draw(window, RenderStates.Default);

        //    //Displays Wood Sprite and number of wood
        //    _woodSprite.Draw(window, RenderStates.Default);
        //    Text nbWood = new Text(resources["wood"].ToString(), font);
        //    nbWood.Position = new Vector2f(_resolution.X - _boxSize * 2 - 17, _boxSize * 4 + 2);
        //    nbWood.Color = Color.White;
        //    nbWood.CharacterSize = 16;
        //    nbWood.Style = Text.Styles.Bold;
        //    nbWood.Draw(window, RenderStates.Default);

        //    _rockSprite.Draw(window, RenderStates.Default);
        //    Text nbRock = new Text(resources["rock"].ToString(), font);
        //    nbRock.Position = new Vector2f(_resolution.X - _boxSize * 2 - 17, _boxSize * 5 + 2);
        //    nbRock.Color = Color.White;
        //    nbRock.CharacterSize = 16;
        //    nbRock.Style = Text.Styles.Bold;
        //    nbRock.Draw(window, RenderStates.Default);

        //    _metalSprite.Draw(window, RenderStates.Default);
        //    Text nbMetal = new Text(resources["metal"].ToString(), font);
        //    nbMetal.Position = new Vector2f(_resolution.X - _boxSize * 2 - 17, _boxSize * 6 + 2);
        //    nbMetal.Color = Color.White;
        //    nbMetal.CharacterSize = 16;
        //    nbMetal.Style = Text.Styles.Bold;
        //    nbMetal.Draw(window, RenderStates.Default);

        //    _electricitySprite.Draw(window, RenderStates.Default);
        //    Text nbElec = new Text(resources["electricity"].ToString(), font);
        //    nbElec.Position = new Vector2f(_resolution.X - _boxSize * 2 - 17, _boxSize * 7 + 2);
        //    nbElec.Color = Color.White;
        //    nbElec.CharacterSize = 16;
        //    nbElec.Style = Text.Styles.Bold;
        //    nbElec.Draw(window, RenderStates.Default);

        //    _waterSprite.Draw(window, RenderStates.Default);
        //    Text nbWater = new Text(resources["water"].ToString(), font);
        //    nbWater.Position = new Vector2f(_resolution.X - _boxSize * 2 - 17, _boxSize * 8 + 2);
        //    nbWater.Color = Color.White;
        //    nbWater.CharacterSize = 16;
        //    nbWater.Style = Text.Styles.Bold;
        //    nbWater.Draw(window, RenderStates.Default);

        //    //Displays Pollution Sprite and number
        //    _pollutionSprite.Draw(window, RenderStates.Default);
        //    Text nbPollution = new Text(resources["pollution"].ToString(), font);
        //    nbPollution.Position = new Vector2f(_resolution.X - _boxSize * 2 - 17, _boxSize * 9 + 2);
        //    nbPollution.Color = Color.White;
        //    nbPollution.CharacterSize = 16;
        //    nbPollution.Style = Text.Styles.Bold;
        //    nbPollution.Draw(window, RenderStates.Default);

        //    //Displays Population and check if hovering
        //    _people.Draw(window, RenderStates.Default);
        //    if (_people.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
        //    {
        //        Text nbPeople = new Text(resources["nbPeople"].ToString(), font);
        //        nbPeople.Position = new Vector2f(_resolution.X - _boxSize * 2 - 8, _boxSize * 12 + 2);
        //        nbPeople.Color = Color.White;
        //        nbPeople.CharacterSize = 16;
        //        nbPeople.Style = Text.Styles.Bold;
        //        nbPeople.Draw(window, RenderStates.Default);
        //    }

        //    //Displays Satisfaction and check if hovering
        //    if (satisfaction < 0.3f) _satisfaction.Texture = _ctx._uiTextures[12]; //Angry
        //    else if (satisfaction > 0.7f)
        //    {
        //        _satisfaction.Texture = _ctx._uiTextures[14]; //Smile
        //        //Console.WriteLine("HAPPY");
        //    }
        //    else _satisfaction.Texture = _ctx._uiTextures[13]; //Confused

        //    _satisfaction.Draw(window, RenderStates.Default);

        //    if (_satisfaction.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
        //    {
        //        Text textSatisfaction = new Text(satisfaction * 100 + "%", font);
        //        //textSatisfaction.Position = new Vector2f(_resolution.X - _boxSize * 2 - 8, _boxSize * 12 + 2);
        //        textSatisfaction.Position = new Vector2f(_satisfaction.Position.X + 15, _satisfaction.Position.Y + 64);
        //        textSatisfaction.Color = Color.White;
        //        textSatisfaction.CharacterSize = 16;
        //        textSatisfaction.Style = Text.Styles.Bold;
        //        textSatisfaction.Draw(window, RenderStates.Default);
        //    }
        //    //window.Draw(rec);
        //}

        //public void DrawTimeBar(RenderWindow window, GameTime gameTime, Font font)
        //{
        //    RectangleShape rec = new RectangleShape();
        //    rec.FillColor = new Color(30, 40, 40);
        //    rec.Size = new Vector2f(_resolution.X, _boxSize * 2);
        //    rec.Position = new Vector2f(0, _resolution.Y - _boxSize - 10);
            
        //    Text Time = new Text(gameTime.InGameTime.ToString("dd/MM/yyyy HH:mm"), font)
        //    {
        //        Position = new Vector2f(0, _resolution.Y - 32),
        //        Color = Color.White,
        //        CharacterSize = 23,
        //        Style = Text.Styles.Bold
        //    };

        //    rec.Draw(window, RenderStates.Default);
        //    _rectangleTimeBar.Draw(window, RenderStates.Default);
        //    _pause.Draw(window, RenderStates.Default);
        //    _play.Draw(window, RenderStates.Default);
        //    _fastForward.Draw(window, RenderStates.Default);

        //    Time.Draw(window, RenderStates.Default);
        //}

        //public void DrawBuildButton(RenderWindow window, Font font)
        //{
        //    RectangleShape rec = new RectangleShape();
        //    rec.OutlineColor = new Color(Color.Black);
        //    rec.OutlineThickness = 3.0f;
        //    rec.FillColor = new Color(30, 40, 40);
        //    rec.Size = new Vector2f((_boxSize * 12) - 4, _boxSize * 6);
        //    rec.Position = new Vector2f(_resolution.X - _boxSize * 12, _resolution.Y / 2 - _boxSize * 2);

        //    RectangleShape onglet1 = new RectangleShape();
        //    onglet1.OutlineColor = new Color(Color.Blue);
        //    onglet1.OutlineThickness = 3.0f;
        //    onglet1.FillColor = new Color(Color.Black);
        //    onglet1.Size = new Vector2f(((_boxSize * 12) / 3) - 6, (_boxSize * 6) / 6);
        //    onglet1.Position = new Vector2f(_resolution.X - _boxSize * 12, _resolution.Y / 2 - _boxSize * 2);

        //    Text text = new Text("Habitation", font);
        //    text.Color = new Color(Color.White);
        //    text.CharacterSize = 16;
        //    text.Position = new Vector2f(_resolution.X - _boxSize * 12 + 5, _resolution.Y / 2 - _boxSize * 2);
        //    text.Style = Text.Styles.Bold;

        //    RectangleShape onglet2 = new RectangleShape();
        //    onglet2.OutlineColor = new Color(Color.Red);
        //    onglet2.OutlineThickness = 3.0f;
        //    onglet2.FillColor = new Color(Color.Black);
        //    onglet2.Size = new Vector2f(((_boxSize * 12) / 3) - 6, (_boxSize * 6) / 6);
        //    onglet2.Position = new Vector2f(_resolution.X - _boxSize * 8, _resolution.Y / 2 - _boxSize * 2);

        //    Text publicBuilding = new Text("Public", font);
        //    publicBuilding.Color = new Color(Color.White);
        //    publicBuilding.CharacterSize = 16;
        //    publicBuilding.Position = new Vector2f(_resolution.X - _boxSize * 8 + 5, _resolution.Y / 2 - _boxSize * 2);
        //    publicBuilding.Style = Text.Styles.Bold;

        //    RectangleShape onglet3 = new RectangleShape();
        //    onglet3.OutlineColor = new Color(Color.Yellow);
        //    onglet3.OutlineThickness = 3.0f;
        //    onglet3.FillColor = new Color(Color.Black);
        //    onglet3.Size = new Vector2f(((_boxSize * 12) / 3) - 6, (_boxSize * 6) / 6);
        //    onglet3.Position = new Vector2f(_resolution.X - _boxSize * 4, _resolution.Y / 2 - _boxSize * 2);

        //    Text resourcesBuilding = new Text("Resources", font);
        //    resourcesBuilding.Color = new Color(Color.White);
        //    resourcesBuilding.CharacterSize = 16;
        //    resourcesBuilding.Position = new Vector2f(_resolution.X - _boxSize * 4 + 5, _resolution.Y / 2 - _boxSize * 2);
        //    resourcesBuilding.Style = Text.Styles.Bold;

        //    _buildButton.Draw(window, RenderStates.Default);

        //    if (_buildSelected)
        //    {
        //        if (rec.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
        //        {
        //            int j = 0;

        //            //window.Draw(rec);
        //            window.Draw(onglet1);
        //            window.Draw(onglet2);
        //            window.Draw(onglet3);
        //            window.Draw(text);

        //            window.Draw(publicBuilding);
        //            window.Draw(resourcesBuilding);

        //            if (onglet1.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
        //            {
        //                _tab1Selected = true;
        //                _tab2Selected = false;
        //                _tab3Selected = false;
        //            }
        //            else if (onglet2.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
        //            {

        //                _tab1Selected = false;
        //                _tab2Selected = true;
        //                _tab3Selected = false;
        //            }
        //            else if (onglet3.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
        //            {
        //                _tab1Selected = false;
        //                _tab2Selected = false;
        //                _tab3Selected = true;
        //            }
        //            DrawBuildingNeeds(window, font);

        //            DrawBuildingChoices(window, font);
        //        }
        //        else _buildSelected = false;
        //    }
        //}


        //public void DrawDestroyButton(RenderWindow window)
        //{
        //    _destroyButton.Draw(window, RenderStates.Default);
        //}

        public bool CheckBuildSelected(RenderWindow window)
        {
            if (_buildButton.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y) && _buildSelected == false)
            {
                _buildSelected = true;
                _destroySelected = false;
                return true;
            } else if (_buildButton.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y) && _buildSelected == true)
            {
                _buildSelected = false;
            }
            return false;
        }

        public bool CheckTabSelected(RenderWindow window)
        {
            if (_habitationTab.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
            {
                _habitationTabSelected = true;
                _publicTabSelected = false;
                _ressourcesTabSelected = false;
            }
            else if (_publicTab.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
            {
                _publicTabSelected = true;
                _habitationTabSelected = false;
                _ressourcesTabSelected = false;
            }
            else if (_ressourcesTab.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
            {
                _publicTabSelected = false;
                _habitationTabSelected = false;
                _ressourcesTabSelected = true;
            }
            return false;
        }

        public bool CheckDestroySelected(RenderWindow window)
        {
            if (_destroyButton.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
            {
                window.SetMouseCursorVisible(false);
                _mouseSprite = new Sprite(_ctx._uiTextures[33]);
                _mouseSprite.Scale = new Vector2f(0.5f, 0.5f);
                _destroySelected = true;
                return true;
            }
            return false;
        }

        public bool CheckTimeBar(float x, float y, GameTime gameTime)
        {
            if (_pause.GetGlobalBounds().Contains(x, y))
            {
                gameTime.TimeScale = 0;
            }
            else if (_play.GetGlobalBounds().Contains(x, y))
            {
                gameTime.TimeScale = 60;
            }
            else if (_fastForward.GetGlobalBounds().Contains(x, y))
            {
                gameTime.TimeScale += 100;
            }
            else return false;

            return true;
        }

        private void DrawBuildingNeeds(RenderWindow window, Font font)
        {
            RectangleShape rec = new RectangleShape
            {
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                FillColor = new Color(Color.White),
                Size = new Vector2f(250, 90)
            };
            rec.Position = new Vector2f(_habitationTab.Position.X + _habitationTab.Size.X + 1, _resolution.Y - 2 * 50 - 50 - 20 - rec.Size.Y - 1);

            if (_buildingSelected != null && _buildingSelected != "") 
            {
                Text text = new Text(_buildingSelected, font)
                {
                    Position = new Vector2f(rec.Position.X + 10, rec.Position.Y),
                    Color = Color.Black,
                    CharacterSize = 18,
                    Style = Text.Styles.Bold
                };

                _buildingTypeSprites.TryGetValue(_spriteSelected, out BuildingType building);

                if(building != null)
                {
                    window.Draw(rec);

                    Text woodNeeds = new Text("Wood cost : " + building.Wood, font);
                    woodNeeds.Position = new Vector2f(rec.Position.X + 10, text.Position.Y + text.CharacterSize);
                    woodNeeds.Color = Color.Black;
                    woodNeeds.CharacterSize = 15;

                    Text rockNeeds = new Text("Rock cost : " + building.Rock, font);
                    rockNeeds.Position = new Vector2f(rec.Position.X + 10,woodNeeds.Position.Y + woodNeeds.CharacterSize);
                    rockNeeds.CharacterSize = 15;
                    rockNeeds.Color = Color.Black;

                    Text metalNeeds = new Text("Metal cost : " + building.Metal, font);
                    metalNeeds.Position = new Vector2f(rec.Position.X + 10, rockNeeds.Position.Y + rockNeeds.CharacterSize);
                    metalNeeds.CharacterSize = 15;
                    metalNeeds.Color = Color.Black;

                    Text coinNeeds = new Text("Coin cost : " + building.Coin, font);
                    coinNeeds.Position = new Vector2f(rec.Position.X + 10, metalNeeds.Position.Y + metalNeeds.CharacterSize);
                    coinNeeds.CharacterSize = 15;
                    coinNeeds.Color = Color.Black;
                    
                    window.Draw(woodNeeds);
                    window.Draw(rockNeeds);
                    window.Draw(metalNeeds);
                    window.Draw(coinNeeds);
                    window.Draw(text);
                }
            }
        }

        private void DrawBuildingChoices(RenderWindow window, Font font)
        {
            _sprites.Clear();
            _buildingTypeSprites.Clear();

            _buildingTypeSprites.Add(_hutSprite, _mapCtx.BuildingTypes[5]);
            _buildingTypeSprites.Add(_houseSprite, _mapCtx.BuildingTypes[4]);
            _buildingTypeSprites.Add(_flatSprite, _mapCtx.BuildingTypes[2]);
            _buildingTypeSprites.Add(_cityHall, _mapCtx.BuildingTypes[0]);
            _buildingTypeSprites.Add(_fireStation, _mapCtx.BuildingTypes[1]);
            _buildingTypeSprites.Add(_hospital, _mapCtx.BuildingTypes[3]);
            _buildingTypeSprites.Add(_police, _mapCtx.BuildingTypes[8]);
            _buildingTypeSprites.Add(_spaceStation, _mapCtx.BuildingTypes[12]);
            _buildingTypeSprites.Add(_warehouse, _mapCtx.BuildingTypes[13]);
            _buildingTypeSprites.Add(_sawMill, _mapCtx.BuildingTypes[11]);
            _buildingTypeSprites.Add(_oreMine, _mapCtx.BuildingTypes[7]);
            _buildingTypeSprites.Add(_powerPlant, _mapCtx.BuildingTypes[9]);
            _buildingTypeSprites.Add(_metalMine, _mapCtx.BuildingTypes[6]);
            _buildingTypeSprites.Add(_pumpingStation, _mapCtx.BuildingTypes[10]);
            _buildingTypeSprites.Add(_shop, _mapCtx.BuildingTypes[15]);
            _buildingTypeSprites.Add(_factory, _mapCtx.BuildingTypes[14]);
            _buildingTypeSprites.Add(_park, _mapCtx.BuildingTypes[16]);

            if (_habitationTabSelected == true)
            {

                _hutSprite.Scale = new Vector2f(2.0f, 2.0f);
                _hutSprite.Draw(window, RenderStates.Default);

                _houseSprite.Scale = new Vector2f(2.0f, 2.0f);
                _houseSprite.Draw(window, RenderStates.Default);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[4].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, (uint)_houseSprite.Position.X, (uint)_houseSprite.Position.Y, 0, 0, 64, 64);

                _drawUIctx.RenderSprite(_flatSprite, window, (uint)_flatSprite.Position.X, (uint)_flatSprite.Position.Y, 0, 0, 64, 64);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[2].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, (uint)_flatSprite.Position.X, (uint)_flatSprite.Position.Y, 0, 0, 64, 64);

                _sprites.Add(_hutSprite, "HUT");
                _sprites.Add(_houseSprite, "HOUSE");
                _sprites.Add(_flatSprite, "FLAT");
            }
            else if (_publicTabSelected == true)
            {
                _drawUIctx.RenderSprite(_cityHall, window, (uint)_cityHall.Position.X, (uint)_cityHall.Position.Y, 0, 0, 96, 64);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[0].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, (uint)_cityHall.Position.X, (uint)_cityHall.Position.Y, 0, 0, 64, 64);
                
                _fireStation.Draw(window, RenderStates.Default);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[1].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, (uint)_fireStation.Position.X, (uint)_fireStation.Position.Y, 0, 0, 64, 64);

                _drawUIctx.RenderSprite(_hospital, window, (uint)_hospital.Position.X, (uint)_hospital.Position.Y, 0, 0, 96, 64);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[3].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, (uint)_hospital.Position.X, (uint)_hospital.Position.Y, 0, 0, 64, 64);
                
                _police.Draw(window, RenderStates.Default);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[8].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, (uint)_police.Position.X, (uint)_police.Position.Y, 0, 0, 64, 64);

                _drawUIctx.RenderSprite(_spaceStation, window, (uint)_spaceStation.Position.X, (uint)_spaceStation.Position.Y, 0, 0, 96, 64);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[12].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, (uint)_spaceStation.Position.X, (uint)_spaceStation.Position.Y, 0, 0, 64, 64);

                _warehouse.Draw(window, RenderStates.Default);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[13].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, (uint)_warehouse.Position.X, (uint)_warehouse.Position.Y, 0, 0, 64, 64);

                _park.Scale = new Vector2f(2.0f, 2.0f);
                _park.Draw(window, RenderStates.Default);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[16].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, (uint)_park.Position.X, (uint)_park.Position.Y, 0, 0, 64, 64);

                _sprites.Add(_cityHall, "CITY HALL");
                _sprites.Add(_fireStation, "FIRE STATION");
                _sprites.Add(_hospital, "HOSPITAL");
                _sprites.Add(_police, "POLICE DEPARTMENT");
                _sprites.Add(_spaceStation, "SPACE STATION");
                _sprites.Add(_warehouse, "WAREHOUSE");
                _sprites.Add(_park, "PARK");
            }
            else if (_ressourcesTabSelected == true)
            {
                _sawMill.Draw(window, RenderStates.Default);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[11].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, (uint)_sawMill.Position.X, (uint)_sawMill.Position.Y, 0, 0, 64, 64);

                _oreMine.Draw(window, RenderStates.Default);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[7].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, (uint)_oreMine.Position.X, (uint)_oreMine.Position.Y, 0, 0, 64, 64);

                _metalMine.Draw(window, RenderStates.Default);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[6].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, (uint)_metalMine.Position.X, (uint)_metalMine.Position.Y, 0, 0, 64, 64);

                _powerPlant.Draw(window, RenderStates.Default);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[9].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, (uint)_powerPlant.Position.X, (uint)_powerPlant.Position.Y, 0, 0, 64, 64);

                _pumpingStation.Draw(window, RenderStates.Default);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[10].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, (uint)_pumpingStation.Position.X, (uint)_pumpingStation.Position.Y, 0, 0, 64, 64);

                _shop.Draw(window, RenderStates.Default);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[15].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, (uint)_shop.Position.X, (uint)_shop.Position.Y, 0, 0, 64, 64);

                _factory.Draw(window, RenderStates.Default);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[14].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, (uint)_factory.Position.X, (uint)_factory.Position.Y, 0, 0, 64, 64);

                _sprites.Add(_sawMill, "SAWMILL");
                _sprites.Add(_oreMine, "ORE MINE");
                _sprites.Add(_metalMine, "METAL MINE");
                _sprites.Add(_powerPlant, "POWER PLANT");
                _sprites.Add(_pumpingStation, "PUMPING STATION");
                _sprites.Add(_shop, "SHOP");
                _sprites.Add(_factory, "FACTORY");
            }

            foreach (Sprite sprite in _sprites.Keys)
            {
                if (sprite.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    _sprites.TryGetValue(sprite, out _buildingSelected);
                    _spriteSelected = sprite;
                    DrawBuildingNeeds(window,font);
                }
            }
        }

        public void DrawExperience(RenderWindow window, Font font)
        {
            _expBarFilled.Size = new Vector2f(_expBar.Size.X * ((float)_experienceManager.GetPercentage() / 100f), _expBar.Size.Y);
            _expBar.Draw(window, RenderStates.Default);
            _expBarFilled.Draw(window, RenderStates.Default);

            Text level = new Text("Level : "+ _experienceManager.Level.ToString(), font);
            level.Position = new Vector2f(_resolution.X - 32 * 15, _resolution.Y - 32);
            level.CharacterSize = 25;
            level.Style = Text.Styles.Bold;
            level.Draw(window, RenderStates.Default);
        }

        internal void DrawBuildingInformations(RenderWindow window, Font font, Building building)
        {
            RectangleShape rec = new RectangleShape();
            rec.OutlineColor = new Color(Color.Black);
            rec.OutlineThickness = 3.0f;
            rec.FillColor = new Color(Color.White);
            rec.Size = new Vector2f(32 * 8, 32 * 4);

            if ((building.X * 32 - 32 * 6) >= 0)
            {
                rec.Position = new Vector2f((building.Y * 32), (building.X * 32 - 32 * 7));
            }
            else
            {
                rec.Position = new Vector2f(building.Y * 32, building.X * 32 + 32 * 7);
            }
            rec.Draw(window, RenderStates.Default);
            foreach (KeyValuePair<Sprite, BuildingType> buildingType in BuildingTypeSprites)
            {
                for (int i = 0; i < _mapCtx.BuildingTypes.Count; i++)
                {
                    if (_mapCtx.BuildingTypes[i].GetType().Equals(building.Type.GetType()))
                    {
                        Text water = new Text("Water consomation : ", font);
                        water.Color = new Color(52, 152, 219);
                        water.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 10);
                        water.CharacterSize = 17;
                        water.Draw(window, RenderStates.Default);

                        Text nbWater = new Text(_mapCtx.BuildingTypes[i].Water + "/H", font);
                        nbWater.Position = new Vector2f(rec.Position.X + 32 * 6, rec.Position.Y + 10);
                        nbWater.Color = new Color(52, 152, 219);
                        nbWater.CharacterSize = 14;
                        nbWater.Style = Text.Styles.Bold;
                        nbWater.Draw(window, RenderStates.Default);
                        
                        Text electricity = new Text("Electricity consomation : ", font);
                        electricity.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 50);
                        electricity.Color = new Color(236, 193, 5);
                        electricity.CharacterSize = 17;
                        electricity.Draw(window, RenderStates.Default);

                        Text nbElectricity = new Text(_mapCtx.BuildingTypes[i].Electricity + "/H", font);
                        nbElectricity.Position = new Vector2f(rec.Position.X + 32 * 6, rec.Position.Y + 50);
                        nbElectricity.CharacterSize = 14;
                        nbElectricity.Color = new Color(236, 193, 5);
                        nbElectricity.Style = Text.Styles.Bold;
                        nbElectricity.Draw(window, RenderStates.Default);
                        
                        if (_mapCtx.BuildingTypes[i].Cost > 0)
                        {
                            Text charges = new Text("Charges : ", font);
                            charges.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 80);
                            charges.Color = new Color(203, 67, 53);
                            charges.CharacterSize = 17;
                            charges.Draw(window, RenderStates.Default);

                            Text nbCharges = new Text(_mapCtx.BuildingTypes[i].Cost + "/H", font);
                            nbCharges.Position = new Vector2f(rec.Position.X + 32 * 6, rec.Position.Y + 80);
                            nbCharges.CharacterSize = 14;
                            nbCharges.Color = new Color(203, 67, 53);
                            nbCharges.Style = Text.Styles.Bold;
                            nbCharges.Draw(window, RenderStates.Default);
                        }
                        else
                        {
                            Text charges = new Text("Taxes : ", font);
                            charges.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 80);
                            charges.Color = new Color(68, 198, 14);
                            charges.CharacterSize = 17;
                            charges.Draw(window, RenderStates.Default);

                            Text nbCharges = new Text(_mapCtx.BuildingTypes[i].Cost + "/H", font);
                            nbCharges.Position = new Vector2f(rec.Position.X + 32 * 6, rec.Position.Y + 80);
                            nbCharges.CharacterSize = 14;
                            nbCharges.Color = new Color(68, 198, 14);
                            nbCharges.Style = Text.Styles.Bold;
                            nbCharges.Draw(window, RenderStates.Default);
                        }
                    }
                }
            }
        }

        public bool CheckBuildingToBuild(Window window, ResourcesManager resources)
        {
            if (_buildSelected == false) return false;

            if(_habitationTabSelected)
            {
                foreach(Sprite sprite in _tab1Sprite.Keys)
                {
                    if(sprite.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y))
                    {
                        if(Mouse.IsButtonPressed(Mouse.Button.Left))
                        {
                            _buildingTypeSprites.TryGetValue(sprite, out BuildingType building);
                            if (!resources.CheckResourcesNeeded(building)) return false;
                            else if(building.UnlockingLevel > _experienceManager.Level)
                            {
                                return false;
                            }
                            else
                            {
                                _mapCtx.ChosenBuilding = building;
                                //window.SetMouseCursorVisible(false);
                                _mouseSprite = new Sprite(sprite);
                                _mouseSprite.Position = new Vector2f(Mouse.GetPosition(window).X + 64, Mouse.GetPosition(window).Y + 64);
                                return true;
                            }
                        }
                    }
                }
            }
            else if (_publicTabSelected)
            {
                foreach (Sprite sprite in _tab2Sprite.Keys)
                {
                    if (sprite.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y))
                    {
                        _buildingTypeSprites.TryGetValue(sprite, out BuildingType building);
                        if (!resources.CheckResourcesNeeded(building)) return false;
                        else if (building.UnlockingLevel > _experienceManager.Level)
                        {
                            return false;
                        }
                        else
                        {
                            _mapCtx.ChosenBuilding = building;
                            //window.SetMouseCursorVisible(false);
                            _mouseSprite = new Sprite(sprite);
                            _mouseSprite.Position = new Vector2f(Mouse.GetPosition(window).X + 64, Mouse.GetPosition(window).Y + 64);
                            return true;
                        }
                    }
                }
            }
            else if(_ressourcesTabSelected)
            {
                foreach (Sprite sprite in _tab3Sprite.Keys)
                {
                    if (sprite.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y))
                    {
                        _buildingTypeSprites.TryGetValue(sprite, out BuildingType building);
                        if (!resources.CheckResourcesNeeded(building)) return false;
                        else if (building.UnlockingLevel > _experienceManager.Level)
                        {
                            return false;
                        }
                        else
                        {
                            _mapCtx.ChosenBuilding = building;
                            //window.SetMouseCursorVisible(false);
                            _mouseSprite = new Sprite(sprite);
                            _mouseSprite.Position = new Vector2f(Mouse.GetPosition(window).X + 64, Mouse.GetPosition(window).Y + 64);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool DestroySelected
        {
            get { return _destroySelected; }
            set { _destroySelected = value; }
        }

        public bool SettingsSelected
        {
            get { return _settingsSelected; }
            set { _settingsSelected = value; }
        }

        public bool ExitSelected
        {
            get { return _exitSelected; }
            set { _exitSelected = value; }
        }

        public Map Map
        {
            get { return _mapCtx; }
            set { _mapCtx = value; }
        }

        public ResourcesManager ResourcesManager
        {
            get { return _resourcesManager; }
            set { _resourcesManager = value; }
        }

        public ExperienceManager ExperienceManager
        {
            get { return _experienceManager; }
            set { _experienceManager = value; }
        }

        public Dictionary<Sprite, BuildingType> BuildingTypeSprites => _buildingTypeSprites;
        public Dictionary<Sprite, BuildingType> Tab1Sprite => _tab1Sprite;
        public Dictionary<Sprite, BuildingType> Tab2Sprite => _tab2Sprite;
        public Dictionary<Sprite, BuildingType> Tab3Sprite => _tab3Sprite;


        public void DrawInGameMenu (RenderWindow window, Font font, GameTime gameTime)
        {
            _settingsButton.Position = new Vector2f(0, 0);
            _settingsButton.Draw(window, RenderStates.Default);

            RectangleShape rec = new RectangleShape();
            rec.Size = new Vector2f(_resolution.X - _boxSize * 8, _resolution.Y - _boxSize * 5);
            rec.Position = new Vector2f(_boxSize * 3, _boxSize * 2);
            rec.FillColor = new Color(30, 30, 40);

            //_musicCursor.Position.X = _musicSlider.Position.X + (_musicSlider.Size.X * _ctx.SoundManager.MusicVolume / 100) - (_musicCursor.Size.X / 2);


            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                if (_settingsButton.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    SettingsSelected = true;
                }
            }

            if(_settingsSelected)
            {
                gameTime.TimeScale = 0f;

                rec.Draw(window, RenderStates.Default);
                _exitButton.Position = new Vector2f(rec.Position.X, rec.Position.Y);
                _exitButton.Draw(window, RenderStates.Default);

                ExitSelected = false;
                _hovering = false;

                for (int i = 0; i < 4; i++)
                {
                    _menu[i].Draw(window, RenderStates.Default);

                    if (_menu[i].GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                    {
                        _hovering = true;
                        _menu[i] = _menuActif[i];
                        SelectedItem = i;
                    }
                }

                if (_hovering == false)
                {
                    if (SelectedItem != -1)
                    {
                        _menu[0] = _saveButton;
                        _menu[1] = _returnButton;
                        _menu[2] = _helpButton;
                        _menu[3] = _quitButton;
                    }
                    SelectedItem = -1;
                }

                if (_exitButton.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    if (Mouse.IsButtonPressed(Mouse.Button.Left)) ExitSelected = true;
                }
                if (ExitSelected)
                {
                    gameTime.TimeScale = 60f;
                    SettingsSelected = false;
                }
                _musicCursor.Position = new Vector2f(_musicSlider.Position.X + (_musicSlider.Size.X * _ctx.SoundManager.MusicVolume / 100) - (_musicCursor.Size.X / 2), _musicCursor.Position.Y);
                _SFXCursor.Position = new Vector2f(_SFXSlider.Position.X + (_SFXSlider.Size.X * _ctx.SoundManager.SFXVolume / 100) - (_SFXCursor.Size.X / 2), _SFXCursor.Position.Y);

                _musicSlider.Draw(window, RenderStates.Default);
                _musicCursor.Draw(window, RenderStates.Default);
                _musicText.Draw(window, RenderStates.Default);

                _SFXSlider.Draw(window, RenderStates.Default);
                _SFXCursor.Draw(window, RenderStates.Default);
                _SFXText.Draw(window, RenderStates.Default);
            }
        }

        public void DrawHelp(RenderWindow window, GameTime gameTime)
        {

            RectangleShape rec = new RectangleShape();
            rec.Size = new Vector2f(_resolution.X - _boxSize * 8, _resolution.Y - _boxSize * 5);
            rec.Position = new Vector2f(_boxSize * 3, _boxSize * 2);
            rec.FillColor = new Color(30, 30, 40);

            _exitButton.Position = new Vector2f(rec.Position.X * 11, rec.Position.Y);
            _exitButton.Scale = new Vector2f(0.8f, 0.8f);

            _next.Position = new Vector2f(rec.Position.X * 11, rec.Position.Y * 9.2f);
            _next.Color = new Color(Color.White);
             _return2.Position = new Vector2f(rec.Position.X * 11.1f, rec.Position.Y * 9.2f);

            _return.Position = new Vector2f(rec.Position.X, rec.Position.Y * 9.2f);


            Console.WriteLine(_ctx.MenuState);
            string intro = "PROJECT : STELLAR  \n   But du jeu : ";
            string goal = "La planète terre à été détruite. Pour donner une nouvelle chance à l'humanité vous avez la \n chance de pouvoir coloniser une nouvelle planète. Faites grandir votre population dans un \n nouvel environnement sain où personne ne manque de rien.";
            string howToPlayIntro = "   Comment jouer : ";
            string howToPlay = "Le jeu se compose de 3 types de batiments : \n    - Batiments d'habitation \n    - Batiments public \n    - Batiments de ressources,\n \n Vous retrouverez ces batiments dans l'onglet construction en bas à gauche de votre écran.\n Pour construire ces batiments vous aurez besoin de ressources. Les ressources sont au \n nombres de 3 : \n    - Bois \n    - Pierre \n    - Metal \n \n Vous commencez le jeu avec un certains nombre de ressources. Par la suite pour en \n produire vous avez deux solutions.\n La première solution permet la production de ressources à long terme. Il s'agit de la pose \n de batiments de type ressources. Attention pour stocker vos ressources vous aurez \n besoin d'entrepots. Vous trouverez ces entrepots dans les batiments de type public.\n Ils sont disponibles dès le debut de partie.\n La deuxième solution est d'aller chercher des ressources grace aux stations spatials que \n vous obtenez plus tard dans le jeu. Le fonctionnement des stations spatial est simple. Il\n vous suffit de cliquer sur l'une d'elles. Vous pouvez alors choisir quelle ressources vous \n souhaitez aller chercher et combien de vaisseau vous souhaitez envoyer.";
            string page2 = "Laisser le temps s'écouler et vos entrepots se remplissent comme par magie \n \n En debut de partie vous devez poser des batiments d'habitation dans le but d'augmenter la \n population de votre ville et donc votre experience. Plus vos habitants sont heureux, c'est à\n dire la satisfaction proche des 100%, plus la population augmente vite.\n La satisfaction se trouve sur la menu, c'est le petit visage vert, orange ou rouge. \n \n Les élèments modifiant la satisfactions sont : \n    - La pollution \n    - La production d'eau \n    - La production d'électricité \n    - La présence de batiments de services publiques sur votre map \n    - Si vos feux, crimes, maladies sont résolus à tant \n    - Une production de marchandise suffisante pour satisfaire vos magasins et un nombre\n     de magasins surffisant pour satisfaire vos habitants \n \n Plus votre niveau augmente plus vous debloquez de batiments.\n A partir du niveau 5 vous debloquez la mairie.\n Une fois posée la mairie vous permet de debloquer d'autres batiments publics.\n De plus des evenements de type maladie, crime et feu commencent à apparaitre dans votre\n ville vous devez avoir sufisament d'hopitaux, casernes, station de polices pour que leurs\n vehicules puissent couvrir toute votre ville.\n\n Mais ce n'est pas tout, faites attentions aux chutes de météorites. Elles detruiront certains\n de vos batiments. Faites particulierement attention aux \n batiments de ressources et aux entrepots pour ne pas vous retrouvez avec des habitants \n insatisfaits et une ville déserte.";
            Text Intro = new Text(intro, _ctx.FontHelp)
            {
                CharacterSize = 20,
                Color = new Color(Color.White),
                Style = Text.Styles.Bold,
                Position = new Vector2f(rec.Position.X + 32, rec.Position.Y + 10)
            };
            Text Goal = new Text(goal, _ctx.FontHelp)
            {
                CharacterSize = 14,
                Color = new Color(Color.White),
                Style = Text.Styles.Bold,
                Position = new Vector2f(rec.Position.X + 64, rec.Position.Y + 70)
            };

            Text HowToPlayIntro = new Text(howToPlayIntro, _ctx.FontHelp)
            {
                CharacterSize = 20,
                Color = new Color(Color.White),
                Style = Text.Styles.Bold,
                Position = new Vector2f(rec.Position.X + 32, rec.Position.Y + 140)
            };

            Text HowToPlay = new Text(howToPlay, _ctx.FontHelp)
            {
                CharacterSize = 14,
                Color = new Color(Color.White),
                Style = Text.Styles.Bold,
                Position = new Vector2f(rec.Position.X + 64, rec.Position.Y + 190)
            };

            Text Page2 = new Text(page2, _ctx.FontHelp)
            {
                CharacterSize = 14,
                Color = new Color(Color.White),
                Style = Text.Styles.Bold,
                Position = new Vector2f(rec.Position.X + 64, rec.Position.Y + 70)
            };
            if (_ctx.MenuState == 4)
            {
                rec.Draw(window, RenderStates.Default);
                gameTime.TimeScale = 0f;
                Intro.Draw(window, RenderStates.Default);
                Goal.Draw(window, RenderStates.Default);
                HowToPlayIntro.Draw(window, RenderStates.Default);
                HowToPlay.Draw(window, RenderStates.Default);
                _exitButton.Draw(window, RenderStates.Default);
                _next.Draw(window, RenderStates.Default);
                if (_next.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    if (Mouse.IsButtonPressed(Mouse.Button.Left)) _ctx.MenuState = 5;
                  

                }

            }
             if (_ctx.MenuState == 5)
            {
                rec.Draw(window, RenderStates.Default);
                _exitButton.Draw(window, RenderStates.Default);
                Page2.Draw(window, RenderStates.Default);
                _return2.Draw(window, RenderStates.Default);
                _return.Draw(window, RenderStates.Default);
              
            }

            if (_exitButton.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
            {
                if (Mouse.IsButtonPressed(Mouse.Button.Left)) ExitSelected = true;
            }
            if (ExitSelected)
            {
                gameTime.TimeScale = 60f;
                SettingsSelected = false;
                HelpSelected = false;
                _ctx.MenuState = 1;
            }

         

      

           
            }

        public View test => _view;
        public bool HelpSelected
        {
            get { return _helpSelected; }
            set { _helpSelected = value; }
        }
        public int SelectedItem
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value; }
        }

        public void UpdateBuildingTabs()
        {
            _tab1Sprite.Clear();
            _tab2Sprite.Clear();
            _tab3Sprite.Clear();

            _tab1Sprite.Add(_hutSprite, _mapCtx.BuildingTypes[5]);
            _tab1Sprite.Add(_houseSprite, _mapCtx.BuildingTypes[4]);
            _tab1Sprite.Add(_flatSprite, _mapCtx.BuildingTypes[2]);

            _tab2Sprite.Add(_cityHall, _mapCtx.BuildingTypes[0]);
            _tab2Sprite.Add(_fireStation, _mapCtx.BuildingTypes[1]);
            _tab2Sprite.Add(_hospital, _mapCtx.BuildingTypes[3]);
            _tab2Sprite.Add(_police, _mapCtx.BuildingTypes[8]);
            _tab2Sprite.Add(_spaceStation, _mapCtx.BuildingTypes[12]);
            _tab2Sprite.Add(_warehouse, _mapCtx.BuildingTypes[13]);

            _tab3Sprite.Add(_sawMill, _mapCtx.BuildingTypes[11]);
            _tab3Sprite.Add(_oreMine, _mapCtx.BuildingTypes[7]);
            _tab3Sprite.Add(_powerPlant, _mapCtx.BuildingTypes[9]);
            _tab3Sprite.Add(_metalMine, _mapCtx.BuildingTypes[6]);
            _tab3Sprite.Add(_pumpingStation, _mapCtx.BuildingTypes[10]);
        }

        public void DrawMouseCursor(RenderWindow window)
        {
            if (!Equals(_mouseSprite, null))
            {
                _mouseSprite.Scale = new Vector2f(1f, 1f);
                _mouseSprite.Draw(window, RenderStates.Default);
            }
        }

        public void DrawSpaceStationUI(RenderWindow window, Font font, int posX, int posY, Building building, int index)
        {
            if (_menus[index].IsOn)
            {
                _menus[index].Rec.Position = new Vector2f((float)building.SpritePosition.Y * 32, (float)building.SpritePosition.X * 32);
                _menus[index].Rec.Draw(window, RenderStates.Default);

                _menus[index].RedCross.Position = new Vector2f(_menus[index].Rec.Position.X - 32, _menus[index].Rec.Position.Y);
                _menus[index].RedCross.Scale = new Vector2f(0.5f, 0.5f);
                _menus[index].RedCross.Draw(window, RenderStates.Default);
                
                for(int a = 0; a < _menus.Count; a++)
                {
                    if(a == index)
                    {
                        if (_menus[a].RedCross.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                        {
                            if (Mouse.IsButtonPressed(Mouse.Button.Left))
                            {
                                _menus[a].IsOn = false;
                            }
                        }
                    }
                }

                _menus[index].Tabs[0].Position = new Vector2f(_menus[index].Rec.Position.X, _menus[index].Rec.Position.Y);
                _menus[index].Tabs[1].Position = new Vector2f(_menus[index].Rec.Position.X + 32 * 3, _menus[index].Rec.Position.Y);
                _menus[index].Tabs[2].Position = new Vector2f(_menus[index].Rec.Position.X + 32 * 6, _menus[index].Rec.Position.Y);
                _menus[index].Tabs[3].Position = new Vector2f(_menus[index].Rec.Position.X + 32 * 9, _menus[index].Rec.Position.Y);

                _menus[index].Texts[0].Position = new Vector2f(_menus[index].Rec.Position.X + 10, _menus[index].Rec.Position.Y);
                _menus[index].Texts[1].Position = new Vector2f(_menus[index].Rec.Position.X + 32 * 3 + 10, _menus[index].Rec.Position.Y);
                _menus[index].Texts[2].Position = new Vector2f(_menus[index].Rec.Position.X + 32 * 6 + 10, _menus[index].Rec.Position.Y);
                _menus[index].Texts[3].Position = new Vector2f(_menus[index].Rec.Position.X + 32 * 9 + 10, _menus[index].Rec.Position.Y);              

                _menus[index].Availabilities[0].Position = new Vector2f(_menus[index].Rec.Position.X + 10, _menus[index].Rec.Position.Y + 40);
                _menus[index].Availabilities[1].Position = new Vector2f(_menus[index].Rec.Position.X + 32 * 3 + 10, _menus[index].Rec.Position.Y + 40);
                _menus[index].Availabilities[2].Position = new Vector2f(_menus[index].Rec.Position.X + 32 * 6 + 10, _menus[index].Rec.Position.Y + 40);
                _menus[index].Availabilities[3].Position = new Vector2f(_menus[index].Rec.Position.X + 32 * 9 + 10, _menus[index].Rec.Position.Y + 40);

                for (int i = 0; i < 4; i++)
                {
                    _menus[index].Tabs[i].Draw(window, RenderStates.Default);
                    _menus[index].Texts[i].Draw(window, RenderStates.Default);
                }

                for (int i = 0; i < _menus[index].TabState.Length; i++)
                {
                    if (_menus[index].Tabs[i].GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                    {
                        _menus[index].TabState[i] = true;
                        TabActive = i;
                    }
                }

                for(int i = 0; i < _menus[index].Tabs.Length; i++)
                {
                    if (i != TabActive)
                    {
                        _menus[index].Tabs[i].FillColor = Color.White;
                    }
                    else
                        _menus[index].Tabs[TabActive].FillColor = Color.Yellow;
                }
                _menus[index].Tabs[TabActive].Draw(window, RenderStates.Default);
                _menus[index].Texts[TabActive].Draw(window, RenderStates.Default);

                Sprite send = _menus[index].SendSprite;

                wood.Position = new Vector2f(_menus[index].Rec.Position.X + _boxSize, _menus[index].Rec.Position.Y + _boxSize * 2);
                woodChosen.Position = new Vector2f(_menus[index].Rec.Position.X + _boxSize, _menus[index].Rec.Position.Y + _boxSize * 2);
                metal.Position = new Vector2f(_menus[index].Rec.Position.X + _boxSize * 4, _menus[index].Rec.Position.Y + _boxSize * 2);
                metalChosen.Position = new Vector2f(_menus[index].Rec.Position.X + _boxSize * 4, _menus[index].Rec.Position.Y + _boxSize * 2);
                rock.Position = new Vector2f(_menus[index].Rec.Position.X + _boxSize * 7, _menus[index].Rec.Position.Y + _boxSize * 2);
                rockChosen.Position = new Vector2f(_menus[index].Rec.Position.X + _boxSize * 7, _menus[index].Rec.Position.Y + _boxSize * 2);

                for (int i = 0; i < _spriteMenu.Count; i++)
                {
                    _spriteMenu[i].Draw(window, RenderStates.Default);
                    if (building.ShipList[TabActive].Resource == "")
                    {
                        if (_spriteMenu[i].GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                        {
                            if (Mouse.IsButtonPressed(Mouse.Button.Left))
                            {
                                _choiceMade = i;
                                if (_choiceMade == 0) _resource = "wood";
                                else if (_choiceMade == 1) _resource = "metal";
                                else if (_choiceMade == 2) _resource = "rock";
                            }
                        }
                    }
                }
                _spriteMenuActif[_choiceMade].Draw(window, RenderStates.Default);

                for (int i = 0; i < building.Type.List.Count; i++)
                {
                    if (Equals(building, building.Type.List[i]))
                    {
                        if (building.Type.List[i].ShipList[TabActive].IsAvailable)
                            _menus[index].Availabilities[TabActive].FillColor = Color.Green;
                        else
                        {
                            _menus[index].Availabilities[TabActive].FillColor = Color.Red;
                        }
                        _menus[index].Availabilities[TabActive].Draw(window, RenderStates.Default);

                        if (send.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                        {
                            send = _menus[index].SendSpriteActive;
                            send.Draw(window, RenderStates.Default);
                            if (Mouse.IsButtonPressed(Mouse.Button.Left))
                            {
                                _sent = true;
                                _activeSpaceStation = building.Type.List[i];
                                _undisposedTime = _ctx.GameTime.InGameTime;
                                _ship = _activeSpaceStation.ShipList[TabActive];
                            }
                        }
                        else send = _menus[index].SendSprite;
                    }
                }
                send.Position = new Vector2f(_menus[index].Rec.Position.X + 32 * 3, _menus[index].Rec.Position.Y + 32 * 5);
                send.Draw(window, RenderStates.Default);
            }
            if (_sent)
            {
                _activeSpaceStation.SendShip(_ship, _undisposedTime, _resource);
                _sent = false;
                _menus[index].IsOn = false;
            }
        }

        public bool MenuON
        {
            get { return _menuON; }
            set { _menuON = value; }
        }

        public Sprite MouseSprite
        {
            get { return _mouseSprite; }
            set { _mouseSprite = value; }
        }

        public void DrawBuildingList(RenderWindow window, Font spacefont)
        {
            RectangleShape backgroundListMenu = new RectangleShape
            {
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                Size = new Vector2f(_resolution.X, 70 * 2),
                FillColor = new Color(255,255,255,100),
                Position = new Vector2f(0, _resolution.Y - 2 * 50 - 50 - 20)
            };

            _habitationTab = new RectangleShape
            {
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                Size = new Vector2f(300,120/3),
                FillColor = new Color(Color.White),
                Position = new Vector2f(-10, _resolution.Y - 2 * 50 - 50 - 20)
            };

            Text text = new Text("Habitation", spacefont)
            {
                Color = new Color(Color.Black),
                CharacterSize = 15,
                Position = new Vector2f(150, _resolution.Y - 2 * 50 - 50 - 20 + 5),
                Style = Text.Styles.Bold
            };

            _publicTab = new RectangleShape
            {
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                Size = new Vector2f(300, 120 / 3),
                FillColor = new Color(Color.White),
                Position = new Vector2f(-10, _resolution.Y - 2 * 50 - 50 - 20 + 120 /3 )
            };

              Text text2 = new Text("Public", spacefont)
            {
                Color = new Color(Color.Black),
                CharacterSize = 15,
                Position = new Vector2f(150, _resolution.Y - 2 * 50 - 50 - 20 + 120 / 3 + 5),
                Style = Text.Styles.Bold
            };

            _ressourcesTab = new RectangleShape
            {
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                Size = new Vector2f(300, 120 / 3),
                FillColor = new Color(Color.White),
                Position = new Vector2f(-10, _resolution.Y - 2 * 50 - 50 - 20 +( 120 / 3)*2)
            };

            Text text3 = new Text("Ressources", spacefont)
            {
                Color = new Color(Color.Black),
                CharacterSize = 15,
                Position = new Vector2f(150, _resolution.Y - 2 * 50 - 50 - 20 + (120 / 3) * 2 + 5),
                Style = Text.Styles.Bold
            };

            if (_buildSelected == true)
            {
                if (_habitationTab.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    _habitationTab.FillColor = new Color(Color.Yellow);
                } else if (_publicTab.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                   _publicTab.FillColor = new Color(Color.Yellow);
                } else if (_ressourcesTab.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    _ressourcesTab.FillColor = new Color(Color.Yellow);
                }

                if (_habitationTabSelected == true)
                {
                    _habitationTab.FillColor = new Color(106,109,109);
                    text.Color = new Color(Color.White);
                }
                else if (_publicTabSelected == true)
                {
                    _publicTab.FillColor = new Color(106, 109, 109);
                    text2.Color = new Color(Color.White);
                }
                else if (_ressourcesTabSelected == true)
                {
                    _ressourcesTab.FillColor = new Color(106, 109, 109);
                    text3.Color = new Color(Color.White);
                }
                

                DrawBuildingNeeds(window, font);

                window.Draw(backgroundListMenu);
                window.Draw(_habitationTab);
                window.Draw(_publicTab);
                window.Draw(_ressourcesTab);

                window.Draw(text);
                window.Draw(text2);
                window.Draw(text3);
            }
        }

        public void BuildingTabList(RenderWindow window, Font font)
        {
            if (_buildSelected == true)
            {
                DrawBuildingChoices(window, font);
            }
        }

        public void BackgroundMenuBar(RenderWindow window, Dictionary<string, int> resources, Font font, float satisfaction)
        {
            CircleShape backgroundRemoveCircle = new CircleShape(40)
            {
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                FillColor = new Color(Color.White),
                Position = new Vector2f(-10, _resolution.Y - (5 * 25) - 75 - 15)
            };

            RectangleShape bottomBackgroundRectangle = new RectangleShape
            {
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                Size = new Vector2f(_resolution.X - 25, 90),
                FillColor = new Color(Color.White),
                Position = new Vector2f(0, _resolution.Y - 2 * 15 - 20)
            };

            CircleShape backgroundBuildCircle = new CircleShape(70)
            {
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                FillColor = new Color(Color.White),
                Position = new Vector2f(-10, _resolution.Y - 2 * 50 - 50 - 20)
            };

            RectangleShape leftBackgroundRectangle = new RectangleShape
            {
                Size = new Vector2f(30, 200),
                FillColor = new Color(Color.White),
                Position = new Vector2f(0, _resolution.Y - (5 * 25) - 75 - 15)
            };

            RectangleShape leftBackgroundRectangle2 = new RectangleShape
            {
                Size = new Vector2f(70, 200),
                FillColor = new Color(Color.White),
                Position = new Vector2f(0, _resolution.Y - 2 * 50 - 50 - 21)
            };

            CircleShape rightBackgroundCircle = new CircleShape(25)
            {
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                FillColor = new Color(Color.White),
                Position = new Vector2f(_resolution.X - 50, _resolution.Y - 50)
            };

            RectangleShape rightBackgroundRectangle = new RectangleShape
            {
                Size = new Vector2f(_resolution.X, 50),
                FillColor = new Color(Color.White),
                Position = new Vector2f(0, _resolution.Y - 2 * 15)
            };

            RectangleShape rightBackgroundRectangle2 = new RectangleShape
            {
                Size = new Vector2f(_resolution.X - 25, 90),
                FillColor = new Color(Color.White),
                Position = new Vector2f(0, _resolution.Y - 2 * 15 - 20)
            };

            CircleShape leftPopulation = new CircleShape(25)
            {
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                FillColor = new Color(Color.White),
                Position = new Vector2f(150 + 50 + 50 + 25, _resolution.Y - 2 * 15 - 20 - 25)
            };

            CircleShape rightPoupulation = new CircleShape(25)
            {
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                FillColor = new Color(Color.White),
                Position = new Vector2f(150 + 50 + 100 + 50 + 25, _resolution.Y - 2 * 15 - 20 - 25)
            };

            RectangleShape rectanglePopulation = new RectangleShape
            {
                Size = new Vector2f(105, 30),
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                FillColor = new Color(Color.White),
                Position = new Vector2f(150 + 50 + 25 + 50 + 25, _resolution.Y - 2 * 15 - 20 - 25)
            };

            RectangleShape hideRectanglePopulation = new RectangleShape
            {
                Size = new Vector2f(107, 30),
                FillColor = new Color(Color.White),
                Position = new Vector2f(150 + 50 + 25 - 1 + 50 + 25, _resolution.Y - 2 * 15 - 20 - 25)
            };

            Text nbPeople = new Text(resources["nbPeople"].ToString(), font)
            {
                Position = new Vector2f(rectanglePopulation.Position.X + rectanglePopulation.Size.X / 2 - ((resources["nbPeople"].ToString().Length)*16)/2, _resolution.Y - 2 * 15 - 20 - 25 + 2),
                Color = Color.Black,
                CharacterSize = 16,
                Style = Text.Styles.Bold
            };

            float sat = satisfaction * 100;

            Text textSatisfaction = new Text(satisfaction * 100 + "%", font)
            {
                Position = new Vector2f(rectanglePopulation.Position.X + rectanglePopulation.Size.X / 2 - ((sat.ToString().Length - 2)*16)/2, _resolution.Y - 2 * 15 - 20 - 25 + 2),
                Color = Color.Black,
                CharacterSize = 16,
                Style = Text.Styles.Bold
             };

            if (_people.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
            {
                leftPopulation.Draw(window, RenderStates.Default);
                rightPoupulation.Draw(window, RenderStates.Default);
                rectanglePopulation.Draw(window, RenderStates.Default);
                hideRectanglePopulation.Draw(window, RenderStates.Default);
                nbPeople.Draw(window, RenderStates.Default);

            }

            if (_satisfaction.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
            {
                leftPopulation.Draw(window, RenderStates.Default);
                rightPoupulation.Draw(window, RenderStates.Default);
                rectanglePopulation.Draw(window, RenderStates.Default);
                hideRectanglePopulation.Draw(window, RenderStates.Default);
                textSatisfaction.Draw(window, RenderStates.Default);
            }

            backgroundRemoveCircle.Draw(window, RenderStates.Default);
            bottomBackgroundRectangle.Draw(window, RenderStates.Default);
            backgroundBuildCircle.Draw(window, RenderStates.Default);
            leftBackgroundRectangle.Draw(window, RenderStates.Default);
            leftBackgroundRectangle2.Draw(window, RenderStates.Default);
            rightBackgroundCircle.Draw(window, RenderStates.Default);
            rightBackgroundRectangle.Draw(window, RenderStates.Default);
            rightBackgroundRectangle2.Draw(window, RenderStates.Default);

            
        }

        public void MenuBar(RenderWindow window, GameTime gameTime, Font font, Dictionary<string, int> resources, float satisfaction)
        {
            CircleShape buildCircle = new CircleShape(50)
            {
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                FillColor = new Color(Color.Blue),
                Position = new Vector2f(15, _resolution.Y - 2 * 50 - 50),
                
            };

            buildCircle.Draw(window, RenderStates.Default);

            _buildButton = new Sprite(_ctx._uiTextures[3])
            {
                Position = new Vector2f(buildCircle.Position.X + _buildButton.GetGlobalBounds().Width / 4, buildCircle.Position.Y + _buildButton.GetGlobalBounds().Height / 4)
            };

            _buildButton.Draw(window, RenderStates.Default);

            CircleShape removeCircle = new CircleShape(25)
            {
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                FillColor = new Color(Color.Green),
                Position = new Vector2f(5, _resolution.Y - (5 * 25) - 75)
            };

            removeCircle.Draw(window, RenderStates.Default);

            _destroyButton = new Sprite(_ctx._uiTextures[33])
            {
                Position = new Vector2f(removeCircle.Position.X + _destroyButton.GetGlobalBounds().Width / 4, removeCircle.Position.Y + _destroyButton.GetGlobalBounds().Height / 4),
                Scale = new Vector2f(0.5f, 0.5f)
            };

            _destroyButton.Draw(window, RenderStates.Default);

            //TIME
            CircleShape timeCircleLeft = new CircleShape(15)
            {
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                FillColor = new Color(Color.White),
                Position = new Vector2f(0 + 5, _resolution.Y - 2 * 15 - 10)
            };

            timeCircleLeft.Draw(window, RenderStates.Default);

            CircleShape timeCircleRight = new CircleShape(15)
            {
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                FillColor = new Color(Color.White),
                Position = new Vector2f(105 + 5, _resolution.Y - 2 * 15 - 10)
            };

            timeCircleRight.Draw(window, RenderStates.Default);

            RectangleShape timeRectangle = new RectangleShape
            {
                Size = new Vector2f(105, 30),
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                FillColor = new Color(Color.White),
                Position = new Vector2f(15 + 5, _resolution.Y - 2 * 15 - 10)
            };

            RectangleShape hideTime = new RectangleShape
            {
                Size = new Vector2f(107, 30),
                FillColor = new Color(Color.White),
                Position = new Vector2f(15 + 5 - 1, _resolution.Y - 2 * 15 - 10)
            };

            timeRectangle.Draw(window, RenderStates.Default);
            hideTime.Draw(window, RenderStates.Default);

            Text Time = new Text(gameTime.InGameTime.ToString("HH:mm"), font)
            {
                Position = new Vector2f(15 + 55, _resolution.Y - 2 * 15 - 10),
                Color = Color.Black,
                CharacterSize = 22,
                Style = Text.Styles.Bold
            };

            Time.Draw(window, RenderStates.Default);
            _play.Draw(window, RenderStates.Default);
            _pause.Draw(window, RenderStates.Default);
            _fastForward.Draw(window, RenderStates.Default);

            //MONEY
            CircleShape moneyCircleLeft = new CircleShape(15)
            {
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                FillColor = new Color(Color.White),
                Position = new Vector2f(150 + 5, _resolution.Y - 2 * 15 - 10)
            };

            moneyCircleLeft.Draw(window, RenderStates.Default);

            CircleShape moneyCircleRight = new CircleShape(15)
            {
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                FillColor = new Color(Color.White),
                Position = new Vector2f(350 + 5, _resolution.Y - 2 * 15 - 10)
            };

            moneyCircleRight.Draw(window, RenderStates.Default);

            RectangleShape moneyRectangle = new RectangleShape
            {
                Size = new Vector2f(200, 30),
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                FillColor = new Color(Color.White),
                Position = new Vector2f(150 + 15 + 5, _resolution.Y - 2 * 15 - 10)
            };

            moneyRectangle.Draw(window, RenderStates.Default);

            RectangleShape hideMoney = new RectangleShape
            {
                Size = new Vector2f(202, 30),
                FillColor = new Color(Color.White),
                Position = new Vector2f(150 + 15 + 5 - 1, _resolution.Y - 2 * 15 - 10)
            };

            hideMoney.Draw(window, RenderStates.Default);

            _coinSprite.Draw(window, RenderStates.Default);
            Text nbCoins = new Text(resources["coins"].ToString(), font)
            {
                Position = new Vector2f(150 + 50, _resolution.Y - 2 * 15 - 8),
                Color = Color.Black,
                CharacterSize = 20,
                Style = Text.Styles.Bold
            };
            nbCoins.Draw(window, RenderStates.Default);

            //Displays Satisfaction and check if hovering
            if (satisfaction < 0.3f) _satisfaction.Texture = _ctx._uiTextures[12]; //Angry
            else if (satisfaction > 0.7f)
            {
                _satisfaction.Texture = _ctx._uiTextures[14];//Happy
            }
            else _satisfaction.Texture = _ctx._uiTextures[13]; //Confused

            _satisfaction.Draw(window, RenderStates.Default);
            _people.Draw(window, RenderStates.Default);

            //RESSOURCES
            CircleShape resourceCircleLeft = new CircleShape(15)
            {
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                FillColor = new Color(Color.White),
                Position = new Vector2f(350 + 45 + 5, _resolution.Y - 2 * 15 - 10)
            };

            resourceCircleLeft.Draw(window, RenderStates.Default);

            CircleShape resourceCircleRight = new CircleShape(15)
            {
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                FillColor = new Color(Color.White),
                Position = new Vector2f(350 + 45 + 400 + 5 + 2*110+20, _resolution.Y - 2 * 15 - 10)
            };

            resourceCircleRight.Draw(window, RenderStates.Default);

            RectangleShape resourceRectangle = new RectangleShape
            {
                Size = new Vector2f(400+2*110+20, 30),
                OutlineColor = new Color(Color.Black),
                OutlineThickness = 1.0f,
                FillColor = new Color(Color.White),
                Position = new Vector2f(350 + 45 + 15 + 5, _resolution.Y - 2 * 15 - 10)
            };

            resourceRectangle.Draw(window, RenderStates.Default);

            RectangleShape hideRessource = new RectangleShape
            {
                Size = new Vector2f(402+2*110+20, 30),
                FillColor = new Color(Color.White),
                Position = new Vector2f(350 + 45 + 15 + 5 - 1, _resolution.Y - 2 * 15 - 10)
            };

            hideRessource.Draw(window, RenderStates.Default);

            _woodSprite.Draw(window, RenderStates.Default);

            Text nbWood = new Text(resources["wood"].ToString(), font)
            {
                Position = new Vector2f(_woodSprite.Position.X + _woodSprite.GetGlobalBounds().Width, _woodSprite.Position.Y + _woodSprite.GetGlobalBounds().Height / 16 * 2),
                Color = Color.Black,
                CharacterSize = 16,
                Style = Text.Styles.Bold
            };
            nbWood.Draw(window, RenderStates.Default);
            _rockSprite.Draw(window, RenderStates.Default);
            Text nbRock = new Text(resources["rock"].ToString(), font)
            {
                Position = new Vector2f(_rockSprite.Position.X + _rockSprite.GetGlobalBounds().Width, _rockSprite.Position.Y + _rockSprite.GetGlobalBounds().Height / 16 * 2),
                Color = Color.Black,
                CharacterSize = 16,
                Style = Text.Styles.Bold
            };
            nbRock.Draw(window, RenderStates.Default);
            _metalSprite.Draw(window, RenderStates.Default);

            Text nbMetal = new Text(resources["metal"].ToString(), font)
            {
                Position = new Vector2f(_metalSprite.Position.X + _metalSprite.GetGlobalBounds().Width, _metalSprite.Position.Y + _metalSprite.GetGlobalBounds().Height / 16 * 2),
                Color = Color.Black,
                CharacterSize = 16,
                Style = Text.Styles.Bold
            };
            nbMetal.Draw(window, RenderStates.Default);
            _waterSprite.Draw(window, RenderStates.Default);

            Text nbWater = new Text(resources["water"].ToString(), font)
            {
                Position = new Vector2f(_waterSprite.Position.X + _waterSprite.GetGlobalBounds().Width, _waterSprite.Position.Y + _waterSprite.GetGlobalBounds().Height / 16 * 2),
                Color = Color.Black,
                CharacterSize = 16,
                Style = Text.Styles.Bold
            };
            nbWater.Draw(window, RenderStates.Default);

            _electricitySprite.Draw(window, RenderStates.Default);
            Text nbElectricity = new Text(resources["electricity"].ToString(), font)
            {
                Position = new Vector2f(_electricitySprite.Position.X + _electricitySprite.GetGlobalBounds().Width, _electricitySprite.Position.Y + _electricitySprite.GetGlobalBounds().Height / 16 * 2),
                Color = Color.Black,
                CharacterSize = 16,
                Style = Text.Styles.Bold
            };
            nbElectricity.Draw(window, RenderStates.Default);

            _pollutionSprite.Draw(window, RenderStates.Default);
            Text nbPollution = new Text(resources["pollution"].ToString(), font)
            {
                Position = new Vector2f(_pollutionSprite.Position.X + _pollutionSprite.GetGlobalBounds().Width, _pollutionSprite.Position.Y + _pollutionSprite.GetGlobalBounds().Height / 16 * 2),
                Color = Color.Black,
                CharacterSize = 16,
                Style = Text.Styles.Bold
            };
            nbPollution.Draw(window, RenderStates.Default);

            Text level = new Text("Level : " + _experienceManager.Level.ToString(), font)
            {
                Position = new Vector2f(resourceCircleRight.Position.X + resourceCircleRight.GetGlobalBounds().Width + 10, resourceCircleRight.Position.Y + resourceCircleRight.GetGlobalBounds().Height / 16 * 2),
                CharacterSize = 16,
                Style = Text.Styles.Bold,
                Color = new Color(Color.Black)
            };
            level.Draw(window, RenderStates.Default);

            if (level.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
            {
                _expBarFilled.Size = new Vector2f(_expBar.Size.X * ((float)_experienceManager.GetPercentage() / 100f), _expBar.Size.Y);
                _expBar.Draw(window, RenderStates.Default);
                _expBarFilled.Draw(window, RenderStates.Default);
            }
        }

        public int TabActive
        {
            get { return _tabActif; }
            set { _tabActif = value; }
        }

        public void ReturnShip (ExplorationShips ship, int i, string resource, int nbresource, RenderWindow window)
        {
            ship.IsAvailable = true;
            _resourcesManager.NbResources[resource] += nbresource;
            ship.Resource = "";
            //_menus[i].Availabilities.FillColor = Color.Green;
            //_menus[i].Availabilities.Draw(window, RenderStates.Default);
        }

        public void CreateMenu(Game ctx, Building building)
        {
            SpaceMenu menu = new SpaceMenu(ctx, building);
            menu.List.Add(menu);
            _menus.Add(menu);
        }

        public List<SpaceMenu> Menus
        {
            get { return _menus; }
            set { _menus = value; }
        }

        public bool DrawMeteor(RenderWindow window, Font font)
        {
            if (_meteorWait == null) _meteorWait = new Clock();

            if (_meteorWait.ElapsedTime.AsSeconds() < 5)
            {
                _meteors.Draw(window, RenderStates.Default);
                Text info;
                RectangleShape rec;

                if (_meteorWait.ElapsedTime.AsSeconds() < 2)
                {
                    info = new Text("Meteors are falling !", font);
                    info.Position = new Vector2f(_resolution.X / 9 * 4, _resolution.Y / 5 * 4);
                }
                else
                {
                    string str = "Meteors have fallen from the sky and " + _ctx.CityEvents.NbDestroyedBuildings + " buildings have been destroyed !";
                    info = new Text(str, font);
                    info.Position = new Vector2f(_resolution.X / 15 * 2, _resolution.Y / 5 * 4);
                }

                rec = new RectangleShape()
                {
                    Position = new Vector2f(0, info.Position.Y),
                    Size = new Vector2f(_resolution.X, 50 + 20),
                    FillColor = Color.Black
                };
                rec.Draw(window, RenderStates.Default);

                info.CharacterSize = 50;
                info.Color = Color.Yellow;
                info.Draw(window, RenderStates.Default);
            }
            else
            {
                _meteorWait = null;
                _ctx.CityEvents.WaitMeteors = false;
                return false;
            }

            return true;
        }

        public bool CheckSoundSlider(RenderWindow window)
        {
            if (_settingsSelected)
            {
                if (_musicSlider.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y))
                {
                    float mouseX = Mouse.GetPosition(window).X - _musicSlider.Position.X;

                    float percent = (mouseX * 100) / (_musicSlider.Size.X);
                    if (percent > 100) percent = 100;
                    else if (percent < 0) percent = 0;
                    _ctx.SoundManager.MusicVolume = percent;
                    return true;
                }
                else if (_SFXSlider.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y))
                {
                    float mouseX = Mouse.GetPosition(window).X - _SFXSlider.Position.X;
                    float percent = (mouseX * 100) / (_SFXSlider.Size.X);

                    if (percent > 100) percent = 100;
                    else if (percent < 0) percent = 0;
                    _ctx.SoundManager.SFXVolume = percent;
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}