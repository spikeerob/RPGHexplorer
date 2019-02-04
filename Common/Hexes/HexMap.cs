using System;
using System.Collections.Generic;

namespace Common.Hexes
{
    public class HexMap
    {
        public List<Hex> Hexes = new List<Hex>();

        public void AddHex(Hex hex)
        {
            Hexes.Add(hex);
        }

        public static HexMap FromRectangle(int width, int height)
        {
            var map = new HexMap();

            // TODO
            
            return map;
        }
        
        public static HexMap FromHexagon(int radius)
        {
            var map = new HexMap();

            for (var q = -radius; q <= radius; q++)
            {
                for (var r = Math.Max(-radius, -q-radius); r <= Math.Min(radius, -q+radius); r++)
                {
                    map.AddHex(Hex.FromAxialCoords(q, r));
                }
            }

            return map;
        }

    }
}