using System;
using SFML.Graphics;
using SFML.Window;
using System.IO;
using SFML.System;
using ProjectStellar;

namespace ProjectStellar
{
    public class Map
    {
        Building[,] _boxes = new Building[TileView.Bottom, TileView.Right];
        Sprite _bgSprite = new Sprite(new Texture("./backgroundSprite.png"));
        Sprite[] _sprites = new Sprite[20];

        public void AddBuilding(int x, int y, Building building)
        {
            _boxes[x, y] = building;
        }

        public void RemoveBuilding(int x, int y, Building building)
        {
            _boxes[x, y] = null;
        }

        public bool CheckBuilding(int x, int y)
        {
            if (_boxes[x, y] != null) return true;
            return false;
        }

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

        public void DrawMapTile(RenderWindow window)
        {
            for(int x = 0; x < TileView.Right; x++)
            {
                for(int y = 0; y < TileView.Bottom; y++)
                {
                    if (_boxes[x, y] == null)
                        RenderSprite(_bgSprite, window, (x*32), (y*32), 0, 0, 32, (128 / 4));
                    
                    else 
                        RenderSprite(_sprites[0], window, (x * 32), (y * 32), 0, 0, 32, (128 / 4));
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

        public static void RenderGraphics(RenderWindow window)
        {
            DrawGrid(window);
        }
    }
}