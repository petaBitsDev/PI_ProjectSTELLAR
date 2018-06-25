﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
    class Park : Building
    {
        bool _onFire;
        bool _isSick;
        bool _isVictimCrime;
        readonly BuildingType _type;

        public Park(BuildingType type, int x, int y) : base(type, x, y)
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
            get { return _isVictimCrime; }
            set { _isVictimCrime = value; }
        }
    }
}