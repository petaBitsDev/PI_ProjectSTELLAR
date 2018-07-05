using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]

    public class FireType : IEventType
    {
        Map _ctx;

        float _fireProbability;

        bool _isOnFire;


        bool _previousFire;

        int _nbFireMax;

        int _nbFireReal;

        List<Building> _building;
       FireStationType fireStationType;
        // FireType _fire;

        public FireType(Map ctx)

        {
            _ctx = ctx;

            _previousFire = false;

            _fireProbability = 0.40f;

            fireStationType = (FireStationType)_ctx.BuildingTypes[1];
            _building = new List<Building>();


        }

        public Fire CreateEvent()
        {
            Fire fire = new Fire(_ctx, this);
            return fire;
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

            //Console.WriteLine("nb event : " + NbEventReal);

        }



        public void CalculEventProbability()

        {

            if (PreviousEvent == false)

            {
               _fireProbability += 0.12f;
            }

            else

            {
                _fireProbability -= 0.12f;
            } 

        }


        public void IsBuildingGettingEvent()

        {
            int probability;
            Random random = new Random();
            probability = random.Next(1, 101);
            //Console.WriteLine(" FIRE Event probability" + EventProbability * 100 );
            //Console.WriteLine();
            //Console.WriteLine("FIRE probability" + probability);

            if (probability <= EventProbability * 10)

            {
                IsEventHappening = true;
                CreateEvent();
                //Console.WriteLine(" FIRE Is event Happening " + IsEventHappening);
                //Console.WriteLine();
            }

            else

            {
                 IsEventHappening = false;
            }

        }



       
        }

  
    }

