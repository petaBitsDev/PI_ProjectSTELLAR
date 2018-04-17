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

    }
}


