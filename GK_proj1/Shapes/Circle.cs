using System.Drawing;
using GK_proj1.Relations;

namespace GK_proj1.Shapes
{
    public class Circle : IShape, IGeometricObject
    {
        public const int CenterSize = 10;
        public const int RingHitbox = 5;
        private int _ChangeCounter = 0;
        private const int _MaxChangeCount = 20;

        public Point Center
        {
            get; set;
        }
        public IRelation Relation { get; set; }
        public Color Color { get; set; } = Color.Black;

        public int Radius;

        private Font _Font;
        private Color _FontColor = Color.Blue;

        public Circle(Point p)
        {
            Center = new Point(p.X, p.Y);
            Radius = 1;
            _Font = new Font("Arial", 14);
        }

        public Bitmap DrawShape(Bitmap bitmap)
        {
            Graphics g = Graphics.FromImage(bitmap);

            Drawing.DrawPoint(g, Center, CenterSize, Color);
            Drawing.DrawCircle(g, Center, Radius, Color);

            if (Relation != null)
                Drawing.DrawRelationSymbol(g, Center, _Font, Relation, _FontColor);

            g.Dispose();
            return bitmap;
        }

        // function effectively drags the whole shape
        public void DragPoint(Point p, Vertex selectedVertex)
        {
            _ChangeCounter = 0;
            Point oldCenter = Center;

            if (!ChangePoint(p, selectedVertex))
                Center = oldCenter;
        }


        public bool ChangePoint(Point p, Vertex selectedVertex)
        {
            if (++_ChangeCounter > _MaxChangeCount)
                return false;

            Center = p;
            if (Relation != null && !Relation.IsSatisfied())
                if (!Relation.PreserveRelation(selectedVertex))
                    return false;

            return true;
        }

        public void DragEdge(Point p, Edge e, Point lp)
        {        
            ChangeRadius((int)Geometry.Distance(Center, p));  
        }

        public void ChangeRadius(int r)
        {
            _ChangeCounter = 0;
            int oldRadius = Radius;
            Radius = r;

            if (Relation != null && !Relation.IsSatisfied())
                if (!Relation.PreserveRelation(new Edge()))
                    Radius = oldRadius;
        }

        public void DragEntireShape(Point p, Vertex v)
        {
            DragPoint(p, v);
        }

        public void DragEntireShapeByEdge(Point p, Edge e, Point lp)
        {
            DragPoint(Geometry.PointAddition(Geometry.PointSubstraction(p, lp), Center), new Vertex());
        }

        public void DeletePoint(Vertex v)
        {
            return;
        }

        public (bool, Vertex) CheckPointHitbox(Point p)
        {
            if (Geometry.Distance(Center, p) < CenterSize)
                return (true, null);

            return (false, null);
        }

        public (bool, Edge) CheckEdgeHitbox(Point p)
        {
            int dist = (int)Geometry.Distance(p, Center);
            if (dist > Radius - RingHitbox && dist < Radius + RingHitbox)
                return (true, null);

            return (false, null);
        }
    }
}
