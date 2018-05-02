using NUnit.Framework;
using ProjectStellar.Library;
using System;

namespace ProjectStellar
{
    [TestFixture]
    public class RunnerTests
    {
        [Test]

        public void create_building()
        {
            Map map = new Map(12,15);
            Building sut = new Building(map, 120, 40, 15, 12, 65, 89, 655, 45, true, 45);
            
            Assert.That(sut.RockNeeded, Is.EqualTo(120));
            Assert.That(sut.WoodNeeded, Is.EqualTo(40));
            Assert.That(sut.StellarCoinNeeded, Is.EqualTo(15));
            Assert.That(sut.MetalNeeded, Is.EqualTo(12));
            Assert.That(sut.ElectricityConsume, Is.EqualTo(65));
            Assert.That(sut.WaterConsume, Is.EqualTo(89));
            Assert.That(sut.AirPollution, Is.EqualTo(655));
            Assert.That(sut.NbPeople, Is.EqualTo(45));

        }

        [Test]

        public void check_if_destroy_a_building_if_it_exits_work_well()
        {
            Map map = new Map(12, 15);
            Building sut = new Building(map, 120, 40, 15, 12, 65, 89, 655, 45, true, 24);

            sut.IsBuild = false;

          //  Assert.Throws<ArgumentException>(() => sut.Destroy());

            Building sut1 = new Building(map, 120, 40, 15, 12, 65, 89, 655, 45, true, 76);
          
            Assert.That(sut1.IsBuild, Is.True);
            //sut1.Destroy();
            //Assert.That(sut1.IsBuild, Is.False);
        }

        [Test]

        public void add_a_building_in_the_array_when_you_create_it()
        {
            
            Map map = new Map(12,15);
            FireStation sut = new FireStation(map, 10, 30, 50, 0, 10, 10, 0, 5, false, 20);

            map.AddBuilding(3, 2, sut);

            Assert.That(map.CheckBuilding(3, 2), Is.True);
            Assert.That(map.CheckBuilding(3, 8), Is.False);
            Assert.That(map.Boxes[3,2], Is.EqualTo(sut));

        }

        [Test]

        public void remove_a_building_from_the_array_when_it_is_destroy()
        {
            Map map = new Map(12,15);
            Hut sut = new Hut(map, 10, 30, 50, 0, 10, 10, 0, 5, false, 20);

            map.AddBuilding(3, 2, sut);

            Assert.That(map.CheckBuilding(3, 2), Is.True);
            Assert.That(map.CheckBuilding(3, 8), Is.False);
            Assert.That(map.Boxes[3, 2], Is.EqualTo(sut));

            map.RemoveBuilding(3, 2, sut);

            Assert.That(map.CheckBuilding(3, 2), Is.False);
            Assert.That(map.Boxes[3, 2], Is.EqualTo(null));

        }

        [Test]

        public void create_a_building_and_add_it_in_the_array_with_the_create_function()
        {
            Map map = new Map(12,15);

            map.CreateHut(1, 1);
            map.CreateHouse(1, 2);
            map.CreateHouse(1, 4);
            map.CreateFlat(1, 3);
            map.CreateFlat(1, 5);
            map.CreateFlat(1, 6);


            Assert.That(map.CheckBuilding(1, 1), Is.True);
            Assert.That(map.CheckBuilding(1, 2), Is.True);
            Assert.That(map.CheckBuilding(1, 4), Is.True);
            Assert.That(map.CheckBuilding(1, 3), Is.True);
            Assert.That(map.CheckBuilding(1, 5), Is.True);
            Assert.That(map.CheckBuilding(1, 6), Is.True);



        }

        [Test]

        public void when_a_building_is_detroy_remove_it_from_the_array_and_decrement_the_coumpteur()
        {
            Map map = new Map(12,15);
            Hut sut = new Hut(map, 10, 30, 50, 0, 10, 10, 0, 5, false, 20);
            House house = new House(map, 65, 120, 110, 15, 25, 30, 5, 20, false, 50);
            Flat flat = new Flat(map, 65, 120, 110, 15, 25, 30, 5, 20, false, 50);



            map.CreateHut(1, 1);
            map.CreateHouse(1, 2);
            map.CreateHouse(1, 4);
            map.CreateFlat(1, 3);
            map.CreateFlat(1, 5);
            map.CreateFlat(1, 6);


            Assert.That(map.CheckBuilding(1, 1), Is.True);
            Assert.That(map.CheckBuilding(1, 2), Is.True);
            Assert.That(map.CheckBuilding(1, 4), Is.True);
            Assert.That(map.CheckBuilding(1, 3), Is.True);
            Assert.That(map.CheckBuilding(1, 5), Is.True);
            Assert.That(map.CheckBuilding(1, 6), Is.True);



            map.DestroyHut(1, 1, sut);
            map.DestroyHouse(1, 4, house);
            map.DestroyFlat(1, 3, flat);
            map.DestroyFlat(1, 5, flat);

            Assert.That(map.CheckBuilding(1, 1), Is.False);
            Assert.That(map.CheckBuilding(1, 4), Is.False);
            Assert.That(map.CheckBuilding(1, 3), Is.False);
            Assert.That(map.CheckBuilding(1, 5), Is.False);
     
        }

        [Test]

        public void the_dictionnary_of_building_is_update_as_it_should()
        {
            Map map = new Map(15,16);
            Hut hut = new Hut(map, 10, 30, 50, 0, 10, 10, 0, 5, false, 20);

            Flat flat = new Flat(map, 65, 120, 110, 15, 25, 30, 5, 20, false, 50);



            Assert.That(map.NbBuilding.ContainsKey("hut"), Is.False);
            Assert.That(map.NbBuilding.ContainsKey("house"), Is.False);
            Assert.That(map.NbBuilding.ContainsKey("flat"), Is.False);

            map.CreateHut(1, 1);
            map.CreateHouse(2, 4);
            map.CreateFlat(1, 6);

            Assert.That(map.NbBuilding["hut"], Is.EqualTo(1));
            Assert.That(map.NbBuilding.ContainsKey("house"), Is.True);
            Assert.That(map.NbBuilding.ContainsKey("flat"), Is.True);

            map.CreateHouse(2, 8);


            Assert.That(map.NbBuilding["house"], Is.EqualTo(2));

            map.CreateMetalMine(7,7);

            Assert.That(map.NbBuilding["metalMine"], Is.EqualTo(1));


            map.CreateFlat(1, 8);
            map.CreateFlat(1, 9);

            Assert.That(map.NbBuilding["flat"], Is.EqualTo(3));

            map.DestroyFlat(1, 6, flat);

            Assert.That(map.NbBuilding["flat"], Is.EqualTo(2));

            map.DestroyHut(1, 1, hut);
            Assert.That(map.NbBuilding["hut"], Is.EqualTo(0));


        }

        //[Test]
        //public void calcul_the_pollution_of_the_city()
        //{
        //    Map map = new Map(14,16);
        //    CityManager manager = new CityManager(map);


        //    map.CreateHut(1, 1);
        //    map.CreateHouse(2, 4);
        //    map.CreateHouse(2, 8);
        //    map.CreateFlat(1, 8);
        //    map.CreateFlat(1, 9);
        //    map.CreateFlat(1, 6);


        //    Assert.That(manager.CityPollution, Is.EqualTo(100));
            
        //}

        [Test]
        public void calcul_the_tax_from_all_the_non_public_bat()
        {
            Map map = new Map(15,16);
            CityManager manager = new CityManager(map);


            map.CreateHut(1, 1);
            map.CreateHouse(2, 4);
            map.CreateHouse(2, 8);
            map.CreateFlat(1, 8);
            map.CreateFlat(1, 9);
            map.CreateFlat(1, 6);

           

            Assert.That(manager.CityTaxes, Is.EqualTo(270));
        }

        [Test]

        public void the_resources_are_initialize_as_they_should()
        {
            Map map = new Map(10,10);

            ResourcesManager resourcesManager = new ResourcesManager(map);

            resourcesManager.UpdateResources();

            Assert.That(resourcesManager.NbResources["wood"], Is.EqualTo(500));
            Assert.That(resourcesManager.NbResources["rock"], Is.EqualTo(500));
            Assert.That(resourcesManager.NbResources["metal"], Is.EqualTo(150));

        }

        [Test]

        public void the_resources_update_as_they_should_but_not_in_function_of_the_time()
        {
            Map map = new Map(10, 10);

            ResourcesManager resourcesManager = new ResourcesManager(map);

            resourcesManager.UpdateResources();

            Assert.That(resourcesManager.NbResources["wood"], Is.EqualTo(500));
            Assert.That(resourcesManager.NbResources["rock"], Is.EqualTo(500));
            Assert.That(resourcesManager.NbResources["metal"], Is.EqualTo(150));

            map.CreateSawMill(2, 6);
            resourcesManager.UpdateResources();



            Assert.That(resourcesManager.NbResources["wood"], Is.EqualTo(570));

            map.CreateOreMine(1, 5);
            map.CreateOreMine(1, 6);
            resourcesManager.UpdateResources();

            Assert.That(resourcesManager.NbResources["rock"], Is.EqualTo(640));

            map.CreateMetalMine(1, 7);
            map.CreateMetalMine(1, 8);
            map.CreateMetalMine(1, 9);
            resourcesManager.UpdateResources();

            
            Assert.That(resourcesManager.NbResources["metal"], Is.EqualTo(360));
          

        }

        [Test]

        public void the_city_helper_is_working()
        {
            Resolution _resolution = new Resolution();
            Game game = new Game(0, _resolution, false);
            Map map = new Map(20, 20);
            game.Initialize();

            CityHelper city = new CityHelper(map);
            Assert.That(city.ListBuilding.Count, Is.EqualTo(28));
        }

        [Test]
        public void calcul_the_pollution_of_the_city()
        {
            Resolution _resolution = new Resolution();
            Game game = new Game(0, _resolution, false);
            Map map = new Map(20, 20);
            game.Initialize();
            CityManager cityManager = new CityManager(map);


            map.CreateHut(1, 1);
            map.CreateHouse(2, 4);
            map.CreateHouse(2, 8);
            map.CreateFlat(1, 8);
            map.CreateFlat(1, 9);
            map.CreateFlat(1, 6);


            Assert.That(cityManager.CityPollution, Is.EqualTo(25));

        }
    }
}


