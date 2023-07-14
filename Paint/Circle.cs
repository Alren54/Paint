using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class Circle : Shape
    {
        public Circle(Point shapeSize, Point shapeLocation, Color color, int colorIndex)
        {
            this.shapeSize = shapeSize;
            this.shapeLocation = shapeLocation;
            this.color = color;
            this.colorIndex = colorIndex;
            shapeIndex = 1;
        }
        public override void Draw(Graphics g, Brush b, int shapeLocationX, int shapeLocationY, int selectedShapeSizeX, int selectedShapeSizeY)
        {
            Brush brushWhite = new SolidBrush(Color.White);

            shapeSize = new Point(selectedShapeSizeX, selectedShapeSizeY);
            shapeLocation = new Point(shapeLocationX, shapeLocationY);

            g.FillRectangle(brushWhite, shapeLocationX - 1, shapeLocationY - 1, selectedShapeSizeX + 2, selectedShapeSizeY + 2);
            g.FillEllipse(b, shapeLocationX, shapeLocationY, selectedShapeSizeX, selectedShapeSizeY);
        }
    }
}
