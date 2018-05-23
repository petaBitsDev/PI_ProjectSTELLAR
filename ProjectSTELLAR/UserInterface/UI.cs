using System;
using System.Globalization;
using System.Collections.Generic;
using System.Threading;
using SFML.Graphics;
using SFML.System;
using ProjectStellar.Library;
using SFML.Window;
using System.Collections.Generic;

namespace ProjectStellar
{
    public class UI
    {
        List<Sprite> _sprites;
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
        Dictionary<Sprite, Building> _chosenBuildings;
        private bool _tab1Selected;
        private bool _tab2Selected;
        private bool _tab3Selected;
        private int _buildingSelected;

        Sprite _play;
        Sprite _pause;
        Sprite _fastForward;
        Sprite _navbarSprite;
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
        private List<Building> _buildingList;
        private ResourcesManager _resourcesManager;
        private ExperienceManager _experienceManager;

        public UI(Game ctx, Resolution resolution, Map context, DrawUI drawUI, uint width, uint height, GameTime gameTime, List<Building> buildingList, ResourcesManager resourcesManager, ExperienceManager experienceManager)
        {
            _sprites = new List<Sprite>();
            _chosenBuildings = new Dictionary<Sprite, Building>();

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

            _coinSprite = new Sprite(_ctx._uiTextures[5])
            {
                Position = new Vector2f((width * _boxSize) + _boxSize, 2),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _woodSprite = new Sprite(_ctx._uiTextures[7])
            {
                Position = new Vector2f((width * _boxSize) + _boxSize, _boxSize + 2),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _pollutionSprite = new Sprite(_ctx._uiTextures[6])
            {
                Position = new Vector2f((width * _boxSize) + _boxSize, _boxSize * 6 + 2),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _buildButton = new Sprite(_ctx._uiTextures[3])
            {
                Position = new Vector2f((Width * 32 + _boxSize), (Height * 32 - _boxSize * 6))
            };

            _destroyButton = new Sprite(_ctx._uiTextures[4])
            {
                Position = new Vector2f((Width * 32 + _boxSize), (Height * 32 - _boxSize * 2)),
                Scale = new Vector2f(2f, 2f)
            };

            _flatSprite = new Sprite(_ctx._buildingsTextures[2])
            {
                Position = new Vector2f((Width * 32 + 160), (Height * 32 - _boxSize * 5 + 20)),
                Scale = new Vector2f(0.5f, 0.5f)
            };

            _hutSprite = new Sprite(_ctx._buildingsTextures[1])
            {
                Position = new Vector2f((Width * 32 /*+ _boxSize*/), (Height * 32 - _boxSize * 5 + 20))
            };


            _houseSprite = new Sprite(_ctx._buildingsTextures[3])
            {
                Position = new Vector2f((Width * 32 + 80), (Height * 32 - _boxSize * 5 + 20))

            };

            _powerPlant = new Sprite(_ctx._buildingsTextures[4])
            {
                Position = new Vector2f((Width * 32 + 120), (Height * 32 - _boxSize * 5 + 20))

            };

            _pumpingStation = new Sprite(_ctx._buildingsTextures[5])
            {
                Position = new Vector2f((Width * 32 + 160), (Height * 32 - _boxSize * 5 + 20))
            };

            _cityHall = new Sprite(_ctx._buildingsTextures[6])
            {
                Position = new Vector2f((Width * 32 + 200), (Height * 32 - _boxSize * 5 + 20))
            };

            _fireStation = new Sprite(_ctx._buildingsTextures[8])
            {
                Position = new Vector2f((Width * 32), (Height * 32 - _boxSize * 5 + 20))
            };

            _hospital = new Sprite(_ctx._buildingsTextures[9])
            {
                Position = new Vector2f((Width * 32 + 40), (Height * 32 - _boxSize * 5 + 20))
            };

            _police = new Sprite(_ctx._buildingsTextures[10])
            {
                Position = new Vector2f((Width * 32 + 80), (Height * 32 - _boxSize * 5 + 20))
            };

            _spaceStation = new Sprite(_ctx._buildingsTextures[11])
            {
                Position = new Vector2f((Width * 32 + 120), (Height * 32 - _boxSize * 5 + 20))
            };

            _sawMill = new Sprite(_ctx._buildingsTextures[12])
            {
                Position = new Vector2f((Width * 32), (Height * 32 - _boxSize * 5 + 20))

            };

            _oreMine = new Sprite(_ctx._buildingsTextures[13])
            {
                Position = new Vector2f((Width * 32 + 40), (Height * 32 - _boxSize * 5 + 20))
            };

            _metalMine = new Sprite(_ctx._buildingsTextures[14])
            {
                Position = new Vector2f((Width * 32 + 80), (Height * 32 - _boxSize * 5 + 20))

            };

            _warehouse = new Sprite(_ctx._buildingsTextures[15])
            {
                Position = new Vector2f((Width * 32 + 160), (Height * 32 - _boxSize * 5 + 20))

            };

            _waterSprite = new Sprite(_ctx._uiTextures[10])
            {
                Position = new Vector2f((width * _boxSize) + _boxSize, _boxSize * 4 + 2),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _electricitySprite = new Sprite(_ctx._uiTextures[11])
            {
                Position = new Vector2f((width * _boxSize) + _boxSize, _boxSize * 5 + 2),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _rockSprite = new Sprite(_ctx._uiTextures[9])
            {
                Position = new Vector2f((width * _boxSize) + _boxSize, _boxSize * 2 + 2),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _metalSprite = new Sprite(_ctx._uiTextures[8])
            {
                Position = new Vector2f((width * _boxSize) + _boxSize, _boxSize * 3 + 2),
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _angrySprite = new Sprite(_ctx._uiTextures[12]);
            _smileSprite = new Sprite(_ctx._uiTextures[14]);
            _confusedSprite = new Sprite(_ctx._uiTextures[13]);
            _navbarSprite = new Sprite(_ctx._uiTextures[15]);

            _expBar = new RectangleShape()
            {
                Size = new Vector2f(200, 30),
                Position = new Vector2f((resolution.X / 10) * 3, resolution.Y - 40)
            };

            _expBarFilled = new RectangleShape(_expBar)
            {
                FillColor = Color.Blue
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
            //Creates resources bar
            //RectangleShape rec = new RectangleShape();
            //rec.OutlineColor = new Color(Color.Red);
            //rec.OutlineThickness = 2.0f;
            //rec.FillColor = new Color(Color.Transparent);
            //rec.Size = new Vector2f(_boxSize, (Height) * _boxSize);
            //rec.Position = new Vector2f((Width * _boxSize) - _boxSize * 3, 2);

            //for(int i = (int)(Width * _boxSize) + (int)(_boxSize * 3); i > (int)(Width * _boxSize); i--)
            //{
            //    for(int j = 0; j < Height * 32; j++)
            //    {
            //        _navbarSprite.Position = new Vector2f(i, j);
            //        _navbarSprite.Draw(window, RenderStates.Default);
            //    }
            //}
            //for(int x = 0; x < Width * 32; x++)
            //{
            //    int y = (int)Height * 32;
            //    _navbarSprite.Position = new Vector2f(x, y);
            //    _navbarSprite.Draw(window, RenderStates.Default);
            //}

            //Displays Coins Sprite and number of coins
            _coinSprite.Draw(window, RenderStates.Default);
            Text nbCoins = new Text(resources["coins"].ToString(), font);
            nbCoins.Position = new Vector2f((Width * _boxSize) + _boxSize * 2 + 3, 6);
            nbCoins.Color = Color.White;
            nbCoins.CharacterSize = 16;
            nbCoins.Style = Text.Styles.Bold;
            nbCoins.Draw(window, RenderStates.Default);

            //Displays Wood Sprite and number of wood
            _woodSprite.Draw(window, RenderStates.Default);
            Text nbWood = new Text(resources["wood"].ToString(), font);
            nbWood.Position = new Vector2f((Width * _boxSize) + _boxSize * 2 + 3, _boxSize + 6);
            nbWood.Color = Color.White;
            nbWood.CharacterSize = 16;
            nbWood.Style = Text.Styles.Bold;
            nbWood.Draw(window, RenderStates.Default);

            //Displays Pollution Sprite and number
            _pollutionSprite.Draw(window, RenderStates.Default);
            Text nbPollution = new Text(resources["pollution"].ToString(), font);
            nbPollution.Position = new Vector2f((Width * _boxSize) + _boxSize * 2 + 3, _boxSize * 6 + 6);
            nbPollution.Color = Color.White;
            nbPollution.CharacterSize = 16;
            nbPollution.Style = Text.Styles.Bold;
            nbPollution.Draw(window, RenderStates.Default);

            _rockSprite.Draw(window, RenderStates.Default);
            Text nbRock = new Text(resources["rock"].ToString(), font);
            nbRock.Position = new Vector2f((Width * _boxSize) + _boxSize * 2 + 3, _boxSize * 2 + 6);
            nbRock.Color = Color.White;
            nbRock.CharacterSize = 16;
            nbRock.Style = Text.Styles.Bold;
            nbRock.Draw(window, RenderStates.Default);

            _metalSprite.Draw(window, RenderStates.Default);
            Text nbMetal = new Text(resources["metal"].ToString(), font);
            nbMetal.Position = new Vector2f((Width * _boxSize) + _boxSize * 2 + 3, _boxSize * 3 + 6);
            nbMetal.Color = Color.White;
            nbMetal.CharacterSize = 16;
            nbMetal.Style = Text.Styles.Bold;
            nbMetal.Draw(window, RenderStates.Default);

            _electricitySprite.Draw(window, RenderStates.Default);
            Text nbElec = new Text(_resourcesManager.ElectricityBalance.ToString(), font);
            nbElec.Position = new Vector2f((Width * _boxSize) + _boxSize * 2 + 3, _boxSize * 4 + 6);
            nbElec.Color = Color.White;
            nbElec.CharacterSize = 16;
            nbElec.Style = Text.Styles.Bold;
            nbElec.Draw(window, RenderStates.Default);

            _waterSprite.Draw(window, RenderStates.Default);
            Text nbWater = new Text(_resourcesManager.WaterBalance.ToString(), font);
            nbWater.Position = new Vector2f((Width * _boxSize) + _boxSize * 2 + 3, _boxSize * 5 + 6);
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
            rec.FillColor = new Color(Color.White);
            rec.Size = new Vector2f((_boxSize * 8) - 4, _boxSize * 4);
            rec.Position = new Vector2f((Width * 32), (Height * 32 - _boxSize * 6));

            RectangleShape onglet1 = new RectangleShape();
            onglet1.OutlineColor = new Color(Color.Blue);
            onglet1.OutlineThickness = 3.0f;
            onglet1.FillColor = new Color(Color.White);
            onglet1.Size = new Vector2f(((_boxSize * 8) / 3) - 6, (_boxSize * 4) / 6);
            onglet1.Position = new Vector2f((Width * 32), (Height * 32 - _boxSize * 6));
            Text text = new Text("Habitation", font);
            text.Color = new Color(Color.Black);
            text.CharacterSize = 12;
            text.Position = new Vector2f((Width * 32) + 2, (Height * 32 - _boxSize * 6));
            text.Style = Text.Styles.Bold;

            RectangleShape onglet2 = new RectangleShape();
            onglet2.OutlineColor = new Color(Color.Red);
            onglet2.OutlineThickness = 3.0f;
            onglet2.FillColor = new Color(Color.White);
            onglet2.Size = new Vector2f(((_boxSize * 8) / 3) - 6, (_boxSize * 4) / 6);
            onglet2.Position = new Vector2f((Width * 32) + 85, (Height * 32 - _boxSize * 6));
            Text publicBuilding = new Text("Public", font);
            publicBuilding.Color = new Color(Color.Black);
            publicBuilding.CharacterSize = 12;
            publicBuilding.Position = new Vector2f((Width * 32) + 88, (Height * 32 - _boxSize * 6));
            publicBuilding.Style = Text.Styles.Bold;

            RectangleShape onglet3 = new RectangleShape();
            onglet3.OutlineColor = new Color(Color.Yellow);
            onglet3.OutlineThickness = 3.0f;
            onglet3.FillColor = new Color(Color.White);
            onglet3.Size = new Vector2f(((_boxSize * 8) / 3) - 6, (_boxSize * 4) / 6);
            onglet3.Position = new Vector2f((Width * 32) + 170, (Height * 32 - _boxSize * 6));
            Text resourcesBuilding = new Text("Resources", font);
            resourcesBuilding.Color = new Color(Color.Black);
            resourcesBuilding.CharacterSize = 12;
            resourcesBuilding.Position = new Vector2f((Width * 32) + 175, (Height * 32 - _boxSize * 6));
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
            rec.FillColor = new Color(Color.White);
            rec.Size = new Vector2f((_boxSize * 6) , _boxSize * 2);
            rec.Position = new Vector2f((Width * 32), (Height * 32 - _boxSize * 3.5f));



            if(_buildingSelected == 1)
            {
                Text hut = new Text("Hut", font);
                hut.Position = rec.Position;
                hut.Color = Color.Black;
                hut.CharacterSize = 13;

                
                _chosenBuildings.TryGetValue(_hutSprite, out Building building);

                if(building != null)
                {
                    window.Draw(rec);

                    Text woodNeeds = new Text("Wood cost : " + building.WoodNeeded, font);
                    woodNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 15);
                    woodNeeds.Color = Color.Black;
                    woodNeeds.CharacterSize = 12;

                    Text rockNeeds = new Text("Rock cost : " + building.RockNeeded, font);
                    rockNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 25);
                    rockNeeds.CharacterSize = 12;
                    rockNeeds.Color = Color.Black;

                    Text metalNeeds = new Text("Metal cost : " + building.MetalNeeded, font);
                    metalNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 35);
                    metalNeeds.CharacterSize = 12;
                    metalNeeds.Color = Color.Black;

                    Text coinNeeds = new Text("Coin cost : " + building.StellarCoinNeeded, font);
                    coinNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 45);
                    coinNeeds.CharacterSize = 12;
                    coinNeeds.Color = Color.Black;



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
                house.Color = Color.Black;
                house.CharacterSize = 13;

                _chosenBuildings.TryGetValue(_houseSprite, out Building building);
                if(building != null)
                {
                    Text woodNeeds = new Text("Wood cost : " + building.WoodNeeded, font);
                    woodNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 15);
                    woodNeeds.Color = Color.Black;
                    woodNeeds.CharacterSize = 12;

                    Text rockNeeds = new Text("Rock cost : " + building.RockNeeded, font);
                    rockNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 25);
                    rockNeeds.CharacterSize = 12;
                    rockNeeds.Color = Color.Black;

                    Text metalNeeds = new Text("Metal cost : " + building.MetalNeeded, font);
                    metalNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 35);
                    metalNeeds.CharacterSize = 12;
                    metalNeeds.Color = Color.Black;

                    Text coinNeeds = new Text("Coin cost : " + building.StellarCoinNeeded, font);
                    coinNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 45);
                    coinNeeds.CharacterSize = 12;
                    coinNeeds.Color = Color.Black;


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
                flat.Color = Color.Black;
                flat.CharacterSize = 13;

                _chosenBuildings.TryGetValue(_flatSprite, out Building building);

                if (building != null)
                {
                    window.Draw(rec);


                    Text woodNeeds = new Text("Wood cost : " + building.WoodNeeded, font);
                    woodNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 15);
                    woodNeeds.Color = Color.Black;
                    woodNeeds.CharacterSize = 12;

                    Text rockNeeds = new Text("Rock cost : " + building.RockNeeded, font);
                    rockNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 25);
                    rockNeeds.CharacterSize = 12;
                    rockNeeds.Color = Color.Black;

                    Text metalNeeds = new Text("Metal cost : " + building.MetalNeeded, font);
                    metalNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 35);
                    metalNeeds.CharacterSize = 12;
                    metalNeeds.Color = Color.Black;

                    Text coinNeeds = new Text("Coin cost : " + building.StellarCoinNeeded, font);
                    coinNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 45);
                    coinNeeds.CharacterSize = 12;
                    coinNeeds.Color = Color.Black;



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
                cityHall.Color = Color.Black;
                cityHall.CharacterSize = 13;

                _chosenBuildings.TryGetValue(_cityHall, out Building building);

                if(building != null)
                {
                    window.Draw(rec);

                    Text woodNeeds = new Text("Wood cost : " + building.WoodNeeded, font);
                    woodNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 15);
                    woodNeeds.Color = Color.Black;
                    woodNeeds.CharacterSize = 12;

                    Text rockNeeds = new Text("Rock cost : " + building.RockNeeded, font);
                    rockNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 25);
                    rockNeeds.CharacterSize = 12;
                    rockNeeds.Color = Color.Black;

                    Text metalNeeds = new Text("Metal cost : " + building.MetalNeeded, font);
                    metalNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 35);
                    metalNeeds.CharacterSize = 12;
                    metalNeeds.Color = Color.Black;

                    Text coinNeeds = new Text("Coin cost : " + building.StellarCoinNeeded, font);
                    coinNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 45);
                    coinNeeds.CharacterSize = 12;
                    coinNeeds.Color = Color.Black;



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
                fireStation.Color = Color.Black;
                fireStation.CharacterSize = 13;

                _chosenBuildings.TryGetValue(_fireStation, out Building building);

                if(building != null)
                {
                    window.Draw(rec);

                    Text woodNeeds = new Text("Wood cost : " + building.WoodNeeded, font);
                    woodNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 15);
                    woodNeeds.Color = Color.Black;
                    woodNeeds.CharacterSize = 12;

                    Text rockNeeds = new Text("Rock cost : " + building.RockNeeded, font);
                    rockNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 25);
                    rockNeeds.CharacterSize = 12;
                    rockNeeds.Color = Color.Black;

                    Text metalNeeds = new Text("Metal cost : " + building.MetalNeeded, font);
                    metalNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 35);
                    metalNeeds.CharacterSize = 12;
                    metalNeeds.Color = Color.Black;

                    Text coinNeeds = new Text("Coin cost : " + building.StellarCoinNeeded, font);
                    coinNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 45);
                    coinNeeds.CharacterSize = 12;
                    coinNeeds.Color = Color.Black;



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
                hospital.Color = Color.Black;
                hospital.CharacterSize = 13;

                _chosenBuildings.TryGetValue(_hospital, out Building building);

                if(building != null)
                {
                    window.Draw(rec);

                    Text woodNeeds = new Text("Wood cost : " + building.WoodNeeded, font);
                    woodNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 15);
                    woodNeeds.Color = Color.Black;
                    woodNeeds.CharacterSize = 12;

                    Text rockNeeds = new Text("Rock cost : " + building.RockNeeded, font);
                    rockNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 25);
                    rockNeeds.CharacterSize = 12;
                    rockNeeds.Color = Color.Black;

                    Text metalNeeds = new Text("Metal cost : " + building.MetalNeeded, font);
                    metalNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 35);
                    metalNeeds.CharacterSize = 12;
                    metalNeeds.Color = Color.Black;

                    Text coinNeeds = new Text("Coin cost : " + building.StellarCoinNeeded, font);
                    coinNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 45);
                    coinNeeds.CharacterSize = 12;
                    coinNeeds.Color = Color.Black;



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
                police.Color = Color.Black;
                police.CharacterSize = 13;

                _chosenBuildings.TryGetValue(_police, out Building building);

                if(building != null)
                {
                    window.Draw(rec);

                    Text woodNeeds = new Text("Wood cost : " + building.WoodNeeded, font);
                    woodNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 15);
                    woodNeeds.Color = Color.Black;
                    woodNeeds.CharacterSize = 12;

                    Text rockNeeds = new Text("Rock cost : " + building.RockNeeded, font);
                    rockNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 25);
                    rockNeeds.CharacterSize = 12;
                    rockNeeds.Color = Color.Black;

                    Text metalNeeds = new Text("Metal cost : " + building.MetalNeeded, font);
                    metalNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 35);
                    metalNeeds.CharacterSize = 12;
                    metalNeeds.Color = Color.Black;

                    Text coinNeeds = new Text("Coin cost : " + building.StellarCoinNeeded, font);
                    coinNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 45);
                    coinNeeds.CharacterSize = 12;
                    coinNeeds.Color = Color.Black;



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
                spaceStation.Color = Color.Black;
                spaceStation.CharacterSize = 13;

                _chosenBuildings.TryGetValue(_spaceStation, out Building building);

                if(building != null)
                {
                    window.Draw(rec);

                    Text woodNeeds = new Text("Wood cost : " + building.WoodNeeded, font);
                    woodNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 15);
                    woodNeeds.Color = Color.Black;
                    woodNeeds.CharacterSize = 12;

                    Text rockNeeds = new Text("Rock cost : " + building.RockNeeded, font);
                    rockNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 25);
                    rockNeeds.CharacterSize = 12;
                    rockNeeds.Color = Color.Black;

                    Text metalNeeds = new Text("Metal cost : " + building.MetalNeeded, font);
                    metalNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 35);
                    metalNeeds.CharacterSize = 12;
                    metalNeeds.Color = Color.Black;

                    Text coinNeeds = new Text("Coin cost : " + building.StellarCoinNeeded, font);
                    coinNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 45);
                    coinNeeds.CharacterSize = 12;
                    coinNeeds.Color = Color.Black;



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
                warehouse.Color = Color.Black;
                warehouse.CharacterSize = 13;

                _chosenBuildings.TryGetValue(_warehouse, out Building building);

                if(building != null)
                {
                    window.Draw(rec);

                    Text woodNeeds = new Text("Wood cost : " + building.WoodNeeded, font);
                    woodNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 15);
                    woodNeeds.Color = Color.Black;
                    woodNeeds.CharacterSize = 12;

                    Text rockNeeds = new Text("Rock cost : " + building.RockNeeded, font);
                    rockNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 25);
                    rockNeeds.CharacterSize = 12;
                    rockNeeds.Color = Color.Black;

                    Text metalNeeds = new Text("Metal cost : " + building.MetalNeeded, font);
                    metalNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 35);
                    metalNeeds.CharacterSize = 12;
                    metalNeeds.Color = Color.Black;

                    Text coinNeeds = new Text("Coin cost : " + building.StellarCoinNeeded, font);
                    coinNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 45);
                    coinNeeds.CharacterSize = 12;
                    coinNeeds.Color = Color.Black;



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
                sawMill.Color = Color.Black;
                sawMill.CharacterSize = 13;

                _chosenBuildings.TryGetValue(_sawMill, out Building building);

                if(building != null)
                {
                    window.Draw(rec);

                    Text woodNeeds = new Text("Wood cost : " + building.WoodNeeded, font);
                    woodNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 15);
                    woodNeeds.Color = Color.Black;
                    woodNeeds.CharacterSize = 12;

                    Text rockNeeds = new Text("Rock cost : " + building.RockNeeded, font);
                    rockNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 25);
                    rockNeeds.CharacterSize = 12;
                    rockNeeds.Color = Color.Black;

                    Text metalNeeds = new Text("Metal cost : " + building.MetalNeeded, font);
                    metalNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 35);
                    metalNeeds.CharacterSize = 12;
                    metalNeeds.Color = Color.Black;

                    Text coinNeeds = new Text("Coin cost : " + building.StellarCoinNeeded, font);
                    coinNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 45);
                    coinNeeds.CharacterSize = 12;
                    coinNeeds.Color = Color.Black;



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
                oreMine.Color = Color.Black;
                oreMine.CharacterSize = 13;

                _chosenBuildings.TryGetValue(_oreMine, out Building building);

                if(building != null)
                {
                    window.Draw(rec);

                    Text woodNeeds = new Text("Wood cost : " + building.WoodNeeded, font);
                    woodNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 15);
                    woodNeeds.Color = Color.Black;
                    woodNeeds.CharacterSize = 12;

                    Text rockNeeds = new Text("Rock cost : " + building.RockNeeded, font);
                    rockNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 25);
                    rockNeeds.CharacterSize = 12;
                    rockNeeds.Color = Color.Black;

                    Text metalNeeds = new Text("Metal cost : " + building.MetalNeeded, font);
                    metalNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 35);
                    metalNeeds.CharacterSize = 12;
                    metalNeeds.Color = Color.Black;

                    Text coinNeeds = new Text("Coin cost : " + building.StellarCoinNeeded, font);
                    coinNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 45);
                    coinNeeds.CharacterSize = 12;
                    coinNeeds.Color = Color.Black;



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
                metalMine.Color = Color.Black;
                metalMine.CharacterSize = 13;

                _chosenBuildings.TryGetValue(_metalMine, out Building building);

                if(building != null)
                {
                    window.Draw(rec);

                    Text woodNeeds = new Text("Wood cost : " + building.WoodNeeded, font);
                    woodNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 15);
                    woodNeeds.Color = Color.Black;
                    woodNeeds.CharacterSize = 12;

                    Text rockNeeds = new Text("Rock cost : " + building.RockNeeded, font);
                    rockNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 25);
                    rockNeeds.CharacterSize = 12;
                    rockNeeds.Color = Color.Black;

                    Text metalNeeds = new Text("Metal cost : " + building.MetalNeeded, font);
                    metalNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 35);
                    metalNeeds.CharacterSize = 12;
                    metalNeeds.Color = Color.Black;

                    Text coinNeeds = new Text("Coin cost : " + building.StellarCoinNeeded, font);
                    coinNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 45);
                    coinNeeds.CharacterSize = 12;
                    coinNeeds.Color = Color.Black;



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
                powerPlant.Color = Color.Black;
                powerPlant.CharacterSize = 13;

                _chosenBuildings.TryGetValue(_powerPlant, out Building building);

                if(building != null)
                {
                    window.Draw(rec);

                    Text woodNeeds = new Text("Wood cost : " + building.WoodNeeded, font);
                    woodNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 15);
                    woodNeeds.Color = Color.Black;
                    woodNeeds.CharacterSize = 12;

                    Text rockNeeds = new Text("Rock cost : " + building.RockNeeded, font);
                    rockNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 25);
                    rockNeeds.CharacterSize = 12;
                    rockNeeds.Color = Color.Black;

                    Text metalNeeds = new Text("Metal cost : " + building.MetalNeeded, font);
                    metalNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 35);
                    metalNeeds.CharacterSize = 12;
                    metalNeeds.Color = Color.Black;

                    Text coinNeeds = new Text("Coin cost : " + building.StellarCoinNeeded, font);
                    coinNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 45);
                    coinNeeds.CharacterSize = 12;
                    coinNeeds.Color = Color.Black;



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
                pumpingStation.Color = Color.Black;
                pumpingStation.CharacterSize = 13;

                _chosenBuildings.TryGetValue(_pumpingStation, out Building building);

                if(building != null)
                {
                    window.Draw(rec);

                    Text woodNeeds = new Text("Wood cost : " + building.WoodNeeded, font);
                    woodNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 15);
                    woodNeeds.Color = Color.Black;
                    woodNeeds.CharacterSize = 12;

                    Text rockNeeds = new Text("Rock cost : " + building.RockNeeded, font);
                    rockNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 25);
                    rockNeeds.CharacterSize = 12;
                    rockNeeds.Color = Color.Black;

                    Text metalNeeds = new Text("Metal cost : " + building.MetalNeeded, font);
                    metalNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 35);
                    metalNeeds.CharacterSize = 12;
                    metalNeeds.Color = Color.Black;

                    Text coinNeeds = new Text("Coin cost : " + building.StellarCoinNeeded, font);
                    coinNeeds.Position = new Vector2f(rec.Position.X + 10, rec.Position.Y + 45);
                    coinNeeds.CharacterSize = 12;
                    coinNeeds.Color = Color.Black;



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
            _sprites.Clear();
            _chosenBuildings.Clear();

            if (IsTab1Active == true)
            {

                _hutSprite.Draw(window, RenderStates.Default);
                _sprites.Add(_hutSprite);
                _chosenBuildings.Add(_hutSprite, _buildingList[13]);

                if (_hutSprite.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    _buildingSelected = 1;
                }


                //_buildingChoices[j++] = new BuildingChoice(_hutSprite,);

                _houseSprite.Draw(window, RenderStates.Default);
                _sprites.Add(_houseSprite);
                _chosenBuildings.Add(_houseSprite, _buildingList[12]);
                //_buildingChoices[j++] = _houseSprite;

                if (_houseSprite.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    _buildingSelected = 2;
                }


                _flatSprite.Draw(window, RenderStates.Default);
                _sprites.Add(_flatSprite);
                _chosenBuildings.Add(_flatSprite, _buildingList[11]);
                //_buildingChoices[j++] = _flatSprite;

                if (_flatSprite.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    _buildingSelected = 3;
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

                        _waterSprite.Draw(window, RenderStates.Default);
                        Text water = new Text("Water consomation : ", font);
                        Text nbWater = new Text(_buildingList[i].WaterConsume + "/H", font);
                        water.Position = new Vector2f((X * 32 + 12), (Y * 32 - 32 * 5.9f));
                        nbWater.Position = new Vector2f((X * 32 + 100), (Y * 32 - 32 * 5.35f));
                        nbWater.Color = new Color(52, 152, 219);
                        water.Color = new Color(52, 152, 219);
                        water.CharacterSize = 17;
                        nbWater.CharacterSize = 14;
                        nbWater.Style = Text.Styles.Bold;
                        nbWater.Draw(window, RenderStates.Default);
                        water.Draw(window, RenderStates.Default);

                        _electricitySprite.Draw(window, RenderStates.Default);
                        Text electricity = new Text("Electricity consomation : ", font);
                        electricity.Position = new Vector2f((X * 32 + 12), (Y * 32 - 32 * 4.9f));
                        electricity.Color = new Color(236, 193, 5);
                        electricity.CharacterSize = 17;
                        Text nbElectricity = new Text(_buildingList[i].ElectricityConsume + "/H", font);
                        nbElectricity.Position = new Vector2f((X * 32 + 100), (Y * 32 - 32 * 4.35f));
                        nbElectricity.CharacterSize = 14;
                        nbElectricity.Color = new Color(236, 193, 5);
                        nbElectricity.Style = Text.Styles.Bold;
                        nbElectricity.Draw(window, RenderStates.Default);
                        electricity.Draw(window, RenderStates.Default);

                        if (_buildingList[i].CostMoney == true)
                        {
                            _coinSprite.Draw(window, RenderStates.Default);
                            Text charges = new Text("Charges : ", font);
                            charges.Position = new Vector2f((X * 32 + 12), (Y * 32 - 32 * 3.9f));
                            charges.Color = new Color(203, 67, 53);
                            charges.CharacterSize = 17;
                            Text nbCharges = new Text(_buildingList[i].MoneyWinOrLost + "/H", font);
                            nbCharges.Position = new Vector2f((X * 32 + 100), (Y * 32 - 32 * 3.35f));
                            nbCharges.CharacterSize = 14;
                            nbCharges.Color = new Color(203, 67, 53);
                            nbCharges.Style = Text.Styles.Bold;
                            nbCharges.Draw(window, RenderStates.Default);
                            charges.Draw(window, RenderStates.Default);
                        }
                        else
                        {
                            _coinSprite.Draw(window, RenderStates.Default);
                            Text charges = new Text("Taxes : ", font);
                            charges.Position = new Vector2f((X * 32 + 12), (Y * 32 - 35 * 3.9f));
                            charges.Color = new Color(68, 198, 14);
                            charges.CharacterSize = 17;
                            Text nbCharges = new Text(_buildingList[i].MoneyWinOrLost + "/H", font);
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

        public bool CheckBuildingToBuild(float x, float y, ResourcesManager resources)
        {
            if (_buildSelected == false) return false;
            for (int i = 0; i < _sprites.Count; i++)
            {
                if (_sprites[i].GetGlobalBounds().Contains(x, y))
                {
                    _chosenBuildings.TryGetValue(_sprites[i], out Building building);
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

        public Map Map
        {
            get { return _mapCtx; }
            set { _mapCtx = value; }
        }
    }
}