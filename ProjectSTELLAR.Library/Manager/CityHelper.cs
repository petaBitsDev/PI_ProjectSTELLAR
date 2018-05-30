using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    class CityHelper
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
        static List<BuildingType> _buildingType;

        public CityHelper()
        {
            _buildingType = new List<BuildingType>();

            metalMine = new MetalMineType();
            _buildingType.Add(metalMine);
            oreMine = new OreMineType();
            _buildingType.Add(oreMine);
            sawMill = new SawmillType();
            _buildingType.Add(sawMill); 
            cityHall = new CityHallType();
            _buildingType.Add(cityHall);
            fireStation = new FireStationType();
            _buildingType.Add(fireStation);
            hospital = new HospitalType();
            _buildingType.Add(hospital);
            policeStation = new PoliceStationType();
            _buildingType.Add(policeStation);
            powerPlant = new PowerPlantType();
            _buildingType.Add(powerPlant);
            pumpingStation = new PumpingStationType();
            _buildingType.Add(pumpingStation);
            spaceStation = new SpaceStationType();
            _buildingType.Add(spaceStation);
            warehouse = new WarehouseType();
            _buildingType.Add(warehouse);
            flat = new FlatType();
            _buildingType.Add(flat);
            house = new HouseType();
            _buildingType.Add(house);
            hut = new HutType();
            _buildingType.Add(hut);
        }

        public static List<BuildingType> ListBuildingType => _buildingType;
    }
}
