using ProjectSTELLAR.Library;
using SFML.Audio;
using SFML.Window;
using SFML.Graphics;
using System;

namespace ProjectStellar
{
    class Program
    {
        static void Main(string[] args)
        {
            //Game tutoGame = new Game();
            //tutoGame.Run();
            RenderWindow window = new RenderWindow(new VideoMode(1200, 600), "Project STELLAR");
            Menu menu = new Menu(1080, 720);

            while (window.IsOpen)
            {

                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    menu.Move(Keyboard.Key.Up);
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    menu.Move(Keyboard.Key.Down);

                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Return))
                {
                    if (menu.SelectedItem == 0)
                    {
                        window.Close();
                        Game game = new Game();
                        game.Run();
                        break;
                    }
                    else if (menu.SelectedItem == 1)
                    {
                        window.Close();
                    }
                }
                menu.Draw(window);
                window.Display();
            }
           

        }
    }
}
