using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
    public class Fire : IEvent
    {
        Map _ctx;
        bool _eventHandle;
        FireType _firetype;
        BuildingType buildingSelected;
        FireStationType fireStationType;
        DateTime now;



        public Fire(Map ctx, FireType fireType)
        {
            _ctx = ctx;
            _firetype = fireType;
            fireStationType = (FireStationType)_ctx.BuildingTypes[1];

        }
        public bool EventHandle
        {
            get { return _eventHandle; }
            set { _eventHandle = value; }
        }

        public void BuildingEvent(GameTime gameTime)

        {
            Random random = new Random();
            int _idxBuildingType;
            _idxBuildingType = random.Next(1, _ctx.BuildingTypes.Count);
            buildingSelected = _ctx.BuildingTypes[_idxBuildingType];

            Console.WriteLine("FIRE -- idx building type" +_idxBuildingType);
            Console.WriteLine();

            if (buildingSelected.List.Count != 0)
            {
                Console.WriteLine("FIRE -- je suis rentré dans la boucle car il y a des instances du building type sur ma map");
                Console.WriteLine();
                int _idxBuilding;
                _idxBuilding = random.Next(buildingSelected.List.Count);

                Console.WriteLine("FIRE -- idx Building Selected"  +_idxBuilding );
                Console.WriteLine();

                if ((buildingSelected == _ctx.BuildingTypes[1]) || (buildingSelected == _ctx.BuildingTypes[0]))
                {
                    Console.WriteLine("FIRE --je relance building event car le batiments n'est pas selectinnable");
                    Console.WriteLine();
                    BuildingEvent(gameTime);
                 
                }
                else if (buildingSelected.List[_idxBuilding].OnFire == true)
                {
                    Console.WriteLine("FIRE -- je relance building event car le batiments est deja en feu");
                    Console.WriteLine();
                    BuildingEvent(gameTime);

                }
                else
                {
                    Console.WriteLine("FIRE -- buildingevent a rempli sa fonction");
                    buildingSelected.List[_idxBuilding].OnFire = true;
                    _firetype.BuildingHasEvent.Add(buildingSelected.List[_idxBuilding]);
                    _firetype.BuildingHasEvent[_firetype.BuildingHasEvent.Count -1 ].TimeOfEvent = gameTime.InGameTime;
                    Console.WriteLine("FIRE -- is the building selected on fire : " + buildingSelected.List[_idxBuilding].OnFire);
                    Console.WriteLine();
                }
            }
            else
            {
                BuildingEvent(gameTime);

            }


        }

        public void NewEvent(GameTime gameTime)

        {
            double _timeMax = 180;
            fireStationType.BuildingDistance(_ctx);
            FireStation fireStation = (FireStation)fireStationType.Origin;
     
            DateTime endOfEvent = now.AddMinutes(2);

            bool _iscityHall = false;

            _firetype.CalculEventProbability();
            
            CityHallType cityHallType = (CityHallType)_ctx.BuildingTypes[0];

            if (cityHallType.List.Count != 0) _iscityHall = true;

            _firetype.CalculNbEventReal();



            if (_iscityHall == true)

            {
                if(fireStationType.List.Count != 0)
                {
                    if (_firetype.BuildingHasEvent.Count != 0)
                    {
                        fireStation.ServiceBuildingWorking();
                        

                    }
                }

                for (int i = 0; i < _firetype.NbEventReal; i++)

                {
                    Console.WriteLine("i = " + i);
                    Console.WriteLine();
                    _firetype.IsBuildingGettingEvent();

                    if (_firetype.IsEventHappening == true)

                    {
                        BuildingEvent(gameTime);

               


                        _firetype.PreviousEvent = true;
                    }

                    else

                    {
                        _firetype.PreviousEvent = false;
                    }

                }

            }


        }
    }
}
