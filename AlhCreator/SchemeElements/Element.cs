using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AlhCreator.SchemeElements
{
    public abstract class Element : Image
    {
        bool _moving;
        Point _mouseOffset;
        Canvas _parent;

        public JoinType TypeOfJoin { get; protected set; }
        public Element[] NextElements { get; protected set; }

        public Element(Canvas parent)
        {
            _parent = parent;

            MouseLeftButtonDown += (s, e) => 
            {
                _moving = true;
                _mouseOffset = Mouse.GetPosition(this);
            };

            MouseLeftButtonUp += (s, e) =>
            {
                _moving = false;
            };

            MouseMove += MoveMouse;

            SizeChanged += (s, e) =>
            {
                ReloadImage();
            };

            Initialized += (s, e) =>
            {
                Source = ReloadImage();
            };
        }

        void MoveMouse(object sender, EventArgs e)
        {
            if (_moving)
            {
                Dispatcher.Invoke(() =>
                {
                    var mousePos = Mouse.GetPosition(_parent);

                    Canvas.SetLeft(this, mousePos.X - _mouseOffset.X);
                    Canvas.SetTop(this, mousePos.Y - _mouseOffset.Y);
                });
            }
        }

        public enum JoinType
        {
            Bottom
        }

        public abstract ImageSource ReloadImage();
    }
}
