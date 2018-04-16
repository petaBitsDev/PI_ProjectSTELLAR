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
        static Texture _backgroundTexture = new Texture("./resources/img/83504.png");
        static Sprite _backgroundSprite;
        private int _selectedItem = -1;
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
                Position = new Vector2f((width / 5) * 2, height / (3 + 1) * 1),
                Scale = new Vector2f(0.1f, 0.1f),
            };
            _menu[0] = button1;

            Sprite button2 = new Sprite(_ctx._menuTextures[2])
            {
                Position = new Vector2f((width / 5) * 2, height / (3 + 1) * 2),
                Scale = new Vector2f(0.1f, 0.1f),
            };
            _menu[1] = button2;
        }

        public int SelectedItem
        {
            get { return _selectedItem; }
        }

        public void Draw(RenderWindow window)
        {
            for (int i = 0; i < 2; i++)
            {
                window.Draw(_menu[i]);
            }
        }

        public int CheckMouse()
        {
            for (int i = 0; i < 2; i++)
            {
                if (_menu[i].GetLocalBounds().Contains((float)Mouse.GetPosition().X, (float)Mouse.GetPosition().Y))
                {
                    //if (i != _selectedItem)
                    //{
                    //    _menu[i].Texture = _ctx._menuTextures[i + 1];
                    //    return true;
                    //}
                    return (i);
                }
                
            }
            return -1;
        }

        public void Move(Keyboard.Key key)
        {
            if (key == Keyboard.Key.Up)
            {
                _menu[_selectedItem].Color = Color.White;
                _selectedItem--;
                if (_selectedItem < 0) _selectedItem = 0;
                _menu[_selectedItem].Color = Color.Yellow;
            }
            else if (key == Keyboard.Key.Down)
            {
                _menu[_selectedItem].Color = Color.White;
                _selectedItem++;
                if (_selectedItem > 1) _selectedItem = 1;
                _menu[_selectedItem].Color = Color.Yellow;
            }
        }
    }
}
