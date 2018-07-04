using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
    public  class Disease : IEvent
    {
        Map _ctx;
        bool _eventHandle;
        DiseaseType _diseaseType;
        BuildingType buildingSelected;
        HospitalType _hospitalType;
        int compteur = 0;

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

        public void BuildingEvent(GameTime gameTime)
        {

            if (compteur > 3)
            {
                _diseaseType.IsEventHappening = false;
                compteur = 0;
                return;
            }
            else
            {
                Random random = new Random();
                int _idxBuildingtype;
                _idxBuildingtype = random.Next(_ctx.BuildingTypes.Count);
                buildingSelected = _ctx.BuildingTypes[_idxBuildingtype];


                if (buildingSelected.List.Count != 0)
                {

                    int _idxBuilding;
                    _idxBuilding = random.Next(buildingSelected.List.Count);

                    Console.WriteLine();
                    if (buildingSelected.Type == "public")
                    {
                        compteur++;

                        BuildingEvent(gameTime);
                    }
                    else if (buildingSelected.List[_idxBuilding].IsSick == true)
                    {
                        compteur++;

                        BuildingEvent(gameTime);
                    }
                    else
                    {

                        buildingSelected.List[_idxBuilding].IsSick = true;
                        _diseaseType.BuildingHasEvent.Add(buildingSelected.List[_idxBuilding]);
                        _diseaseType.BuildingHasEvent[_diseaseType.BuildingHasEvent.Count - 1].TimeOfEvent = gameTime.InGameTime;

                        compteur = 0;
                    }
                }
                else
                {
                    compteur++;

                    BuildingEvent(gameTime);

                }

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
                    _diseaseType.SelectKindOfSick();
                    _diseaseType.IsBuildingGettingEvent();
                    if (_diseaseType.IsEventHappening == true)
                    {
                        if (gameTime.InGameTime.Equals(endOfEvent)) EventHandle = false;
                        BuildingEvent(gameTime);
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
