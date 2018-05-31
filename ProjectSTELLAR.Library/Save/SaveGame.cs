﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProjectStellar;

namespace ProjectStellar.Library
{
    [Serializable]
    public class SaveGame
    {
        string _name;
        Map _map;
        GameTime _gameTime;
        ResourcesManager _resourcesManager;

        public SaveGame(string name, Map map, GameTime gameTime, ResourcesManager resourcesManager)
        {
            _name = name;
            _map = map;
            _gameTime = gameTime;
            _resourcesManager = resourcesManager;
        }

        public string Name => _name;

        public int Population => _resourcesManager.NbResources["nbPeople"];

        public DateTime Date => _gameTime.InGameTime;

        public Map Map => _map;
        
        public GameTime GameTime => _gameTime;

        public ResourcesManager ResourcesManager => _resourcesManager;
    }
}
