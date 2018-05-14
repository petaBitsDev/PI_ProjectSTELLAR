using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using ProjectStellar.Library;

namespace ProjectStellar
{
    public abstract class GameLoop
    {
        public const int TARGET_FPS = 60;
        public const float TIME_UNTIL_UPDATE = 1f / TARGET_FPS;

        public GameLoop(Resolution resolution, bool isFullscreen, string windowTitle, Color windowClearColor)
        {
            this.WindowClearColor = windowClearColor;
            if (isFullscreen)
                this.Window = new RenderWindow(new VideoMode(resolution.X, resolution.Y), windowTitle, Styles.None);
            else
                this.Window = new RenderWindow(new VideoMode(resolution.X, resolution.Y), windowTitle, Styles.Close);
            this.GameTime = new GameTime();
            //Window.Closed += _windowEvents.WindowClosed;
            //Window.MouseButtonPressed += _windowEvents.MouseClicked;
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
    }
}
