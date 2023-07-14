using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public abstract class Shape
    {
        public Point shapeSize { get; set; }
        public Point shapeLocation { get; set; }
        public int shapeIndex { get; set; }
        public int colorIndex { get; set; }
        public Color color { get; set; }
        public static List<Shape> Shapes {  get; set; }
        public static List<Point> DrawnShapeSize { get; set; }
        public static List<Point> DrawnShapeLocation { get; set; }
        public abstract void Draw(Graphics g, Brush p, int x, int y, int width, int height);
    }
}
