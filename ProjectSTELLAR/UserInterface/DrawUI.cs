using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using ProjectStellar.Library;
using System.Collections;

namespace ProjectStellar
{
    public class DrawUI
    {
        Game _gameCtx;
        Map _mapCtx;
        MapUI _mapUI;
        ResourcesManager _resourcesCtx;
        UI _ui;
        uint _width;
        uint _height;
        GameTime _gameTime;
        List<Building> _buildingList;

        public DrawUI (Game context, Map ctx, uint width, uint height, Resolution resolution, GameTime gameTime, ResourcesManager resourcesManager, List<Building> buildingList, ExperienceManager experienceManager)
        {
            _gameCtx = context;
            _mapCtx = ctx;
            _resourcesCtx = resourcesManager;
            _width = width;
            _height = height;
            _gameTime = gameTime;
            _buildingList = buildingList;
            _ui = new UI(_gameCtx, resolution, _mapCtx, this, _width, _height, _gameTime, _buildingList, resourcesManager, experienceManager);
            _mapUI = new MapUI(_gameCtx, _mapCtx, _width, _height, this, _ui, resolution);
        }

        public void RenderSprite
            (Sprite tmpSprite, RenderWindow target, uint destX, uint destY, int sourceX, int sourceY, int sourceWidth, int sourceHeight)
        {
            tmpSprite.TextureRect = new IntRect(sourceX, sourceY, sourceWidth, sourceHeight);
            tmpSprite.Position = new Vector2f(destX, destY);
            target.Draw(tmpSprite);
        }

        public void RenderGraphics(RenderWindow window, Font font, GameTime gameTime, ResourcesManager resources)
        {
            _mapUI.DrawMapTile(window, _mapCtx.Boxes, font);
         //   _mapUI.DrawGrid(window);
            _ui.DrawBuildButton(window, font);
            _ui.DrawDestroyButton(window);
            _ui.DrawResourcesBar(window, font, resources.NbResources);
            _ui.DrawTimeBar(window, gameTime, font);
            _ui.DrawExperience(window);
            _ui.DrawMenuInGame(window, font);
        }

        public MapUI MapUI => _mapUI;

        public Map Map
        {
            get { return _mapCtx; }
            set { _mapCtx = value; }
        }

        public UI UI => _ui;

        public void UpdateMap(Map map)
        {
            Map = map;
            MapUI.MapContext = map;
            UI.Map = map;
        }
    }
}
