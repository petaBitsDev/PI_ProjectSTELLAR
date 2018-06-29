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
        Sprite _backButton;
        bool _saveSelected;
        List<FloatRect> _deletes;
        float _y1;
        float _y2;

        public MenuLoadGame(float width, float height, Game ctx)
        {
            _ctx = ctx;
            _width = width;
            _height = height;
            _backButton = new Sprite(_ctx._menuTextures[12])
            {
                Position = new Vector2f(32, 32)
            };
        }

        public void Draw(RenderWindow window)
        {
            List<SaveGameMetadata> list = Save.List();
            int i = 1;
            _backButton.Draw(window, RenderStates.Default);
            _deletes = new List<FloatRect>();

            Vector2i pixelPos = Mouse.GetPosition(window);
            Vector2f worldPos = window.MapPixelToCoords(pixelPos, _view);

            window.SetView(_view);

            foreach (SaveGameMetadata metadata in list)
            {

                RectangleShape rec = new RectangleShape();
                rec.Size = new Vector2f(32 * 15, 32 * 3);
                rec.Position = new Vector2f(_ctx.Resolution.X / 2 - (32 * 8), i * 32);
                rec.FillColor = new Color(30, 40, 40);
                rec.OutlineColor = new Color(Color.Black);
                rec.OutlineThickness = 3.0f;
                Sprite delete = new Sprite(_ctx._uiTextures[22])
                {
                    Position = new Vector2f(rec.Position.X + rec.Size.X + 15, rec.Position.Y + 10)
                };
                _deletes.Add(new FloatRect(delete.Position.X, delete.Position.Y, delete.Texture.Size.X, delete.Texture.Size.Y));

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
                delete.Draw(window, RenderStates.Default);

                if (rec.GetGlobalBounds().Contains(worldPos.X, worldPos.Y))
                {
                    nom.Color = Color.Yellow;
                    date.Color = Color.Yellow;
                    population.Color = Color.Yellow;
                    nom.Draw(window, RenderStates.Default);
                    population.Draw(window, RenderStates.Default);
                    date.Draw(window, RenderStates.Default);
                }
            }

            window.SetView(window.DefaultView);
        }

        public void CheckMouse(int mouseX, int mouseY, RenderWindow window)
        {
            List<SaveGameMetadata> list = Save.List();
            int i = 1;
            int j = 0;
            
            Vector2i pixelPos = Mouse.GetPosition(window);
            Vector2f worldPos = window.MapPixelToCoords(pixelPos, _view);

            if (_backButton.GetGlobalBounds().Contains(pixelPos.X, pixelPos.Y))
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

                    if (rec.GetGlobalBounds().Contains(worldPos.X, worldPos.Y))
                    {
                        _chosenSave = metadata.Name;
                        _saveSelected = true;
                        _saveChoice = Save.LoadGame(_chosenSave);
                        _ctx.LoadGame(_saveChoice);
                        _ctx.MenuState = 1;
                    }
                    else if (_deletes[j].Contains(worldPos.X, worldPos.Y))
                    {
                        Save.DeleteSave(metadata.Name);
                        //Console.WriteLine("deleted : " + metadata.Name);
                    }

                    i += 4;
                    j++;
                }
            }
        }

        public SaveGame ChosenSave
        {
            get { return _saveChoice; }
        }

        public bool SaveSelected => _saveSelected;

        public void SetLoadMenu()
        {
            int nbSaves = Save.List().Count;
            _y1 = 0;
            _y2 = 1 * 32 + (4 * 32) * nbSaves;
            
            _view = new View(new Vector2f(_width / 2, _height / 2), new Vector2f(_width, _height));

            _ctx.MenuState = 2;
        }

        public void Scroll(float delta)
        {
            //Console.WriteLine("Y1 = {0}\n Y2 = {1}", _y1, _y2);
            //Up
            if (delta < 0 && _y2 > _height)
            {
                _view.Move(new Vector2f(0, 50));
                _y1 += -50;
                _y2 += -50;
            }
            //Down
            else if (delta > 0 && _y1 < 0)
            {
                _view.Move(new Vector2f(0, -50));
                _y1 += 50;
                _y2 += 50;
            }
        }
    }
}