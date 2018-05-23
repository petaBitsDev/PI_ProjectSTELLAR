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
        Building _building;

        public BuildingChoice(Sprite sprite, Building building)
        {
            _sprite = sprite;
            _building = building;
        }

        public Sprite Sprite => _sprite;

        public Building Building => _building;
    }
}
