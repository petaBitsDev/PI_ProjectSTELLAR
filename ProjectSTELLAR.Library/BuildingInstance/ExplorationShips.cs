using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
    public class ExplorationShips
    {
        bool _available;
        string _resource;
        int _nbResources;
        DateTime _undisposedTime;

        public ExplorationShips()
        {
            _available = true;
            _resource = "";
            _nbResources = 0;
            _undisposedTime = DateTime.Now;
        }

        public void FetchResource ()
        {
            Random n = new Random();
            this.NbResources += n.Next(1, 3);
        }

        public string Resource
        {
            get { return _resource; }
            set { _resource = value; }
        }

        public int NbResources
        {
            get { return _nbResources; }
            set { _nbResources = value; }
        }

        public bool IsAvailable
        {
            get { return _available; }
            set { _available = value; }
        }

        public DateTime UndisposedTime
        {
            get { return _undisposedTime; }
            set { _undisposedTime = value; }
        }
    }
}
