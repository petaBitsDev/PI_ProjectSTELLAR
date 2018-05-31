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
    public class DrawBuildings
    {
        readonly Game _ctx;
        readonly Dictionary<BuildingType, Texture> _textures = new Dictionary<BuildingType, Texture>();
        UI _ui;
        Map _map;
        Building building;


        public DrawBuildings(Game ctx, UI ui, Map map)
        {
            _ctx = ctx;
            //_textures.Add(typeof(FireStation), _ctx._buildingsTextures[0]);
            //_textures.Add(HutType, _ctx._buildingsTextures[1]);
            //_textures.Add(typeof(FlatType), _ctx._buildingsTextures[2]);
            //_textures.Add(typeof(HouseType), _ctx._buildingsTextures[3]);
            //_textures.Add(typeof(PowerPlantType), _ctx._buildingsTextures[4]);
            //_textures.Add(typeof(PumpingStationType), _ctx._buildingsTextures[5]);
            //_textures.Add(typeof(CityHallType), _ctx._buildingsTextures[7]);
            //_textures.Add(typeof(FireStationType), _ctx._buildingsTextures[8]);
            //_textures.Add(typeof(HospitalType), _ctx._buildingsTextures[9]);
            //_textures.Add(typeof(PoliceStationType), _ctx._buildingsTextures[10]);
            //_textures.Add(typeof(SpaceStationType), _ctx._buildingsTextures[11]);
            //_textures.Add(typeof(SawmillType), _ctx._buildingsTextures[12]);
            //_textures.Add(typeof(OreMineType), _ctx._buildingsTextures[13]);
            //_textures.Add(typeof(MetalMineType), _ctx._buildingsTextures[14]);
            //_textures.Add(typeof(WarehouseType), _ctx._buildingsTextures[15]);
            _ui = ui;
            _map = map;
        }

        public void Draw (Type buildingType, RenderWindow window, int x, int y, Font font)
        {
            Vector2i pixelPos = Mouse.GetPosition(window);
            Vector2f worldPos = window.MapPixelToCoords(pixelPos, _ctx._windowEvents.View);

            //_textures.TryGetValue(buildingType, out Texture texture);
            //Sprite sprite = new Sprite(texture);
            //sprite.Position = new Vector2f(x*32, y*32);
            //window.Draw(sprite);

            
            //RectangleShape rec = new RectangleShape();
            //rec.OutlineColor = new Color(Color.Transparent);
            //rec.OutlineThickness = 3.0f;
            //rec.FillColor = new Color(253,254,254);
            
            
            //rec.Size = new Vector2f(32 * 8, 32 * 4);
            //rec.Position = new Vector2f((x * 32), (y * 32 - 32 * 6));

            //building = _map.Boxes[y, x];


            
            //    if (sprite.GetGlobalBounds().Contains(worldPos.X, worldPos.Y))
            //    {
            //        window.SetView(_ctx._windowEvents.View);
            //        window.Draw(rec);
            //        _ui.DrawBuildingInformations(window, font, building, x, y);
            //    }
            
      
        }
    }
}
