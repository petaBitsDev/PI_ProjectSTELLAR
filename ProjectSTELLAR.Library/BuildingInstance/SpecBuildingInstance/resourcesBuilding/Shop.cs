using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
    class Shop : Building, IResourcesBuildings
    {
        bool _onFire;
        bool _isSick;
        bool _isVictimCrime;

        public Shop(BuildingType type, int x, int y) : base(type, x, y)
        {
        }

        public override bool OnFire
        {
            get { return _onFire; }
            set { _onFire = value; }
        }

        public override bool IsSick
        {
            get { return _isSick; }
            set { _isSick = value; }
        }

        public override bool IsVictimCrime
        {
            get { return _isVictimCrime; }
            set { _isVictimCrime = value; }
        }

        public override Vector SpritePosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}