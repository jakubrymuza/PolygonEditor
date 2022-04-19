using GK_proj1.Shapes;

namespace GK_proj1.Relations
{
    public abstract class BinaryRelation : IRelation
    {
        protected int _RelationNumber { get; set; } = 0;


        protected abstract string _Symbol { get; }

        public IGeometricObject First = null;
        public IGeometricObject Second = null;

        protected bool _IsEstablished = false;
        public bool IsEstablished() => _IsEstablished;

        public string GetSymbol() => _Symbol + _RelationNumber;

        public abstract bool EnforceRelation();
        public abstract bool PreserveRelation(Vertex v);
        public abstract bool PreserveRelation(Edge e);

        

        public abstract bool IsSatisfied();

        public void AddTarget(IGeometricObject obj)
        {
            if (obj == null)
                return;

            if (First == null)
                First = obj;
            else
            {
                Second = obj;
                _IsEstablished = true;
            }
            

            obj.Relation = this;
        }

        public void RemoveRelation()
        {
            First.Relation = Second.Relation = null;
        }
    }
}
