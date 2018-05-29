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
        Dictionary<Sprite, String> _sprites;
        CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
        Game _ctx;
        DrawUI _drawUIctx;
        Map _mapCtx;
        GameTime _gameTime;
        Resolution _resolution;
        uint _width;
        uint _height;
        uint _boxSize = 32;
        private bool _buildSelected;
        private bool _destroySelected;
        Dictionary<Sprite, BuildingType> _chosenBuildings;
        private bool _tab1Selected;
        private bool _tab2Selected;
        private bool _tab3Selected;
        private string _buildingSelected;
        bool _settingsSelected;
        bool _exitSelected;

        Sprite _play;
        Sprite _pause;
        Sprite _fastForward;
        Sprite _navbarSprite;
        Sprite _exitButton;
        Sprite _settingsButton;
        RectangleShape _rectangleTimeBar;
        private Sprite _coinSprite;
        private Sprite _woodSprite;
        private Sprite _pollutionSprite;
        private Sprite _buildButton;
        private Sprite _destroyButton;
        private Sprite _flatSprite;
        private Sprite _hutSprite;
        private Sprite _houseSprite;
        private Sprite _waterSprite;
        private Sprite _electricitySprite;
        private Sprite _metalSprite;
        private Sprite _rockSprite;
        private Sprite _smileSprite;
        private Sprite _angrySprite;
        private Sprite _confusedSprite;
        private Sprite _powerPlant;
        private Sprite _pumpingStation;
        private Sprite _cityHall;
        private Sprite _fireStation;
        private Sprite _hospital;
        private Sprite _police;
        private Sprite _spaceStation;
        private Sprite _sawMill;
        private Sprite _metalMine;
        private Sprite _oreMine;
        private Sprite _warehouse;
        private RectangleShape _expBar;
        private RectangleShape _expBarFilled;

        private BuildingChoice[] _buildingChoices;
        private List<BuildingType> _buildingList;
        private ResourcesManager _resourcesManager;
        private ExperienceManager _experienceManager;

        public UI(Game ctx, Resolution resolution, Map context, DrawUI drawUI, uint width, uint height, GameTime gameTime, List<BuildingType> buildingList, ResourcesManager resourcesManager, ExperienceManager experienceManager)
        {
            _sprites = new List<Sprite>();
            _chosenBuildings = new Dictionary<Sprite, BuildingType>();

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
            _buildingList = buildingList;
            _buildingChoices = new BuildingChoice[16];
            _resourcesManager = resourcesManager;
            _tab1Selected = true;
            _tab2Selected = false;
            _tab3Selected = false;
            _experienceManager = experienceManager;
            _buildingSelected = 0;

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
                Position = new Vector2f(_resolution.X / 2 + 32, _resolution.Y - _boxSize),
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
                Position = new Vector2f(_resolution.X - _boxSize * 4, _resolution.Y / 2 + _boxSize * 2)
            };

            _destroyButton = new Sprite(_ctx._uiTextures[20])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 4, _resolution.Y / 2 + _boxSize * 4),
                //Scale = new Vector2f(0.5f, 0.5f)
            };
            _settingsButton = new Sprite(_ctx._uiTextures[21])
            {
                //Scale = new Vector2f(0.5f, 0.5f)
            };

            //XP BAR
            _expBar = new RectangleShape()
            {
                Size = new Vector2f(200, 30),
                Position = new Vector2f((resolution.X / 10) * 3, resolution.Y - 40)
            };

            _expBarFilled = new RectangleShape(_expBar)
            {
                FillColor = Color.Blue
            };

            //RESOURCES
            _coinSprite = new Sprite(_ctx._uiTextures[5])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 4, _boxSize * 2),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _woodSprite = new Sprite(_ctx._uiTextures[7])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 4, _boxSize * 3),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _waterSprite = new Sprite(_ctx._uiTextures[10])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 4, _boxSize * 7),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _electricitySprite = new Sprite(_ctx._uiTextures[11])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 4, _boxSize * 8),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _rockSprite = new Sprite(_ctx._uiTextures[9])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 4, _boxSize * 4),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _metalSprite = new Sprite(_ctx._uiTextures[8])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 4, _boxSize * 5),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _pollutionSprite = new Sprite(_ctx._uiTextures[6])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 4, _boxSize * 6),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _angrySprite = new Sprite(_ctx._uiTextures[12]);
            _smileSprite = new Sprite(_ctx._uiTextures[14]);
            _confusedSprite = new Sprite(_ctx._uiTextures[13]);

            _exitButton = new Sprite(_ctx._uiTextures[22]);
            _navbarSprite = new Sprite(_ctx._uiTextures[15]);

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

            //RESOURCES BUILDINGS
            _powerPlant = new Sprite(_ctx._buildingsTextures[4])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 2, _resolution.Y / 2)
            };

            _pumpingStation = new Sprite(_ctx._buildingsTextures[5])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 4, _resolution.Y / 2)
            };
            
            _sawMill = new Sprite(_ctx._buildingsTextures[12])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 6, _resolution.Y / 2)
            };

            _oreMine = new Sprite(_ctx._buildingsTextures[13])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 8, _resolution.Y / 2)
            };

            _metalMine = new Sprite(_ctx._buildingsTextures[14])
            {
                Position = new Vector2f(_resolution.X - _boxSize * 10, _resolution.Y / 2)
            };
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
        public void DrawResourcesBar(RenderWindow window, Font font, Dictionary<string, int> resources)
        {
            //Displays Coins Sprite and number of coins
            _coinSprite.Draw(window, RenderStates.Default);
            Text nbCoins = new Text(resources["coins"].ToString(), font);
            nbCoins.Position = new Vector2f(_resolution.X - _boxSize * 2, _boxSize * 2 + 2);
            nbCoins.Color = Color.White;
            nbCoins.CharacterSize = 16;
            nbCoins.Style = Text.Styles.Bold;
            nbCoins.Draw(window, RenderStates.Default);

            //Displays Wood Sprite and number of wood
            _woodSprite.Draw(window, RenderStates.Default);
            Text nbWood = new Text(resources["wood"].ToString(), font);
            nbWood.Position = new Vector2f(_resolution.X - _boxSize * 2, _boxSize * 3 + 2);
            nbWood.Color = Color.White;
            nbWood.CharacterSize = 16;
            nbWood.Style = Text.Styles.Bold;
            nbWood.Draw(window, RenderStates.Default);

            //Displays Pollution Sprite and number
            _pollutionSprite.Draw(window, RenderStates.Default);
            Text nbPollution = new Text(resources["pollution"].ToString(), font);
            nbPollution.Position = new Vector2f(_resolution.X - _boxSize * 2, _boxSize * 6 + 2);
            nbPollution.Color = Color.White;
            nbPollution.CharacterSize = 16;
            nbPollution.Style = Text.Styles.Bold;
            nbPollution.Draw(window, RenderStates.Default);

            _rockSprite.Draw(window, RenderStates.Default);
            Text nbRock = new Text(resources["rock"].ToString(), font);
            nbRock.Position = new Vector2f(_resolution.X - _boxSize * 2, _boxSize * 4 + 2);
            nbRock.Color = Color.White;
            nbRock.CharacterSize = 16;
            nbRock.Style = Text.Styles.Bold;
            nbRock.Draw(window, RenderStates.Default);

            _metalSprite.Draw(window, RenderStates.Default);
            Text nbMetal = new Text(resources["metal"].ToString(), font);
            nbMetal.Position = new Vector2f(_resolution.X - _boxSize * 2, _boxSize * 5 + 2);
            nbMetal.Color = Color.White;
            nbMetal.CharacterSize = 16;
            nbMetal.Style = Text.Styles.Bold;
            nbMetal.Draw(window, RenderStates.Default);

            _electricitySprite.Draw(window, RenderStates.Default);
            Text nbElec = new Text(resources["electricity"].ToString(), font);
            nbElec.Position = new Vector2f(_resolution.X - _boxSize * 2, _boxSize * 8 + 2);
            nbElec.Color = Color.White;
            nbElec.CharacterSize = 16;
            nbElec.Style = Text.Styles.Bold;
            nbElec.Draw(window, RenderStates.Default);

            _waterSprite.Draw(window, RenderStates.Default);
            Text nbWater = new Text(resources["water"].ToString(), font);
            nbWater.Position = new Vector2f(_resolution.X - _boxSize * 2, _boxSize * 7 + 2);
            nbWater.Color = Color.White;
            nbWater.CharacterSize = 16;
            nbWater.Style = Text.Styles.Bold;
            nbWater.Draw(window, RenderStates.Default);

            //window.Draw(rec);
        }

        public void DrawTimeBar(RenderWindow window, GameTime gameTime, Font font)
        {
            Text Time = new Text(gameTime.InGameTime.ToString("dd/MM/yyyy HH:mm"), font)
            {
                Position = new Vector2f(0, _resolution.Y - 32),
                Color = Color.White,
                CharacterSize = 23,
                Style = Text.Styles.Bold
            };

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
            //rec.Position = new Vector2f((Width * 32), (Height * 32 - _boxSize * 6));

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
                return true;
            }
            return false;
        }

        public bool CheckDestroySelected(RenderWindow window)
        {
            if (_destroyButton.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
            {
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
            
            if(_buildingSelected == 1)
            {
                Text hut = new Text("Hut", font);
                hut.Position = rec.Position;
                hut.Color = Color.White;
                hut.CharacterSize = 18;
                
                _chosenBuildings.TryGetValue(_hutSprite, out BuildingType building);

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
                    window.Draw(hut);
                }
            }
            else if(_buildingSelected == 2)
            {
                Text house = new Text("House", font);
                house.Position = rec.Position;
                house.Color = Color.White;
                house.CharacterSize = 18;

                _chosenBuildings.TryGetValue(_houseSprite, out BuildingType building);
                if(building != null)
                {
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
                    
                    window.Draw(rec);
                    window.Draw(woodNeeds);
                    window.Draw(rockNeeds);
                    window.Draw(metalNeeds);
                    window.Draw(coinNeeds);
                    window.Draw(house);
                }
            }
            else if(_buildingSelected == 3)
            {
                Text flat = new Text("Flat", font);
                flat.Position = rec.Position;
                flat.Color = Color.White;
                flat.CharacterSize = 18;

                _chosenBuildings.TryGetValue(_flatSprite, out BuildingType building);

                if (building != null)
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
                    window.Draw(flat);
                }
            }
            else if(_buildingSelected == 4)
            {
                Text cityHall = new Text("CityHall", font);
                cityHall.Position = rec.Position;
                cityHall.Color = Color.White;
                cityHall.CharacterSize = 18;

                _chosenBuildings.TryGetValue(_cityHall, out BuildingType building);

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
                    window.Draw(cityHall);
                }
            }
            else if(_buildingSelected == 5)
            {
                Text fireStation = new Text("FireStation", font);
                fireStation.Position = rec.Position;
                fireStation.Color = Color.White;
                fireStation.CharacterSize = 18;

                _chosenBuildings.TryGetValue(_fireStation, out BuildingType building);

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
                    window.Draw(fireStation);
                }
            }
            else if(_buildingSelected == 6)
            {
                Text hospital = new Text("Hospital", font);
                hospital.Position = rec.Position;
                hospital.Color = Color.White;
                hospital.CharacterSize = 18;

                _chosenBuildings.TryGetValue(_hospital, out BuildingType building);

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
                    window.Draw(hospital);
                }
            }
            else if(_buildingSelected == 7)
            {
                Text police = new Text("Police", font);
                police.Position = rec.Position;
                police.Color = Color.White;
                police.CharacterSize = 18;

                _chosenBuildings.TryGetValue(_police, out BuildingType building);

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
                    window.Draw(police);
                }
            }
            else if(_buildingSelected == 8)
            {
                Text spaceStation = new Text("Space station", font);
                spaceStation.Position = rec.Position;
                spaceStation.Color = Color.White;
                spaceStation.CharacterSize = 18;

                _chosenBuildings.TryGetValue(_spaceStation, out BuildingType building);

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
                    window.Draw(spaceStation);
                }
            }
            else if(_buildingSelected == 9)
            {
                Text warehouse = new Text("Warehouse", font);
                warehouse.Position = rec.Position;
                warehouse.Color = Color.White;
                warehouse.CharacterSize = 18;

                _chosenBuildings.TryGetValue(_warehouse, out BuildingType building);

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
                    window.Draw(warehouse);
                }
            }
            else if(_buildingSelected == 10)
            {
                Text sawMill = new Text("Sawmill", font);
                sawMill.Position = rec.Position;
                sawMill.Color = Color.White;
                sawMill.CharacterSize = 18;

                _chosenBuildings.TryGetValue(_sawMill, out BuildingType building);

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
                    window.Draw(sawMill);
                }
            }
            else if(_buildingSelected == 11)
            {
                Text oreMine = new Text("Oremine", font);
                oreMine.Position = rec.Position;
                oreMine.Color = Color.White;
                oreMine.CharacterSize = 18;

                _chosenBuildings.TryGetValue(_oreMine, out BuildingType building);

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
                    window.Draw(oreMine);
                }
        
            }
            else if(_buildingSelected == 12)
            {
                Text metalMine = new Text("Metal mine", font);
                metalMine.Position = rec.Position;
                metalMine.Color = Color.White;
                metalMine.CharacterSize = 18;

                _chosenBuildings.TryGetValue(_metalMine, out BuildingType building);

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
                    window.Draw(metalMine);
                }
            }
            else if(_buildingSelected == 13)
            {
                Text powerPlant = new Text("powerPlant", font);
                powerPlant.Position = rec.Position;
                powerPlant.Color = Color.White;
                powerPlant.CharacterSize = 18;

                _chosenBuildings.TryGetValue(_powerPlant, out BuildingType building);

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
                    window.Draw(powerPlant);
                }
            }
            else if(_buildingSelected == 14)
            {
                Text pumpingStation = new Text("pumpingStation", font);
                pumpingStation.Position = rec.Position;
                pumpingStation.Color = Color.White;
                pumpingStation.CharacterSize = 18;

                _chosenBuildings.TryGetValue(_pumpingStation, out BuildingType building);

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
                    window.Draw(pumpingStation);
                }
            }
        }
            
        private void DrawBuildingChoices(RenderWindow window, Font font)
        {
            if (IsTab1Active == true)
            {
                _hutSprite.Draw(window, RenderStates.Default);
                _sprites.Add(_hutSprite, "HUT");
                _houseSprite.Draw(window, RenderStates.Default);
                _sprites.Add(_houseSprite, "HOUSE");
                _flatSprite.Draw(window, RenderStates.Default);
                _sprites.Add(_flatSprite, "FLAT");
                
                foreach(Sprite i in _sprites.Keys)
                { 
                    if(i.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                    {
                        _sprites.TryGetValue(i, out _buildingSelected);
                    }
                }
            }
            else if (IsTab2Active)
            {
                _cityHall.Draw(window, RenderStates.Default);
                _sprites.Add(_cityHall);
                _chosenBuildings.Add(_cityHall, _buildingList[3]);

                if (_cityHall.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    _buildingSelected = 4;
                }
                
                _fireStation.Draw(window, RenderStates.Default);
                _sprites.Add(_fireStation);
                _chosenBuildings.Add(_fireStation, _buildingList[4]);

                if (_fireStation.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    _buildingSelected = 5;
                }
                
                _hospital.Draw(window, RenderStates.Default);
                _sprites.Add(_hospital);
                _chosenBuildings.Add(_hospital, _buildingList[5]);

                if (_hospital.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    _buildingSelected = 6;
                }
                
                _police.Draw(window, RenderStates.Default);
                _sprites.Add(_police);
                _chosenBuildings.Add(_police, _buildingList[6]);

                if (_police.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    _buildingSelected = 7;
                }
                
                _spaceStation.Draw(window, RenderStates.Default);
                _sprites.Add(_spaceStation);
                _chosenBuildings.Add(_spaceStation, _buildingList[9]);

                if (_spaceStation.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    _buildingSelected = 8;
                }

                _warehouse.Draw(window, RenderStates.Default);
                _sprites.Add(_warehouse);
                _chosenBuildings.Add(_warehouse, _buildingList[10]);

                if (_warehouse.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    _buildingSelected = 9;
                }
            }
            else if (IsTab3Active)
            {
                _sawMill.Draw(window, RenderStates.Default);
                _sprites.Add(_sawMill);
                _chosenBuildings.Add(_sawMill, _buildingList[2]);

                if (_sawMill.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    _buildingSelected = 10;
                }
                
                _oreMine.Draw(window, RenderStates.Default);
                _sprites.Add(_oreMine);
                _chosenBuildings.Add(_oreMine, _buildingList[1]);

                if (_oreMine.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    _buildingSelected = 11;
                }
                
                _metalMine.Draw(window, RenderStates.Default);
                _sprites.Add(_metalMine);
                _chosenBuildings.Add(_metalMine, _buildingList[0]);

                if (_metalMine.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    _buildingSelected = 12;
                }


                _powerPlant.Draw(window, RenderStates.Default);
                _sprites.Add(_powerPlant);
                _chosenBuildings.Add(_powerPlant, _buildingList[7]);

                if (_powerPlant.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    _buildingSelected = 13;
                }


                _pumpingStation.Draw(window, RenderStates.Default);
                _sprites.Add(_pumpingStation);
                _chosenBuildings.Add(_pumpingStation, _buildingList[8]);

                if (_pumpingStation.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    _buildingSelected = 14;
                }
            }
        }
           
        public void DrawExperience(RenderWindow window)
        {
            _expBarFilled.Size = new Vector2f(_expBar.Size.X * ((float)_experienceManager.GetPercentage() / 100f), _expBar.Size.Y);
            _expBar.Draw(window, RenderStates.Default);
            _expBarFilled.Draw(window, RenderStates.Default);
        }

        //public bool CheckBuildingToBuild(float x, float y, ResourcesManager resources)
        //{
        //    if (_buildSelected == false) return false;
        //    for (int i = 0; i < _sprites.Count; i++)
        //    {
        //        if (_sprites[i].GetGlobalBounds().Contains(x, y))
        //        {

        //            _chosenBuildings.TryGetValue(_sprites[i], out Building building);
        //            if (!resources.CheckResourcesNeeded(building)) return false;
        //            _mapCtx.ChosenBuilding = building;
        //            //Console.WriteLine(type);
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        //   internal void DrawBuildingNeeds(RenderWindow window, Font font,)

        internal void DrawBuildingInformations(RenderWindow window, Font font, Building building, float X, float Y)
        {
            //RectangleShape rec = new RectangleShape();
            //rec.OutlineColor = new Color(Color.Black);
            //rec.OutlineThickness = 3.0f;
            //rec.FillColor = new Color(Color.White);
            //rec.Size = new Vector2f(32 * 8, 32 * 4);
            //rec.Position = new Vector2f(X, Y);
            //rec.Draw(window, RenderStates.Default);
            if (!object.Equals(building, null))
            {
                for (int i = 0; i < _buildingList.Count; i++)
                {
                    if (_buildingList[i].GetType() == building.GetType())
                    {

                        Text water = new Text("Water consomation : ", font);
                        water.Color = new Color(52, 152, 219);
                        water.Position = new Vector2f((X * 32 + 12), (Y * 32 - 32 * 5.9f));
                        water.CharacterSize = 17;

                        Text nbWater = new Text(_buildingList[i].Water + "/H", font);
                        nbWater.Position = new Vector2f((X * 32 + 100), (Y * 32 - 32 * 5.35f));
                        nbWater.Color = new Color(52, 152, 219);
                        nbWater.CharacterSize = 14;
                        nbWater.Style = Text.Styles.Bold;

                        nbWater.Draw(window, RenderStates.Default);
                        water.Draw(window, RenderStates.Default);

                        Text electricity = new Text("Electricity consomation : ", font);
                        electricity.Position = new Vector2f((X * 32 + 12), (Y * 32 - 32 * 4.9f));
                        electricity.Color = new Color(236, 193, 5);
                        electricity.CharacterSize = 17;

                        Text nbElectricity = new Text(_buildingList[i].Electricity + "/H", font);
                        nbElectricity.Position = new Vector2f((X * 32 + 100), (Y * 32 - 32 * 4.35f));
                        nbElectricity.CharacterSize = 14;
                        nbElectricity.Color = new Color(236, 193, 5);
                        nbElectricity.Style = Text.Styles.Bold;

                        nbElectricity.Draw(window, RenderStates.Default);
                        electricity.Draw(window, RenderStates.Default);

                        if (_buildingList[i].Cost > 0)
                        {
                            _coinSprite.Draw(window, RenderStates.Default);

                            Text charges = new Text("Charges : ", font);
                            charges.Position = new Vector2f((X * 32 + 12), (Y * 32 - 32 * 3.9f));
                            charges.Color = new Color(203, 67, 53);
                            charges.CharacterSize = 17;

                            Text nbCharges = new Text(_buildingList[i].Cost + "/H", font);
                            nbCharges.Position = new Vector2f((X * 32 + 100), (Y * 32 - 32 * 3.35f));
                            nbCharges.CharacterSize = 14;
                            nbCharges.Color = new Color(203, 67, 53);
                            nbCharges.Style = Text.Styles.Bold;

                            nbCharges.Draw(window, RenderStates.Default);
                            charges.Draw(window, RenderStates.Default);
                        }
                        else
                        {

                            Text charges = new Text("Taxes : ", font);
                            charges.Position = new Vector2f((X * 32 + 12), (Y * 32 - 35 * 3.9f));
                            charges.Color = new Color(68, 198, 14);
                            charges.CharacterSize = 17;

                            Text nbCharges = new Text(_buildingList[i].Cost + "/H", font);
                            nbCharges.Position = new Vector2f((X * 32 + 100), (Y * 32 - 32 * 3.35f));
                            nbCharges.CharacterSize = 14;
                            nbCharges.Color = new Color(68, 198, 14);
                            nbCharges.Style = Text.Styles.Bold;

                            nbCharges.Draw(window, RenderStates.Default);
                            charges.Draw(window, RenderStates.Default);
                        }
                    }
                }
            }
        }

        public bool CheckBuildingToBuild(Window window, ResourcesManager resources)
        {
            if (_buildSelected == false) return false;
            for (int i = 0; i < _sprites.Count; i++)
            {
                if (_sprites[i].GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y))
                {
                    _chosenBuildings.TryGetValue(_sprites[i], out BuildingType building);
                    if (!resources.CheckResourcesNeeded(building)) return false;
                    _mapCtx.ChosenBuilding = building;
                    //Console.WriteLine(type);
                    return true;
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

        public void DrawInGameMenu (RenderWindow window, Font font)
        {
            _settingsButton.Position = new Vector2f(_resolution.X - _boxSize, 0);
            _settingsButton.Draw(window, RenderStates.Default);

        }
    }
}