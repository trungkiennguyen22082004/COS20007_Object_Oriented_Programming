using SplashKitSDK;
using System;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;

        public MyCircle(Color color, float x, float y, int radius)
        {
            Color = color;
            X = x;
            Y = y;
            Radius = radius;
        }
        public MyCircle() : this(Color.Blue, 0, 0, 50)
        {
        }

        public int Radius
        {
            get 
            { 
                return _radius; 
            }
            set 
            {
                _radius = value; 
            }
        }
        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SplashKit.FillCircle(Color, X, Y, _radius);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, _radius + 2);
        }

        public override bool IsAt(Point2D point2D)
        {
            float a = (float)(point2D.X - X);
            float b = (float)(point2D.Y - Y);

            if (Math.Sqrt(a * a + b * b) < _radius)
                return true;

            return false;
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(Radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
        }
    }
}
