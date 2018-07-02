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
using System.Numerics;

namespace ProjectStellar
{
    public class MapUI
    {
        Dictionary<Building, RectangleShape> _recs;
        Dictionary<SpaceShips, Sprite> _spaceshipSprites;
        List<Sprite> _spriteList;
        Sprite _bgSprite;
        Sprite _spaceShip;
        Sprite _spaceShip1;
        Sprite _spaceShip2;
        uint _width;
        uint _height;
        int _index;
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
        Sprite _alien;
        Sprite _alienZoom;
        Sprite _disease;
        Sprite _diseaseRed;
        Sprite _fireTruck;
        double _distance;

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
            _recs = new Dictionary<Building, RectangleShape>();
            _distance = 0;

            _bgSprite = new Sprite(new Texture("./resources/img/tileset.png"));
            _spaceShip = new Sprite(new Texture("./resources/img/startup.png"));
            _spaceShip1 = new Sprite(new Texture("./resources/img/startup1.png"));
            _spaceShip2 = new Sprite(new Texture("./resources/img/rocket.png"));
            _spaceShip = new Sprite(new Texture("./resources/img/ufo.png"));
            _spaceShip1 = new Sprite(new Texture("./resources/img/ufo1.png"));
            _spaceShip2 = new Sprite(new Texture("./resources/img/ufo2.png"));

            _fireTruck = new Sprite(context._spriteTruck[0]);


            _fire = new Sprite(context._spriteSheet[1])
            {
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _flame = new Sprite(context._spriteSheet[2])
            {
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _alien = new Sprite(context._spriteSheet[3])
            {
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _alienZoom = new Sprite(context._spriteSheet[4])
            {
                Scale = new Vector2f(0.8f, 0.8f)
            };

            _disease = new Sprite(context._spriteSheet[5]) { Scale = new Vector2f(0.8f, 0.8f) };
            _diseaseRed = new Sprite(context._spriteSheet[6]) { Scale = new Vector2f(0.8f, 0.8f) };
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


            for (int a = 0; a < _cases.Length; a++)
            {
                if (_cases[a].Contains((int)worldPos.X, (int)worldPos.Y))
                {
                    if (!object.Equals(boxes[_cases[a].X, _cases[a].Y], null))
                    {
                        _ui.DrawBuildingInformations(window, font, boxes[_cases[a].X, _cases[a].Y]);
                    }
                }

                if (!object.Equals(boxes[_cases[a].X, _cases[a].Y], null))
                {
                    if (boxes[_cases[a].X, _cases[a].Y].Type.Equals(_ctx.BuildingTypes[12]))
                    {
                        for(int b = 0; b < boxes[_cases[a].X, _cases[a].Y].Type.List.Count; b++)
                        {
                            if (Equals(boxes[_cases[a].X, _cases[a].Y], boxes[_cases[a].X, _cases[a].Y].Type.List[b]))
                                _index = b;
                        }
                        if (_ctx.BuildingTypes[12].List.Count > 0)
                            _ui.CreateMenu(_gameCtx, _ctx.BuildingTypes[12].List[_ctx.BuildingTypes[12].List.Count - 1]);
                        if(CheckSpaceMenu(boxes[_cases[a].X, _cases[a].Y], window, (int)worldPos.X, (int)worldPos.Y))
                        {
                            _ui.Menus[_index].IsOn = true;
                        }
                        _ui.DrawSpaceStationUI(window, font, (int)worldPos.X, (int)worldPos.Y, boxes[_cases[a].X, _cases[a].Y], _index);
                    }
                    if(boxes[_cases[a].X, _cases[a].Y].OnFire)
                    {
                        for(int i = 0; i < _ctx.BuildingTypes[1].List.Count; i++)
                        {
                            _distance = _ctx.BuildingTypes[1].List[0].GetDistance(boxes[_cases[a].X, _cases[a].Y]);
                            _distance = Math.Min(_ctx.BuildingTypes[1].List[i].GetDistance(boxes[_cases[a].X, _cases[a].Y]), _distance);
                        }
                        for(int j = 0; j < _ctx.BuildingTypes[1].List.Count; j++)
                        {
                            if (_ctx.BuildingTypes[1].List[j].GetDistance(boxes[_cases[a].X, _cases[a].Y]) == _distance)
                            {
                                for(int b = 0; b < _ctx.BuildingTypes[1].List[j].TruckList.Count; b++)
                                {
                                    if(_ctx.BuildingTypes[1].List[j].TruckList[b].IsFree)
                                        _ctx.BuildingTypes[1].List[j].SendTruck(_ctx.BuildingTypes[1].List[j].TruckList[b], boxes[_cases[a].X, _cases[a].Y]);
                                }
                            }
                        }
                    }
                }
            }
            for (int b = 0; b < _ctx.SpaceShipsList.Count; b++)
            {
                Sprite spaceShip;

                if (b % 2 == 0)
                    spaceShip = _spaceShip1;
                else
                    spaceShip = _spaceShip2;

                spaceShip.Position = new Vector2f((float)_ctx.SpaceShipsList[b].Position.X, (float)_ctx.SpaceShipsList[b].Position.Y);
                spaceShip.Scale = new Vector2f(0.5f, 0.5f);
                spaceShip.Draw(window, RenderStates.Default);
            }
            DrawFire(window);
            DrawAlien(window);
            DrawSickness(window);
            DrawFireStationTruck(window);
        }
    
    

        public bool CheckSpaceMenu (Building b, RenderWindow window, int posX, int posY)
        {
            if (b.SpritePosition.X == posY / 32 && b.SpritePosition.Y == posX / 32)
            {
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    b.MenuOn = true;
                    return true;
                }
                return false;
            }
            return false;
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
                if (y + 2 > _ctx.Width - 1 || x + 1 > _ctx.Height - 1) return false;
                if (!Equals(_ctx.Boxes[x, y], null)) return false;
                if (!Equals(_ctx.Boxes[x, y + 1], null)) return false;
                if (!Equals(_ctx.Boxes[x, y + 2], null)) return false;
                if (!Equals(_ctx.Boxes[x + 1, y], null)) return false;
                if (!Equals(_ctx.Boxes[x + 1, y + 1], null)) return false;
                if (!Equals(_ctx.Boxes[x + 1, y + 2], null)) return false;
            }
            else if (size == 4)
            {
                if (y + 1 > _ctx.Width - 1 || x + 1 > _ctx.Height - 1) return false;
                if (!Equals(_ctx.Boxes[x, y], null)) return false;
                if (!Equals(_ctx.Boxes[x + 1, y], null)) return false;
                if (!Equals(_ctx.Boxes[x, y + 1], null)) return false;
                if (!Equals(_ctx.Boxes[x + 1, y + 1], null)) return false;
            }
            else
            {
                if (y > _ctx.Width - 1 || x > _ctx.Height - 1) return false;
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

        private void DrawAlien(RenderWindow window)
        {
            int X;
            int Y;
            bool a = false;

            if(_ctx.NewCrimeType.BuildingHasEvent.Count != 0)
            {
                for(int i = 0; i < _ctx.NewCrimeType.BuildingHasEvent.Count; i++)
                {

                    if (_gameCtx.GameTime.InGameTime >= _ctx.NewCrimeType.BuildingHasEvent[i].EndOfEvent)
                    {
                        _ctx.NewCrimeType.BuildingHasEvent.Remove(_ctx.NewCrimeType.BuildingHasEvent[i]);
                        Console.WriteLine("ALLLLLLOOOOO Fire supprimer");
                        a = true;
                    }

                    if (a == false)
                    {

                        X = _ctx.NewCrimeType.BuildingHasEvent[i].X;
                    Y = _ctx.NewCrimeType.BuildingHasEvent[i].Y;

                    if(_ctx.NewCrimeType.BuildingHasEvent[i].Size == 1)
                    {
                        _alien.Position = new Vector2f(Y * 32, X * 32 + 15);
                        _alienZoom.Position = new Vector2f(Y * 32, X * 32 + 15);
                    }
                    else if(_ctx.NewCrimeType.BuildingHasEvent[i].Size == 4)
                    {
                        _alien.Position = new Vector2f(Y * 32 + 12, X * 32 + 15);
                        _alienZoom.Position = new Vector2f(Y * 32 + 12, X * 32 + 15);
                    }
                    else if(_ctx.NewCrimeType.BuildingHasEvent[i].Size == 6)
                    {
                        _alien.Position = new Vector2f(Y * 32 + 53, X * 32 + 53);
                        _alienZoom.Position = new Vector2f(Y * 32 + 53, X * 32 + 53);

                    }
                    if(GameContext.GameTime.InGameTime.Minute % 2 == 0)
                    {
                        window.Draw(_alien);
                    }
                    else if(GameContext.GameTime.InGameTime.Minute % 2 == 1)
                    {
                        window.Draw(_alienZoom);
                    }

                    }
                    else
                    {
                        DrawAlien(window);
                    }
                }
            }
 
        }

        private void DrawFire(RenderWindow window)
        {
            int yFire;
            int xFire;
            int xFlame;
            bool a = false;
            int yFlame;
            DateTime now = GameContext.GameTime.InGameTime;

            if (_ctx.NewFireType.BuildingHasEvent.Count != 0)
            {
                for (int i = 0; i < _ctx.NewFireType.BuildingHasEvent.Count; i++)
                {
                    Console.WriteLine("1 " + _gameCtx.GameTime.InGameTime);
                    Console.WriteLine("2 " + _ctx.NewFireType.BuildingHasEvent[i].EndOfEvent);

                    if (_gameCtx.GameTime.InGameTime >= _ctx.NewFireType.BuildingHasEvent[i].EndOfEvent)
                    {
                        _ctx.NewFireType.BuildingHasEvent.Remove(_ctx.NewFireType.BuildingHasEvent[i]);
                        Console.WriteLine("ALLLLLLOOOOO Fire supprimer");
                        a = true;
                    }

                    if (a == false)
                    {
                        xFire = _ctx.NewFireType.BuildingHasEvent[i].X;
                        yFire = _ctx.NewFireType.BuildingHasEvent[i].Y;

                        if (_ctx.NewFireType.BuildingHasEvent[i].Size == 1)
                        {
                            _flame.Position = new Vector2f(yFire * 32 + 3, xFire * 32 + 18);
                            _fire.Position = new Vector2f(yFire * 32 + 3, xFire * 32 + 18);
                        }
                        else if (_ctx.NewFireType.BuildingHasEvent[i].Size == 6)
                        {
                            _fire.Position = new Vector2f((yFire * 32) + 25, (xFire * 32) + 20);
                            _flame.Position = new Vector2f((yFire * 32) + 25, (xFire * 32) + 20);
                        }
                        else if (_ctx.NewFireType.BuildingHasEvent[i].Size == 4)
                        {
                            _flame.Position = new Vector2f((yFire * 32) + 24, (xFire * 32) + 30);
                            _fire.Position = new Vector2f((yFire * 32) + 24, (xFire * 32) + 23);
                        }

                        if (GameContext.GameTime.InGameTime.Minute % 2 == 0)
                        {
                            window.Draw(_fire);
                        }
                        else if (GameContext.GameTime.InGameTime.Minute % 2 == 1)
                        {
                            window.Draw(_flame);
                        }
                    }
                    else
                    {
                        DrawFire(window);
                    }
                }
            }
        }

        private void DrawSickness(RenderWindow window)
        {
            int X;
            int Y;
            bool a = false;

            if(_ctx.NewDiseaseType.BuildingHasEvent.Count != 0)
            {
                for(int i = 0; i<_ctx.NewDiseaseType.BuildingHasEvent.Count; i++)
                {
                    if (_gameCtx.GameTime.InGameTime >= _ctx.NewDiseaseType.BuildingHasEvent[i].EndOfEvent)
                    {
                        _ctx.NewDiseaseType.BuildingHasEvent.Remove(_ctx.NewDiseaseType.BuildingHasEvent[i]);
                        Console.WriteLine("ALLLLLLOOOOO Fire supprimer");
                        a = true;
                    }

                    if(a == false)
                    {
                        X = _ctx.NewDiseaseType.BuildingHasEvent[i].X;
                        Y = _ctx.NewDiseaseType.BuildingHasEvent[i].Y;
                        
                        if (_ctx.NewDiseaseType.BuildingHasEvent[i].Size == 1)
                        {
                            _disease.Position = new Vector2f(Y * 32 + 3, X * 32 + 18);
                            _diseaseRed.Position = new Vector2f(Y * 32 + 3, X * 32 + 18);
                        }
                        else if (_ctx.NewDiseaseType.BuildingHasEvent[i].Size == 4)
                        {
                            _disease.Position = new Vector2f(Y * 32 + 24, X * 32 + 24);
                            _diseaseRed.Position = new Vector2f(Y * 32 + 24, X * 32 + 24);
                        }
                        else if (_ctx.NewDiseaseType.BuildingHasEvent[i].Size == 6)
                        {
                            _disease.Position = new Vector2f(Y * 32 + 53, X * 32 + 53);
                            _diseaseRed.Position = new Vector2f(Y * 32 + 53, X * 32 + 53);

                        }
                        if (GameContext.GameTime.InGameTime.Minute % 2 == 0)
                        {
                            window.Draw(_disease);
                        }
                        else if (GameContext.GameTime.InGameTime.Minute % 2 == 1)
                        {
                            window.Draw(_diseaseRed);
                        }
                    }
                    else
                    {
                        DrawSickness(window);
                    }
                }
            }
        }

        private void DrawFireStationTruck(RenderWindow window)
        {
            Sprite truck = new Sprite(_gameCtx._spriteTruck[0]);
            for(int i = 0; i < _ctx.BuildingTypes[1].List.Count; i++)
            {
                for(int j = 0; j < _ctx.BuildingTypes[1].List[i].TruckList.Count; j++)
                {
                    if (!_ctx.BuildingTypes[1].List[i].TruckList[j].IsFree)
                    {
                        truck.Position = new Vector2f((float)_ctx.BuildingTypes[1].List[i].TruckList[j].Position.Y * 32, (float)_ctx.BuildingTypes[1].List[i].TruckList[j].Position.X * 32);
                        truck.Draw(window, RenderStates.Default);
                    }
                }
            }
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



