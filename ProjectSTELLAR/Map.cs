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
            RectangleShape rec = new RectangleShape();
            for(int x = TileView.Left; x < TileView.Right; x++)
            {
                for(int y = TileView.Top; y < TileView.Bottom; y++)
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

        public static void RenderGraphics(RenderWindow window)
        {
            DrawGrid(window);
        }
    }
}
