using System;
using SFML.Graphics;
using SFML.Window;
using System.IO;
using SFML.System;
using ProjectStellar;
using System.Xml.Linq;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


namespace ProjectStellar
{
    public class MapUI
    {
        Sprite _bgSprite = new Sprite(new Texture("./resources/img/tileset.png"));
        Sprite[] _sprites = new Sprite[20];
        int _width;
        int _height;
        Map _ctx;
        Game _gameCtx;
        DrawBuildings _drawBuildings;

        public MapUI(Game context, Map ctx, int width, int height)
        {
            _gameCtx = context;
            _ctx = ctx;
            _width = width;
            _height = height;
            DrawBuildings _drawBuildings = new DrawBuildings(_gameCtx);
        }

        public Map MapContext => _ctx;

        public int Width => _width;

        public int Height => _height;

        public Game GameContext => _gameCtx;

        public struct Rect
        {
            public int Top;
            public int Bottom;
            public int Left;
            public int Right;
        }

        public static Rect TileView;

        static void DrawGrid(RenderWindow window)
        {
            TileView.Top = 0;
            TileView.Bottom = 10;
            TileView.Left = 0;
            TileView.Right = 10;

            RectangleShape rec = new RectangleShape();
            for (int x = TileView.Left; x < 20; x++)
            {
                for (int y = TileView.Top; y < 20; y++)
                {
                    rec.OutlineColor = new Color(Color.Black);
                    rec.OutlineThickness = 1.0f;
                    rec.FillColor = new Color(Color.Transparent);
                    rec.Size = new Vector2f((x * 32), (y * 32));
                    rec.Position = new Vector2f((TileView.Left * 32), (TileView.Top * 32) + 1);
                    window.Draw(rec);
                }
            }
        }

        public void DrawResourcesBar(RenderWindow window, Dictionary<string,int> resources)
        {
            RectangleShape rec = new RectangleShape();

            rec.OutlineColor = new Color(Color.Black);
            rec.OutlineThickness = 1.5f;
            rec.FillColor = new Color(Color.Transparent);
            rec.Size = new Vector2f(Width, (1 * 32));
            rec.Position = new Vector2f((TileView.Left * 32), (TileView.Top * 32) + 1);

            window.Draw(rec);
        }
        
        public void DrawMapTile(RenderWindow window, Building[,] boxes)
        {
            for (int x = 0; x < Width - 1; x++)
            {
                for (int y = 0; y < Height - 1; y++)
                {
                    RenderSprite(_bgSprite, window, (x * 32), (y * 32), 0, 0, 32, 32);
                }
            }

            for (int i = 0; i < (boxes.Length/Height); i++)
            {
                for (int j = 0; j < (boxes.Length/Width); j++)
                {
                    if (!object.Equals(boxes[i,j],null))
                    {
                        Type type = boxes[i, j].GetType();
                        _drawBuildings.Draw(type, window, i, j);
                    }
                }
            }
        }

        public static void RenderSprite
            (Sprite tmpSprite, RenderWindow target, int destX, int destY, int sourceX, int sourceY, int sourceWidth, int sourceHeight)
        {
            tmpSprite.TextureRect = new IntRect(sourceX, sourceY, sourceWidth, sourceHeight);
            tmpSprite.Position = new Vector2f(destX, destY);
            target.Draw(tmpSprite);
        }

        public void RenderGraphics(RenderWindow window)
        {
            DrawMapTile(window, _ctx.Boxes);
            DrawGrid(window);
            //DrawResourcesBar(window, _ctx.NbResources);
        }
    }
}
