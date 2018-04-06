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
        private float _timeScale = 1f;

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
        }
    }
}
