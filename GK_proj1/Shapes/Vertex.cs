using GK_proj1.Relations;
using System.Collections.Generic;
using System.Drawing;

namespace GK_proj1.Shapes
{
    public class Vertex : IGeometricObject
    {
        public const int VertexSize = 10;

        public Point Coords;

        public List<Edge> Edges = new List<Edge>(); // edges incident with the vertex

        public IRelation Relation { get; set; }
        public Color Color { get; set; } = Color.Black;

        private Font _Font;
        private Color _FontColor = Color.Blue;

        public Polygon Parent;

        public Vertex(Point p)
        {
            Coords = new Point(p.X, p.Y);
            _Font = new Font("Arial", 14);
        }

        public Vertex()
        {
            _Font = new Font("Arial", 14);
        }

        public Graphics DrawVertex(Graphics g)
        {
            Drawing.DrawPoint(g, Coords, VertexSize, Color);

            if (Relation != null)
                Drawing.DrawRelationSymbol(g, Coords, _Font, Relation, _FontColor);

            return g;
        }

        public (Vertex, Vertex) GetNeighbors() => (Edges[0]?.GetTheOtherEnd(this), Edges[1]?.GetTheOtherEnd(this));
    }
}
