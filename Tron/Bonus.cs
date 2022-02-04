using System.Drawing;

namespace Tron {
    class Bonus {
        public Brush Brush { get; set; }
        public Size Size { get; set; }
        public Point Location { get; set; }
        public Rectangle Rectangle {
            get {
                return new Rectangle(Location, Size);
            }
        }

        public Bonus(Brush brush, Size size, Point location) {
            Brush = brush;
            Size = size;
            Location = location;
        }

        public void Draw(Graphics graphics) {
            graphics.FillEllipse(Brush, Rectangle);
        }

        public bool Intersect(Rectangle rectangle) {
            return Rectangle.IntersectsWith(rectangle);
        }
    }
}
