using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    public class HutType : BuildingType
    {
        int _cost;
        int _wood;
        int _rock;
        int _metal;
        int _water;
        int _electricity;
        int _pollution;
        int _nbPeople;
        List <Building> _list;

        public HutType()
        {

        }

        public override void CreateInstance(int x, int y)
        {

        }

        public override void DeleteInstance(int x, int y)
        {

        }

        public override int Count()
        {
            return _list.Count;
        }
    }
}
