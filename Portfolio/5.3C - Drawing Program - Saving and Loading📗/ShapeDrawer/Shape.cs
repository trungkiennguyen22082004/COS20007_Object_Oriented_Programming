using SplashKitSDK;
using System;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        private Color _color;

        private float _x;
        private float _y;

        private bool _selected;
        public Shape(Color color, float x, float y)
        {
            _color = color;

            _x = x;
            _y = y;
        }
        public Shape() : this(SplashKit.RandomRGBColor(255), 0, 0)
        {
        }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public abstract void Draw();

        public abstract bool IsAt(Point2D point2D);

        public bool Selected
        {
            get 
            {
                return _selected;
            }
            set 
            {
                _selected = value; 
            }
        }

        public abstract void DrawOutline();

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteColor(Color);
            writer.WriteLine(X);
            writer.WriteLine(Y);
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            Color = reader.ReadColor();
            X = reader.ReadSingle();
            Y = reader.ReadSingle();
        }
    }
}
