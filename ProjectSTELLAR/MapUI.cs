using System;
using SFML.Graphics;
using SFML.Window;
using System.IO;
using SFML.System;
using ProjectStellar;
using System.Xml.Linq;
using System.Linq;

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

        public Map Context => _ctx;

        //string[] _bgArray;
        //Vector2f _tileSize;
        //Texture _tileset;
        //int _width;
        //int _height;

        //public Map(String XML)
        //{
        //    using (FileStream fs = File.OpenRead(XML))
        //    using (StreamReader sr = new StreamReader(fs, true))
        //    {
        //        XElement xml = XElement.Load(sr);
        //        string bg = xml.Descendants("data").Single().Value;
        //        _bgArray = bg.Split(',');

        //        _width = 10;
        //        _height = 10;
        //        _tileSize = new Vector2f(32, 32);
        //        _tileset = new Texture("./resources/tileset.png");
        //    }
        //}

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
            for (int x = TileView.Left; x < 10; x++)
            {
                for (int y = TileView.Top; y < 10; y++)
                {
                    rec.OutlineColor = new Color(Color.Red);
                    rec.OutlineThickness = 1.0f;
                    rec.FillColor = new Color(Color.Transparent);
                    rec.Size = new Vector2f((x * 32), (y * 32));
                    rec.Position = new Vector2f((TileView.Left * 32), (TileView.Top * 32));
                    window.Draw(rec);
                }
            }
        }

        public void DrawMapTile(RenderWindow window, Building[,] boxes)
        {
            for (int x = 0; x < 10 - 1; x++)
            {
                for (int y = 0; y < 10 - 1; y++)
                {
                    RenderSprite(_bgSprite, window, (x * 32), (y * 32), 0, 0, 32, 32);
                }
            }

            for(int i = 0; i < boxes.Length; i++)
            {
                for(int j = 0; j < boxes.Length; j++)
                {
                    if(boxes[i,j] != null)
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

        public Building[,] CheckMap ()
        {

        }

        public void RenderGraphics(RenderWindow window)
        {
            DrawMapTile(window, _ctx.Boxes);
            DrawGrid(window);
        }
    }
}
