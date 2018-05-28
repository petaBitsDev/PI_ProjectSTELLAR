using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
    public class CityHelper
    {
        MetalMineType metalMine;
        SawmillType sawMill;
        OreMineType oreMine;
        CityHallType cityHall;
        FireStationType fireStation;
        HospitalType hospital;
        PoliceStationType policeStation;
        PowerPlantType powerPlant;
        PumpingStationType pumpingStation;
        SpaceStationType spaceStation;
        WarehouseType warehouse;
        FlatType flat;
        HouseType house;
        HutType hut;
        Map _map;
        public CityHelper(Map map)
        {
            _map = map;

            metalMine = new MetalMineType();
            oreMine = new OreMineType();
            sawMill = new SawmillType();
            cityHall = new CityHallType();
            fireStation = new FireStationType();
            hospital = new HospitalType();
            policeStation = new PoliceStationType();
            powerPlant = new PowerPlantType();
            pumpingStation = new PumpingStationType();
            spaceStation = new SpaceStationType();
            warehouse = new WarehouseType();
            flat = new FlatType();
            house = new HouseType();
            hut = new HutType();
        }

        static List<BuildingType> _listBuilding = new List<BuildingType>();

        public void CreateListBuilding()
        {
            _listBuilding.Add(metalMine);
            _listBuilding.Add(oreMine);
            _listBuilding.Add(sawMill);
            _listBuilding.Add(cityHall);
            _listBuilding.Add(fireStation);
            _listBuilding.Add(hospital);
            _listBuilding.Add(policeStation);
            _listBuilding.Add(powerPlant);
            _listBuilding.Add(pumpingStation);
            _listBuilding.Add(spaceStation);
            _listBuilding.Add(warehouse);
            _listBuilding.Add(flat);
            _listBuilding.Add(house);
            _listBuilding.Add(hut);
        }

        public List<BuildingType> ListBuilding
        {
            get
            {
                return _listBuilding;
            }
        }

        public HutType GetHut
        {
            get { return hut; }
        }

        public HouseType GetHouse
        {
            get { return house; }
        }
        public FlatType GetFlat
        {
            get { return flat; }
        }
        public WarehouseType GetWarehouse
        {
            get { return warehouse; }
        }
        public SpaceStationType GetSpaceStation
        {
            get { return spaceStation; }
        }
        public PumpingStationType GetPumpingStation
        {
            get { return pumpingStation; }
        }
        public FireStationType GetFireStation
        {
            get { return fireStation; }
        }
        public PoliceStationType GetPoliceStation
        {
            get { return policeStation; }
        }
        public HospitalType GetHospital
        {
            get { return hospital; }
        }
        public PowerPlantType GetPowerPlant
        {
            get { return powerPlant; }
        }
        public OreMineType GetOreMine
        {
            get { return oreMine; }
        }
        public MetalMineType GetMetalMine
        {
            get { return metalMine; }
        }

        public SawmillType GetSawmill
        {
            get { return sawMill; }
        }

        public CityHallType GetCityHall
        {
            get { return cityHall; }
        }
    }
