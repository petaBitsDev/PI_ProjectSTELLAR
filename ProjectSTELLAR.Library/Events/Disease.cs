using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    class Disease : IEvent
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


        public Disease(Map ctx)
        {
            _ctx = ctx;
            _diseaseProbability = 0.1f;
            _previousDisease = false;
        }

        public bool EventHandle
        {
            get { return _eventHandle; }
            set { _eventHandle = true; }
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
        public void BuildingEvent()
        {
            Random random = new Random();
            int _idxBuildingtype;
            _idxBuildingtype = random.Next(_ctx.BuildingTypes.Count);
            BuildingType BuildingSelected = _ctx.BuildingTypes[_idxBuildingtype];
            int _idxBuilding;
            _idxBuilding = random.Next(BuildingSelected.List.Count);

            if(BuildingSelected.Type == "public")
            {
                BuildingEvent();
            }
            else if(BuildingSelected.List[_idxBuilding].IsSick == true)
            {
                BuildingEvent();
            }
            else
            {
                BuildingSelected.List[_idxBuilding].IsSick = true;
                BuildingHasEvent.Add(BuildingSelected.List[_idxBuilding]);
            }
        }

        public void CalculEventProbability()
        {
            if(PreviousEvent == false)
            {
                EventProbability += 0.1f;
            }
            else
            {
                EventProbability -= 0.1f;
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
                NbEventMax = 3;
            }
            else if(totalNbVehicule < 6 && totalNbBed < 50)
            {
                NbEventMax = 8;
            }
            else 
            {
                NbEventMax = 20;
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

            if(probability <= EventProbability * 100)
            {
                IsEventHappening = true;
            }
            else
            {
                IsEventHappening = false;
            }
        }

        public void NewEvent(GameTime gameTime)
        {
            DateTime now = gameTime.InGameTime;
            DateTime endOfEvent = now.AddMinutes(2);

            bool _isHospital = false;

            CalculEventProbability();
            HospitalType hospitalType = (HospitalType)_ctx.BuildingTypes[3];
            if (hospitalType.List.Count != 0) _isHospital = true;

            if(_isHospital == true)
            {
                CalculNbEventReal();
                for(int i = 0; i < NbEventReal; i++)
                {
                    SelectKindOfSick();
                    IsBuildingGettingEvent();
                    if (IsEventHappening == true)
                    {
                        if (gameTime.InGameTime.Equals(endOfEvent)) EventHandle = false;
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
