using SplashKitSDK;
using System;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        // Endpoint(_x2, _y2)
        private float _x2;
        private float _y2;

        public MyLine(Color color, float startX, float startY, float endX, float endY) 
        {
            Color = color;
            X = startX;
            Y = startY;
            X2 = endX;
            Y2 = endY;
        }

        public MyLine() : this(Color.Red, 0, 0, 0, 0)
        {
        }

        public float X2
        {
            get
            {
                return _x2;
            }
            set
            {
                _x2 = value;
            }
        }

        public float Y2
        {
            get
            {
                return _y2;
            }
            set
            {
                _y2 = value;
            }
        }

        public override void Draw() 
        {
            if (Selected)
            {
                DrawOutline();
            }

            // By default, the start point (X, Y) will be the coordinates of the mouse when clicking, and the end point (X2, Y2) will be (0, 0)
            SplashKit.DrawLine(Color, X, Y, X2, Y2);
        }

        public override bool IsAt(Point2D point2D)
        {
            return SplashKit.PointOnLine(point2D, SplashKit.LineFrom(X, Y, X2, Y2));
        }

        public override void DrawOutline()
        {
            Point2D[] points = new Point2D[4];
            points[0] = SplashKit.PointAt(X - 2, Y - 2);
            points[1] = SplashKit.PointAt(X + 2, Y - 2);
            points[2] = SplashKit.PointAt(X2 - 2, Y2 + 2);
            points[3] = SplashKit.PointAt(X2 + 2, Y2 + 2);

            Quad outlineQuad = new Quad();
            outlineQuad.Points = points;

            SplashKit.FillQuad(Color.Black, outlineQuad);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(X2);
            writer.WriteLine(Y2);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            X2 = reader.ReadSingle();
            Y2 = reader.ReadSingle();
        }
    }
}
