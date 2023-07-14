using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class Hexagon : Shape
    {
        public Hexagon(Point shapeSize, Point shapeLocation, Color color, int colorIndex)
        {
            this.shapeSize = shapeSize;
            this.shapeLocation = shapeLocation;
            this.color = color;
            this.colorIndex = colorIndex;
            shapeIndex = 3;
        }
        public override void Draw(Graphics g, Brush b, int shapeLocationX, int shapeLocationY, int selectedShapeSizeX, int selectedShapeSizeY)
        {
            Brush brushWhite = new SolidBrush(Color.White);
            Point[] points = new Point[6];
            points[0] = new Point(shapeLocationX + selectedShapeSizeX / 2, shapeLocationY); //en üst orta
            points[1] = new Point(shapeLocationX + selectedShapeSizeX, shapeLocationY + selectedShapeSizeY / 3); // üst sağ
            points[2] = new Point(shapeLocationX + selectedShapeSizeX, shapeLocationY + 2 * selectedShapeSizeY / 3); // alt sağ
            points[3] = new Point(shapeLocationX + selectedShapeSizeX / 2, shapeLocationY + selectedShapeSizeY); // en alt orta
            points[4] = new Point(shapeLocationX, shapeLocationY + 2 * selectedShapeSizeY / 3); // alt sol
            points[5] = new Point(shapeLocationX, shapeLocationY + selectedShapeSizeY / 3); // üst sol

            shapeSize = new Point(selectedShapeSizeX, selectedShapeSizeY);
            shapeLocation = new Point(shapeLocationX, shapeLocationY);

            g.FillRectangle(brushWhite, shapeLocationX - 1, shapeLocationY - 1, selectedShapeSizeX + 2, selectedShapeSizeY + 2);
            g.FillPolygon(b, points);
            return;
        }
    }
}
