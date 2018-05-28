using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace ProjectStellar
{
    class BuildingChoice
    {
        Sprite _sprite;
        BuildingType _building;

        public BuildingChoice(Sprite sprite, BuildingType building)
        {
            _sprite = sprite;
            _building = building;
        }

        public Sprite Sprite => _sprite;

        public BuildingType Building => _building;
    }
}
