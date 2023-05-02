using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing(Color.Blue);

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape = new Shape(Color.Green, SplashKit.MouseX(), SplashKit.MouseY(), 100, 100);
                    myDrawing.AddShape(newShape);
                }

                if (SplashKit.KeyDown(KeyCode.SpaceKey))
                    myDrawing.Background = SplashKit.RandomRGBColor(255);

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                    myDrawing.SelectedShapesAt(SplashKit.MousePosition());

                if ((SplashKit.KeyTyped(KeyCode.BackspaceKey)) || (SplashKit.KeyTyped(KeyCode.DeleteKey)))
                {
                    foreach (Shape shape in myDrawing.SelectedShapes)
                        myDrawing.RemoveShape(shape);
                }
                myDrawing.Draw();

                SplashKit.RefreshScreen();

                } while (!window.CloseRequested);
        }
    }
}
