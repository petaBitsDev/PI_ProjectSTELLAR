using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
    public class Truck
    {
        bool _isFree;
        float _speed;
        Vector _position;
        Vector _direction;

        public Truck()
        {
            _speed = 2.55f;
            _isFree = true;
        }

        public float Speed => _speed;

        public bool IsFree
        {
            get { return _isFree; }
            set { _isFree = value; }
        }
    }
}
