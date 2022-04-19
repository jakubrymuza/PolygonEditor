// Autor: Jakub Rymuza
// 305870

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GK_proj1.Shapes;
using GK_proj1.Relations;

namespace GK_proj1
{
    public enum Modes
    {
        Default, CreateNewPolygon, CreateNewCircle, DeletePoint, DivideEdge, EdgeDrag, VertexDrag, PolygonDrag, 
        AddUnaryRelation, AddBinaryRelation1, AddBinaryRelation2, RemoveRelation, InputLength, InputRadius
    }

    public partial class Form1 : Form
    {


        private Modes _Mode = Modes.Default;
        private List<IShape> _Shapes = new List<IShape>();
        private IShape _SelectedShape = null;
        private Vertex _SelectedVertex = null;
        private Edge _SelectedEdge = null;
        private Point _LastPosition;
        private IRelation _NewRelation = null;
        public bool AutoTangent = true;

        private Modes Mode
        {
            get { return _Mode; }
            set
            {
                _Mode = value;
                ModeLabel.Text = _Mode.ToString();
            }
        }

        public Form1()
        {
            InitializeComponent();
            GenerateInitialScene();
        }

        private void MyPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bitmap = new Bitmap(MyPictureBox.Width, MyPictureBox.Height);

            foreach (IShape s in _Shapes)
                s.DrawShape(bitmap);

            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void MyPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _LastPosition = e.Location;

            switch (Mode)
            {              
                case Modes.Default:
                case Modes.PolygonDrag:
                    CheckDragHitboxes(e.Location);
                    break;

                case Modes.AddBinaryRelation1:
                case Modes.AddBinaryRelation2:
                case Modes.AddUnaryRelation:
                    AddRelationAction(e.Location);
                    break;

                case Modes.RemoveRelation:
                    RemoveRelationAction(e.Location);
                    break;

                case Modes.CreateNewPolygon:
                    NewPolygonAction(e.Location);
                    break;

                case Modes.CreateNewCircle:
                    NewCircleAction(e.Location);
                    break;

                case Modes.DeletePoint:
                    DeletePointAction(e.Location);
                    break;

                case Modes.DivideEdge:
                    DivideEdgeAction(e.Location);
                    break;

                default: return;
            }

            MyPictureBox.Invalidate();

        }


        private void AddRelationAction(Point p)
        {
            IGeometricObject obj = CheckGeometricObjectHitbox(p);

            if (obj == null)
                return;

            _NewRelation.AddTarget(obj);

            switch(Mode)
            {
                case Modes.AddBinaryRelation1:
                    Mode = Modes.AddBinaryRelation2;
                    break;

                case Modes.AddBinaryRelation2:
                    Mode = Modes.Default;
                    _NewRelation.EnforceRelation();
                    break;

                case Modes.AddUnaryRelation:


                    if (_NewRelation is FixedLengthRelation)
                    {
                        Mode = Modes.InputLength;
                        FixedLengthTextBox.Text = ((Edge)((FixedLengthRelation)_NewRelation).Target).Length().ToString();

                        break;
                    }
                    else if (_NewRelation is FixedRadiusRelation)
                    {
                        Mode = Modes.InputLength;
                        FixedRadiusTextBox.Text = ((Circle)((FixedRadiusRelation)_NewRelation).Target).Radius.ToString();

                        break;
                    }
                    else if (_NewRelation is FixedPointRelation)
                        ((FixedPointRelation)_NewRelation).Point = ((Circle)obj).Center;

                    Mode = Modes.Default;
                    _NewRelation.EnforceRelation();
                    break;
            }
        }



        private void RemoveRelationAction(Point p)
        {
            IGeometricObject obj = CheckGeometricObjectHitbox(p);

            if(obj != null)
                obj.Relation.RemoveRelation();

            Mode = Modes.Default;
        }

        private void DivideEdgeAction(Point p)
        {
            (bool IsClicked, Edge e, IShape s) = CheckShapesEdgeHitbox(p);

            if (IsClicked && e != null)
            {
                ((Polygon)s).DivideEdge(e);
                Mode = Modes.Default;
            }
                
        }

        private void DeletePointAction(Point p)
        {
            (bool IsClicked, Vertex v, IShape s) = CheckShapesPointHitbox(p);

            if (IsClicked)
            {
                if (v == null) // s is circle
                    _Shapes.Remove(s);

                s.DeletePoint(v);

                EndDrawing();
            }
        }

        private void NewPolygonAction(Point p)
        {
            if (_SelectedShape == null)
            {
                _SelectedShape = new Polygon();
                _Shapes.Add(_SelectedShape);
            }

            ((Polygon)_SelectedShape).AddVertex(p);
        }

        private void NewCircleAction(Point p)
        {
            _SelectedShape = new Circle(p);
            _Shapes.Add(_SelectedShape);
            EnableDragging();

        }

        private void MyPictureBox_MouseMove(object sender, MouseEventArgs e)
        {

            switch (Mode)
            {
                case Modes.CreateNewCircle:
                    ((Circle)_SelectedShape).Radius = (int)Geometry.Distance(e.Location, ((Circle)_SelectedShape).Center);
                    break;

                case Modes.VertexDrag:
                    _SelectedShape.DragPoint(e.Location, _SelectedVertex);
                    break;

                case Modes.PolygonDrag:
                    if (_SelectedEdge != null)
                        _SelectedShape.DragEntireShapeByEdge(e.Location, _SelectedEdge, _LastPosition);
                    else _SelectedShape.DragEntireShape(e.Location, _SelectedVertex);
                    break;

                case Modes.EdgeDrag:
                    _SelectedShape.DragEdge(e.Location, _SelectedEdge, _LastPosition);
                    break;

                default: return;
            }

            _LastPosition = e.Location;

            if (AutoTangent)
                CheckShapesTangent();

            MyPictureBox.Invalidate();

        }

        private void MyPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            DisableDragging();
            EndDrawing();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            switch(e.KeyCode)
            {
                case Keys.Escape:
                    if (Mode == Modes.CreateNewPolygon)
                        FinishCreatingPolygon();
                    else Mode = Modes.Default;
                    break;

                case Keys.Enter:
                    if (Mode == Modes.InputLength)
                    {
                        if(_NewRelation is FixedLengthRelation)
                            ((FixedLengthRelation)_NewRelation).Length = double.Parse(FixedLengthTextBox.Text);
                        else ((FixedRadiusRelation)_NewRelation).Length = int.Parse(FixedRadiusTextBox.Text);


                        Mode = Modes.Default;
                        _NewRelation.EnforceRelation();

                        MyPictureBox.Invalidate();
                    }
                    break;

            }

        }


        // czesc labolatoryjna:
        private void CheckShapesTangent()
        {
            foreach (var s1 in _Shapes)
            {
                if (s1 is Circle)
                {
                    if (((Circle)s1).Relation != null && ((Circle)s1).Relation is TangentRelation)
                        continue;


                    foreach (var s2 in _Shapes)
                    {
                        if (s2 is Polygon)
                            CheckShapeTangent((Circle)s1, (Polygon)s2);
                    }
                }
            }
        }

        private void CheckShapeTangent(Circle c, Polygon poly)
        {
            foreach (var e in poly.GetEdges())
            {

                if (e.Relation == null && Geometry.IsTangent(c, e))
                {
                    var r = new TangentRelation();
                    r.AddTarget(c);
                    r.AddTarget(e);
                }

            }
        }


    }
}
