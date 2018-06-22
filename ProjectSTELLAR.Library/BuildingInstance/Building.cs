﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
    public abstract class Building
    {
        BuildingType _buildingType;
        readonly int _x;
        readonly int _y;
        int _size;
        bool _onFire;
        bool _isSick;
        bool _isCrimeVictim;
        List<Building> _instanceBuilding = new List<Building>();
        List<ExplorationShips> _list = new List<ExplorationShips>();
        Vector _spritePosition;

        public Building(BuildingType buildingType, int x, int y)
        {
            _x = x;
            _y = y;
            _buildingType = buildingType;
            _size = buildingType.Size;
            _onFire = false;
            _isSick = false;
            _isCrimeVictim = false;
            _spritePosition = new Vector(_x, _y);
        }

        public virtual void SendShip(ExplorationShips ship, DateTime inGameTime)
        {
            DateTime end = inGameTime.AddHours(1.0);

            ship.UndisposedTime = end;
            ship.IsAvailable = false;
        }
        
        public abstract Vector SpritePosition { get; set; }
        public virtual List<ExplorationShips> ShipList { get; set; }
        public abstract bool IsVictimCrime{get; set;}
        public abstract bool OnFire { get; set; }
        public abstract bool IsSick { get; set; }
        public int X => _x;
        public int Y => _y;
        public BuildingType Type => _buildingType;
        public int Size => _size;
    }
}