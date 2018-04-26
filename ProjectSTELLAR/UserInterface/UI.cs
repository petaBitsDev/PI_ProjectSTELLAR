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
        Resolution _resolution;
        uint _width;
        uint _height;

        public UI(Game ctx, Resolution resolution, Map context, DrawUI drawUI, uint width, uint height)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
            _ctx = ctx;
            _drawUIctx = drawUI;
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
        public void DrawResourcesBar(RenderWindow window, DateTime time, Font font)
        {
            //, Dictionary<string,int> resources
            Sprite coinSprite = new Sprite(new Texture(_ctx._uiTextures[5]));
            Sprite woodSprite = new Sprite(new Texture(_ctx._uiTextures[7]));
            Sprite pollutionSprite = new Sprite(new Texture(_ctx._uiTextures[6]));

            RectangleShape rec = new RectangleShape();
            rec.OutlineColor = new Color(Color.Red);
            rec.OutlineThickness = 2.0f;
            rec.FillColor = new Color(Color.Transparent);
            rec.Size = new Vector2f((Width - 1) * 32, (1 * 32) + 1);
            rec.Position = new Vector2f((0 * 32), (0 * 32) + 1);

            _drawUIctx.RenderSprite(coinSprite, window, (Width / 2 * 32) + 32, 0, 0, 0, 32, 32);
            _drawUIctx.RenderSprite(woodSprite, window, (Width / 2 * 32) + 64, 0, 0, 0, 32, 32);
            _drawUIctx.RenderSprite(pollutionSprite, window, (Width / 2 * 32) + 96, 0, 0, 0, 32, 32);

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
