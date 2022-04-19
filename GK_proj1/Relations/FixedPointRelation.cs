using GK_proj1.Shapes;
using System.Drawing;

namespace GK_proj1.Relations
{
    public class FixedPointRelation : UnaryRelation
    {
        protected override string _Symbol { get; } = "FP";
        private static int _RelationCount = 0;
        public Point Point;

        public FixedPointRelation()
        {
            _RelationNumber = ++_RelationCount;
        }

        public override bool EnforceRelation() => true;

        public override bool PreserveRelation(Vertex v)
        {
            ((Circle)Target).Center = Point;
            return true;
        }

        public override bool PreserveRelation(Edge e) => true;

        public override bool IsSatisfied() => false;
    }
}
