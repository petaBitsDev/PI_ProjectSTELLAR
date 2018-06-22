using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    public class Truck
    {
        bool _isFree;
        float _speed;
        public Truck()
        {
            _speed = 0.25f;
        }

        public float Speed => _speed;

        public bool IsFree
        {
            get { return _isFree; }
            set { _isFree = value; }
        }
    }
}
