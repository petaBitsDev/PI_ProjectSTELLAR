using System;
using SFML.System;

namespace ProjectStellar.Library
{
    public static class Meteorite
    {
        static readonly int _radius = 5;
        
        public static int Falls(int level, Map map, ResourcesManager resources)
        {
            Random random = new Random();
            int nbDestroyed = 0;

            //Determine si l'event a lieu
            if (random.Next(0, 101) < level * 3)
            {
                //Determine le nombre de meteorites
                int nbMeteors = random.Next(1, 6);
                Vector2i fallsCoords;

                Console.WriteLine("Chute de {0} météorites", nbMeteors);

                for (int i = 0; i < nbMeteors; i++)
                {
                    fallsCoords = new Vector2i(random.Next(0, map.Width), random.Next(0, map.Height));

                    nbDestroyed += DestroyBuildings(fallsCoords, map, resources);
                }
            }

            return nbDestroyed;
        }

        public static int DestroyBuildings(Vector2i fallsCoord, Map map, ResourcesManager resources)
        {
            //Console.WriteLine("Destructions aux coords : {0}, {1}");

            int y = fallsCoord.Y - _radius;
            int xDiff = 0;
            int i;
            int nbDestroyed = 0;

            while (y <= fallsCoord.Y + _radius)
            {
                if (y >= 0 && y < map.Height)
                {
                    for (i = fallsCoord.X - xDiff; i <= fallsCoord.X + xDiff; i++)
                    {
                        if(i >= 0 && i < map.Width)
                        {
                            if (map.CheckBuilding(i, y))
                            {
                                Console.WriteLine("Supression de {0} aux coord x = {1}, y = {2}", map.Boxes[i, y].Type, map.Boxes[i, y].X, map.Boxes[i, y].Y);
                                map.Boxes[i, y].Type.DeleteInstance(i, y, map, map.Boxes[i, y], resources);
                                nbDestroyed++;
                            }
                        }
                    }
                }

                if (y < fallsCoord.Y)
                    xDiff++;
                else
                    xDiff--;

                y++;
            }

            return nbDestroyed;
        }
    }
}
