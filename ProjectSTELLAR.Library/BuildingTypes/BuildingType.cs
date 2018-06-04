using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    public abstract class BuildingType
    {


        public virtual void CreateInstance(int x, int y, ResourcesManager resources, Map map)
        {
            //map.AddBuilding(x, y);
            //resources.UpdateWhenCreate(this);
        }

        public virtual void DeleteInstance(int x, int y, Map map, Building building)
        {
            map.RemoveBuilding(x, y);
            this.List.Remove(building);
        }

        public abstract int Cost { get; }
        public abstract int Coin { get; }
        public abstract int Wood { get; }
        public abstract int Rock { get; }
        public abstract int Metal { get; }
        public abstract int Water { get; }
        public abstract int Electricity { get; }
        public abstract int Pollution { get; }
        public abstract int NbPeople { get; }
        public abstract string Type { get; }
        public abstract int Size { get; }
        public abstract List<Building> List { get; }
       
        public abstract int NbBuilding { get;}
    }

}
