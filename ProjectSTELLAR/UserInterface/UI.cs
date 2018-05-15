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

        private BuildingChoice[] _buildingChoices;
        private List<Building> _buildingList;
        private ResourcesManager _resourcesManager;

        public UI(Game ctx, Resolution resolution, Map context, DrawUI drawUI, uint width, uint height, GameTime gameTime, List<Building> buildingList, ResourcesManager resourcesManager)
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
                Size = new Vector2f(_resolution.X - _boxSize*4 + 10, _boxSize),
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
                Position = new Vector2f((Width * 32 + _boxSize), (Height * 32 - _boxSize * 5))
            };

            _destroyButton = new Sprite(_ctx._uiTextures[4])
            {
                Position = new Vector2f((Width * 32 + _boxSize), (Height * 32 - _boxSize * 2)),
                Scale = new Vector2f(2f, 2f)
            };

            _flatSprite = new Sprite(_ctx._buildingsTextures[2])
            {
                Position = new Vector2f((Width * 32), (Height * 32 - _boxSize * 5)),
                Scale = new Vector2f(0.5f,0.5f)
            };

            _hutSprite = new Sprite(_ctx._buildingsTextures[1])
            {
                Position = new Vector2f((Width * 32 - _boxSize*4), (Height * 32 - _boxSize * 5))
            };

            _houseSprite = new Sprite(_ctx._buildingsTextures[3])
            {
                Position = new Vector2f((Width * 32 - _boxSize * 2), (Height * 32 - _boxSize * 5))
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
            rec.Size = new Vector2f(_boxSize * 8, _boxSize * 4);
            rec.Position = new Vector2f((Width * 32) - _boxSize*5, (Height * 32 - _boxSize * 6));

            _buildButton.Draw(window, RenderStates.Default);
            
            if (_buildSelected)
            {
                if (rec.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    int j = 0;

                    window.Draw(rec);

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
            if(_buildButton.GetGlobalBounds().Contains((float) Mouse.GetPosition(window).X, (float) Mouse.GetPosition(window).Y))
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

        public bool CheckTimeBar(float x, float y)
        {
            if (_pause.GetGlobalBounds().Contains(x, y))
            {
                _gameTime.TimeScale = 0;
            }
            else if (_play.GetGlobalBounds().Contains(x, y))
            {
                _gameTime.TimeScale = 60;
            }
            else if (_fastForward.GetGlobalBounds().Contains(x, y))
            {
                _gameTime.TimeScale += 100;
            }
            else return false;

            return true;
        }

        private void DrawBuildingChoices(RenderWindow window, Font font)
        {
            _sprites.Clear();
            _chosenBuildings.Clear();

            _hutSprite.Draw(window, RenderStates.Default);
            Text hut = new Text("HUT", font);
            hut.Position = new Vector2f((Width * 32 - _boxSize * 4), (Height * 32 - _boxSize * 4));
            hut.Color = Color.Black;
            hut.CharacterSize = 13;
            hut.Style = Text.Styles.Bold;
            hut.Draw(window, RenderStates.Default);
            _sprites.Add(_hutSprite);
            _chosenBuildings.Add(_hutSprite, _buildingList[13]);
            
            //_buildingChoices[j++] = new BuildingChoice(_hutSprite,);

            _houseSprite.Draw(window, RenderStates.Default);
            Text house = new Text("HOUSE", font);
            house.Position = new Vector2f((Width * 32 - _boxSize * 2), (Height * 32 - _boxSize * 4));
            house.Color = Color.Black;
            house.CharacterSize = 13;
            house.Style = Text.Styles.Bold;
            house.Draw(window, RenderStates.Default);
            _sprites.Add(_houseSprite);
            _chosenBuildings.Add(_houseSprite, _buildingList[12]);
            //_buildingChoices[j++] = _houseSprite;

            _flatSprite.Draw(window, RenderStates.Default);
            Text flat = new Text("FLAT", font);
            flat.Position = new Vector2f((Width * 32), (Height * 32 - _boxSize * 4));
            flat.Color = Color.Black;
            flat.CharacterSize = 13;
            flat.Style = Text.Styles.Bold;
            flat.Draw(window, RenderStates.Default);
            _sprites.Add(_flatSprite);
            _chosenBuildings.Add(_flatSprite, _buildingList[11]);
            //_buildingChoices[j++] = _flatSprite;
        }

        public bool CheckBuildingToBuild(float x, float y)
        {
            if (_buildSelected == false) return false;
            for (int i = 0; i < _sprites.Count; i++)
            {
                if (_sprites[i].GetGlobalBounds().Contains(x, y))
                {
                    _chosenBuildings.TryGetValue(_sprites[i], out Building building);
                    if (!_resourcesManager.CheckResourcesNeeded(building)) return false;
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
    }
}
