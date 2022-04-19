using GK_proj1.Shapes;
using System;

namespace GK_proj1.Relations
{
    public class EqualLengthRelation : BinaryRelation
    {
        protected override string _Symbol { get; } = "EqL";
        private static int _RelationCount = 0;
        private const double eps = 1;

        public EqualLengthRelation()
        {
            _RelationNumber = ++_RelationCount;
        }

        public override bool EnforceRelation()
        {
            if (IsSatisfied())
                return true;

            (Vertex v1, Vertex v2) = ((Edge)First).Ends;


            v1.Parent.ChangePointPosition(Geometry.GetPointAlongLine(v1.Coords, v2.Coords, ((Edge)Second).Length()), v2);
            return true;
        }

        public override bool PreserveRelation(Vertex v)
        {
            if (IsSatisfied())
                return true;

            (Vertex v1, Vertex v2) = ((Edge)First).Ends;
            (Vertex v3, Vertex v4) = ((Edge)Second).Ends;


            if (v1 == v)
                v1.Parent.ChangePointPosition(Geometry.GetPointAlongLine(v1.Coords, v2.Coords, ((Edge)Second).Length()), v2);
            else if (v2 == v)
                v1.Parent.ChangePointPosition(Geometry.GetPointAlongLine(v2.Coords, v1.Coords, ((Edge)Second).Length()), v1);
            else if (v3 == v)
                v1.Parent.ChangePointPosition(Geometry.GetPointAlongLine(v3.Coords, v4.Coords, ((Edge)First).Length()), v4);
            else v1.Parent.ChangePointPosition(Geometry.GetPointAlongLine(v4.Coords, v3.Coords, ((Edge)First).Length()), v3);

            return true;
        }

        public override bool PreserveRelation(Edge e) => true;

        public override bool IsSatisfied() => Math.Abs(((Edge)First).Length() - ((Edge)Second).Length()) < eps;

    }
}
