﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{ 
    public class HospitalType : BuildingType
    {
        int _cost;
        int _coin;
        int _wood;
        int _rock;
        int _metal;
        int _water;
        int _electricity;
        int _pollution;
        int _nbPeople;
        public List<Building> _list = new List<Building>();

        public HospitalType()
        {
            _rock = 70;
            _wood = 40;
            _coin = 67;
            _metal = 75;
            _electricity = 45;
            _water = 60;
            _pollution = 15;
            _nbPeople = 25;
            _cost = 30;
        }

       // public override int Rock => _rock;
        public override int Wood => _wood;
        public override int Coin => _coin;
        public override int Metal => _metal;
        public override int Electricity => _electricity;
        public override int Water => _water;
        public override int Pollution => _pollution;
        public override int NbPeople => _nbPeople;
        public override int Cost => _cost;
        public List<Building> List => _list;

    }
}