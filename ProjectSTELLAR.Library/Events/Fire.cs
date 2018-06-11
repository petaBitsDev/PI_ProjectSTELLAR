using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    public class Fire : IEvent
    {
        Map _ctx;

        float _fireProbability;

        bool _isOnFire;

        bool _eventHandle;

        bool _previousFire;

        int _nbFireMax;

        int _nbFireReal;

        List<Building> _building;



        public Fire(Map ctx)

        {

            _ctx = ctx;

            _previousFire = false;

            _fireProbability = 0.14f;

        }

        public bool EventHandle
        {
            get { return _eventHandle; }
            set { _eventHandle = value; }
        }

      public bool PreviousEvent

        {

            get { return _previousFire; }

            set { _previousFire = value; }

        }



        public bool IsEventHappening

        {

            get { return _isOnFire; }

            set { _isOnFire = value; }
         }


        public int NbEventMax

        {

            get { return _nbFireMax; }

            set { _nbFireMax = value; }

        }



        public int NbEventReal

        {

            get { return _nbFireReal; }

            set { _nbFireReal = value; }

        }



        public float EventProbability

        {

            get { return _fireProbability; }

            set { _fireProbability = value; }

        }



        public List<Building> BuildingHasEvent

        {

            get { return _building; }

            set { _building = value; }

        }

        public void CalculNbEventMax()

        {
            FireStationType fireStationType = (FireStationType)_ctx.BuildingTypes[1];
            int totalnbTruck = 0;
            for(int i = 0; i < fireStationType.List.Count; i++)
            {
                FireStation f = (FireStation)fireStationType.List[i];
                totalnbTruck += f.NbVehicule;
            }

            if (totalnbTruck< 2)

            {

                NbEventMax = 3;

            }

            else if (totalnbTruck >= 2 || totalnbTruck <= 4)

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



        public void CalculEventProbability()

        {

            if (PreviousEvent == false)

            {
               EventProbability += 0.3f;
            }

            else

            {
                EventProbability -= 0.3f;
            } 

        }



        public void BuildingEvent()

        {
            Random random = new Random();
            int _idxBuildingType;
            _idxBuildingType = random.Next(_ctx.BuildingTypes.Count);
            BuildingType buildingSelected = _ctx.BuildingTypes[_idxBuildingType];
            int _idxBuilding;
          
            _idxBuilding = random.Next(buildingSelected.List.Count);
           

            if(Equals(buildingSelected, typeof(FireStationType)))
            {
                BuildingEvent();
            }
            else if (buildingSelected.List[_idxBuilding].OnFire == true)
            {
                BuildingEvent();

            }
            else
            {
                buildingSelected.List[_idxBuilding].OnFire = true;
                BuildingHasEvent.Add(buildingSelected.List[_idxBuilding]);
            }

        }



        public void IsBuildingGettingEvent()

        {
            int probability;
            Random random = new Random();
            probability = random.Next(1, 101);

            if (probability <= EventProbability * 100)

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

            bool _isFireStation = false;

            CalculEventProbability();
            FireStationType fireStationType = (FireStationType)_ctx.BuildingTypes[1];
            if (fireStationType.List.Count != 0) _isFireStation = true;




            if (_isFireStation == true)

            {
             
                        CalculNbEventReal();
                        for (int i = 0; i <= NbEventReal; i++)

                        {

                        IsBuildingGettingEvent();

                        if (IsEventHappening == true)

                        {
                       //     if (gameTime.InGameTime.Equals(endOfEvent)) EventHandle = false;

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
