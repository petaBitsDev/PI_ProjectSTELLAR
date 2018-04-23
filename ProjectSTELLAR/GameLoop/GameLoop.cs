using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace ProjectStellar
{
    public abstract class GameLoop
    {
        public const int TARGET_FPS = 60;
        public const float TIME_UNTIL_UPDATE = 1f / TARGET_FPS;

        public GameLoop(uint windowWidth, uint windowHeight, bool isFullscreen, string windowTitle, Color windowClearColor)
        {
            this.WindowClearColor = windowClearColor;
            if (isFullscreen)
                this.Window = new RenderWindow(new VideoMode(windowWidth, windowHeight), windowTitle, Styles.None);
            else
                this.Window = new RenderWindow(new VideoMode(windowWidth, windowHeight), windowTitle, Styles.Titlebar);
            this.GameTime = new GameTime();
            Window.Closed += WindowClosed;
        }

        public RenderWindow Window {
            get;
            protected set;
        }

        public GameTime GameTime {
            get;
            protected set;
        }

        public Color WindowClearColor
        {
            get;
            protected set;
        }

        public void Run()
        {
            LoadContent();
            Initialize();

            float totalTimeBeforeUpdate = 0f;
            float previousTimeElapsed = 0f;
            float deltaTime = 0f;
            float totalTimeElapsed = 0f;

            Clock clock = new Clock();

            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                totalTimeElapsed = clock.ElapsedTime.AsSeconds();
                deltaTime = totalTimeElapsed - previousTimeElapsed;
                previousTimeElapsed = totalTimeElapsed;

                totalTimeBeforeUpdate += deltaTime;

                if (totalTimeBeforeUpdate >= TIME_UNTIL_UPDATE)
                {
                    GameTime.Update(totalTimeBeforeUpdate, totalTimeElapsed);
                    totalTimeBeforeUpdate = 0f;

                    Update(GameTime);

                    Window.Clear(WindowClearColor);
                    Draw(GameTime);
                    Window.Display();
                }
            }
        }

        public abstract void LoadContent();
        public abstract void Initialize();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);

        private void WindowClosed(object sender, EventArgs e)
        {
            Window.Close();
        }
    }
}
