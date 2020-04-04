using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;
using Point = System.Drawing.Point;

public static class BitmapExtensions
{
    public static void DrawLine(this Bitmap bmp, Pen pen, Point a, Point b)
    {
        Graphics.FromImage(bmp).DrawLine(pen, a, b);
    }

    public static void DrawEllipse(this Bitmap bmp, Pen pen, Rectangle rect)
    {
        Graphics.FromImage(bmp).FillEllipse(System.Drawing.Brushes.White, rect);
        Graphics.FromImage(bmp).DrawEllipse(pen, rect);
    }

    public static void DrawArc(this Bitmap bmp, Pen pen, Rectangle rect, float a_angle, float b_angle)
    {
        Graphics.FromImage(bmp).FillPie(System.Drawing.Brushes.White, rect, a_angle, b_angle);
        Graphics.FromImage(bmp).DrawArc(pen, rect, a_angle, b_angle);
    }

    public static void DrawRectangle(this Bitmap bmp, Pen pen, Rectangle rect)
    {
        Graphics.FromImage(bmp).FillRectangle(System.Drawing.Brushes.White, rect);
        Graphics.FromImage(bmp).DrawRectangle(pen, rect);
    }

    public static void DrawRectangleWithoutLeftAndRight(this Bitmap bmp, Pen pen, Rectangle rect)
    {
        Graphics.FromImage(bmp).FillRectangle(System.Drawing.Brushes.White, rect);
        Graphics.FromImage(bmp).DrawLine(pen, rect.X, rect.Y, rect.Right, rect.Y);
        Graphics.FromImage(bmp).DrawLine(pen, rect.X, rect.Bottom, rect.Right, rect.Bottom);
    }

    public static ImageSource ToImageSource(this Bitmap bmp)
    {
        return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                   bmp.GetHbitmap(),
                   IntPtr.Zero,
                   Int32Rect.Empty,
                   BitmapSizeOptions.FromEmptyOptions());
    }

    public static void Fill(this Bitmap bmp, Color color)
    {
        Graphics.FromImage(bmp).Clear(color);
    }
}