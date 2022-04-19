using System;
using GK_proj1.Shapes;
using System.Drawing;

namespace GK_proj1.Relations
{
    public class TangentRelation : BinaryRelation
    {
        protected override string _Symbol { get; } = "T";
        private static int _RelationCount = 0;

        public TangentRelation()
        {
            _RelationNumber = ++_RelationCount;
        }

        
        public override bool EnforceRelation()
        {
            // nie do końca działa

            if (IsSatisfied())
                return true;

            (Circle c, Edge e) = GetParametres();

            (Vertex v1, Vertex v2) = e.Ends;

            if(v1.Coords.X == v2.Coords.X) // vertical edge
            {
                c.ChangePoint(new Point(v1.Coords.X - c.Radius, c.Center.Y), new Vertex());
                return true;
            }

            if(v1.Coords.Y == v2.Coords.Y) // horizonta line
            {
                c.ChangePoint(new Point(v1.Coords.X, c.Center.Y - c.Radius), new Vertex());
                return true;
            }

            // edge equation
            double a1 = Geometry.GetSlope(v1.Coords, v2.Coords);
            double b1 = Geometry.GetShift(v1.Coords, a1);

            // orthogonal line equation
            double a2 = -1 / a1;
            double b2 = (double)(c.Center.X + c.Center.Y) / a1;

            double dist = Geometry.GetPointLineDistance(c.Center, v1.Coords, v2.Coords) - c.Radius;

            // point on orthogonal line
            int x4 = c.Center.X + 50;
            int y4 = (int)(a2 * x4 + b2);
            Point p = new Point(x4, y4);

            c.Center = Geometry.GetPointAlongLine(c.Center, p, dist);

            //c.ChangePoint(pp, new Vertex());


            return true;
        }

        public override bool PreserveRelation(Vertex v)
        {
            return EnforceRelation();
        }

        public override bool PreserveRelation(Edge e)
        {
            return EnforceRelation();
        }

        public override bool IsSatisfied()
        {
            (Circle c, Edge e) = GetParametres();

            return Geometry.IsTangent(c, e);
        }

        private (Circle, Edge) GetParametres()
        {
            Circle c;
            Edge e;

            if (First is Circle)
            {
                c = (Circle)First;
                e = (Edge)Second;
            }
            else
            {
                c = (Circle)Second;
                e = (Edge)First;
            }

            return (c, e);
        }
    }
}
