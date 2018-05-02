using SFML.Audio;
using SFML.Window;
using SFML.Graphics;
using System;
using SFML.System;

namespace ProjectStellar
{
    class Menu
    {
        readonly Sprite[] _menu = new Sprite[2];
        static Texture _backgroundTexture = new Texture("./resources/img/menuBG.png");
        static Sprite _backgroundSprite;
        private int _selectedIndex = -1;
        private bool _hovering;
        Font font = new Font("./resources/fonts/arial.ttf");
        Game _ctx;

        public Menu(float width, float height, Game ctx)
        {
            //Text menu1 = new Text
            //{
            //    Font = font,
            //    Color = Color.White,
            //    DisplayedString = "Play Game",
            //    Position = new Vector2f(width / 2, height / (3 + 1) * 1)
            //};
            //menu[0] = menu1;

            //Text menu2 = new Text
            //{
            //    Font = font,
            //    Color = Color.White,
            //    DisplayedString = "Exit Game",
            //    Position = new Vector2f(width / 2, height / (3 + 1) * 2)
            //};
            //menu[1] = menu2;
            _ctx = ctx;

            Sprite button1 = new Sprite(_ctx._menuTextures[0])
            {
                Position = new Vector2f((width / 7) * 2, height / (3 + 1) * 1),
                Scale = new Vector2f(0.7f, 0.7f),
            };
            _menu[0] = button1;

            Sprite button2 = new Sprite(_ctx._menuTextures[1])
            {
                Position = new Vector2f((width / 7) * 2, height / (3 + 1) * 2.5f),
                Scale = new Vector2f(0.7f, 0.7f),
            };
            _menu[1] = button2;
        }

        public int SelectedItem
        {
            get { return _selectedIndex; }
        }

        public void Draw(RenderWindow window)
        {
            for (int i = 0; i < 2; i++)
            {
                window.Draw(_menu[i]);
            }
        }

        public void CheckMouse(RenderWindow window)
        {
            _hovering = false;
            for (int i = 0; i < 2; i++)
            {
                if (_menu[i].GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    // Ici 2 est le nombre de cases avant d'arriver à la seconde texture du bouton
                    _menu[i].Texture = _ctx._menuTextures[i + 2];
                    _selectedIndex = i;
                    _hovering = true;
                }
            }
            if (_hovering == false)
            {
                if (_selectedIndex != -1) _menu[_selectedIndex].Texture = _ctx._menuTextures[_selectedIndex];
                _selectedIndex = -1;
            }
            else
            {
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    if (_selectedIndex == 0) _ctx._state = 1 ; //launch game
                    else if (_selectedIndex == 1) window.Close();
                }
            }
        }

        public bool IsHovering => _hovering;
    }
}
