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
        uint _width;
        uint _height;
        Map _ctx;
        Game _gameCtx;
        DrawUI _drawUIctx;
        DrawBuildings _drawBuildings;
        Cases[] _cases;
        UI _ui;

        public MapUI(Game context, Map ctx, uint width, uint height, DrawUI drawUI, UI ui)
        {
            _gameCtx = context;
            _ctx = ctx;
            _drawUIctx = drawUI;
            _width = width;
            _height = height;
            _drawBuildings = new DrawBuildings(_gameCtx);
            _ui = ui;
        }

        public Map MapContext => _ctx;

        public uint Width => _width;

        public uint Height => _height;

        public Game GameContext => _gameCtx;

        public struct Rect
        {
            public int Top;
            public int Bottom;
            public int Left;
            public int Right;
        }

        public static Rect TileView;

        public void DrawGrid(RenderWindow window)
        {
            TileView.Top = 0;
            TileView.Bottom = 10;
            TileView.Left = 0;
            TileView.Right = 10;
            int i = 0;

            RectangleShape rec;
            _cases = new Cases[Width * Height];

            for (int x = TileView.Left; x < Width; x++)
            {
                for (int y = TileView.Top; y < Height; y++)
                {
                    rec = new RectangleShape();
                    rec.OutlineColor = new Color(Color.Black);
                    rec.OutlineThickness = 1.0f;
                    rec.FillColor = new Color(Color.Transparent);
                    rec.Size = new Vector2f(32, 32);
                    rec.Position = new Vector2f(x * 32, y* 32);
                    window.Draw(rec);
                    _cases[i++] = new Cases(rec, y, x);
                }
            }
        }
        
        public void DrawMapTile(RenderWindow window, Building[,] boxes)
        {
            for (uint x = 0; x < Width; x++)
            {
                for (uint y = 0; y < Height; y++)
                {
                    _drawUIctx.RenderSprite(_bgSprite, window, (x * 32), (y * 32), 0, 0, 32, 32);
                }
            }

            for (int i = 0; i < (boxes.Length / Height); i++)
            {
                for (int j = 0; j < (boxes.Length / Width); j++)
                {
                    if (!object.Equals(boxes[i, j], null))
                    {
                        Type type = boxes[i, j].GetType();
                        _drawBuildings.Draw(type, window, j, i);
                    }
                }
            }
        }

        public bool CheckMap(float X, float Y)
        {
            Console.WriteLine("x = {0}, y = {1}", X, Y);
            for (int i = 0; i < _cases.Length; i++)
            {
                if (_cases[i].Rec.GetGlobalBounds().Contains(X, Y))
                {
                    Console.WriteLine(_cases[i].X + "  " + _cases[i].Y);
                    //Console.WriteLine("Cast : " + (int)_cases[i].X + "  " + (int)_cases[i].Y);
                    if (!object.Equals(_ctx.ChosenBuilding, null))
                    {
                        _ctx.AddBuilding(_cases[i].X, _cases[i].Y);
                    }
                    else if (_ui.DestroySelected)
                    {
                        _ctx.RemoveBuilding(_cases[i].X, _cases[i].Y);
                        _ui.DestroySelected = false;
                    }
                    return true;
                }
            }

            return false;
        }
    }
}
