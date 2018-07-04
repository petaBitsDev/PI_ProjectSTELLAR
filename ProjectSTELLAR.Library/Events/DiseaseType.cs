using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]

    public class DiseaseType : IEventType
    {

        float _diseaseProbability;

        bool _isGettingSick;

        bool _previousDisease;

        int _nbDiseaseMax;

        int _nbDiseaseReal;

        List<Building> _building;

        bool _isTakingABed;

        bool _eventHandle;
        Map _ctx;


        public DiseaseType(Map ctx)
        {
            _ctx = ctx;
            _diseaseProbability = 0.1f;
            _previousDisease = false;
            _building = new List<Building>();

        }

        public Disease CreateEvent()
        {
            Disease disease = new Disease(_ctx, this);
            return disease;
        }
        public bool IsTakingABed
        {
            get { return _isTakingABed; }
            set { _isTakingABed = value; }
        }


        public bool PreviousEvent
        {
            get { return _previousDisease; }
            set { _previousDisease = value; }
        }
        public bool IsEventHappening
        {
            get { return _isGettingSick; }
            set { _isGettingSick = value; }
        }
      
        public int NbEventMax
        {
            get { return _nbDiseaseMax; }
            set { _nbDiseaseMax = value; }
        }

        public int NbEventReal
        {
            get { return _nbDiseaseReal; }
            set { _nbDiseaseReal = value; }
        }
        public float EventProbability
        {
            get { return _diseaseProbability; }
            set { _diseaseProbability = value; }
        }
        public List<Building> BuildingHasEvent
        {
            get { return _building; }
            set { _building = value; }
        }

        public void SelectKindOfSick()
        {
            int choice;
            Random random = new Random();
            choice = random.Next(2);
            if (choice == 0) _isTakingABed = true;
            else _isTakingABed = false;

        }


        public void CalculEventProbability()
        {
            if(PreviousEvent == false)
            {
                EventProbability += 0.1f;
            }
            else
            {
                EventProbability -= 0.3f;
            }
        }

        public void CalculNbEventMax()
        {
            HospitalType hospitalType = (HospitalType)_ctx.BuildingTypes[3];
            int totalNbVehicule = 0;
            int totalNbBed = 0;
            for(int i = 0; i < hospitalType.List.Count; i++)
            {
                Hospital h = (Hospital)hospitalType.List[i];
                totalNbVehicule += h.NbVehicule;
                totalNbBed += h.NbBed;
            }

            if(totalNbVehicule < 3 && totalNbBed < 20)
            {
                NbEventMax = 2;
            }
            else if(totalNbVehicule < 6 && totalNbBed < 50)
            {
                NbEventMax = 3;
            }
            else 
            {
                NbEventMax = 5;
            }
        }

        public void CalculNbEventReal()
        {
            Random random = new Random();

            CalculNbEventMax();

            NbEventReal = random.Next(NbEventMax + 1);
            Console.WriteLine("DISEASE NB EVENT :" + NbEventReal);
        }

        public void IsBuildingGettingEvent()
        {
            int probability;
            
            Random random = new Random();
            probability = random.Next(1, 101);
            Console.WriteLine("DISEASE probability :" + probability );
            Console.WriteLine();

            Console.WriteLine("DISEASE EVENTPROBABILITY :" + EventProbability * 10);
            if(probability <= EventProbability * 10)
            {
                IsEventHappening = true;
            }
            else
            {
                IsEventHappening = false;
            }
        }

   
    }
}
