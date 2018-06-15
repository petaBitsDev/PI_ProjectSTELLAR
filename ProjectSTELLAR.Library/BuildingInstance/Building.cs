using System;
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

        public Building(BuildingType buildingType, int x, int y)
        {
            _x = x;
            _y = y;
            _buildingType = buildingType;
            _size = buildingType.Size;
            _onFire = false;
            _isSick = false;
            _isCrimeVictim = false;
        }

        public abstract bool IsVictimCrime{get; set;}
        public abstract bool OnFire { get; set; }
        public abstract bool IsSick { get; set; }
        public int X => _x;
        public int Y => _y;
        public BuildingType Type => _buildingType;
        public int Size => _size;


    }
}