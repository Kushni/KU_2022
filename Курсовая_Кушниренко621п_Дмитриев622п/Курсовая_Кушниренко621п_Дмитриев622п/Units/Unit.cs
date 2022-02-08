﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    abstract class Unit
    {
       
        public Unit(TypeMove typemove, string name, string color, Coordinates newcoordinates, bool ispacked = false)
        {
            typeMove = typemove;
            Name = name;
            Color = color;
            coordinates = newcoordinates;
            IsPacked = ispacked;
        }

        public enum TypeMove
        {
            Ground,
            Water,
            Flying,
        }

        TypeMove typeMove;

        int id;

        string Name;

        public bool IsPacked { get; protected set; }

        string Color;

        public int CellNumber { get; internal set; }

        //Перенес GetCellNumber в класс Cell

        int SpeedUnit = 10;

        public int size = 0;

        public int internalSize = 0;

        Coordinates coordinates;

        Coordinates coordinatesNextPoint;

        List<Coordinates> WayToPoint;

        void TryMove ()
        {
            double LenghtX = coordinatesNextPoint.x - coordinates.x;
            double LenghtY = coordinatesNextPoint.y - coordinates.y;
        }
    }
}
