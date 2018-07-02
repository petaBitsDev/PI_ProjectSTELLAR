using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
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
            if (resources["water"] < 0)
            {
                _satisfaction = _satisfaction - (resources["water"] * -0.001f);
                Console.WriteLine("Il n'y a pas assez d'eau la satisfaction diminue");
            }
            else { _satisfaction += 0.001f; Console.WriteLine("Il y à assez d'eau la satisaction augmente"); }

            if (resources["electricity"] < 0) { _satisfaction = _satisfaction - (resources["electricity"] * -0.001f); Console.WriteLine("Il n'y a pas assez d'electricite la satisfaction diminue"); }


            else { _satisfaction += 0.001f; Console.WriteLine("Il y à assez d'electricite la satisaction augmente"); }
                if (resources["pollution"] > 200) { _satisfaction = _satisfaction - (resources["pollution"] - 200 * 0.001f); Console.WriteLine("Il y a trop de pollution la stisfaction diminue"); }
                else { _satisfaction += 0.001f; Console.WriteLine("La pollution est gerer la satisfactiona ugmente"); }
                if (resources["products"] < 0) { _satisfaction = _satisfaction - (resources["products"] * -0.001f); Console.WriteLine("Il n'y a pas assez de product produit satsfaction diminu"); }
                else { _satisfaction += 0.001f; Console.WriteLine("Il y a assez de products la satisfaction augmente"); }

            if (level >= 5)
            {
                    // Fire station
                    if (listBuildings[1].List.Count < (resources["nbPeople"] / 1000)) { _satisfaction -= ((resources["nbPeople"] / 1000) - listBuildings[1].List.Count * 0.001f); Console.WriteLine("Il n'y a pas assez de caserne, satisfaction --"); }
                    else { _satisfaction += 0.001f; Console.WriteLine("assez de caserne, satsfaction ++"); }
                    // Hospital
                    if (listBuildings[3].List.Count < (resources["nbPeople"] / 1000)) { _satisfaction -= ((resources["nbPeople"] / 1000) - listBuildings[3].List.Count * 0.001f); Console.WriteLine("pas assez hopitaux, satisfaction -- "); }
                    else { _satisfaction += 0.001f; Console.WriteLine("assez d'hopitaux; satisfaction ++"); }
                // Police station
                if (listBuildings[8].List.Count < (resources["nbPeople"] / 1000)) { _satisfaction -= ((resources["nbPeople"] / 1000) - listBuildings[8].List.Count * 0.001f); Console.WriteLine("pas assez police, satisfaction --"); }
                else { _satisfaction += 0.001f; Console.WriteLine("assez de police satisfaction ++"); }
            }

            if (_satisfaction < 0f) _satisfaction = 0f;
            else if (_satisfaction > 1f) _satisfaction = 1f;
            Console.WriteLine("Satisfaction : " + Satifaction);
        }

        public void UnsolvedEvent(Map map)
        {
            foreach (IEvent e in map.ListEvent)
            {
                if (e.EventHandle == true)
                {
                    _satisfaction += 0.03f;
                }
                else
                {
                    _satisfaction -= 0.01f;
                    if (_satisfaction < 0f) _satisfaction = 0f;

                }
            }

        }
    }
}

