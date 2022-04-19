using GK_proj1.Relations;
using System.Drawing;

namespace GK_proj1.Shapes
{
    public interface IGeometricObject
    {
        public IRelation Relation { get; set; }
        public Color Color { get; set; }
    }
}
