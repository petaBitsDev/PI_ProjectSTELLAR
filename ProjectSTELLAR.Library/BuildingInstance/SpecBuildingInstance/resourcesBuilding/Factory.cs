using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library.BuildingInstance.SpecBuildingInstance.resourcesBuilding
{
    class Factory : Building, IResourcesBuildings
    {
        bool _onFire;
        bool _isSick;
        bool _isCrimeVictim;
        readonly BuildingType _type;
        Vector _spritePosition;

        public Factory(BuildingType type, int x, int y) : base(type, x, y)
        {
            _type = type;
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
            get { return _isCrimeVictim; }
            set { _isCrimeVictim = value; }
        }

        public override Vector SpritePosition
        {
            get { return _spritePosition; }
            set { _spritePosition = value; }
        }
    }
}