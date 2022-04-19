using System;
using GK_proj1.Shapes;
using System.Drawing;

namespace GK_proj1.Relations
{
    public class PerpendicularRelation : BinaryRelation
    {
        protected override string _Symbol { get; } = "P";
        private static int _RelationCount = 0;

        public PerpendicularRelation()
        {
            _RelationNumber = ++_RelationCount;
        }



        public override bool EnforceRelation()
        {
            if (IsSatisfied())
                return true;

            (Vertex v1, Vertex v2, Vertex v3, Vertex v4) = GetVertexes();

            if(v3 == v1 || v3 == v2)
                return v4.Parent.ChangePointPosition(new Point(v2.Coords.Y - v1.Coords.Y + v3.Coords.X, v1.Coords.X - v2.Coords.X + v3.Coords.Y), v4);
            else return v3.Parent.ChangePointPosition(new Point(v2.Coords.Y - v1.Coords.Y + v4.Coords.X, v1.Coords.X - v2.Coords.X + v4.Coords.Y), v3);

        }

        public override bool PreserveRelation(Vertex v)
        {
            if (IsSatisfied())
                return true;

            (Vertex v1, Vertex v2, Vertex v3, Vertex v4) = GetVertexes();

            if(v1 == v || v2 == v)
            {
                if (v3 == v1 || v3 == v2)
                    return v4.Parent.ChangePointPosition(new Point(v2.Coords.Y - v1.Coords.Y + v3.Coords.X, v1.Coords.X - v2.Coords.X + v3.Coords.Y), v4);
                else return v3.Parent.ChangePointPosition(new Point(v2.Coords.Y - v1.Coords.Y + v4.Coords.X, v1.Coords.X - v2.Coords.X + v4.Coords.Y), v3);
            }
            else
            {
                if (v1 == v3 || v1 == v4)
                    return v2.Parent.ChangePointPosition(new Point(v4.Coords.Y - v3.Coords.Y + v1.Coords.X, v3.Coords.X - v4.Coords.X + v1.Coords.Y), v2);
                else return v1.Parent.ChangePointPosition(new Point(v4.Coords.Y - v3.Coords.Y + v2.Coords.X, v3.Coords.X - v4.Coords.X + v2.Coords.Y), v1);

            }
        }

        public override bool PreserveRelation(Edge e)
        {
            (Vertex v1, Vertex v2) = e.Ends;

            return PreserveRelation(v1);
        }

        public override bool IsSatisfied()
        {
            (Vertex v1, Vertex v2, Vertex v3, Vertex v4) = GetVertexes();

            return Geometry.AreOrthogonal(v1.Coords, v2.Coords, v3.Coords, v4.Coords);
        }

        private (Vertex, Vertex, Vertex, Vertex) GetVertexes()
        {
            (Vertex v1, Vertex v2) = ((Edge)First).Ends;
            (Vertex v3, Vertex v4) = ((Edge)Second).Ends;

            return (v1, v2, v3, v4);
        }

    }
}
