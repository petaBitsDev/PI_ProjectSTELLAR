using ProjectStellar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
        public class CityManager
    {
        int _totalPollution;
        int _totalTaxes ;
        Map _ctx;
        Dictionary<string, int> _nbResources = new Dictionary<string, int>();


        public  CityManager(Map ctx)
        {
            _ctx = ctx;
        }

        public Dictionary<string, int> nbResources => _nbResources;
        public int CityTaxes
        {
            get { return _totalTaxes = (Hut.Tax * NbHut) + (House.Tax * NbHouse) + (Flat.Tax * NbFlat);  }
        }

        public int CityPollution
        {
            get { return _totalPollution = (Hut.Pollution * NbHut) + (House.Pollution * NbHouse) + (Flat.Pollution * NbFlat); }
           
        }

        private int NbHut
        {
            get
            {
                
                _ctx.NbBuilding.TryGetValue("hut", out int nbHut);
                return nbHut;
            }
        }

        private int NbHouse
        {
            get
            {
               
                _ctx.NbBuilding.TryGetValue("house", out int nbHouse);
                return nbHouse;
            }
        }

        private int NbFlat
        {
            get {
               _ctx.NbBuilding.TryGetValue("flat", out int nbFlat);
               
                return nbFlat;
                }
      
        }


    }
}
