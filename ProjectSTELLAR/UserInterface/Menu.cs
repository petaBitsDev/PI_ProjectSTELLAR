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
        Sprite[] _menuActif = new Sprite[3];
        Sprite _newGame;
        Sprite _loadGame;
        Sprite _quitGame;
        static Texture _backgroundTexture = new Texture("./resources/img/backg.png");
        static Sprite _backgroundSprite;
        private int _selectedIndex = -1;
        private bool _hovering;
        Font font = new Font("./resources/fonts/arial.ttf");
        Game _ctx;
        View _view;
        RenderWindow _window;

        public Menu(float width, float height, Game ctx, View view, RenderWindow window)
        {
            _ctx = ctx;
            _view = view;
            _window = window;

            _newGame = new Sprite(_ctx._menuTextures[0])
            {
                Position = new Vector2f(_view.Size.X / 2 - 200, _view.Size.Y * 1/3 - 40),
                Scale = new Vector2f(0.5f, 0.5f),
            };
            _menu[0] = _newGame;

            _loadGame = new Sprite(_ctx._menuTextures[1])
            {
                Position = new Vector2f(_view.Size.X / 2 - 200, _view.Size.Y / 2),
                Scale = new Vector2f(0.5f, 0.5f),
            };
            _menu[1] = _loadGame;

            _quitGame = new Sprite(_ctx._menuTextures[3])
            {
                Position = new Vector2f(_view.Size.X / 2 - 200, _view.Size.Y * 2/3 + 40),
                Scale = new Vector2f(0.5f, 0.5f)
            };
            _menu[2] = _quitGame;

            Sprite button4 = new Sprite(_ctx._menuTextures[5])
            {
                Position = new Vector2f(_view.Size.X / 2 - 200, _view.Size.Y * 1 / 3 - 40),
                Scale = new Vector2f(0.5f, 0.5f),
            };
            _menuActif[0] = button4;

            Sprite button5 = new Sprite(_ctx._menuTextures[6])
            {
                Position = new Vector2f(_view.Size.X / 2 - 200, _view.Size.Y / 2),
                Scale = new Vector2f(0.5f, 0.5f),
            };
            _menuActif[1] = button5;

            Sprite button6 = new Sprite(_ctx._menuTextures[8])
            {
                Position = new Vector2f(_view.Size.X / 2 - 200, _view.Size.Y * 2 / 3 + 40),
                Scale = new Vector2f(0.5f, 0.5f)
            };
            _menuActif[2] = button6;
        }

        public int SelectedItem
        {
            get { return _selectedIndex; }
        }

        public void Draw()
        {
            for (int i = 0; i < 3; i++)
            {
                _window.Draw(_menu[i]);
            }
        }

        public void CheckMouse(RenderWindow window)
        {
            _hovering = false;
            for (int i = 0; i < 3; i++)
            {
                if (_menu[i].GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    // Ici 4 est le nombre de cases avant d'arriver à la seconde texture du bouton
                    _menu[i] = _menuActif[i];
                    _selectedIndex = i;
                    _hovering = true;
                }
            }
            if (_hovering == false)
            {
                if (_selectedIndex != -1)
                {
                    _menu[0] = _newGame;
                    _menu[1] = _loadGame;
                    _menu[2] = _quitGame;
                }
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
