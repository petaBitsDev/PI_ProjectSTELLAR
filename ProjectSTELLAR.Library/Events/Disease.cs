using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    class Disease : IEvent
    {
        Map _ctx;
        bool _eventHandle;
        DiseaseType _diseaseType;
        BuildingType buildingSelected;
        HospitalType _hospitalType;

        public Disease(Map ctx, DiseaseType diseaseType)
        {
            _ctx = ctx;
            _diseaseType = diseaseType;
            _hospitalType = (HospitalType)_ctx.BuildingTypes[3];
        }

        public bool EventHandle
        {
            get { return _eventHandle; }
            set { _eventHandle = value; }
        }

        public void BuildingEvent()
        {
            Random random = new Random();
            int _idxBuildingtype;
            _idxBuildingtype = random.Next(_ctx.BuildingTypes.Count);
             buildingSelected = _ctx.BuildingTypes[_idxBuildingtype];
            Console.WriteLine("DISEASE -- idx building type for disease" + _idxBuildingtype);
            Console.WriteLine();


            if (buildingSelected.List.Count != 0)
            {

                Console.WriteLine("DISEASE -- je suis rentré dans la boucle car il y a des instances du building type sur ma map");
                Console.WriteLine();
                int _idxBuilding;
                _idxBuilding = random.Next(buildingSelected.List.Count);

                Console.WriteLine("DISEASE -- idx Building Selected" + _idxBuilding);
                Console.WriteLine();
                if (buildingSelected.Type == "public")
                {
                    Console.WriteLine("DISEASE le building selectionné etait public");
                    Console.WriteLine();
                    BuildingEvent();
                }
                else if (buildingSelected.List[_idxBuilding].IsSick == true)
                {
                    Console.WriteLine("DISEASE -- le building est deja malade");
                    Console.WriteLine();
                    BuildingEvent();
                }
                else
                {
                    Console.WriteLine("buildingevent a rempli sa fonction");

                    buildingSelected.List[_idxBuilding].IsSick = true;
                   _diseaseType.BuildingHasEvent.Add(buildingSelected.List[_idxBuilding]);
                    Console.WriteLine("disease" +_diseaseType.BuildingHasEvent.ToString());
                    Console.WriteLine(" DISEASE is the building selected sick : " + buildingSelected.List[_idxBuilding].IsSick);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Il n'y a pas d'instance de l'objet sur la carte" );
                Console.WriteLine();
                BuildingEvent();

            }

        }

        public void NewEvent(GameTime gameTime)
        {
            DateTime now = gameTime.InGameTime;
            DateTime endOfEvent = now.AddMinutes(2);

            bool _isCityHall = false;

            _diseaseType.CalculEventProbability();
            CityHallType cityHallType = (CityHallType)_ctx.BuildingTypes[0];
            if (cityHallType.List.Count != 0) _isCityHall = true;
            _diseaseType.CalculNbEventReal();

            if (_isCityHall == true)
            {
                for (int i = 0; i < _diseaseType.NbEventReal; i++)
                {
                    Console.WriteLine("DISEASE -- i = " + i);
                    Console.WriteLine();
                    _diseaseType.SelectKindOfSick();
                    _diseaseType.IsBuildingGettingEvent();
                    if (_diseaseType.IsEventHappening == true)
                    {
                        if (gameTime.InGameTime.Equals(endOfEvent)) EventHandle = false;
                        BuildingEvent();
                        _diseaseType.PreviousEvent = true;
                    }
                    else
                    {
                        _diseaseType.PreviousEvent = false;
                    }
                }

            }
        }
    }
}
