using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    public class SatisfactionManager
    {
        float _satisfaction;

        public SatisfactionManager()
        {
            _satisfaction = 1f;
        }

        public float Satifaction => _satisfaction;

        public void UpdateSatisfaction(Dictionary<string, int> resources, List<BuildingType> listBuildings, int level)
        {
            if (resources["water"] < 0) _satisfaction = _satisfaction - (resources["water"] * -0.001f);
            else _satisfaction += 0.001f;
            if (resources["electricity"] < 0) _satisfaction = _satisfaction - (resources["electricity"] * -0.001f);
            else _satisfaction += 0.001f;
            if (resources["pollution"] > 200) _satisfaction = _satisfaction - (resources["pollution"] - 200 * 0.001f);
            else _satisfaction += 0.001f;
            if (resources["products"] < 0) _satisfaction = _satisfaction - (resources["products"] * -0.001f);
            else _satisfaction += 0.001f;

            if (level >= 5)
            {
                // Fire station
                if (listBuildings[1].List.Count < (resources["nbPeople"] / 1000)) _satisfaction -= ((resources["nbPeople"] / 1000) - listBuildings[1].List.Count * 0.001f);
                else _satisfaction += 0.001f;
                // Hospital
                if (listBuildings[3].List.Count < (resources["nbPeople"] / 1000)) _satisfaction -= ((resources["nbPeople"] / 1000) - listBuildings[3].List.Count * 0.001f);
                else _satisfaction += 0.001f;
                // Police station
                if (listBuildings[8].List.Count < (resources["nbPeople"] / 1000)) _satisfaction -= ((resources["nbPeople"] / 1000) - listBuildings[8].List.Count * 0.001f);
                else _satisfaction += 0.001f;
            }

            if (_satisfaction < 0f) _satisfaction = 0f;
            else if (_satisfaction > 1f) _satisfaction = 1f;
            Console.WriteLine(Satifaction);
        }

        public void UnsolvedEvent()
        {
            _satisfaction -= 0.01f;
            if (_satisfaction < 0f) _satisfaction = 0f;
            else if (_satisfaction > 1f) _satisfaction = 1f;
        }
    }
}
