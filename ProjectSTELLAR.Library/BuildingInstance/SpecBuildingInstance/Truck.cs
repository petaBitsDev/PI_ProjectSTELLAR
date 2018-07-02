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
        Random _random;
        bool _isFree;
        float _speed;
        double _x;
        double _y;
        Vector _position;
        Vector _direction;

        public Truck(double x, double y)
        {
            _x = x;
            _y = y;
            _random = new Random();
            _position = new Vector(_x, _y);
            _speed = 0.00025f;
            _isFree = true;
        }

        public float Speed => _speed;

        public Vector Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public Vector Destination
        {
            get { return _direction; }
            set { _direction = value; }
        }
        public bool IsFree
        {
            get { return _isFree; }
            set { _isFree = value; }
        }
    }
}
