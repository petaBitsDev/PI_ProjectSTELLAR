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
        int compteur;

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
            if (compteur > 5)
            {
                _crimeType.IsEventHappening = false;
                compteur = 0;
                return;
            }
            else
            {
                Random random = new Random();
                int _idxBuildingType;
                _idxBuildingType = random.Next(_ctx.BuildingTypes.Count);

                _buildingSelected = _ctx.BuildingTypes[_idxBuildingType];
                if (_buildingSelected.List.Count != 0)
                {
                    int _idxBuilding;

                    _idxBuilding = random.Next(_buildingSelected.List.Count);


                    if (_buildingSelected is IServiceInstance || (_buildingSelected == _ctx.BuildingTypes[0]))
                    {
                        compteur++;

                        BuildingEvent(gameTime);
                    }
                    else if (_buildingSelected.List[_idxBuilding].IsVictimCrime == true)
                    {
                        compteur++;

                        BuildingEvent(gameTime);
                    }
                    else
                    {
                        _buildingSelected.List[_idxBuilding].IsVictimCrime = true;
                        _crimeType.BuildingHasEvent.Add(_buildingSelected.List[_idxBuilding]);
                        _crimeType.BuildingHasEvent[_crimeType.BuildingHasEvent.Count - 1].TimeOfEvent = gameTime.InGameTime;
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
