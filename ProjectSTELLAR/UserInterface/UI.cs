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

        ExplorationShips _ship;
        DateTime _undisposedTime;
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
        RectangleShape _expBar;
        RectangleShape _expBarFilled;
        RectangleShape _rectangleTimeBar;
        readonly Sprite[] _menu = new Sprite[3];
        readonly Sprite[] _menuActif = new Sprite[3];
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

        uint _width;
        uint _height;
        uint _boxSize = 32;
        private bool _buildSelected;
        private bool _destroySelected;
        private bool _tab1Selected;
        private bool _tab2Selected;
        private bool _tab3Selected;
        private string _buildingSelected;
        bool _settingsSelected;
        bool _exitSelected;
        int _selectedIndex;
        bool _hovering;
        private bool _menuON;
        List<bool> _tab;
        int _tabActif;
        int _choiceMade;
        string _resource;
        bool _sent;
        int _nbDestroyedBuildings;
        Clock _meteorWait;

        public UI(Game ctx, Resolution resolution, Map context, DrawUI drawUI, uint width, uint height, GameTime gameTime, ResourcesManager resourcesManager, ExperienceManager experienceManager)
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

            //TIME BAR
            _play = new Sprite(_ctx._uiTextures[18])
            {
                Position = new Vector2f(_resolution.X / 2, _resolution.Y - 30),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _pause = new Sprite(_ctx._uiTextures[17])
            {
                Position = new Vector2f(_resolution.X / 2 - 34, _resolution.Y - 30),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _fastForward = new Sprite(_ctx._uiTextures[16])
            {
                Position = new Vector2f(_resolution.X / 2 + 32, _resolution.Y - _boxSize + 3),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _rectangleTimeBar = new RectangleShape()
            {
                FillColor = Color.Transparent,
                Size = new Vector2f(_resolution.X - _boxSize * 4 + 10, _boxSize),
                Position = new Vector2f(0, _resolution.Y - _boxSize)
            };

            //UI BUTTONS
            _buildButton = new Sprite(_ctx._uiTextures[3])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 3, _resolution.Y / 2 + _boxSize * 2)
            };

            _destroyButton = new Sprite(_ctx._uiTextures[20])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 3, _resolution.Y / 2 + _boxSize * 5),
                //Scale = new Vector2f(0.5f, 0.5f)
            };
            _settingsButton = new Sprite(_ctx._uiTextures[21])
            {
                Scale = new Vector2f(0.8f, 0.8f)
            };
            _exitButton = new Sprite(_ctx._uiTextures[22]);

            _saveButton = new Sprite(_ctx._menuTextures[2])
            {
                Position = new Vector2f(_resolution.X / 2 - _boxSize * 7, _boxSize * 2),
                Scale = new Vector2f(0.5f, 0.5f)
            };
            _menu[0] = _saveButton;

            _saveButtonActive = new Sprite(_ctx._menuTextures[7])
            {
                Position = new Vector2f(_resolution.X / 2 - _boxSize * 7, _boxSize * 2),
                Scale = new Vector2f(0.5f, 0.5f)
            };
            _menuActif[0] = _saveButtonActive;

            _returnButton = new Sprite(_ctx._menuTextures[4])
            {
                Position = new Vector2f(_resolution.X / 2 - _boxSize * 7, _boxSize * 8),
                Scale = new Vector2f(0.5f, 0.5f)
            };
            _menu[1] = _returnButton;

            _returnButtonActive = new Sprite(_ctx._menuTextures[9])
            {
                Position = new Vector2f(_resolution.X / 2 - _boxSize * 7, _boxSize * 8),
                Scale = new Vector2f(0.5f, 0.5f)
            };
            _menuActif[1] = _returnButtonActive;

            _quitButton = new Sprite(_ctx._menuTextures[3])
            {
                Position = new Vector2f(_resolution.X / 2 - _boxSize * 7, _boxSize * 14),
                Scale = new Vector2f(0.5f, 0.5f)
            };
            _menu[2] = _quitButton;

            _quitButtonActive = new Sprite(_ctx._menuTextures[8])
            {
                Position = new Vector2f(_resolution.X / 2 - _boxSize * 7, _boxSize * 14),
                Scale = new Vector2f(0.5f, 0.5f)
            };
            _menuActif[2] = _quitButtonActive;

            _sendButton = new Sprite(_ctx._uiTextures[24]);
            _sendActifButton = new Sprite(_ctx._uiTextures[25]);

            //XP BAR
            _expBar = new RectangleShape()
            {
                Size = new Vector2f(200, 30),
                Position = new Vector2f(resolution.X - 204, resolution.Y - _boxSize)
            };

            _expBarFilled = new RectangleShape(_expBar)
            {
                FillColor = Color.Blue
            };

            //RESOURCES
            _coinSprite = new Sprite(_ctx._uiTextures[5])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 4 + 5, _boxSize * 3),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _woodSprite = new Sprite(_ctx._uiTextures[7])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 4 + 5, _boxSize * 4),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _rockSprite = new Sprite(_ctx._uiTextures[9])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 4 + 5, _boxSize * 5),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _metalSprite = new Sprite(_ctx._uiTextures[8])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 4 + 5, _boxSize * 6),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _electricitySprite = new Sprite(_ctx._uiTextures[11])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 4 + 5, _boxSize * 7),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _waterSprite = new Sprite(_ctx._uiTextures[10])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 4 + 5, _boxSize * 8),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _pollutionSprite = new Sprite(_ctx._uiTextures[6])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 4 + 5, _boxSize * 9),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _people = new Sprite(_ctx._uiTextures[23])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 3, _boxSize * 10)
            };

            _satisfaction = new Sprite(_ctx._uiTextures[12])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 3, _boxSize * 19 - 15)
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
            _flatSprite = new Sprite(_ctx._buildingsTextures[2])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 6, _resolution.Y / 2),
                Scale = new Vector2f(0.5f, 0.5f)
            };

            _hutSprite = new Sprite(_ctx._buildingsTextures[1])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 10, _resolution.Y / 2)
            };


            _houseSprite = new Sprite(_ctx._buildingsTextures[3])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 8, _resolution.Y / 2)

            };

            //PUBLIC BUILDINGS
            _cityHall = new Sprite(_ctx._buildingsTextures[6])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 2, _resolution.Y / 2)
            };

            _fireStation = new Sprite(_ctx._buildingsTextures[8])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 4, _resolution.Y / 2)
            };

            _hospital = new Sprite(_ctx._buildingsTextures[9])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 6, _resolution.Y / 2)
            };

            _police = new Sprite(_ctx._buildingsTextures[10])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 8, _resolution.Y / 2)
            };

            _warehouse = new Sprite(_ctx._buildingsTextures[15])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 12, _resolution.Y / 2)
            };

            _spaceStation = new Sprite(_ctx._buildingsTextures[11])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 10, _resolution.Y / 2)
            };

            _park = new Sprite(_ctx._buildingsTextures[19])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 10, _resolution.Y / 2 + 64)
            };

            //RESOURCES BUILDINGS
            _powerPlant = new Sprite(_ctx._buildingsTextures[4])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 10, _resolution.Y / 2)
            };

            _pumpingStation = new Sprite(_ctx._buildingsTextures[5])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 8, _resolution.Y / 2)
            };
            
            _sawMill = new Sprite(_ctx._buildingsTextures[12])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 6, _resolution.Y / 2)
            };

            _oreMine = new Sprite(_ctx._buildingsTextures[13])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 4, _resolution.Y / 2)
            };

            _metalMine = new Sprite(_ctx._buildingsTextures[14])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 2, _resolution.Y / 2)
            };

            _shop = new Sprite(_ctx._buildingsTextures[17])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 10, _resolution.Y / 2 + 64)
            };

            _factory = new Sprite(_ctx._buildingsTextures[18])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 8, _resolution.Y / 2 + 64)
            };

            _lockSprite = new Sprite(_ctx._buildingsTextures[16])
            {
                Scale = new Vector2f(0.5f, 0.5f)
            };

            // habitations
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

            _meteors = new Sprite(_ctx._uiTextures[34]);
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
        public uint Width => _width;

        public uint Height => _height;

        /// <summary>
        /// Draws the resources bar.
        /// </summary>
        /// <param name="window">The window.</param>
        public void DrawResourcesBar(RenderWindow window, Font font, Dictionary<string, int> resources, float satisfaction)
        {
            RectangleShape rec = new RectangleShape();
            rec.FillColor = new Color(30, 40, 40);
            rec.Size = new Vector2f(_boxSize * 5, _resolution.Y);
            rec.Position = new Vector2f(_resolution.X - _boxSize * 4 - 5, 0);

            rec.Draw(window, RenderStates.Default);

            //Displays Coins Sprite and number of coins
            _coinSprite.Draw(window, RenderStates.Default);
            Text nbCoins = new Text(resources["coins"].ToString(), font);
            nbCoins.Position = new Vector2f(_resolution.X - _boxSize * 2 - 17, _boxSize * 3 + 2);
            nbCoins.Color = Color.White;
            nbCoins.CharacterSize = 16;
            nbCoins.Style = Text.Styles.Bold;
            nbCoins.Draw(window, RenderStates.Default);

            //Displays Wood Sprite and number of wood
            _woodSprite.Draw(window, RenderStates.Default);
            Text nbWood = new Text(resources["wood"].ToString(), font);
            nbWood.Position = new Vector2f(_resolution.X - _boxSize * 2 - 17, _boxSize * 4 + 2);
            nbWood.Color = Color.White;
            nbWood.CharacterSize = 16;
            nbWood.Style = Text.Styles.Bold;
            nbWood.Draw(window, RenderStates.Default);

            _rockSprite.Draw(window, RenderStates.Default);
            Text nbRock = new Text(resources["rock"].ToString(), font);
            nbRock.Position = new Vector2f(_resolution.X - _boxSize * 2 - 17, _boxSize * 5 + 2);
            nbRock.Color = Color.White;
            nbRock.CharacterSize = 16;
            nbRock.Style = Text.Styles.Bold;
            nbRock.Draw(window, RenderStates.Default);

            _metalSprite.Draw(window, RenderStates.Default);
            Text nbMetal = new Text(resources["metal"].ToString(), font);
            nbMetal.Position = new Vector2f(_resolution.X - _boxSize * 2 - 17, _boxSize * 6 + 2);
            nbMetal.Color = Color.White;
            nbMetal.CharacterSize = 16;
            nbMetal.Style = Text.Styles.Bold;
            nbMetal.Draw(window, RenderStates.Default);

            _electricitySprite.Draw(window, RenderStates.Default);
            Text nbElec = new Text(resources["electricity"].ToString(), font);
            nbElec.Position = new Vector2f(_resolution.X - _boxSize * 2 - 17, _boxSize * 7 + 2);
            nbElec.Color = Color.White;
            nbElec.CharacterSize = 16;
            nbElec.Style = Text.Styles.Bold;
            nbElec.Draw(window, RenderStates.Default);

            _waterSprite.Draw(window, RenderStates.Default);
            Text nbWater = new Text(resources["water"].ToString(), font);
            nbWater.Position = new Vector2f(_resolution.X - _boxSize * 2 - 17, _boxSize * 8 + 2);
            nbWater.Color = Color.White;
            nbWater.CharacterSize = 16;
            nbWater.Style = Text.Styles.Bold;
            nbWater.Draw(window, RenderStates.Default);

            //Displays Pollution Sprite and number
            _pollutionSprite.Draw(window, RenderStates.Default);
            Text nbPollution = new Text(resources["pollution"].ToString(), font);
            nbPollution.Position = new Vector2f(_resolution.X - _boxSize * 2 - 17, _boxSize * 9 + 2);
            nbPollution.Color = Color.White;
            nbPollution.CharacterSize = 16;
            nbPollution.Style = Text.Styles.Bold;
            nbPollution.Draw(window, RenderStates.Default);

            //Displays Population and check if hovering
            _people.Draw(window, RenderStates.Default);
            if (_people.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
            {
                Text nbPeople = new Text(resources["nbPeople"].ToString(), font);
                nbPeople.Position = new Vector2f(_resolution.X - _boxSize * 2 - 8, _boxSize * 12 + 2);
                nbPeople.Color = Color.White;
                nbPeople.CharacterSize = 16;
                nbPeople.Style = Text.Styles.Bold;
                nbPeople.Draw(window, RenderStates.Default);
            }

            //Displays Satisfaction and check if hovering
            if (satisfaction < 0.3f) _satisfaction.Texture = _ctx._uiTextures[12]; //Angry
            else if (satisfaction > 0.7f)
            {
                _satisfaction.Texture = _ctx._uiTextures[14]; //Smile
                //Console.WriteLine("HAPPY");
            }
            else _satisfaction.Texture = _ctx._uiTextures[13]; //Confused

            _satisfaction.Draw(window, RenderStates.Default);

            if (_satisfaction.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
            {
                Text textSatisfaction = new Text(satisfaction * 100 + "%", font);
                //textSatisfaction.Position = new Vector2f(_resolution.X - _boxSize * 2 - 8, _boxSize * 12 + 2);
                textSatisfaction.Position = new Vector2f(_satisfaction.Position.X + 15, _satisfaction.Position.Y + 64);
                textSatisfaction.Color = Color.White;
                textSatisfaction.CharacterSize = 16;
                textSatisfaction.Style = Text.Styles.Bold;
                textSatisfaction.Draw(window, RenderStates.Default);
            }
            //window.Draw(rec);
        }

        public void DrawTimeBar(RenderWindow window, GameTime gameTime, Font font)
        {
            RectangleShape rec = new RectangleShape();
            rec.FillColor = new Color(30, 40, 40);
            rec.Size = new Vector2f(_resolution.X, _boxSize * 2);
            rec.Position = new Vector2f(0, _resolution.Y - _boxSize - 10);
            
            Text Time = new Text(gameTime.InGameTime.ToString("dd/MM/yyyy HH:mm"), font)
            {
                Position = new Vector2f(0, _resolution.Y - 32),
                Color = Color.White,
                CharacterSize = 23,
                Style = Text.Styles.Bold
            };

            rec.Draw(window, RenderStates.Default);
            _rectangleTimeBar.Draw(window, RenderStates.Default);
            _pause.Draw(window, RenderStates.Default);
            _play.Draw(window, RenderStates.Default);
            _fastForward.Draw(window, RenderStates.Default);

            Time.Draw(window, RenderStates.Default);
        }

        public void DrawBuildButton(RenderWindow window, Font font)
        {
            RectangleShape rec = new RectangleShape();
            rec.OutlineColor = new Color(Color.Black);
            rec.OutlineThickness = 3.0f;
            rec.FillColor = new Color(30, 40, 40);
            rec.Size = new Vector2f((_boxSize * 12) - 4, _boxSize * 6);
            rec.Position = new Vector2f(_resolution.X - _boxSize * 12, _resolution.Y / 2 - _boxSize * 2);

            RectangleShape onglet1 = new RectangleShape();
            onglet1.OutlineColor = new Color(Color.Blue);
            onglet1.OutlineThickness = 3.0f;
            onglet1.FillColor = new Color(Color.Black);
            onglet1.Size = new Vector2f(((_boxSize * 12) / 3) - 6, (_boxSize * 6) / 6);
            onglet1.Position = new Vector2f(_resolution.X - _boxSize * 12, _resolution.Y / 2 - _boxSize * 2);

            Text text = new Text("Habitation", font);
            text.Color = new Color(Color.White);
            text.CharacterSize = 16;
            text.Position = new Vector2f(_resolution.X - _boxSize * 12 + 5, _resolution.Y / 2 - _boxSize * 2);
            text.Style = Text.Styles.Bold;

            RectangleShape onglet2 = new RectangleShape();
            onglet2.OutlineColor = new Color(Color.Red);
            onglet2.OutlineThickness = 3.0f;
            onglet2.FillColor = new Color(Color.Black);
            onglet2.Size = new Vector2f(((_boxSize * 12) / 3) - 6, (_boxSize * 6) / 6);
            onglet2.Position = new Vector2f(_resolution.X - _boxSize * 8, _resolution.Y / 2 - _boxSize * 2);

            Text publicBuilding = new Text("Public", font);
            publicBuilding.Color = new Color(Color.White);
            publicBuilding.CharacterSize = 16;
            publicBuilding.Position = new Vector2f(_resolution.X - _boxSize * 8 + 5, _resolution.Y / 2 - _boxSize * 2);
            publicBuilding.Style = Text.Styles.Bold;

            RectangleShape onglet3 = new RectangleShape();
            onglet3.OutlineColor = new Color(Color.Yellow);
            onglet3.OutlineThickness = 3.0f;
            onglet3.FillColor = new Color(Color.Black);
            onglet3.Size = new Vector2f(((_boxSize * 12) / 3) - 6, (_boxSize * 6) / 6);
            onglet3.Position = new Vector2f(_resolution.X - _boxSize * 4, _resolution.Y / 2 - _boxSize * 2);

            Text resourcesBuilding = new Text("Resources", font);
            resourcesBuilding.Color = new Color(Color.White);
            resourcesBuilding.CharacterSize = 16;
            resourcesBuilding.Position = new Vector2f(_resolution.X - _boxSize * 4 + 5, _resolution.Y / 2 - _boxSize * 2);
            resourcesBuilding.Style = Text.Styles.Bold;

            _buildButton.Draw(window, RenderStates.Default);

            if (_buildSelected)
            {
                if (rec.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    int j = 0;

                    window.Draw(rec);
                    window.Draw(onglet1);
                    window.Draw(onglet2);
                    window.Draw(onglet3);
                    window.Draw(text);

                    window.Draw(publicBuilding);
                    window.Draw(resourcesBuilding);

                    if (onglet1.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                    {
                        _tab1Selected = true;
                        _tab2Selected = false;
                        _tab3Selected = false;
                    }
                    else if (onglet2.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                    {

                        _tab1Selected = false;
                        _tab2Selected = true;
                        _tab3Selected = false;
                    }
                    else if (onglet3.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                    {
                        _tab1Selected = false;
                        _tab2Selected = false;
                        _tab3Selected = true;
                    }
                    DrawBuildingNeeds(window, font);

                    DrawBuildingChoices(window, font);
                }
                else _buildSelected = false;
            }
        }


        public void DrawDestroyButton(RenderWindow window)
        {
            _destroyButton.Draw(window, RenderStates.Default);
        }

        public bool CheckBuildSelected(RenderWindow window)
        {
            if (_buildButton.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
            {
                _buildSelected = true;
                _destroySelected = false;
                //window.SetMouseCursorVisible(false);
                return true;
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
            RectangleShape rec = new RectangleShape();
            rec.OutlineColor = new Color(Color.Black);
            rec.OutlineThickness = 3.0f;
            rec.FillColor = new Color(Color.Black);
            rec.Size = new Vector2f((_boxSize * 6) , _boxSize * 2);
            rec.Position = new Vector2f(_resolution.X - _boxSize * 11, _resolution.Y / 2 + _boxSize * 5);

            if (_buildingSelected != null && _buildingSelected != "") 
            {
                Text text = new Text(_buildingSelected, font);
                text.Position = rec.Position;
                text.Color = Color.White;
                text.CharacterSize = 18;

                _buildingTypeSprites.TryGetValue(_spriteSelected, out BuildingType building);

                if(building != null)
                {
                    window.Draw(rec);

                    Text woodNeeds = new Text("Wood cost : " + building.Wood, font);
                    woodNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 15);
                    woodNeeds.Color = Color.White;
                    woodNeeds.CharacterSize = 15;

                    Text rockNeeds = new Text("Rock cost : " + building.Rock, font);
                    rockNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 25);
                    rockNeeds.CharacterSize = 15;
                    rockNeeds.Color = Color.White;

                    Text metalNeeds = new Text("Metal cost : " + building.Metal, font);
                    metalNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 35);
                    metalNeeds.CharacterSize = 15;
                    metalNeeds.Color = Color.White;

                    Text coinNeeds = new Text("Coin cost : " + building.Coin, font);
                    coinNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 45);
                    coinNeeds.CharacterSize = 15;
                    coinNeeds.Color = Color.White;
                    
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
            //_tab1Sprite.Clear();
            //_tab2Sprite.Clear();
            //_tab3Sprite.Clear();

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

            if (IsTab1Active == true)
            {
                _drawUIctx.RenderSprite(_hutSprite, window, _resolution.X - _boxSize * 10, _resolution.Y / 2, 0, 0, 32, 32);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[5].UnlockingLevel) _drawUIctx.RenderSprite(_lockSprite, window, _resolution.X - _boxSize * 10, _resolution.Y / 2, 0, 0, 64, 64);
                _drawUIctx.RenderSprite(_houseSprite, window, _resolution.X - _boxSize * 8, _resolution.Y / 2, 0, 0, 32, 32);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[4].UnlockingLevel) _drawUIctx.RenderSprite(_lockSprite, window, _resolution.X - _boxSize * 8, _resolution.Y / 2, 0, 0, 64, 64);
                _drawUIctx.RenderSprite(_flatSprite, window, _resolution.X - _boxSize * 6, _resolution.Y / 2, 0, 0, 64, 64);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[2].UnlockingLevel) _drawUIctx.RenderSprite(_lockSprite, window, _resolution.X - _boxSize * 6, _resolution.Y / 2, 0, 0, 64, 64);

                _sprites.Add(_hutSprite, "HUT");
                _sprites.Add(_houseSprite, "HOUSE");
                _sprites.Add(_flatSprite, "FLAT");
            }
            else if (IsTab2Active)
            {
                _drawUIctx.RenderSprite(_cityHall, window, _resolution.X - _boxSize * 2, _resolution.Y / 2, 0, 0, 32, 32);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[0].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, _resolution.X - _boxSize * 2, _resolution.Y / 2, 0, 0, 64, 64);

                _drawUIctx.RenderSprite(_fireStation, window, _resolution.X - _boxSize * 4, _resolution.Y / 2, 0, 0, 32, 32);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[1].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, _resolution.X - _boxSize * 4, _resolution.Y / 2, 0, 0, 64, 64);

                _drawUIctx.RenderSprite(_hospital, window, _resolution.X - _boxSize * 6, _resolution.Y / 2, 0, 0, 32, 32);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[3].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, _resolution.X - _boxSize * 6, _resolution.Y / 2, 0, 0, 64, 64);

                _drawUIctx.RenderSprite(_police, window, _resolution.X - _boxSize * 8, _resolution.Y / 2, 0, 0, 32, 32);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[8].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, _resolution.X - _boxSize * 8, _resolution.Y / 2, 0, 0, 64, 64);

                _drawUIctx.RenderSprite(_spaceStation, window, _resolution.X - _boxSize * 10, _resolution.Y / 2, 0, 0, 32, 32);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[12].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, _resolution.X - _boxSize * 10, _resolution.Y / 2, 0, 0, 64, 64);

                _drawUIctx.RenderSprite(_warehouse, window, _resolution.X - _boxSize * 12, _resolution.Y / 2, 0, 0, 32, 32);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[13].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, _resolution.X - _boxSize * 12, _resolution.Y / 2, 0, 0, 64, 64);

                _drawUIctx.RenderSprite(_park, window, _resolution.X - _boxSize * 10, _resolution.Y / 2 + 64, 0, 0, 32, 32);

                _sprites.Add(_cityHall, "CITY HALL");
                _sprites.Add(_fireStation, "FIRE STATION");
                _sprites.Add(_hospital, "HOSPITAL");
                _sprites.Add(_police, "POLICE DEPARTMENT");
                _sprites.Add(_spaceStation, "SPACE STATION");
                _sprites.Add(_warehouse, "WAREHOUSE");
                _sprites.Add(_park, "PARK");
            }
            else if (IsTab3Active)
            {
                _drawUIctx.RenderSprite(_sawMill, window, _resolution.X - _boxSize * 6, _resolution.Y / 2, 0, 0, 32, 32);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[11].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, _resolution.X - _boxSize * 6, _resolution.Y / 2, 0, 0, 64, 64);

                _drawUIctx.RenderSprite(_oreMine, window, _resolution.X - _boxSize * 4, _resolution.Y / 2, 0, 0, 32, 32);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[7].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, _resolution.X - _boxSize * 4, _resolution.Y / 2, 0, 0, 64, 64);

                _drawUIctx.RenderSprite(_metalMine, window, _resolution.X - _boxSize * 2, _resolution.Y / 2, 0, 0, 32, 32);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[6].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, _resolution.X - _boxSize * 2, _resolution.Y / 2, 0, 0, 64, 64);

                _drawUIctx.RenderSprite(_powerPlant, window, _resolution.X - _boxSize * 10, _resolution.Y / 2, 0, 0, 32, 32);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[9].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, _resolution.X - _boxSize * 10, _resolution.Y / 2, 0, 0, 64, 64);

                _drawUIctx.RenderSprite(_pumpingStation, window, _resolution.X - _boxSize * 8, _resolution.Y / 2, 0, 0, 32, 32);
                if (_experienceManager.Level < _mapCtx.BuildingTypes[10].UnlockingLevel)
                    _drawUIctx.RenderSprite(_lockSprite, window, _resolution.X - _boxSize * 8, _resolution.Y / 2, 0, 0, 64, 64);

                _drawUIctx.RenderSprite(_shop, window, _resolution.X - _boxSize * 10, _resolution.Y / 2 + 64, 0, 0, 32, 32);

                _drawUIctx.RenderSprite(_factory, window, _resolution.X - _boxSize * 8, _resolution.Y / 2 + 64, 0, 0, 32, 32);

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

            if(_tab1Selected)
            {
                foreach(Sprite sprite in _tab1Sprite.Keys)
                {
                    if(sprite.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y))
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
                            window.SetMouseCursorVisible(false);
                            _mouseSprite = new Sprite(sprite);
                            _mouseSprite.Position = new Vector2f(Mouse.GetPosition(window).X - 10, Mouse.GetPosition(window).Y - 10);
                            return true;
                        }
                    }
                }
            }
            else if (_tab2Selected)
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
                            window.SetMouseCursorVisible(false);
                            _mouseSprite = new Sprite(sprite);
                            _mouseSprite.Position = new Vector2f(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y);
                            return true;
                        }
                    }
                }
            }
            else if(_tab3Selected)
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
                            window.SetMouseCursorVisible(false);
                            _mouseSprite = new Sprite(sprite);
                            _mouseSprite.Position = new Vector2f(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y);
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
            _settingsButton.Position = new Vector2f(_resolution.X - _boxSize * 2, 0);
            _settingsButton.Draw(window, RenderStates.Default);

            RectangleShape rec = new RectangleShape();
            rec.Size = new Vector2f(_resolution.X - _boxSize * 8, _resolution.Y - _boxSize * 5);
            rec.Position = new Vector2f(_boxSize * 3, _boxSize * 2);
            rec.FillColor = new Color(30, 30, 40);

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

                for (int i = 0; i < 3; i++)
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
                        _menu[2] = _quitButton;
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
            }
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
                _mouseSprite.Draw(window, RenderStates.Default);
            }
        }

        public void DrawSpaceStationUI(RectangleShape invisibleRec, RenderWindow window, Font font, int posX, int posY, Building building)
        {
            if (_menuON)
            {
                RectangleShape rec = new RectangleShape();
                rec.Size = new Vector2f(_boxSize * 12, _boxSize * 6);
                rec.Position = new Vector2f((float)building.SpritePosition.Y * 32 - _boxSize * 6, (float)building.SpritePosition.X * 32 - _boxSize * 2);
                rec.FillColor = new Color(30, 30, 40);
                rec.Draw(window, RenderStates.Default);

                if (!invisibleRec.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    _menuON = false;
                }

                RectangleShape[] tabs = new RectangleShape[4];
                RectangleShape tab = new RectangleShape();
                tab.Size = new Vector2f(rec.Size.X / 4, _boxSize);
                tab.Position = new Vector2f(rec.Position.X, rec.Position.Y);
                tabs[0] = tab;

                RectangleShape tab1 = new RectangleShape();
                tab1.Size = new Vector2f(rec.Size.X / 4, _boxSize);
                tab1.Position = new Vector2f(rec.Position.X + _boxSize * 3, rec.Position.Y);
                tabs[1] = tab1;

                RectangleShape tab2 = new RectangleShape();
                tab2.Size = new Vector2f(rec.Size.X / 4, _boxSize);
                tab2.Position = new Vector2f(rec.Position.X + _boxSize * 6, rec.Position.Y);
                tabs[2] = tab2;

                RectangleShape tab3 = new RectangleShape();
                tab3.Size = new Vector2f(rec.Size.X / 4, _boxSize);
                tab3.Position = new Vector2f(rec.Position.X + _boxSize * 9, rec.Position.Y);
                tabs[3] = tab3;

                Text[] texts = new Text[4];
                Text s = new Text("Ship 1", font);
                s.CharacterSize = 20;
                s.Position = new Vector2f(rec.Position.X + 5, rec.Position.Y + 3);
                s.Color = new Color(30, 30, 40);
                texts[0] = s;

                Text s1 = new Text("Ship 2", font);
                s1.CharacterSize = 20;
                s1.Position = new Vector2f(rec.Position.X + 5 + _boxSize * 3, rec.Position.Y + 3);
                s1.Color = new Color(30, 30, 40);
                texts[1] = s1;

                Text s2 = new Text("Ship 3", font);
                s2.CharacterSize = 20;
                s2.Position = new Vector2f(rec.Position.X + 5 + _boxSize * 6, rec.Position.Y + 3);
                s2.Color = new Color(30, 30, 40);
                texts[2] = s2;

                Text s3 = new Text("Ship 4", font);
                s3.CharacterSize = 20;
                s3.Position = new Vector2f(rec.Position.X + 5 + _boxSize * 9, rec.Position.Y + 3);
                s3.Color = new Color(30, 30, 40);
                texts[3] = s3;

                RectangleShape availability = new RectangleShape();
                availability.Size = new Vector2f(64, 12);
                availability.Position = new Vector2f(rec.Position.X + 16, rec.Position.Y + _boxSize + 5);
                _availabilities[0] = availability;

                RectangleShape availability1 = new RectangleShape();
                availability1.Size = new Vector2f(64, 12);
                availability1.Position = new Vector2f(rec.Position.X + _boxSize * 3 + 16, rec.Position.Y + _boxSize + 5);
                _availabilities[1] = availability1;

                RectangleShape availability2 = new RectangleShape();
                availability2.Size = new Vector2f(64, 12);
                availability2.Position = new Vector2f(rec.Position.X + 16 + _boxSize * 6, rec.Position.Y + _boxSize + 5);
                _availabilities[2] = availability2;

                RectangleShape availability3 = new RectangleShape();
                availability3.Size = new Vector2f(64, 12);
                availability3.Position = new Vector2f(rec.Position.X + 16 + _boxSize * 9, rec.Position.Y + _boxSize + 5);
                _availabilities[3] = availability3;

                _sendButton.Position = new Vector2f(rec.Position.X + _boxSize * 3, rec.Position.Y + _boxSize * 5 - 5);
                _sendActifButton.Position = new Vector2f(rec.Position.X + _boxSize * 3, rec.Position.Y + _boxSize * 5 - 5);

                for (int i = 0; i < 4; i++)
                {
                    tabs[i].Draw(window, RenderStates.Default);
                    texts[i].Draw(window, RenderStates.Default);
                }

                for (int i = 0; i < _tab.Count; i++)
                {
                    if (tab.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                    {
                        _tab[0] = true;
                        _tab[1] = false;
                        _tab[2] = false;
                        _tab[3] = false;
                        TabActive = 0;
                    }
                    if (tab1.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                    {
                        _tab[0] = false;
                        _tab[1] = true;
                        _tab[2] = false;
                        _tab[3] = false;
                        TabActive = 1;
                    }
                    if (tab2.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                    {
                        _tab[0] = false;
                        _tab[1] = false;
                        _tab[2] = true;
                        _tab[3] = false;
                        TabActive = 2;
                    }
                    if (tab3.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                    {
                        _tab[0] = false;
                        _tab[1] = false;
                        _tab[2] = false;
                        _tab[3] = true;
                        TabActive = 3;
                    }
                }
                
                tabs[TabActive].FillColor = Color.Yellow;
                tabs[TabActive].Draw(window, RenderStates.Default);
                texts[TabActive].Draw(window, RenderStates.Default);

                Sprite send = _sendButton;

                wood.Position = new Vector2f(rec.Position.X + _boxSize, rec.Position.Y + _boxSize * 2);
                woodChosen.Position = new Vector2f(rec.Position.X + _boxSize, rec.Position.Y + _boxSize * 2);
                metal.Position = new Vector2f(rec.Position.X + _boxSize * 4, rec.Position.Y + _boxSize * 2);
                metalChosen.Position = new Vector2f(rec.Position.X + _boxSize * 4, rec.Position.Y + _boxSize * 2);
                rock.Position = new Vector2f(rec.Position.X + _boxSize * 7, rec.Position.Y + _boxSize * 2);
                rockChosen.Position = new Vector2f(rec.Position.X + _boxSize * 7, rec.Position.Y + _boxSize * 2);

                for (int i = 0; i < _spriteMenu.Count; i++)
                {
                    _spriteMenu[i].Draw(window, RenderStates.Default);
                    if(building.ShipList[TabActive].Resource == "")
                    {
                        if(_spriteMenu[i].GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
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
                            _availabilities[TabActive].FillColor = Color.Green;
                        else
                        {
                            _availabilities[TabActive].FillColor = Color.Red;
                        }
                        _availabilities[TabActive].Draw(window, RenderStates.Default);

                        if (_sendButton.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                        {
                            send = _sendActifButton;
                            if (Mouse.IsButtonPressed(Mouse.Button.Left))
                            {
                                _sent = true;
                                _activeSpaceStation = building.Type.List[i];
                                _undisposedTime = _ctx.GameTime.InGameTime;
                                _ship = _activeSpaceStation.ShipList[TabActive];
                            }
                        }
                        else send = _sendButton;
                    }
                }
                send.Draw(window, RenderStates.Default);
            }
            if (_sent)
            {
                _activeSpaceStation.SendShip(_ship, _undisposedTime, _resource);
                _sent = false;
                _menuON = false;
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
            _availabilities[i].FillColor = Color.Green;
            _availabilities[i].Draw(window, RenderStates.Default);
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
    }
}