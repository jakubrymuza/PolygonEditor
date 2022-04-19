using GK_proj1.Shapes;

namespace GK_proj1.Relations
{
    public abstract class UnaryRelation : IRelation
    {
        protected int _RelationNumber { get; set; } = 0;
        protected abstract string _Symbol { get; }

        public IGeometricObject Target = null;

        protected bool _IsEstablished = false;
        public virtual bool IsEstablished() => _IsEstablished;

        public string GetSymbol() => _Symbol + _RelationNumber;

        public abstract bool EnforceRelation();
        public abstract bool PreserveRelation(Vertex v);
        public abstract bool PreserveRelation(Edge e);

        public abstract bool IsSatisfied();

        public void AddTarget(IGeometricObject obj)
        {
            Target = obj;
            obj.Relation = this;
            _IsEstablished = true;
        }

        public void RemoveRelation()
        {
            Target.Relation = null;
        }
    }
}
