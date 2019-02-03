using System;
using System.Collections.Generic;

namespace RPGHexplorer.Lib.HexMap
{
    public class HexMap
    {
        public Dictionary<string, Hex> Hexes = new Dictionary<string, Hex>();

        public void AddHex(Hex hex)
        {
            Hexes[hex.Identifier] = hex;
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