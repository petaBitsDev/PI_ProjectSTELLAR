using ProjectStellar.Library;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace ProjectStellar
{
    class MenuLoadGame
    {
        string _chosenSave;
        SaveGame _saveChoice;
        float _width;
        float _height;
        View _view;
        Game _ctx;
        int _selectedIndex;
        private bool _hovering;
        Sprite _backButton;
        bool _saveSelected;

        public MenuLoadGame(float width, float height, Game ctx, View view)
        {
            _ctx = ctx;
            _width = width;
            _height = height;
            _view = view;
            _backButton = new Sprite(_ctx._menuTextures[12])
            {
                Position = new Vector2f(32, 32)
            };
        }
        public int SelectedItem
        {
            get { return _selectedIndex; }
        }

        public bool Hoovering
        {
            get { return _hovering; }
            set { _hovering = value; }
        }
        public void Draw(RenderWindow window)
        {
            List<SaveGameMetadata> list = Save.List();
            int i = 1;
            _backButton.Draw(window, RenderStates.Default);

            foreach(SaveGameMetadata metadata in list)
            {

                RectangleShape rec = new RectangleShape();
                rec.Size = new Vector2f(32 * 15, 32 * 3);
                rec.Position = new Vector2f(_ctx.Resolution.X / 2 - (32 * 8), i * 32);
                rec.FillColor = new Color(30, 40, 40);
                rec.OutlineColor = new Color(Color.Black);
                rec.OutlineThickness = 3.0f;
                
                Text nom = new Text(metadata.Name.ToString(), _ctx._font)
                {
                    CharacterSize = 25,
                    Color = new Color(Color.White),
                    Style = Text.Styles.Bold,
                    Position = new Vector2f(rec.Position.X + 32, rec.Position.Y + 10)
                };

                Text population = new Text("Population : "+ metadata.Population.ToString(), _ctx._font)
                {
                    CharacterSize = 15,
                    Color = new Color(Color.White),
                    Style = Text.Styles.Bold,
                    Position = new Vector2f(rec.Position.X + 32 * 5, rec.Position.Y + 32 * 2 - 5)
                };

                Text date = new Text(metadata.Date.ToString("dd/MM/yyyy HH:mm"), _ctx._font)
                {
                    CharacterSize = 15,
                    Color = new Color(Color.White),
                    Style = Text.Styles.Bold,
                    Position = new Vector2f(rec.Position.X + (32 * 9), rec.Position.Y + 10)
                };
                i += 4;

                rec.Draw(window, RenderStates.Default);
                nom.Draw(window, RenderStates.Default);
                population.Draw(window, RenderStates.Default);
                date.Draw(window, RenderStates.Default);

                if (rec.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                {
                    Hoovering = true;
                    if (Hoovering)
                    {
                        nom.Color = Color.Yellow;
                        date.Color = Color.Yellow;
                        population.Color = Color.Yellow;
                        nom.Draw(window, RenderStates.Default);
                        population.Draw(window, RenderStates.Default);
                        date.Draw(window, RenderStates.Default);
                    }

                    //if(Mouse.IsButtonPressed(Mouse.Button.Left))
                    //{
                    //    _chosenSave = metadata.Name;
                    //    _saveSelected = true;
                    //    _saveChoice = Save.LoadGame(_chosenSave);
                    //}
                }

                //if(_backButton.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
                //{
                //    if(Mouse.IsButtonPressed(Mouse.Button.Left))
                //    {
                //        _ctx.MenuState = 0;
                //    }
                //}
            }
        }

        public void CheckMouse(float mouseX, float mouseY)
        {
            List<SaveGameMetadata> list = Save.List();
            int i = 1;

            if (_backButton.GetGlobalBounds().Contains(mouseX, mouseY))
                _ctx.MenuState = 0;
            else
            {
                foreach (SaveGameMetadata metadata in list)
                {
                    RectangleShape rec = new RectangleShape()
                    {
                        Size = new Vector2f(32 * 15, 32 * 3),
                        Position = new Vector2f(_ctx.Resolution.X / 2 - (32 * 8), i * 32)
                    };

                    if (rec.GetGlobalBounds().Contains(mouseX, mouseY))
                    {
                        _chosenSave = metadata.Name;
                        _saveSelected = true;
                        _saveChoice = Save.LoadGame(_chosenSave);
                        _ctx.LoadGame(_saveChoice);
                        _ctx.MenuState = 1;
                    }

                    i += 4;
                }
            }
        }

        public SaveGame ChosenSave
        {
            get { return _saveChoice; }
        }

        public bool SaveSelected => _saveSelected;
    }
}
