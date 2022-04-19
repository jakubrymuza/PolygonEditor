using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GK_proj1.Shapes;
using GK_proj1.Relations;

namespace GK_proj1
{
    public partial class Form1 : Form
    {
        private void GenerateInitialScene()
        {
            List<Point> pts1 = new List<Point>();
            pts1.Add(new Point(130, 150));
            pts1.Add(new Point(200, 200));
            pts1.Add(new Point(100, 300));
            pts1.Add(new Point(70, 50));
            pts1.Add(new Point(80, 400));

            Polygon p1 = AddNonUserPolygon(pts1);

            var r1 = new PerpendicularRelation();
            r1.AddTarget(p1.GetEdges()[0]);
            r1.AddTarget(p1.GetEdges()[1]);
            r1.EnforceRelation();

            var r2 = new FixedLengthRelation();
            r2.Length = 350;
            r2.AddTarget(p1.GetEdges()[3]);
            r2.EnforceRelation();



            List<Point> pts2 = new List<Point>();
            pts2.Add(new Point(200, 300));
            pts2.Add(new Point(100, 500));
            pts2.Add(new Point(600, 200));
            pts2.Add(new Point(250, 300));
            Polygon p2 = AddNonUserPolygon(pts2);

            var r3 = new EqualLengthRelation();
            r3.AddTarget(p2.GetEdges()[0]);
            r3.AddTarget(p2.GetEdges()[2]);
            r3.EnforceRelation();



            Circle c1 = AddNonUserCircle(new Point(500, 100), 100);
            var r4 = new FixedPointRelation();
            r4.AddTarget(c1);
            r4.Point = c1.Center;

            Circle c2 = AddNonUserCircle(new Point(450, 450), 80);
            var r5 = new FixedRadiusRelation();
            r5.AddTarget(c2);
            r5.Length = c2.Radius;

            Mode = Modes.Default;
        }

        private Polygon AddNonUserPolygon(List<Point> pts)
        {
            foreach (var p in pts)
                NewPolygonAction(p);

            Polygon pol = (Polygon)_SelectedShape;

            FinishCreatingPolygon();
            return pol;
        }

        private Circle AddNonUserCircle(Point p, int r)
        {
            Circle c = new Circle(p);
            c.Radius = r;
            _Shapes.Add(c);

            return c;
        }

    }
}
