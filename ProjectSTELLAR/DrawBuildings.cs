using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace ProjectStellar
{
    public class DrawBuildings
    {
        readonly Game _ctx;
        readonly Dictionary<Type, Texture> _textures = new Dictionary<Type, Texture>();
        UI _ui;
        private CityHelper _listBuilding;
        Map _map;
        Building building;


        public DrawBuildings(Game ctx, UI ui, Map map)
        {
            _ctx = ctx;
            //_textures.Add(typeof(FireStation), _ctx._buildingsTextures[0]);
            _textures.Add(typeof(Hut), _ctx._buildingsTextures[1]);
            _textures.Add(typeof(Flat), _ctx._buildingsTextures[2]);
            _textures.Add(typeof(House), _ctx._buildingsTextures[3]);
            _textures.Add(typeof(PowerPlant), _ctx._buildingsTextures[4]);
            _textures.Add(typeof(PumpingStation), _ctx._buildingsTextures[5]);
            _textures.Add(typeof(CityHall), _ctx._buildingsTextures[7]);
            _textures.Add(typeof(FireStation), _ctx._buildingsTextures[8]);
            _textures.Add(typeof(Hospital), _ctx._buildingsTextures[9]);
            _textures.Add(typeof(PoliceStation), _ctx._buildingsTextures[10]);
            _textures.Add(typeof(SpaceStation), _ctx._buildingsTextures[11]);
            _textures.Add(typeof(Sawmill), _ctx._buildingsTextures[12]);
            _textures.Add(typeof(OreMine), _ctx._buildingsTextures[13]);
            _textures.Add(typeof(MetalMine), _ctx._buildingsTextures[14]);
            _textures.Add(typeof(Warehouse), _ctx._buildingsTextures[15]);
            _ui = ui;
            _map = map;
            _listBuilding = new CityHelper(_map);

        }

        public void Draw (Type buildingType, RenderWindow window, int x, int y, Font font)
        {
            
            _textures.TryGetValue(buildingType, out Texture texture);
            Sprite sprite = new Sprite(texture);
            sprite.Position = new Vector2f(x*32, y*32);
            window.Draw(sprite);

            
            RectangleShape rec = new RectangleShape();
            rec.OutlineColor = new Color(Color.Transparent);
            rec.OutlineThickness = 3.0f;
            rec.FillColor = new Color(253,254,254);
            
            
            rec.Size = new Vector2f(32 * 8, 32 * 4);
            rec.Position = new Vector2f((x * 32), (y * 32 - 32 * 6));

            building = _map.Boxes[y, x];

             
            
            if (sprite.GetGlobalBounds().Contains((float)Mouse.GetPosition(window).X, (float)Mouse.GetPosition(window).Y))
            {
                window.Draw(rec);
                _ui.DrawBuildingInformations(window, font, building, x, y);
                
            }
        }
    }
}
