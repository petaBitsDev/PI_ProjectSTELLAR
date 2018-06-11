using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    class Truck
    {
        bool _isFree;
        float _speed;
        public Truck()
        {
            _speed = 10.0f;
        }

        public float Speed => _speed;

        public bool IsFree
        {
            get { return _isFree; }
            set { _isFree = value; }
        }
    }
}
