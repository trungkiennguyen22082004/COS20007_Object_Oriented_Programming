using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            Shape myShape;
            myShape = new Shape(Color.Green, 0, 0, 100, 100);

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.X = (float)SplashKit.MouseX();
                    myShape.Y = (float)SplashKit.MouseY();
                }

                if (myShape.IsAt(SplashKit.MousePosition()))
                {
                    if (SplashKit.KeyDown(KeyCode.SpaceKey))
                        myShape.Color = Color.RandomRGB(255);
                }
                myShape.Draw();

                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
    }
}
