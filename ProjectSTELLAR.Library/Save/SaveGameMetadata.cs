using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
    public class SaveGameMetadata
    {
        string _name;
        DateTime _date;
        int _population;

        public SaveGameMetadata(string name, DateTime date, int population)
        {
            _name = name;
            _date = date;
            _population = population;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public int Population
        {
            get { return _population; }
            set { _population = value; }
        }
    }
}
