using GK_proj1.Shapes;

namespace GK_proj1.Relations
{
    public interface IRelation
    {
        public string GetSymbol();
        public bool IsSatisfied();
        public bool EnforceRelation();

        /// <summary>
        /// preserves relation after moving vertex v, returns false if unable to do that
        /// </summary>
        public bool PreserveRelation(Vertex v);

        /// <summary>
        /// preserves relation after moving edge e, returns false if unable to do that
        /// </summary>
        public bool PreserveRelation(Edge e);   
        
        public void RemoveRelation();
        public void AddTarget(IGeometricObject obj);
        public bool IsEstablished();

    }
}


