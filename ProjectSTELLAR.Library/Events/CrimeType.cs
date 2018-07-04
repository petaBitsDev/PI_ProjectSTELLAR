using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProjectStellar.Library
{
    [Serializable]

    public class CrimeType : IEventType
    {
        // JOLANN WAS HERE

        Map _ctx;

        float _crimeProbability;

        bool _isCrime;

        bool _previousCrime;

        int _nbCrimeMax;

        int _nbCrimeReal;

        List<Building> _building;

        bool _eventHandle;


        public CrimeType(Map ctx)

        {
            _ctx = ctx;
            _previousCrime = false;

            _crimeProbability = 0.017f;

            _eventHandle = true;
            _building = new List<Building>();


        }

        internal Crime CreateEvent()
        {
            Crime crime = new Crime(_ctx, this);
            return crime;
        }

        public bool EventHandle
        {
            get { return _eventHandle; }
            set { _eventHandle = value; }

        }

        public bool PreviousEvent
        {
            get { return _previousCrime; }
            set { _previousCrime = value; }
        }

        public bool IsEventHappening
        {
            get { return _isCrime; }
            set { _isCrime = value; }
        }
        public int NbEventMax
        {
            get { return _nbCrimeMax; }
            set { _nbCrimeMax = value; }
        }
        public int NbEventReal
        {
            get { return _nbCrimeReal; }
            set { _nbCrimeReal = value; }
        }
        public float EventProbability
        {
            get { return _crimeProbability; }
            set { _crimeProbability = value; }
        }
        public List<Building> BuildingHasEvent
        {
            get { return _building; }
            set { _building = value; }
        }

    
        public void CalculEventProbability()
        {
            if (PreviousEvent == false) EventProbability += 0.2f;
            else EventProbability  -= 0.2f;
        }

        public void CalculNbEventMax()
        {
            PoliceStationType policeStationType = (PoliceStationType)_ctx.BuildingTypes[8];
            int totalNbVehicule = 0;
            for(int i = 0; i<policeStationType.List.Count; i++)
            {
                PoliceStation p = (PoliceStation)policeStationType.List[i];
                totalNbVehicule += p.NbVehicule;
            }

            if(totalNbVehicule < 2)
            {
                NbEventMax = 1;
            }
            else if (totalNbVehicule >= 2 || totalNbVehicule <= 4)

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
            Console.WriteLine("CRIME -- NB event : " + NbEventReal);
        }

        public void IsBuildingGettingEvent()
        {
            int probability;
            Random random = new Random();
            probability = random.Next(1, 101);

            Console.WriteLine("CRIME -- probability : " + probability);
            Console.WriteLine();
            Console.WriteLine("CRIME -- EVENTPROBABILITY :" + EventProbability * 10);
            if (probability <= EventProbability*10)
            {
                IsEventHappening = true;
            }
            else IsEventHappening = false;
        }

      
    }
}
