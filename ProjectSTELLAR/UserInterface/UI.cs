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
        bool _buildSelected;

        Sprite _play;
        Sprite _pause;
        Sprite _fastForward;
        Sprite _coinSprite;
        Sprite _woodSprite;
        Sprite _pollutionSprite;
        Sprite _buildButton;
        Sprite _flatSprite;
        Sprite _hutSprite;
        Sprite _houseSprite;
        RectangleShape _rectangleTimeBar;
        private Sprite _coinSprite;
        private Sprite _woodSprite;
        private Sprite _pollutionSprite;
        private Sprite _buildButton;
        private Sprite _flatSprite;
        private Sprite _hutSprite;
        private Sprite _houseSprite;
        private BuildingChoice[] _buildingChoices;

        public UI(Game ctx, Resolution resolution, Map context, DrawUI drawUI, uint width, uint height, GameTime gameTime)
        {
            _sprites = new List<Sprite>();

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

            _play = new Sprite(_ctx._uiTextures[0])
            {
                Position = new Vector2f(64, _resolution.Y - 32),
                //Scale = new Vector2f(_resolution.X / 33.75f)
            };

            _pause = new Sprite(_ctx._uiTextures[1])
            {
                Position = new Vector2f(10, _resolution.Y - 32),
                //Scale = new Vector2f(_resolution.X / 33.75f)
            };

            _fastForward = new Sprite(_ctx._uiTextures[2])
            {
                Position = new Vector2f(128, _resolution.Y - 32),
                //Scale = new Vector2f(_resolution.X / 33.75f)
            };

            _rectangleTimeBar = new RectangleShape()
            {
                FillColor = Color.White,
                Size = new Vector2f(300, 100),
                Position = new Vector2f(0, _resolution.Y - 100)
            };

            _coinSprite = new Sprite(_ctx._uiTextures[5])
            {
                Position = new Vector2f((width / 2 * _boxSize) + _boxSize, 0)
            };

            _woodSprite = new Sprite(_ctx._uiTextures[7])
            {
                Position = new Vector2f((width / 2 * _boxSize) + _boxSize * 3, 0)
            };

            _pollutionSprite = new Sprite(_ctx._uiTextures[6])
            {
                Position = new Vector2f((Width / 2 * _boxSize) + _boxSize * 5, 0)
            };

            _buildButton = new Sprite(_ctx._uiTextures[3])
            {
                Position = new Vector2f((Width * 32 + _boxSize), (Height * 32 - _boxSize * 5))
            };

            _flatSprite = new Sprite(_ctx._buildingsTextures[2])
            {
                Position = new Vector2f((Width * 32 + _boxSize + 128), (Height * 32 - _boxSize * 5))
            };

            _hutSprite = new Sprite(_ctx._buildingsTextures[1])
            {
                Position = new Vector2f((Width * 32 + _boxSize), (Height * 32 - _boxSize * 5))
            };

            _houseSprite = new Sprite(_ctx._buildingsTextures[3])
            {
                Position = new Vector2f((Width * 32 + _boxSize + 64), (Height * 32 - _boxSize * 5))
            };

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
            RectangleShape rec = new RectangleShape();
            rec.OutlineColor = new Color(Color.Red);
            rec.OutlineThickness = 2.0f;
            rec.FillColor = new Color(Color.Transparent);
            rec.Size = new Vector2f((Width) * _boxSize, (1 * _boxSize) + 1);
            rec.Position = new Vector2f((0 * _boxSize), (0 * _boxSize) + 1);

            //Displays Coins Sprite and number of coins
            _coinSprite.Draw(window, RenderStates.Default);
            Text nbCoins = new Text(resources["coins"].ToString(), font);
            nbCoins.Position = new Vector2f((Width / 2 * _boxSize) + _boxSize * 2, 0);
            nbCoins.Color = Color.Black;
            nbCoins.CharacterSize = 13;
            nbCoins.Style = Text.Styles.Bold;
            nbCoins.Draw(window, RenderStates.Default);

            //Displays Wood Sprite and number of wood
            _woodSprite.Draw(window, RenderStates.Default);
            Text nbWood = new Text(resources["wood"].ToString(), font);
            nbWood.Position = new Vector2f((Width / 2 * _boxSize) + _boxSize * 4, 0);
            nbWood.Color = Color.Black;
            nbWood.CharacterSize = 13;
            nbWood.Style = Text.Styles.Bold;
            nbWood.Draw(window, RenderStates.Default);

            //Displays Pollution Sprite and number
            _pollutionSprite.Draw(window, RenderStates.Default);
            Text nbPollution = new Text(resources["pollution"].ToString(), font);
            nbPollution.Position = new Vector2f((Width / 2 * _boxSize) + _boxSize * 6, 0);
            nbPollution.Color = Color.Black;
            nbPollution.CharacterSize = 13;
            nbPollution.Style = Text.Styles.Bold;
            nbPollution.Draw(window, RenderStates.Default);

            window.Draw(rec);
        }

        public void DrawTimeBar(RenderWindow window, GameTime gameTime, Font font)
        {
            Text Time = new Text(gameTime.InGameTime.ToString("dd/MM/yyyy HH:mm"), font)
            {
                Position = new Vector2f(0, _resolution.Y - 96),
                Color = Color.Black
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
            rec.Position = new Vector2f((Width * 32), (Height * 32 - _boxSize * 5));

            _buildButton.Draw(window, RenderStates.Default);

            if(_buildButton.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
            {
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    _buildSelected = true;
                }
            }
            if (_buildSelected)
            {
                window.Draw(rec);
                if (rec.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    int j = 0;

                    window.Draw(rec);

                    _hutSprite.Draw(window, RenderStates.Default);
                    Text hut = new Text("HUT", font);
                    hut.Position = new Vector2f((Width * 32 + _boxSize), (Height * 32 - _boxSize * 4));
                    hut.Color = Color.Black;
                    hut.CharacterSize = 13;
                    hut.Style = Text.Styles.Bold;
                    hut.Draw(window, RenderStates.Default);
                    //_buildingChoices[j++] = new BuildingChoice(_hutSprite,);

                    _houseSprite.Draw(window, RenderStates.Default);
                    Text house = new Text("HOUSE", font);
                    house.Position = new Vector2f((Width * 32 + _boxSize + 64), (Height * 32 - _boxSize * 4));
                    house.Color = Color.Black;
                    house.CharacterSize = 13;
                    house.Style = Text.Styles.Bold;
                    house.Draw(window, RenderStates.Default);
                    //_buildingChoices[j++] = _houseSprite;

                    _flatSprite.Draw(window, RenderStates.Default);
                    Text flat = new Text("FLAT", font);
                    flat.Position = new Vector2f((Width * 32 + _boxSize + 128), (Height * 32 - _boxSize * 4));
                    flat.Color = Color.Black;
                    flat.CharacterSize = 13;
                    flat.Style = Text.Styles.Bold;
                    flat.Draw(window, RenderStates.Default);
                    //_buildingChoices[j++] = _flatSprite;
                }
                else _buildSelected = false;
            }
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

        //public bool CheckBuildingToBuild(float x, float y)
        //{

        //}
    }
}
