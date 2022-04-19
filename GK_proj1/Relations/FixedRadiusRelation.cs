using System;
using GK_proj1.Shapes;

namespace GK_proj1.Relations
{
    class FixedRadiusRelation : UnaryRelation
    {
        protected override string _Symbol { get; } = "FR";
        private static int _RelationCount = 0;
        public int Length = -1;
        private const double eps = 1;

        public override bool IsEstablished() => _IsEstablished && Length != -1;

        public FixedRadiusRelation()
        {
            _RelationNumber = ++_RelationCount;
        }

        public override bool EnforceRelation()
        {
            if (IsSatisfied())
                return true;

            ((Circle)Target).ChangeRadius(Length);

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

        public override bool IsSatisfied() => Math.Abs(((Circle)Target).Radius - Length) < eps;
    }
}
