using System;
using System.Collections.Generic;

namespace RPGHexplorer.Common.Hexes
{
    public class Layout
    {
        public Orientation Orientation { get; }

        public Point Size { get; }

        public Point Origin { get; }

        public Layout(Orientation orientation, Point size, Point origin)
        {
            Orientation = orientation;
            Size = size;
            this.Origin = origin;
        }

        public Point HexToPoint(Hex hex)
        {
            var x = (Orientation.F0 * hex.Q + Orientation.F1 * hex.R) * Size.X;
            var y = (Orientation.F2 * hex.Q + Orientation.F3 * hex.R) * Size.Y;
            
            return new Point(x + Origin.X, y + Origin.Y);
        }

        private Point GetHexCornerOffset(int corner)
        {
            var angle = 2.0 * Math.PI * (Orientation.StartAngle + corner) / 6;
            
            return new Point(Size.X * Math.Cos(angle), Size.Y * Math.Sin(angle));
        }

        public IEnumerable<Point> GetHexCorners(Hex hex)
        {
            var corners = new List<Point>();
            var center = HexToPoint(hex);

            for (var i = 0; i < 6; i++)
            {
                var offset = GetHexCornerOffset(i);
                corners.Add(new Point(center.X + offset.X, center.Y + offset.Y));
            }

            return corners;
        }
        
    }
}