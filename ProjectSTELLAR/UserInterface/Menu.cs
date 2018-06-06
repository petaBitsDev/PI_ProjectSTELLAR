using SFML.Audio;
using SFML.Window;
using SFML.Graphics;
using System;
using SFML.System;

namespace ProjectStellar
{
    class Menu
    {
        readonly Sprite[] _menu = new Sprite[3];
        static Texture _backgroundTexture = new Texture("./resources/img/backg.png");
        static Sprite _backgroundSprite;
        private int _selectedIndex = -1;
        private bool _hovering;
        Font font = new Font("./resources/fonts/arial.ttf");
        Game _ctx;
        View _view;

        public Menu(float width, float height, Game ctx, View view)
        {
            _ctx = ctx;
            _view = view;

            Sprite button1 = new Sprite(_ctx._menuTextures[0])
            {
                Position = new Vector2f(_view.Size.X / 2 - 200, _view.Size.Y * 1/3 - 40),
                Scale = new Vector2f(0.5f, 0.5f),
            };
            _menu[0] = button1;

            Sprite button2 = new Sprite(_ctx._menuTextures[1])
            {
                Position = new Vector2f(_view.Size.X / 2 - 200, _view.Size.Y / 2),
                Scale = new Vector2f(0.5f, 0.5f),
            };
            _menu[1] = button2;

            Sprite button3 = new Sprite(_ctx._menuTextures[2])
            {
                Position = new Vector2f(_view.Size.X / 2 - 200, _view.Size.Y * 2/3 + 40),
                Scale = new Vector2f(0.5f, 0.5f)
            };
            _menu[2] = button3;
        }

        public int SelectedItem
        {
            get { return _selectedIndex; }
        }

        public void Draw(RenderWindow window)
        {
            for (int i = 0; i < 3; i++)
            {
                window.Draw(_menu[i]);
            }
        }

        public void CheckMouse(RenderWindow window)
        {
            _hovering = false;
            for (int i = 0; i < 3; i++)
            {
                if (_menu[i].GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    // Ici 2 est le nombre de cases avant d'arriver à la seconde texture du bouton
                    _menu[i].Texture = _ctx._menuTextures[i + 4];
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
                    if (_selectedIndex == 0) _ctx.MenuState = 3; //launch game
                    else if (_selectedIndex == 1) _ctx.MenuState = 2;
                    else if (_selectedIndex == 2) window.Close();
                }
            }
        }

        public bool IsHovering => _hovering;
    }
}
