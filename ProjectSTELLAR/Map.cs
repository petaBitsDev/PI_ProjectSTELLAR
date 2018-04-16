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
            for(int x = 0; x < 9; x++)
            {
                for(int y = 0; y < 9; y++)
                {
                    rec.OutlineColor = new Color(Color.Red);
                    rec.OutlineThickness = 3.0f;
                    rec.FillColor = new Color(Color.Transparent);
                    rec.Size = new Vector2f((x * 32), (y * 32));
                    rec.Position = new Vector2f((0 * 32 + 3), (0 * 32 + 3));
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
