using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProjectStellar.Library
{
    class Crime : IEvent
    {
        // JOLANN WAS HERE

        Map _ctx;

        float _crimeProbability;

        bool _isCrime;

        bool _previousCrime;

        int _nbCrimeMax;

        int _nbCrimeReal;

        Building _building;

        Timer timer = new Timer();

        bool _eventHandle;


        public Crime(Map ctx)

        {

            _ctx = ctx;

            _previousCrime = false;

            _crimeProbability = 0.17f;

            _eventHandle = true;

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
        public Building BuildingHasEvent
        {
            get { return _building; }
            set { _building = value; }
        }

        public void BuildingEvent()
        {
            Random random = new Random();
            int _idxBuildingType;
            _idxBuildingType = random.Next(_ctx.BuildingTypes.Count);
            BuildingType buildingSelected = _ctx.BuildingTypes[_idxBuildingType];
            int _idxBuilding;

            _idxBuilding = random.Next(buildingSelected.List.Count);

            if(buildingSelected is IServiceBuildings)
            {
                BuildingEvent();
            }
            else if(buildingSelected.List[_idxBuilding].IsVictimCrime == true)
            {
                BuildingEvent();
            }
            else
            {
                buildingSelected.List[_idxBuilding].IsVictimCrime = true;
                BuildingHasEvent = buildingSelected.List[_idxBuilding];
            }
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
                NbEventMax = 3;
            }
            else if (totalNbVehicule >= 2 || totalNbVehicule <= 4)

            {

                NbEventMax = 7;

            }

            else

            {

                NbEventMax = 15;

            }
        }

        public void CalculNbEventReal()
        {
            Random random = new Random();
            CalculNbEventMax();
            NbEventReal = random.Next(NbEventMax + 1);
        }

        public void IsBuildingGettingEvent()
        {
            int probability;
            Random random = new Random();
            probability = random.Next(1, 101);
            if (probability <= EventProbability)
            {
                IsEventHappening = true;
            }
            else IsEventHappening = false;
        }

        public void NewEvent(GameTime gameTime)
        {
            DateTime now = gameTime.InGameTime;
            DateTime endOfEvent = now.AddMinutes(2);
            
            bool _isPoliceStation = false;

            CalculEventProbability();
            PoliceStationType policeStationType = (PoliceStationType)_ctx.BuildingTypes[8];
            if (policeStationType.List.Count != 0) _isPoliceStation = true;

            if(_isPoliceStation == true)
            {
                CalculNbEventReal();
                for(int i = 0; i<NbEventReal; i++)
                {
                    IsBuildingGettingEvent();
                    if(IsEventHappening == true)
                    {
                        if(gameTime.InGameTime.Equals(endOfEvent)) EventHandle = false;
                        BuildingEvent();
                        PreviousEvent = true;
                    }
                    else
                    {
                        PreviousEvent = false;
                    }
                }
            }
        }
    }
}
