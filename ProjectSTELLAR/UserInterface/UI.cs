using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using ProjectStellar.Library;
using SFML.Window;
using System.Windows.Input;
using System.Windows.Forms;

namespace ProjectStellar
{
    class UI
    {
        CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
        Game _ctx;
        DrawUI _drawUIctx;
        Map _mapCtx;
        Resolution _resolution;
        uint _width;
        uint _height;
        uint _boxSize = 32;

        Sprite _play;
        Sprite _pause;
        Sprite _fastForward;
        RectangleShape _rectangleTimeBar;

        public UI(Game ctx, Resolution resolution, Map context, DrawUI drawUI, uint width, uint height)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
            _ctx = ctx;
            _drawUIctx = drawUI;
            _mapCtx = context;
            _height = height;
            _width = width;
            _resolution = resolution;
            _drawUIctx = drawUI;

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
        }

        public uint Width => _width;

        public uint Height => _height;

        /// <summary>
        /// Draws the resources bar.
        /// </summary>
        /// <param name="window">The window.</param>
        public void DrawResourcesBar(RenderWindow window, Font font, Dictionary<string, int> resources)
        {
            Sprite coinSprite = new Sprite(_ctx._uiTextures[5]);
            Sprite woodSprite = new Sprite(_ctx._uiTextures[7]);
            Sprite pollutionSprite = new Sprite(_ctx._uiTextures[6]);

            //Creates resources bar
            RectangleShape rec = new RectangleShape();
            rec.OutlineColor = new Color(Color.Red);
            rec.OutlineThickness = 2.0f;
            rec.FillColor = new Color(Color.Transparent);
            rec.Size = new Vector2f((Width - 1) * _boxSize, (1 * _boxSize) + 1);
            rec.Position = new Vector2f((0 * _boxSize), (0 * _boxSize) + 1);

            //Displays Coins Sprite and number of coins
            _drawUIctx.RenderSprite(coinSprite, window, (Width / 2 * _boxSize) + _boxSize, 0, 0, 0, (int)_boxSize, (int)_boxSize);
            Text nbCoins = new Text(resources["coins"].ToString(), font);
            nbCoins.Position = new Vector2f((Width / 2 * _boxSize) + _boxSize * 2, 0);
            nbCoins.Color = Color.Black;
            nbCoins.CharacterSize = 13;
            nbCoins.Style = Text.Styles.Bold;
            nbCoins.Draw(window, RenderStates.Default);

            //Displays Wood Sprite and number of wood
            _drawUIctx.RenderSprite(woodSprite, window, (Width / 2 * _boxSize) + _boxSize * 3, 0, 0, 0, (int)_boxSize, (int)_boxSize);
            Text nbWood = new Text(resources["wood"].ToString(), font);
            nbWood.Position = new Vector2f((Width / 2 * _boxSize) + _boxSize * 4, 0);
            nbWood.Color = Color.Black;
            nbWood.CharacterSize = 13;
            nbWood.Style = Text.Styles.Bold;
            nbWood.Draw(window, RenderStates.Default);
            
            //Displays Pollution Sprite and number
            _drawUIctx.RenderSprite(pollutionSprite, window, (Width / 2 * _boxSize) + _boxSize * 5, 0, 0, 0, (int)_boxSize, (int)_boxSize);
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
        private bool MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                return true;
            }
            return false;
        }

        public void DrawBuildButton(RenderWindow window)
        {
            Sprite buildButton = new Sprite(_ctx._uiTextures[3]);
            bool isSelected = false;

            _drawUIctx.RenderSprite(buildButton, window, (Width * 32 - _boxSize * 4), (Height * 32 - _boxSize * 4), 0, 0, 64, 64);

            if(buildButton.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
            {
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    isSelected = true;
                }
                if (isSelected)
                {
                    RectangleShape rec = new RectangleShape();
                    rec.OutlineColor = new Color(Color.Black);
                    rec.OutlineThickness = 3.0f;
                    rec.FillColor = new Color(Color.White);
                    rec.Size = new Vector2f(_boxSize * 8, _boxSize * 4);
                    rec.Position = new Vector2f(Width / 2 * _boxSize, Height / 2 * _boxSize);

                    window.Draw(rec);
                }
            }
        }
    }
}
