using System;
using SFML.Graphics;
using SFML.System;

namespace ProjectStellar
{
    public static class DebugUtility
    {
        public const string CONSOLE_FONT_PATH = "./fonts/arial.ttf";

        public static Font consoleFont;

        public static void LoadContent()
        {
            consoleFont = new Font(CONSOLE_FONT_PATH);
        }

        public static void DrawPerformanceData(GameLoop gameLoop, Color fontColor)
        {
            if(consoleFont == null)
            {
                return;
            }

            string totalTimeElapsedStr = gameLoop.GameTime.TotalTimeElapsed.ToString("0.000");
            string deltaStr = gameLoop.GameTime.DeltaTime.ToString("0.00000");
            float fps = 1f / gameLoop.GameTime.DeltaTime;
            string fpsStr = fps.ToString("0.00");

            Text textA = new Text(totalTimeElapsedStr, consoleFont, 14);
            textA.Position = new Vector2f(4f, 8f);
            textA.Color = fontColor;

            Text textB = new Text(deltaStr, consoleFont, 14);
            textB.Position = new Vector2f(4f, 28f);
            textB.Color = fontColor;

            Text textC = new Text(fpsStr, consoleFont, 14);
            textC.Position = new Vector2f(4f, 48f);
            textC.Color = fontColor;

            gameLoop.Window.Draw(textA);
            gameLoop.Window.Draw(textB);
            gameLoop.Window.Draw(textC);
        }
    }
}
