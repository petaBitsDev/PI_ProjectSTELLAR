using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using ProjectStellar.Library;

namespace ProjectStellar
{
    class UI
    {
        Game _ctx;
        Resolution _resolution;

        public UI(Game ctx, Resolution resolution)
        {
            _resolution = resolution;
        }

        //, Dictionary<string,int> resources
        public void DrawResourcesBar(RenderWindow window)
        {
            Sprite coinSprite = new Sprite(new Texture(_ctx._uiTextures[5]));
            Sprite woodSprite = new Sprite(new Texture(_ctx._uiTextures[7]));
            Sprite pollutionSprite = new Sprite(new Texture(_ctx._uiTextures[6]));

            RectangleShape rec = new RectangleShape();
            rec.OutlineColor = new Color(Color.Red);
            rec.OutlineThickness = 2.0f;
            rec.FillColor = new Color(Color.Transparent);
            rec.Size = new Vector2f((_resolution.X - 1) * 32, (1 * 32) + 1);
            //rec.Position = new Vector2f((TileView.Left * 32), (TileView.Top * 32) + 1);

            //RenderSprite(coinSprite, window, (_resolution.X / 2 * 32) + 32, 0, 0, 0, 32, 32);
            //RenderSprite(woodSprite, window, (_resolution.X / 2 * 32) + 64, 0, 0, 0, 32, 32);
            //RenderSprite(pollutionSprite, window, (_resolution.X / 2 * 32) + 96, 0, 0, 0, 32, 32);

            window.Draw(rec);
        }

    }
}
