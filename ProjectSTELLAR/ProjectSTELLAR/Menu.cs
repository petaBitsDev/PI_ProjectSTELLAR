using SFML.Audio;
using SFML.Window;
using SFML.Graphics;
using System;
using SFML.System;

namespace ProjectSTELLAR.Library
{
    class Menu
    {
        readonly Text[] menu = new Text[2];
        static Texture _backgroundTexture = new Texture("../../../ressources/83504.png");
        static Sprite _backgroundSprite;
        private int selectedItem;
        Font font = new Font("../../../ressources/arial.ttf");

        public Menu(float width, float height)
        {
            Text menu1 = new Text
            {
                Font = font,
                Color = Color.White,
                DisplayedString = "Play Game",
                Position = new Vector2f(width / 2, height / (3 + 1) * 1)
            };
            menu[0] = menu1;

            Text menu2 = new Text
            {
                Font = font,
                Color = Color.White,
                DisplayedString = "Exit Game",
                Position = new Vector2f(width / 2, height / (3 + 1) * 2)
            };
            menu[1] = menu2;
            _backgroundSprite = new Sprite(_backgroundTexture);
        }

        public int SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; }
        }

        public void Draw(RenderWindow window)
        {
            _backgroundSprite.Draw(window, RenderStates.Default);
            for (int i = 0; i < 2; i++)
            {
                window.Draw(menu[i]);
            }
        }

        public void Move(Keyboard.Key key)
        {
            if (key == Keyboard.Key.Up)
            {
                menu[selectedItem].Color = Color.White;
                selectedItem--;
                if (selectedItem < 0) selectedItem = 0;
                menu[selectedItem].Color = Color.Yellow;
            }
            else if (key == Keyboard.Key.Down)
            {
                menu[selectedItem].Color = Color.White;
                selectedItem++;
                if (selectedItem > 1) selectedItem = 1;
                menu[selectedItem].Color = Color.Yellow;
            }
        }
    }
}
