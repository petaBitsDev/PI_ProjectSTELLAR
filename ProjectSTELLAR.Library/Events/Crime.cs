using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
     internal class Crime : IEvent
    {
        Map _ctx;
        bool _eventHandle;
        CrimeType _crimeType;
        BuildingType _buildingSelected;
        PoliceStationType _policeStationType;

        public Crime(Map ctx, CrimeType crimeType)
        {
            _ctx = ctx;
            _crimeType = crimeType;
            _policeStationType = (PoliceStationType)_ctx.BuildingTypes[8];
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
            _idxBuildingType = random.Next(_ctx.BuildingTypes.Count);

            Console.WriteLine("CRIME --- IDX BUILDING TYPE :" + _idxBuildingType);
            Console.WriteLine();
            _buildingSelected = _ctx.BuildingTypes[_idxBuildingType];
            if (_buildingSelected.List.Count != 0)
            {
                Console.WriteLine("CRIME -- je suis rentré dans la boucle car il y a des instances du building type sur ma map");
                Console.WriteLine();
                int _idxBuilding;

                _idxBuilding = random.Next(_buildingSelected.List.Count);

                Console.WriteLine("CRIME -- IDX BUILDING INSTANCE : " + _idxBuilding);

                if (_buildingSelected is IServiceInstance || (_buildingSelected == _ctx.BuildingTypes[0]))
                {
                    Console.WriteLine("CRIME -- LE BUILDINC ETAIT SOIT DE SERVICE SOIT LA MAIRIE");
                    Console.WriteLine();
                    BuildingEvent(gameTime);
                }
                else if (_buildingSelected.List[_idxBuilding].IsVictimCrime == true)
                {
                    Console.WriteLine("CRIME -- LE BUILDING EST DEJA VICTIME DE CRIME");
                    Console.WriteLine();
                    BuildingEvent(gameTime);
                }
                else
                {
                    Console.WriteLine("CRIME -- Building event a rempli sa fonction");
                    _buildingSelected.List[_idxBuilding].IsVictimCrime = true;
                    _crimeType.BuildingHasEvent.Add(_buildingSelected.List[_idxBuilding]);
                    _crimeType.BuildingHasEvent[_crimeType.BuildingHasEvent.Count - 1].TimeOfEvent = gameTime.InGameTime;

                    Console.WriteLine("CRIME -- Is building selected victim of a crime : " + _buildingSelected.List[_idxBuilding].IsVictimCrime);

                }
            }
            else
            {
                BuildingEvent(gameTime);

            }
        }

        public void NewEvent(GameTime gt)
        {
            DateTime now = gt.InGameTime;
            DateTime endOfEvent = now.AddMinutes(2);

            bool _isCityHallType = false;

            _crimeType.CalculEventProbability();
            CityHallType cityHallType = (CityHallType)_ctx.BuildingTypes[0];
            if (cityHallType.List.Count != 0) _isCityHallType = true;
            _crimeType.CalculNbEventReal();

            if (_isCityHallType == true)
            {
                for (int i = 0; i <_crimeType.NbEventReal; i++)
                {
                    Console.WriteLine("CRIME -- i = " + i);
                    Console.WriteLine();
                   _crimeType.IsBuildingGettingEvent();
                    if (_crimeType.IsEventHappening == true)
                    {
                        if (gt.InGameTime.Equals(endOfEvent)) EventHandle = false;
                        BuildingEvent(gt);
                       _crimeType.PreviousEvent = true;
                    }
                    else
                    {
                      _crimeType.PreviousEvent = false;
                    }
                }
            }
        }
    }
}
