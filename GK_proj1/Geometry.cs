using System;
using System.Collections.Generic;
using System.Drawing;
using GK_proj1.Shapes;

namespace GK_proj1
{
    public static class Geometry
    {
        public static double Distance(Point p1, Point p2)
        {
            int x = p1.X - p2.X;
            int y = p1.Y - p2.Y;
            return Math.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// returns a square given the center position and side length
        /// </summary>
        public static Rectangle GetCenteredSquare(Point center, int size) => new Rectangle(center.X - size / 2, center.Y - size / 2, size, size);

        public static Point GetMidwayDistance(Point p1, Point p2) => new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);

        public static Point PointAddition(Point p1, Point p2) => new Point(p1.X - p2.X, p1.Y - p2.Y);

        public static Point PointSubstraction(Point p1, Point p2) => new Point(p1.X - p2.X, p1.Y - p2.Y);


        // https://stackoverflow.com/questions/849211/shortest-distance-between-a-point-and-a-line-segment
        public static double GetPointSegmentDistance(Point p, Point ep1, Point ep2)
        {
            
            double A = p.X - ep1.X;
            double B = p.Y - ep1.Y;
            double C = ep2.X - ep1.X;
            double D = ep2.Y - ep1.Y;

            double dot = A * C + B * D;
            double len_sq = C * C + D * D;
            double param = dot / len_sq;

            double xx, yy;

            if (param < 0 || (ep1.X == ep2.X && ep1.Y == ep2.Y))
            {
                xx = ep1.X;
                yy = ep1.Y;
            }
            else if (param > 1)
            {
                xx = ep2.X;
                yy = ep2.Y;
            }
            else
            {
                xx = ep1.X + param * C;
                yy = ep1.Y + param * D;
            }

            double dx = p.X - xx;
            double dy = p.Y - yy;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        // http://www.java2s.com/Code/CSharp/Development-Class/DistanceFromPointToLine.htm
        public static double GetPointLineDistance(Point p, Point ep1, Point ep2) => Math.Abs((ep2.X - ep1.X) * (ep1.Y - p.Y) - (ep1.X - p.X) * (ep2.Y - ep1.Y)) /
                    Math.Sqrt(Math.Pow(ep2.X - ep1.X, 2) + Math.Pow(ep2.Y - ep1.Y, 2));

        /// <summary>
        /// Given line constructed with point p1, p2, return a third point p3 such that the distance between p1 and p3 is equal dist and p3 is collinear with p1, p2
        /// </summary>
        public static Point GetPointAlongLine(Point p1, Point p2, double dist)
        {
            // https://math.stackexchange.com/questions/175896/finding-a-point-along-a-line-a-certain-distance-away-from-another-point
            double ratio = dist / Distance(p1, p2);
            return new Point((int)((1 - ratio) * p1.X + ratio * p2.X),
               (int)((1 - ratio) * p1.Y + ratio * p2.Y));

        }

        public static bool AreOrthogonal(Point p1, Point p2, Point p3, Point p4)
        {
            // https://www.geeksforgeeks.org/check-whether-two-straight-lines-are-orthogonal-or-not/

            int m1, m2;

            if (p2.X - p1.X == 0 && p4.X - p3.X == 0)
                return false;

            else if (p2.X - p1.X == 0)
            {
                m2 = (p4.Y - p3.Y) / (p4.X - p3.X);
                if (m2 == 0)
                    return true;
                else
                    return false;
            }

            else if (p4.X - p3.X == 0)
            {
                m1 = (p2.Y - p1.Y) / (p2.X - p1.X);
                if (m1 == 0)
                    return true;
                else
                    return false;
            }

            else
            {
                m1 = (p2.Y - p1.Y) / (p2.X - p1.X);
                m2 = (p4.Y - p3.Y) / (p4.X - p3.X);

                if (m1 * m2 == -1)
                    return true;
                else
                    return false;
            }
        }

        public static double GetSlope(Point p1, Point p2) => (double)(p2.Y - p1.Y) / (p2.X - p1.X);

        public static double GetShift(Point p, double slope) => (double)p.Y - slope * p.X;


        private static double eps = 5;
        public static bool IsTangent(Circle c, Edge e)
        {
            (Vertex v1, Vertex v2) = e.Ends;

            return Math.Abs(Geometry.GetPointLineDistance(c.Center, v1.Coords, v2.Coords) - c.Radius) < eps;
        }

    }
}
