using NUnit.Framework;
using System;

namespace ProjectStellar
{
    [TestFixture]
    public class RunnerTests
    {
        [Test]

        public void create_building()
        {
            Building sut = new Building(120, 40, 15, 12, 65, 89, 655, 45, true, 45);
            
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
            Building sut = new Building(120, 40, 15, 12, 65, 89, 655, 45, true, 24);

            sut.IsBuild = false;

            Assert.Throws<ArgumentException>(() => sut.Destroy());

            Building sut1 = new Building(120, 40, 15, 12, 65, 89, 655, 45, true, 76);
          
            Assert.That(sut1.IsBuild, Is.True);
            sut1.Destroy();
            Assert.That(sut1.IsBuild, Is.False);
        }

        [Test]

        public void add_a_building_in_the_array_when_you_create_it()
        {
            Map map = new Map();
            Hut sut = new Hut(10, 30, 50, 0, 10, 10, 0, 5, false, 20);

            map.AddBuilding(3, 2, sut);

            Assert.That(map.CheckBuilding(3, 2), Is.True);
            Assert.That(map.CheckBuilding(3, 8), Is.False);
            Assert.That(map.Boxes[3,2], Is.EqualTo(sut));

        }

        [Test]

        public void remove_a_building_from_the_array_when_it_is_destroy()
        {
            Map map = new Map();
            Hut sut = new Hut(10, 30, 50, 0, 10, 10, 0, 5, false, 20);

            map.AddBuilding(3, 2, sut);

            Assert.That(map.CheckBuilding(3, 2), Is.True);
            Assert.That(map.CheckBuilding(3, 8), Is.False);
            Assert.That(map.Boxes[3, 2], Is.EqualTo(sut));

            map.RemoveBuilding(3, 2, sut);

            Assert.That(map.CheckBuilding(3, 2), Is.False);
            Assert.That(map.Boxes[3, 2], Is.EqualTo(null));

        }

    }
}


