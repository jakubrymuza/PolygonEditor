using System;
using System.Collections.Generic;
using System.Drawing;
using GK_proj1.Relations;

namespace GK_proj1.Shapes
{
    public class Polygon : IShape
    {
        private List<Vertex> _Vertices;
        private List<Edge> _Edges;
        private bool _IsCLosed = false;
        private Vertex _FirstVertex = null;
        private Vertex _LastVertex = null;
        private int _ChangeCounter = 0;
        private const int _MaxChangeCount = 20;

        public Polygon()
        {
            _Vertices = new List<Vertex>();
            _Edges = new List<Edge>();
        }

        public Bitmap DrawShape(Bitmap bitmap)
        {
            Graphics g = Graphics.FromImage(bitmap);

            foreach (var e in _Edges)
                e.DrawEdge(bitmap);

            foreach(var v in _Vertices)
                v.DrawVertex(g);
        

            g.Dispose();

            return bitmap;
        }

        public void AddVertex(Point p)
        {
            Vertex v = new Vertex(p);
            _Vertices.Add(v);
            v.Parent = this;

            if (_Vertices.Count > 1)
            {
                Edge e = new Edge(_LastVertex, v);
                _Edges.Add(e);
                e.Parent = this;

                _LastVertex.Edges.Add(e);
                v.Edges.Add(e);

                _LastVertex = v;
            }
            else _FirstVertex = _LastVertex = v;

        }

        public void ClosePolygon()
        {
            if (_IsCLosed == false)
            {
                Edge e = new Edge(_FirstVertex, _LastVertex);
                _Edges.Add(e);
                e.Parent = this;

                _FirstVertex.Edges.Add(e);
                _LastVertex.Edges.Add(e);
            }               

            _IsCLosed = true;
        }

        public void DragPoint(Point p, Vertex selectedVertex)
        {
            _ChangeCounter = 0;
            if (!ChangePointPosition(p, selectedVertex))
            {
                DragEntireShape(p, selectedVertex);
            }
                

        }
        public bool ChangePointPosition(Point p, Vertex selectedVertex)
        {
            if (++_ChangeCounter > _MaxChangeCount)
                return false;

            Point oldCoords = selectedVertex.Coords;
            selectedVertex.Coords = p;

            HandleRelations(selectedVertex.Edges[0], selectedVertex, oldCoords);
            HandleRelations(selectedVertex.Edges[1], selectedVertex, oldCoords);
            return true;
        }

        private void HandleRelations(Edge e, Vertex v, Point oldCoords)
        {
            if (e.Relation != null && !e.Relation.IsSatisfied())
                if (!e.Relation.PreserveRelation(v))
                {
                    Point newCoords = v.Coords;
                    v.Coords = oldCoords;
                    DragEntireShape(newCoords, v);
                }

        }

        public void DragEdge(Point p, Edge e, Point lp)
        {
            _ChangeCounter = 0;
            if (!ChangeEdgePostion(p, e, lp))
            {
                DragEntireShapeByEdge(p, e, lp);
            }

        }

        public bool ChangeEdgePostion(Point p, Edge e, Point lp)
        {
            if (++_ChangeCounter > _MaxChangeCount)
                return false;

            Point shift = Geometry.PointSubstraction(lp, p);

            (Vertex v1, Vertex v2) = e.Ends;

            ChangePointPosition(Geometry.PointAddition(v1.Coords, shift), v1);
            ChangePointPosition(Geometry.PointAddition(v2.Coords, shift), v2);


            if (e.Relation != null && !e.Relation.IsSatisfied())
                e.Relation.PreserveRelation(e);

            return true;
        }

        public void DragEntireShape(Point p, Vertex v)
        {
            Point shift = Geometry.PointSubstraction(p, v.Coords);

            foreach (var vert in _Vertices)
            {
                vert.Coords.X += shift.X;
                vert.Coords.Y += shift.Y;
            }

            CheckAllRelations();
        }

        public void DragEntireShapeByEdge(Point p, Edge e, Point lp)
        {
            Point shift = Geometry.PointSubstraction(p, lp);

            foreach (var v in _Vertices)
            {
                v.Coords.X += shift.X;
                v.Coords.Y += shift.Y;
            }

            CheckAllRelations();
        }

        private void CheckAllRelations()
        {
            foreach (var ed in _Edges)
                if (ed.Relation != null)
                    ed.Relation.EnforceRelation();
        }

        public void DeletePoint(Vertex v)
        {
            if (_Vertices.Count < 4)
                return;

            _Vertices.Remove(v);

            Edge e1 = v.Edges[0], e2 = v.Edges[1];

            e1.Relation?.RemoveRelation();
            _Edges.Remove(e1);

            e2.Relation?.RemoveRelation();
            _Edges.Remove(e2);

            _IsCLosed = false;

            (_FirstVertex, _LastVertex) = v.GetNeighbors();
            _FirstVertex.Edges.Remove(v.Edges[0]);
            _LastVertex.Edges.Remove(v.Edges[1]);
            _FirstVertex.Edges.Remove(v.Edges[0]);
            _LastVertex.Edges.Remove(v.Edges[1]);

            ClosePolygon();

        }

        public void DivideEdge(Edge e)
        {
            (Vertex v1, Vertex v2) = e.Ends;
            Point p = Geometry.GetMidwayDistance(v1.Coords, v2.Coords);

            e.Relation?.RemoveRelation();
            _Edges.Remove(e);

            v1.Edges.Remove(e);
            v2.Edges.Remove(e);
            _IsCLosed = false;

            _FirstVertex = v1;
            _LastVertex = v2;
            AddVertex(p);
            ClosePolygon();
        }

        public (bool, Edge) CheckEdgeHitbox(Point p)
        {
            foreach (Edge e in _Edges)
            {
                (Vertex v1, Vertex v2) = e.Ends;
                if (Geometry.GetPointSegmentDistance(p, v1.Coords, v2.Coords) < Edge.EdgeHitbox)
                    return (true, e);
            }

            return (false, null);
        }

        public (bool, Vertex) CheckPointHitbox(Point p)
        {
            foreach(Vertex v in _Vertices)
                if (Geometry.Distance(v.Coords, p) < Vertex.VertexSize)
                    return (true, v);

            return (false, null);
        }

        public List<Edge> GetEdges() => _Edges;

    }
}
