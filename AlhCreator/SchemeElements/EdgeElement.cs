
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;

namespace AlhCreator.SchemeElements
{
    public class EdgeElement : Element
    {
        System.Drawing.Pen line = new System.Drawing.Pen(System.Drawing.Color.Black, 4);
        private readonly EdgeType _edgeType;

        public EdgeElement(Canvas parent, EdgeType edgeType) : base(parent)
        {
            Width = 200;
            Height = 40;
            _edgeType = edgeType;
            TypeOfJoin = JoinType.Bottom;
        }

        public enum EdgeType
        {
            Start,
            End
        }

        public override ImageSource ReloadImage()
        {
            Bitmap result = new Bitmap((int)Width*4, (int)Height*4);

            result.DrawRectangleWithoutLeftAndRight(line, new Rectangle(result.Height / 2, (int)(line.Width / 2) + 1, result.Width - result.Height, (int)(result.Height - line.Width) - 1));

            result.DrawArc(line, new Rectangle((int)(line.Width / 2), (int)(line.Width / 2), result.Height - (int)(line.Width), result.Height - (int)(line.Width)), 90, 180);
            result.DrawArc(line, new Rectangle((int)(result.Width - result.Height + line.Width / 2 - 1), (int)(line.Width / 2), result.Height - (int)(line.Width), result.Height - (int)(line.Width)), 270, 180);

            return result.ToImageSource();
        }
    }
}
