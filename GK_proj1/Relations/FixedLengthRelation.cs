using System;
using GK_proj1.Shapes;

namespace GK_proj1.Relations
{
    public class FixedLengthRelation : UnaryRelation
    {
        protected override string _Symbol { get; } = "FL";
        private static int _RelationCount = 0; 
        public double Length = -1;
        private const double eps = 1;

        public override bool IsEstablished() => _IsEstablished && Length != -1;

        public FixedLengthRelation()
        {
            _RelationNumber = ++_RelationCount;
        }

        public override bool EnforceRelation()
        {
            if (IsSatisfied())
                return true;

            (Vertex v1, Vertex v2) = ((Edge)Target).Ends;


            v1.Parent.ChangePointPosition(Geometry.GetPointAlongLine(v1.Coords, v2.Coords, Length), v2);
            return true;
        }

        public override bool PreserveRelation(Vertex v)
        {
            if (IsSatisfied())
                return true;

            (Vertex v1, Vertex v2) = ((Edge)Target).Ends;


            if (v1 == v)
                v1.Parent.ChangePointPosition(Geometry.GetPointAlongLine(v1.Coords, v2.Coords, Length), v2);
            else v1.Parent.ChangePointPosition(Geometry.GetPointAlongLine(v2.Coords, v1.Coords, Length), v1);

            return true;
        }

        public override bool PreserveRelation(Edge e) => true;

        public override bool IsSatisfied() => Math.Abs(((Edge)Target).Length() - Length) < eps;
    }
}
