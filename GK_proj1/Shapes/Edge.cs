using System;
using System.Drawing;
using GK_proj1.Relations;

namespace GK_proj1.Shapes
{
    public class Edge : IGeometricObject
    {
        public const int EdgeHitbox = 5;

        public Tuple<Vertex, Vertex> Ends
        {
            get; private set;
        }

        public IRelation Relation { get; set; }
        public Color Color { get; set; } = Color.Black;

        private Font _Font;
        private Color _FontColor = Color.Blue;

        public Polygon Parent;

        public double Length()
        {
            (Vertex p1, Vertex p2) = Ends;
            return Geometry.Distance(p1.Coords, p2.Coords);
        }

        public Edge(Vertex v1, Vertex v2)
        {
            Ends = new Tuple<Vertex, Vertex>(v1, v2);
            _Font = new Font("Arial", 14);
        }

        public Edge()
        {
            _Font = new Font("Arial", 14);
        }


        public void DrawEdge(Bitmap bitmap)
        {
            Drawing.DrawLine(bitmap, Ends.Item1.Coords, Ends.Item2.Coords, Color);

            (Vertex p1, Vertex p2) = Ends;
            Graphics g = Graphics.FromImage(bitmap);
            if (Relation != null)
                Drawing.DrawRelationSymbol(g, new Point((p1.Coords.X + p2.Coords.X) / 2, (p1.Coords.Y + p2.Coords.Y) / 2), _Font, Relation, _FontColor);

            g.Dispose();
        }

        public void DrawRelationSymbol(Bitmap bitmap)
        {
            (Vertex p1, Vertex p2) = Ends;
            Point p = new Point();

            Graphics g = Graphics.FromImage(bitmap);

            g.DrawString(Relation.GetSymbol(), _Font, Brushes.DarkBlue, p.X, p.Y);

            g.Dispose();
        }


        /// <summary>
        /// function returns the other end of the edge than v
        /// </summary>
        public Vertex GetTheOtherEnd(Vertex v)
        {
            if (Ends.Item1 != v)
                return Ends.Item1;
            return Ends.Item2;
        }

    }
}
