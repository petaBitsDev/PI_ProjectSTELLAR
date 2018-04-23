using System;
using SFML.Graphics;
using SFML.Window;
using System.IO;
using SFML.System;
using ProjectStellar;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace ProjectStellar
{
    public class MapUI
    {
        //Sprite _bgSprite = new Sprite(new Texture("./resources/img/tileset.png"));
        Sprite[] _sprites = new Sprite[20];
        int _width;
        int _height;
        Map _ctx;

        public MapUI (Map ctx, int width, int height)
        {
            _ctx = ctx;
            _width = width;
            _height = height;
        }

        public Map Context => _ctx;

        public int Width => _width;

        public int Height => _height;

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
            for(int x = TileView.Left; x <= TileView.Right; x++)
            {
                for(int y = TileView.Top; y <= TileView.Bottom; y++)
                {
                    rec.OutlineColor = new Color(Color.Red);
                    rec.OutlineThickness = 3.0f;
                    rec.FillColor = new Color(Color.Transparent);
                    rec.Size = new Vector2f((x * 32), (y * 32));
                    rec.Position = new Vector2f((TileView.Left * 32 + 3), (TileView.Top * 32 + 3));
                    window.Draw(rec);
                }
            } 
        }
        public void DrawResourcesBar(RenderWindow window, Dictionary<string, int> resources)
        {
            RectangleShape rec = new RectangleShape();

            rec.OutlineColor = new Color(Color.Black);
            rec.OutlineThickness = 1.5f;
            rec.FillColor = new Color(Color.Transparent);
            rec.Size = new Vector2f(Width, (1 * 32));
            rec.Position = new Vector2f((TileView.Left * 32), (TileView.Top * 32) + 1);

            window.Draw(rec);
        }

        //public void DrawMapTile(RenderWindow window)
        //{
        //    for(int x = 0; x < TileView.Right; x++)
        //    {
        //        for(int y = 0; y < TileView.Bottom; y++)
        //        {
        //            if (_ctx.Boxes[x, y] == null)
        //            {
        //                RenderSprite(_bgSprite, window, (x*32), (y*32), 0, 0, 32, (128 / 4));
        //            }
        //            else
        //            {
        //                RenderSprite(_sprites[0], window, (x * 32), (y * 32), 0, 0, 32, (128 / 4));
        //            }
        //        }
        //    }
        //}

        public static void RenderSprite
            (Sprite tmpSprite, RenderWindow target, int destX, int destY, int sourceX, int sourceY, int sourceWidth, int sourceHeight)
        {
            tmpSprite.TextureRect = new IntRect(sourceX, sourceY, sourceWidth, sourceHeight);
            tmpSprite.Position = new Vector2f(destX, destY);
            target.Draw(tmpSprite);
        }

        public void RenderGraphics(RenderWindow window)
        {
            //DrawMapTile(window);
            DrawGrid(window);
            //DrawResourcesBar(window, _ctx.nbResources);
        }
    }
}
