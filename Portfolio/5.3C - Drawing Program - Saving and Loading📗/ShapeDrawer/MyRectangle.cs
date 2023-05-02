﻿using SplashKitSDK;
using System;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        private int _width;
        private int _height;

        public MyRectangle(Color color, float x, float y, int width, int height)
        {
            Color = color;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        public MyRectangle() : this(Color.Green, 0, 0, 100, 100)
        {
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public override void Draw()
        {
            if (Selected)
                DrawOutline();

            SplashKit.FillRectangle(Color, X, Y, Width, Height);
        }

        public override bool IsAt(Point2D point2D)
        {
            if (point2D.X >= X && point2D.X < X + Width && point2D.Y >= Y && point2D.Y < Y + Height)
                return true;
            else
                return false;
        }

        public override void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, X - 2, Y - 2, Width + 4, Height + 4);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(Width); 
            writer.WriteLine(Height);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();
        }
    }
}
