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
        SatisfactionManager _satisfaction;
        UI _ui;
        uint _width;
        uint _height;
        GameTime _gameTime;

        public DrawUI (Game context, Map ctx, uint width, uint height, Resolution resolution, GameTime gameTime, ResourcesManager resourcesManager, ExperienceManager experienceManager, SatisfactionManager satisfaction)
        {
            _gameCtx = context;
            _mapCtx = ctx;
            _resourcesCtx = resourcesManager;
            _satisfaction = satisfaction;
            _width = width;
            _height = height;
            _gameTime = gameTime;
            _ui = new UI(_gameCtx, resolution, _mapCtx, this, _width, _height, _gameTime, resourcesManager, experienceManager);
            _mapUI = new MapUI(_gameCtx, _mapCtx, _width, _height, this, _ui, resolution, _resourcesCtx);
            context._view.Viewport = new FloatRect(0, 0, 0.93f, 0.95f);
        }

        public void RenderSprite
            (Sprite tmpSprite, RenderWindow target, uint destX, uint destY, int sourceX, int sourceY, int sourceWidth, int sourceHeight)
        {
            tmpSprite.TextureRect = new IntRect(sourceX, sourceY, sourceWidth, sourceHeight);
            Sprite sprite = new Sprite(tmpSprite);
            sprite.Position = new Vector2f(destX, destY);
            target.Draw(sprite);
        }

        public void RenderGraphics(RenderWindow window, Font font, GameTime gameTime, ResourcesManager resources)
        {
            //   _mapUI.DrawGrid(window);
            window.SetView(_gameCtx._windowEvents.View);
            _mapUI.DrawMapTile(window, _mapCtx.Boxes, font);
            window.SetView(window.DefaultView);
            _ui.DrawResourcesBar(window, font, resources.NbResources, _satisfaction.Satifaction);
            _ui.DrawTimeBar(window, gameTime, font);
            _ui.DrawBuildButton(window, font);
            _ui.DrawDestroyButton(window);
            _ui.DrawExperience(window, font);
            _ui.DrawInGameMenu(window, font, gameTime);
            _ui.DrawMouseCursor(window);
        }

        public MapUI MapUI => _mapUI;

        public Map Map
        {
            get { return _mapCtx; }
            set { _mapCtx = value; }
        }

        public UI UI => _ui;

        public void UpdateData(Map map, ResourcesManager resources, ExperienceManager experience, SatisfactionManager satisfaction)
        {
            Map = map;
            MapUI.MapContext = map;
            UI.Map = map;

            _resourcesCtx = resources;
            UI.ResourcesManager = resources;
            UI.ExperienceManager = experience;
            UI.UpdateBuildingTabs();
            MapUI.ResourcesManager = resources;
            _satisfaction = satisfaction;
        }
    }
}