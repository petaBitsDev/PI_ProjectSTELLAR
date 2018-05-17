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
using System.Threading;

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
        bool _buildingExist;
        RectangleShape rec = new RectangleShape();
        bool test;

        public MapUI(Game context, Map ctx, uint width, uint height, DrawUI drawUI, UI ui)
        {
            _gameCtx = context;
            _ctx = ctx;
            _drawUIctx = drawUI;
            _width = width;
            _height = height;
            _drawBuildings = new DrawBuildings(_gameCtx,ui, ctx);
            _ui = ui;
        }

        public Map MapContext => _ctx;

        public uint Width => _width;

        public uint Height => _height;

        public Game GameContext => _gameCtx;

        public bool BuildingExist
        {
            get
            {
                return _buildingExist;
            }

            set
            {
                _buildingExist = value;
            }
        }

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
                    rec.OutlineColor = new Color(253, 235,208);
                    rec.OutlineThickness = 1.0f;
                    rec.FillColor = new Color(Color.Transparent);
                    rec.Size = new Vector2f(32, 32);
                    rec.Position = new Vector2f(x * 32, y* 32);
                    window.Draw(rec);
                    _cases[i++] = new Cases(rec, y, x);
                }
            }
        }
        
        public void DrawMapTile(RenderWindow window, Building[,] boxes, Font font)
        {
            for (uint x = 0; x < Width; x++)
            {
                for (uint y = 0; y < Height; y++)
                {
                    _drawUIctx.RenderSprite(_bgSprite, window, (x * 32), (y * 32), 0, 1, 32, 32);
                }
            }

            DrawGrid(window);

            for (int i = 0; i < (boxes.Length / Height); i++)
            {
                for (int j = 0; j < (boxes.Length / Width); j++)
                {
                    if (!object.Equals(boxes[i, j], null))
                    {
                    
                        Type type = boxes[i, j].GetType();
                        _drawBuildings.Draw(type, window, j, i, font);
                    }
                }
            }
        }
     
        public bool Test
        {
            get { return test; }
            set { test = value; }
        }

        public Building ContainsBuilding(int X, int Y)
        {

            int a = (int)X;
            int b = (int)Y;
           
            if (!object.Equals(_ctx.Boxes[a, b], null))
            {
                BuildingExist = true;
                return _ctx.Boxes[a, b];
            }
            else
            {
            BuildingExist = false;

            return null;

            }
        }


        public bool CheckMap(float X, float Y, RenderWindow window, Font font)
        {
            Console.WriteLine("x = {0}, y = {1}", X, Y);
            for (int i = 0; i < _cases.Length; i++)
            {
                ContainsBuilding(_cases[i].X, _cases[i].Y);

                if (_cases[i].Rec.GetGlobalBounds().Contains(X, Y))
                {
                    Console.WriteLine(_cases[i].X + "  " + _cases[i].Y);
                    if (!object.Equals(_ctx.ChosenBuilding, null))
                    {
                        _gameCtx._buildingFactory.CreateBuilding(_cases[i].X, _cases[i].Y, _ctx.ChosenBuilding);
                        _ctx.ChosenBuilding = null;
                    }
                    else if (_ui.DestroySelected)
                    {
                        _ctx.RemoveBuilding(_cases[i].X, _cases[i].Y);
                        _ui.DestroySelected = false;
                    }

                    if (BuildingExist == true)
                    {
                        Console.WriteLine(ContainsBuilding(_cases[i].X, _cases[i].Y));
                        _ui.DrawBuildingInformations(window, font, ContainsBuilding(_cases[i].X, _cases[i].Y), Width/2, Height/2);
                        Thread.Sleep(3000);
                    }
                    else
                    {
                        Console.WriteLine("do not exist");
                    }
                  
                    return true;
                }
            }

            return false;
        }


    }
}
