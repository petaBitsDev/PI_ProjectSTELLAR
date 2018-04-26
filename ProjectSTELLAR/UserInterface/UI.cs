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
        }

        public uint Width => _width;

        public uint Height => _height;

        /// <summary>
        /// Draws the resources bar.
        /// </summary>
        /// <param name="window">The window.</param>
        public void DrawResourcesBar(RenderWindow window, DateTime time, Font font, Dictionary<string, int> resources)
        {
            Sprite coinSprite = new Sprite(new Texture(_ctx._uiTextures[5]));
            Sprite woodSprite = new Sprite(new Texture(_ctx._uiTextures[7]));
            Sprite pollutionSprite = new Sprite(new Texture(_ctx._uiTextures[6]));

            RectangleShape rec = new RectangleShape();
            rec.OutlineColor = new Color(Color.Red);
            rec.OutlineThickness = 2.0f;
            rec.FillColor = new Color(Color.Transparent);
            rec.Size = new Vector2f((Width - 1) * _boxSize, (1 * _boxSize) + 1);
            rec.Position = new Vector2f((0 * _boxSize), (0 * _boxSize) + 1);

            _drawUIctx.RenderSprite(coinSprite, window, (Width / 2 * _boxSize) + _boxSize, 0, 0, 0, (int)_boxSize, (int)_boxSize);
            Text nbCoins = new Text(resources["coins"].ToString(), font);
            nbCoins.Position = new Vector2f((Width / 2 * _boxSize) + _boxSize * 2, 0);
            nbCoins.Color = Color.Black;
            nbCoins.CharacterSize = 13;
            nbCoins.Style = Text.Styles.Bold;
            nbCoins.Draw(window, RenderStates.Default);

            _drawUIctx.RenderSprite(woodSprite, window, (Width / 2 * _boxSize) + _boxSize * 3, 0, 0, 0, (int)_boxSize, (int)_boxSize);
            Text nbWood = new Text(resources["wood"].ToString(), font);
            nbWood.Position = new Vector2f((Width / 2 * _boxSize) + _boxSize * 4, 0);
            nbWood.Color = Color.Black;
            nbWood.CharacterSize = 13;
            nbWood.Style = Text.Styles.Bold;
            nbWood.Draw(window, RenderStates.Default);
            
            _drawUIctx.RenderSprite(pollutionSprite, window, (Width / 2 * _boxSize) + _boxSize * 5, 0, 0, 0, (int)_boxSize, (int)_boxSize);
            Text nbPollution = new Text(resources["pollution"].ToString(), font);
            nbPollution.Position = new Vector2f((Width / 2 * _boxSize) + _boxSize * 6, 0);
            nbPollution.Color = Color.Black;
            nbPollution.CharacterSize = 13;
            nbPollution.Style = Text.Styles.Bold;
            nbPollution.Draw(window, RenderStates.Default);

            window.Draw(rec);
            DrawTime(window, font, time);
        }

        static void DrawTime(RenderWindow window, Font font, DateTime time)
        {
            Text Time = new Text(time.ToString(), font);
            Time.Draw(window, RenderStates.Default);
        }
    }
}
