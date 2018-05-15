using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    public class ExperienceManager
    {
        ResourcesManager _resourcesManager;
        int _level;
        float COEFFICIENT;

        public ExperienceManager(ResourcesManager ressourcesManager)
        {
            _resourcesManager = ressourcesManager;
            _level = 0;
            COEFFICIENT = 0.2f;
        }

        public int CheckLevel()
        {
            int pop = _resourcesManager.NbResources["population"];
            int tempLevel = (int)Math.Floor(COEFFICIENT * Math.Sqrt(pop));

            if (tempLevel > _level) _level = tempLevel;

            return _level;
        }

        public int GetPercentage()
        {
            int goal;
            int actualLevelPop;

            actualLevelPop = (int)((_level / COEFFICIENT) * (_level / COEFFICIENT));
            goal = (int)(((_level + 1) / COEFFICIENT) * ((_level + 1) / COEFFICIENT));
            
            if (_resourcesManager.NbResources["population"] <= actualLevelPop) return 0;
            else
            {
                int diffPop = _resourcesManager.NbResources["population"] - actualLevelPop;
                return (int)((diffPop * 100) / (goal - actualLevelPop));
            }
        }
    }
}
