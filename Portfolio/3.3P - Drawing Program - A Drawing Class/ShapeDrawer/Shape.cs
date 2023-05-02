using SplashKitSDK;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;

namespace ShapeDrawer
{
    public class Shape
    {
        private Color _color;

        private float _x;
        private float _y;

        private float _width;
        private float _height;

        private bool _selected;
        public Shape(Color color, float x, float y, float width, float height)
        {
            _color = color;

            _x = x;
            _y = y;

            _width = width;
            _height = height;
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public float Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public void Draw()
        {
            if (_selected)
                DrawOutline();

            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        public bool IsAt(Point2D point2D) 
        {
            if (point2D.X >= _x && point2D.X < _x + _width && point2D.Y >= _y && point2D.Y < _y + _height) 
                return true;
            else
                return false;
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, _x - 2, _y - 2, _width + 4, _height + 4);
        }
    }
}
