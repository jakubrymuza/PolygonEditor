using System;
using System.Drawing;
using GK_proj1.Relations;

namespace GK_proj1
{
    public static class Drawing
    {
        // http://tech-algorithm.com/articles/drawing-line-using-bresenham-algorithm/
        public static void DrawLine(Bitmap bitmap, Point p1, Point p2, Color Color)
        {
            int x1 = p1.X, x2 = p2.X, y1 = p1.Y, y2 = p2.Y;
            int w = x2 - x1;
            int h = y2 - y1;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;

            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;

            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);

            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }

            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                if (x1 > 0 && y1 > 0 && x1 < bitmap.Width && y1 < bitmap.Height) // otherwise dragging point outside the drawing area would cause the app to crash
                    bitmap.SetPixel(x1, y1, Color);

                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x1 += dx1;
                    y1 += dy1;
                }
                else
                {
                    x1 += dx2;
                    y1 += dy2;
                }
            }
        }

        public static void DrawRelationSymbol(Graphics g, Point p, Font f, IRelation r, Color c)
        {
            g.DrawString(r.GetSymbol(), f, new SolidBrush(c), p.X, p.Y);
        }

        public static void DrawPoint(Graphics g, Point p, int size, Color c)
        {
            try
            {
                g.FillEllipse(new SolidBrush(c), Geometry.GetCenteredSquare(p, size));
            }
            catch(OverflowException)
            {
                return;
            }
            
        }

        public static void DrawCircle(Graphics g, Point p, int r, Color c)
        {
            try
            {
                g.DrawEllipse(new Pen(new SolidBrush(c)), Geometry.GetCenteredSquare(p, 2 * r));
            }
            catch(OverflowException)
            {
                return;
            }
        }

    }
}
