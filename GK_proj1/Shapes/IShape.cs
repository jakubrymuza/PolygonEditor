using System;
using System.Collections.Generic;
using System.Drawing;

namespace GK_proj1.Shapes
{
    public interface IShape
    {
        public Bitmap DrawShape(Bitmap bitmap);

        /// <summary>
        /// function check whether selected point is within hitbox of one of the vertices (for polygons) or center point (for circles)
        /// </summary>
        /// <returns>function returns tuple containing information wheter the shape was clicked and the clicked vertex (for polygons)</returns>
        public (bool, Vertex) CheckPointHitbox(Point p);

        /// <summary>
        /// function check whether selected point is within hitbox of one of the edges (for polygons) or the outer ring (for circles)
        /// </summary>
        /// <returns>function returns tuple containing information wheter the shape was clicked and the clicked edge (for polygons)</returns>
        public (bool, Edge) CheckEdgeHitbox(Point p);

        /// <summary>
        /// function drags polygon's vertex or circle's midpoint to selected location
        /// </summary>
        public void DragPoint(Point p, Vertex selectedVertex);

        /// <summary>
        /// function deletes single vertex (for polygons)
        /// </summary>
        public void DeletePoint(Vertex v);

        public void DragEntireShape(Point p, Vertex v);

        public void DragEdge(Point p, Edge e, Point lp);

        public void DragEntireShapeByEdge(Point p, Edge e, Point lp);

    }
}
