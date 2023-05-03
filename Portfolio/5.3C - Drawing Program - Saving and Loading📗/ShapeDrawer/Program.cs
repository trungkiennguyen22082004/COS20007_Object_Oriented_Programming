﻿using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind { Rectangle, Circle, Line };
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing(Color.White);
            ShapeKind kindToAdd = ShapeKind.Circle;

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;

                    if (kindToAdd == ShapeKind.Circle)
                    {
                        newShape = new MyCircle();
                    }
                    else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        newShape = new MyRectangle();
                    }
                    else
                    {
                        newShape = new MyLine();
                    }

                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();

                    myDrawing.AddShape(newShape);
                }

                if (SplashKit.KeyDown(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                else if (SplashKit.KeyDown(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                else if (SplashKit.KeyDown(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.KeyDown(KeyCode.SpaceKey))
                    myDrawing.Background = SplashKit.RandomRGBColor(255);

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                    myDrawing.SelectedShapesAt(SplashKit.MousePosition());

                if ((SplashKit.KeyTyped(KeyCode.BackspaceKey)) || (SplashKit.KeyTyped(KeyCode.DeleteKey)))
                {
                    foreach (Shape shape in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(shape);
                    }
                }

                if (SplashKit.KeyDown(KeyCode.SKey))
                {
                    myDrawing.Save("E:/COS20007_Object_Oriented_Programming/Portfolio/5.3C - Drawing Program - Saving and Loading📗/TestDrawing.txt");
                }
                if (SplashKit.KeyDown(KeyCode.OKey))
                {
                    try
                    {
                        myDrawing.Load("E:/COS20007_Object_Oriented_Programming/Portfolio/5.3C - Drawing Program - Saving and Loading📗/TestDrawing.txt");
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                }

                myDrawing.Draw();

                SplashKit.RefreshScreen();

                } while (!window.CloseRequested);
        }
    }
}
