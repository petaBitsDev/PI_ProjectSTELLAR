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
using ProjectStellar.Library;

namespace ProjectStellar
{
    public class MapUI
    {
        Dictionary<SpaceShips, Sprite> _spaceshipSprites;
        List<Sprite> _spriteList;
        Sprite _bgSprite;
        Sprite _spaceShip;
        Sprite _spaceShip1;
        Sprite _spaceShip2;
        uint _width;
        uint _height;
        Map _ctx;
        Game _gameCtx;
        DrawUI _drawUIctx;
        DrawBuildings _drawBuildings;
        Case[] _cases;
        UI _ui;
        bool _buildingExist;
        RectangleShape rec = new RectangleShape();
        bool test;
        bool _menuON;
        Resolution _resolution;
        Sprite[,] _mapSprites;
        internal Vector2f _x2y2;
        ResourcesManager _resourcesManager;
        Sprite _fire;
        Sprite _flame;
        RectangleShape _invisibleRec;

        public MapUI(Game context, Map ctx, uint width, uint height, DrawUI drawUI, UI ui, Resolution resolution, ResourcesManager resourcesManager)
        {
            _gameCtx = context;
            _ctx = ctx;
            _drawUIctx = drawUI;
            _width = width;
            _height = height;
            _drawBuildings = new DrawBuildings(_gameCtx, ui, ctx);
            _ui = ui;
            _resolution = resolution;
            _x2y2 = new Vector2f((width + 1) * 32, (height + 1) * 32);
            _resourcesManager = resourcesManager;
            _cases = new Case[Width * Height];
            _menuON = false;
            _invisibleRec = new RectangleShape();

            _bgSprite = new Sprite(new Texture("./resources/img/tileset.png"));
            _spaceShip = new Sprite(new Texture("./resources/img/startup.png"));
            _spaceShip1 = new Sprite(new Texture("./resources/img/startup1.png"));
            _spaceShip2 = new Sprite(new Texture("./resources/img/rocket.png"));
            _spaceShip = new Sprite(new Texture("./resources/img/ufo.png"));
            _spaceShip1 = new Sprite(new Texture("./resources/img/ufo1.png"));
            _spaceShip2 = new Sprite(new Texture("./resources/img/ufo2.png"));

       

            _fire = new Sprite(context._spriteSheet[1])
            {
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _flame = new Sprite(context._spriteSheet[2])
            {
                Scale = new Vector2f(0.8f, 0.8f)
            };
        }

        public Map MapContext
        {
            get { return _ctx; }
            set { _ctx = value; }
        }

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
            int i = 0;

            RectangleShape rec;
            _cases = new Case[Width * Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    rec = new RectangleShape();
                    rec.OutlineColor = new Color(253, 235, 208);
                    rec.OutlineThickness = 1.0f;
                    rec.FillColor = new Color(Color.Transparent);
                    rec.Size = new Vector2f(32, 32);
                    rec.Position = new Vector2f(x * 32, y * 32);
                    window.Draw(rec);
                    //_cases[i++] = new Cases(rec, y, x);
                }
            }
        }

        public void DrawMapTile(RenderWindow window, Building[,] boxes, Font font)
        {
            Vector2i pixelPos = Mouse.GetPosition(window);
            Vector2f worldPos = window.MapPixelToCoords(pixelPos, _gameCtx._windowEvents.View);
            int k = 0;

            for (uint x = 0; x < Width; x++)
            {
                for (uint y = 0; y < Height; y++)
                {
                    _bgSprite.Position = new Vector2f(y, x);
                    _drawUIctx.RenderSprite(_bgSprite, window, (x * 32), (y * 32), 0, 0, 32, 32);
                    _cases[k++] = new Case(_bgSprite.GetGlobalBounds(), x, y);
                }
            }
            for (int i = 0; i < (boxes.Length / Height); i++)
            {
                for (int j = 0; j < (boxes.Length / Width); j++)
                {
                    if (!object.Equals(boxes[i, j], null))
                    {
                        foreach (KeyValuePair<Sprite, BuildingType> buildingType in _ui.Tab1Sprite)
                        {
                            if (boxes[i, j].Type == buildingType.Value)
                            {
                                _drawUIctx.RenderSprite(buildingType.Key, window, (uint)(j * 32), (uint)(i * 32), 0, 0, 32, 32);
                            }
                        }
                        foreach (KeyValuePair<Sprite, BuildingType> buildingType in _ui.Tab2Sprite)
                        {
                            if (boxes[i, j].Type == buildingType.Value)
                            {
                                _drawUIctx.RenderSprite(buildingType.Key, window, (uint)(j * 32), (uint)(i * 32), 0, 0, 32, 32);
                            }
                        }
                        foreach (KeyValuePair<Sprite, BuildingType> buildingType in _ui.Tab3Sprite)
                        {
                            if (boxes[i, j].Type == buildingType.Value)
                            {
                                _drawUIctx.RenderSprite(buildingType.Key, window, (uint)(j * 32), (uint)(i * 32), 0, 0, 32, 32);
                            }
                        }
                    }
                }
            }
            //FIRE-------------------------------------------------------------------------------------
            Clock clock = new Clock();
            int yFire;
            int xFire;
            int xFlame;
            int yFlame;
            DateTime now = GameContext.GameTime.InGameTime;

            if (_ctx.NewFireType.BuildingHasEvent.Count != 0)
            {
                //Console.WriteLine("UI DRAW FIRE IM IN WHILE");
                for (int i = 0; i < _ctx.NewFireType.BuildingHasEvent.Count; i++)
                {
                    xFire = _ctx.NewFireType.BuildingHasEvent[i].X;

                    yFire = _ctx.NewFireType.BuildingHasEvent[i].Y;

                    if (_ctx.NewFireType.BuildingHasEvent[i].Size == 1)
                    {
                        _flame.Position = new Vector2f(yFire * 32+3, xFire * 32 +18);
                        _fire.Position = new Vector2f(yFire * 32+3, xFire * 32 +18);


                    }
                    else if (_ctx.NewFireType.BuildingHasEvent[i].Size == 6)
                    {
                        _fire.Position = new Vector2f((yFire * 32) + 25, (xFire * 32) + 20);
                        _flame.Position = new Vector2f((yFire * 32) + 25, (xFire * 32) + 20);


                    }
                    else if (_ctx.NewFireType.BuildingHasEvent[i].Size == 4)
                    {
                        _flame.Position = new Vector2f((yFire * 32) + 25, (xFire * 32) + 23);
                        _fire.Position = new Vector2f((yFire * 32) + 25, (xFire * 32) + 23);


                    }

                    Console.WriteLine(GameContext.GameTime.InGameTime.Minute);
                    if(GameContext.GameTime.InGameTime.Minute%2 == 0)
                    {
                        window.Draw(_fire); ;


                    }
                    else if(GameContext.GameTime.InGameTime.Minute%2 == 1) 
                    {
                        window.Draw(_flame);

                    }

                }
                for (int a = 0; a < _cases.Length; a++)
                {
                    if (_cases[a].Contains((int)worldPos.X, (int)worldPos.Y))
                    {
                        if (!object.Equals(boxes[_cases[a].X, _cases[a].Y], null))
                        {
                            _ui.DrawBuildingInformations(window, font, boxes[_cases[a].X, _cases[a].Y]);
                        }
                    }
                }
                }
                if (!object.Equals(boxes[_cases[a].X, _cases[a].Y], null))
                {
                    if (boxes[_cases[a].X, _cases[a].Y].Type.Equals(_ctx.BuildingTypes[12]))
                    {
                        CheckSpaceMenu(boxes[_cases[a].X, _cases[a].Y], window, (int)worldPos.X, (int)worldPos.Y);
                        if (_ui.MenuON)
                        {
                            _invisibleRec.Size = new Vector2f(32 * 12, 32 * 6);
                            _invisibleRec.FillColor = Color.Green;
                            _invisibleRec.Position = new Vector2f(boxes[_cases[a].X, _cases[a].Y].SpritePosition.Y * 32 - 32 * 6, boxes[_cases[a].X, _cases[a].Y].SpritePosition.X * 32 - 32 * 2);
                            _invisibleRec.Draw(window, RenderStates.Default);

                            _ui.DrawSpaceStationUI(_invisibleRec, window, font, (int)worldPos.X, (int)worldPos.Y, boxes[_cases[a].X, _cases[a].Y]);
                        }
                    }
                }
            }
            for (int b = 0; b < _ctx.SpaceShipsList.Count; b++)
            {
                Sprite spaceShip;

                //if (_ctx.SpaceShipsList[b].Position.X < _ctx.SpaceShipsList[b].Direction.X)
                //    spaceShip = _spaceShip1;
                //else
                    spaceShip = _spaceShip2;

                spaceShip.Position = new Vector2f(_ctx.SpaceShipsList[b].Position.X, _ctx.SpaceShipsList[b].Position.Y);
                spaceShip.Scale = new Vector2f(1.37f, 1.37f);
                spaceShip.Draw(window, RenderStates.Default);
            }
        }

        public bool CheckSpaceMenu (Building b, RenderWindow window, int posX, int posY)
        {
            if (b.SpritePosition.X == posY / 32 && b.SpritePosition.Y == posX / 32)
            {
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    _ui.MenuON = true;
                    return true;
                }
                return true;
            }
            else return false;
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

        public bool CheckPlace(int x, int y, int size)
        {
            if (size == 6)
            {
                if (!Equals(_ctx.Boxes[x, y], null)) return false;
                if (!Equals(_ctx.Boxes[x, y + 1], null)) return false;
                if (!Equals(_ctx.Boxes[x, y + 2], null)) return false;
                if (!Equals(_ctx.Boxes[x + 1, y], null)) return false;
                if (!Equals(_ctx.Boxes[x + 1, y + 1], null)) return false;
                if (!Equals(_ctx.Boxes[x + 1, y + 2], null)) return false;
            }
            else if (size == 4)
            {
                if (!Equals(_ctx.Boxes[x, y], null)) return false;
                if (!Equals(_ctx.Boxes[x + 1, y], null)) return false;
                if (!Equals(_ctx.Boxes[x, y + 1], null)) return false;
                if (!Equals(_ctx.Boxes[x + 1, y + 1], null)) return false;
            }
            else
            {
                if (!Equals(_ctx.Boxes[x, y], null)) return false;
            }
            return true;
        }

        public bool CheckMap(float mouseX, float mouseY, RenderWindow window, Font font)
        {
            Building building;
            Console.WriteLine("x = {0}, y = {1}", mouseX, mouseY);
            for (int i = 0; i < _cases.Length; i++)
            {
                building = ContainsBuilding(_cases[i].X, _cases[i].Y);

                if (_cases[i].Rec.Contains(mouseX, mouseY))
                {
                    Console.WriteLine(_cases[i].X + "  " + _cases[i].Y);
                    if (!object.Equals(_ctx.ChosenBuilding, null))
                    {
                        if (!_resourcesManager.CheckResourcesNeeded(_ctx.ChosenBuilding))
                        {
                            _ctx.ChosenBuilding = null;
                            window.SetMouseCursorVisible(true);
                            _ui.MouseSprite = null;
                        }
                        else if (CheckPlace(_cases[i].X, _cases[i].Y, _ctx.ChosenBuilding.Size))
                        {
                            _ctx.ChosenBuilding.CreateInstance(_cases[i].X, _cases[i].Y, _resourcesManager, MapContext);

                            if (!_resourcesManager.CheckResourcesNeeded(_ctx.ChosenBuilding))
                            {
                                _ctx.ChosenBuilding = null;
                                window.SetMouseCursorVisible(true);
                                _ui.MouseSprite = null;
                            }
                        }
                    }
                    else if (_ui.DestroySelected && building != null)
                    {
                        building.Type.DeleteInstance(_cases[i].X, _cases[i].Y, MapContext, building, _resourcesManager);
                        //_ui.DestroySelected = false;
                    }
                    else return false;
                    return true;
                }
            }
            return false;
        }

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
        public Sprite[,] MapSprites => _mapSprites;

        public ResourcesManager ResourcesManager
        {
            get { return _resourcesManager; }
            set { _resourcesManager = value; }
        }
    }
}



