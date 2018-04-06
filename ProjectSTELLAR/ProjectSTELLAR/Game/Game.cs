using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace ProjectStellar
{
    public class Game : GameLoop
    {
        public const uint DEFAULT_WINDOW_WIDTH = 640;
        public const uint DEFAULT_WINDOW_HEIGHT = 480;
        public const string WINDOW_TITLE = "Tutorial Game";

        public Game() : base(DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT, WINDOW_TITLE, Color.Green)
        {

        }

        public override void LoadContent()
        {
            DebugUtility.LoadContent();
        }

        public override void Initialize()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
            DebugUtility.DrawPerformanceData(this, Color.White);
        }
    }
}
