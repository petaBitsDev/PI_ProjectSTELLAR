using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    public class GameTime
    {
        private float _deltaTime = 0f;
        private float _timeScale = 2500f;
        private DateTime _inGameTime = new DateTime(2018, 4, 23, 11, 23, 00);

        public GameTime()
        {

        }

        public float TimeScale
        {
            get { return _timeScale; }
            set { _timeScale = value; }
        }

        public float DeltaTime
        {
            get { return _deltaTime * _timeScale; }
            private set { _deltaTime = value; }
        }

        public float TotalTimeElapsed
        {
            get;
            private set;
        }

        public void Update(float deltaTime, float totalTimeElapsed)
        {
            _deltaTime = deltaTime;
            TotalTimeElapsed = totalTimeElapsed;

            _inGameTime = _inGameTime.AddSeconds((double)(_deltaTime * _timeScale));
        }

        public DateTime InGameTime => _inGameTime;
    }
}
