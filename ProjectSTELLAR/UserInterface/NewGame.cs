using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using ProjectStellar.Library;

namespace ProjectStellar
{
    public class NewGame
    {
        readonly uint _resX;
        readonly uint _resY;
        readonly Game _ctx;
        string _name;
        Text _text;
        RectangleShape _textRectangle;
        Sprite _confirm;
        Sprite _confirmActif;
        Sprite _sprite;
        FloatRect _confirmBox;
        Sprite _cancel;
        FloatRect _cancelBox;
        Sprite _instructions;
        Text _error;

        public NewGame(uint resX, uint resY, Game ctx, Font font)
        {
            _resX = resX;
            _resY = resY;
            _ctx = ctx;
            _name = "";

            _text = new Text("", font)
            {
                Position = new Vector2f(resX / 5 * 2, resY / 5 * 2 + 15),
                Color = Color.White
            };

            _textRectangle = new RectangleShape()
            {
                Position = new Vector2f(resX / 2 - (7 * _text.CharacterSize * 0.75f) - 15, resY / 5 * 2 + 24),
                Size = new Vector2f(_text.CharacterSize * 18 * 0.7f, _text.CharacterSize),
                FillColor = Color.Black
            };

            _confirm = new Sprite(_ctx._menuTextures[13]);
            _confirm.Position = new Vector2f(resX / 2 - 32 * 6, resY / 5 * 3);
            _confirm.Scale = new Vector2f(0.5f, 0.5f);

            _confirmActif = new Sprite(_ctx._menuTextures[14]);
            _confirmActif.Position = new Vector2f(resX / 2 - 32 * 6, resY / 5 * 3);
            _confirmActif.Scale = new Vector2f(0.5f, 0.5f);

            _sprite = _confirm;

            //_confirmBox = new FloatRect(_confirm.Position.X + 20, _confirm.Position.Y + 30, _confirm.CharacterSize * _confirm.DisplayedString.Length * 0.75f, _confirm.CharacterSize);

            _cancel = new Sprite(_ctx._menuTextures[12]);
            _cancel.Position = new Vector2f(resX * 0.05f, resY * 0.05f);

            //_cancelBox = new FloatRect(_cancel.Position.X - 10, _cancel.Position.Y + 10, _cancel.CharacterSize * _cancel.DisplayedString.Length * 0.75f, _cancel.CharacterSize);

            _instructions = new Sprite(_ctx._menuTextures[15]);
            _instructions.Position = new Vector2f(resX / 2 - 32 * 12, resY / 13);

            _error = new Text("", font, 40)
            {
                Position = new Vector2f(resX / 6 * 2, resY / 5 * 4),
                Color = Color.Yellow
            };
        }

        public void Draw(RenderWindow window)
        {
            _instructions.Draw(window, RenderStates.Default);
            
            _textRectangle.Draw(window, RenderStates.Default);

            _text.DisplayedString = _name;
            _text.Position = new Vector2f((_resX / 2) - (_text.DisplayedString.Length / 2 * (_text.CharacterSize * 0.53f)) + 10, _text.Position.Y);
            _text.Draw(window, RenderStates.Default);

            if (_confirm.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y))
                _sprite = _confirmActif;
            else _sprite = _confirm;
            _sprite.Draw(window, RenderStates.Default);

            //if (_cancel.GetGlobalBounds().Contains(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y))
            //    _cancel.Color = Color.Yellow;
            //else _cancel.Color = Color.White;
            _cancel.Draw(window, RenderStates.Default);

            if (_error.DisplayedString != "")
                _error.Draw(window, RenderStates.Default);
        }

        public string Name
        {
            get { return _name; }
            set
            {
                bool valid = true;
                if (value.Length > 12)
                    return;

                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] < 'a' || value[i] > 'z')
                    {
                        if (value[i] < 'A' || value[i] > 'Z')
                        {
                            valid = false;
                        }
                    }
                }

                if (valid == true)
                    _name = value;
            }
        }

        public void CheckButtons(int x, int y)
        {
            if (_sprite.GetGlobalBounds().Contains(x, y) && Name != "")
            {
                if(Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    List<SaveGameMetadata> saveList = Save.List();
                    bool valid = true;

                    foreach(SaveGameMetadata save in saveList)
                    {
                        if (save.Name == Name)
                        {
                            valid = false;
                            _error.DisplayedString = Name + " already exists !";
                            return;
                        }
                    }

                    _ctx.StartNewGame();
                }
            }
            else if (_cancel.GetGlobalBounds().Contains(x, y)) _ctx.MenuState = 0;
        }
    }
}
