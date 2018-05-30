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

        bool _previousFire;

        int _nbFireMax;

        int _nbFireReal;

        Building _building;



        public Fire(Map ctx)

        {

            _ctx = ctx;

            _previousFire = false;

            _fireProbability = 0.14f;

        }

      public bool PreviousFire

        {

            get { return _previousFire; }

            set { _previousFire = value; }

        }



        public bool IsOnFire

        {

            get { return _isOnFire; }

            set { _isOnFire = value; }
         }


        public int NbFireMax

        {

            get { return _nbFireMax; }

            set { _nbFireMax = value; }

        }



        public int NbFireReal

        {

            get { return _nbFireReal; }

            set { _nbFireReal = value; }

        }



        public float FireProbability

        {

            get { return _fireProbability; }

            set { _fireProbability = value; }

        }



        public Building BuildingOnFire

        {

            get { return _building; }

            set { _building = value; }

        }

        private void CalcuNbFireMax(FireStation firestation)

        {
            if (firestation.NbTruck< 2)

            {

                NbFireMax = 3;

            }

            else if (firestation.NbTruck >= 2 || firestation.NbTruck <= 4)

            {

                NbFireMax = 7;

            }

            else

            {

                NbFireMax = 15;

            }

        }


        private void CalculNbFireReal(FireStation fireStation)

        {
            Random random = new Random();

            CalcuNbFireMax(fireStation);

            NbFireReal = random.Next(NbFireMax += 1);

        }



        private void CalculFireProbability()

        {

            if (PreviousFire == false)

            {
               FireProbability += 0.3f;
            }

            else

            {
                FireProbability -= 0.3f;
            }

        }



        private void BuildingFire(BuildingType  building)

        {
            int _idxBuilding;
            Random random = new Random();
            _idxBuilding = random.Next(building.List.Count);
           

            if(building.List[_idxBuilding].GetType() == typeof(FireStation))
            {
                BuildingFire(building);
            }
            else if (building.List[_idxBuilding].OnFire == true)
            {
                BuildingFire(building);

            }
            else
            {
                building.List[_idxBuilding].OnFire = true;
                BuildingOnFire = building.List[_idxBuilding];
            }

        }



        private void IsBuildingGettingOnFire()

        {
            int probability;
            Random random = new Random();
            probability = random.Next(1, 101);

            if (probability <= FireProbability * 100)

            {
                IsOnFire = true;
            }

            else

            {
                 IsOnFire = false;
            }

        }



        public void NewFire(BuildingType building, FireStation fireStation)

        {
            bool _isFireStation = false;

            CalculFireProbability();

            foreach(Building b in building.List)
            {
                if (building.List.GetType() == typeof(FireStation))
                {
                    _isFireStation = true;
                }
                else
                {
                    _isFireStation = false;
                }
            }
            
            if (_isFireStation == true)

            {

                if (building.List.Count > 10)

                {

                        CalculNbFireReal(fireStation);
                        for (int i = 0; i <= NbFireReal; i++)

                        {

                        IsBuildingGettingOnFire();

                        if (IsOnFire == true)

                        {
                            BuildingFire(building);
                            PreviousFire = true;
                        }

                        else

                        {
                            PreviousFire = false;
                        }

                    }

                }

            }

        }



    }
}
