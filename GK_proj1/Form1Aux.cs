using System.Drawing;
using System.Windows.Forms;
using GK_proj1.Shapes;

namespace GK_proj1
{
    public partial class Form1 : Form
    {
        private void CheckDragHitboxes(Point p)
        {
            (bool IsClicked, Vertex v, IShape s) = CheckShapesPointHitbox(p);

            if (IsClicked)
            {
                _SelectedVertex = v;
                _SelectedShape = s;
                if (Mode == Modes.Default)
                    Mode = Modes.VertexDrag;
                EnableDragging();
                return;
            }

            Edge e;
            (IsClicked, e, s) = CheckShapesEdgeHitbox(p);

            if (IsClicked)
            {
                _SelectedEdge = e;
                _SelectedShape = s;
                if (Mode == Modes.Default)
                    Mode = Modes.EdgeDrag;
                EnableDragging();
            }
        }

        (bool, Vertex, IShape) CheckShapesPointHitbox(Point p)
        {
            foreach (IShape s in _Shapes)
            {
                (bool IsClicked, Vertex v) = s.CheckPointHitbox(p);

                if (IsClicked)
                    return (IsClicked, v, s);
            }

            return (false, null, null);
        }

        private void EndDrawing()
        {
            _SelectedShape = null;
            _SelectedVertex = null;
            _SelectedEdge = null;
            MyPictureBox.Invalidate();
            Mode = Modes.Default;
        }

        private void EnableDragging()
        {
            MyPictureBox.MouseMove += new MouseEventHandler(MyPictureBox_MouseMove);
            MyPictureBox.MouseUp += new MouseEventHandler(MyPictureBox_MouseUp);
        }

        private void DisableDragging()
        {
            MyPictureBox.MouseMove -= MyPictureBox_MouseMove;
            MyPictureBox.MouseUp -= MyPictureBox_MouseUp;
        }

        (bool, Edge, IShape) CheckShapesEdgeHitbox(Point p)
        {
            foreach (IShape s in _Shapes)
            {
                (bool IsClicked, Edge e) = s.CheckEdgeHitbox(p);

                if (IsClicked)
                    return (IsClicked, e, s);
            }

            return (false, null, null);
        }

        private IGeometricObject CheckGeometricObjectHitbox(Point p)
        {
            (bool IsClicked, Vertex v, IShape s) = CheckShapesPointHitbox(p);

            if (IsClicked)
            {
                if (v == null) // is circle?
                    return (IGeometricObject)s;
                return (IGeometricObject)v;
            }

            Edge e;
            (IsClicked, e, s) = CheckShapesEdgeHitbox(p);

            if (IsClicked)
            {
                if (e == null) // is circle?
                    return (IGeometricObject)s;
                return (IGeometricObject)e;
            }


            return null;
        }

        private void FinishCreatingPolygon()
        {
            ((Polygon)_SelectedShape).ClosePolygon();
            EndDrawing();
        }

    }
}
