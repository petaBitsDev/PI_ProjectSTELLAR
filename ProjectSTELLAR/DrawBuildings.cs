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
        Game _ctx;
        Dictionary<Type, Texture> _textures = new Dictionary<Type, Texture>();

        public DrawBuildings(Game ctx)
        {
            _ctx = ctx;
            //_textures.Add(typeof(FireStation), _ctx._buildingsTextures[0]);
            _textures.Add(typeof(Hut), _ctx._buildingsTextures[1]);
            _textures.Add(typeof(Flat), _ctx._buildingsTextures[2]);
            _textures.Add(typeof(House), _ctx._buildingsTextures[3]);
        }

        public void Draw (Type buildingType, RenderWindow window, int x, int y)
        {
            _textures.TryGetValue(buildingType, out Texture texture);
            Sprite sprite = new Sprite(texture);
            sprite.Position = new Vector2f(x, y);
            window.Draw(sprite);
        }
    }
}
