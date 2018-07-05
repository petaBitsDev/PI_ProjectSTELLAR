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
        bool _onReturn;
        float _speed;
        double _x;
        double _y;
        Vector _position;
        Vector _direction;
        TimeSpan _undisposedTime;
        DateTime _start;
        Building _targetType;
        Building _firestation;

        public Truck(Building firestation, double x, double y)
        {
            _firestation = firestation;
            _random = new Random();
            _position = new Vector(y, x);
            _direction = new Vector();
            _speed = 0.0001f;
            _onReturn = false;
            _isFree = true;
            _undisposedTime = new TimeSpan(0,0,0);
        }

        public TimeSpan UndisposedTime
        {
            get { return _undisposedTime; }
            set { _undisposedTime = value; }
        }

        public void Update()
        {
            Position = MathHelpers.MoveTo(Position, Target, Speed);
        }

        public float Speed => _speed;

        public Vector Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public Vector Target
        {
            get { return _direction; }
            set { _direction = value; }
        }
        public bool IsFree
        {
            get { return _isFree; }
            set { _isFree = value; }
        }

        public bool OnReturn
        {
            get { return _onReturn; }
            set { _onReturn = value; }
        }

        public DateTime StartTime
        {
            get { return _start; }
            set { _start = value; }
        }

        public Building TargetType
        {
            get { return _targetType; }
            set { _targetType = value; }
        }

        public Building FireStation
        {
            get { return _firestation; }
        }
    }
}
