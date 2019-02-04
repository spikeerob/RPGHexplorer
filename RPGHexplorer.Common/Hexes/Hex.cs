using System;

namespace RPGHexplorer.Common.Hexes
{
    public class Hex
    {
        /// <summary>
        /// Equivalent to X for cube coords
        /// </summary>
        public int Q { get; }

        /// <summary>
        /// Equivalent to Y for cube coords
        /// </summary>
        public int R { get; }

        /// <summary>
        /// Equivalent to Z for cube coords
        /// </summary>
        public int S { get; }

        public Hex(int q, int r, int s)
        {
            if (q + r + s != 0)
            {
                throw new ArgumentException("Sum of hex cube coords must equal zero");
            }
            
            Q = q;
            R = r;
            S = s;
        }

        public static Hex FromCubeCoords(int x, int y, int z)
        {
            return new Hex(x, y, z);
        }
        
        public static Hex FromAxialCoords(int q, int r)
        {
            return FromCubeCoords(q, r, -q - r);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                var hex = (Hex) obj;
                return Q == hex.Q && R == hex.R && S == hex.S;
            }
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Q, R, S).GetHashCode();
        }

        public override string ToString()
        {
            return $"Hex({Q}, {R}, {S})";
        }
    }
}