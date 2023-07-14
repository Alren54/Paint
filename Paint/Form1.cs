using Microsoft.VisualBasic.Devices;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        private int _shapeIndex; //�ekil  T�r� G�stergeci
        private int _colorIndex; //Renk G�stergeci
        private Pen _pen;
        private Graphics g;
        
        private bool isPressing; //Mouse Bas�l� Tutuluyor
        private bool isSelectingShape; //�ekil Se�ilebilir
        private bool isSelectedShape; //�ekil Se�ili
        private bool byButton; // �ekil De�i�tirilme Talebinin Butona bas�larak olmas�n� sa�lar.

        private Point _highlightedShapeSize; // Se�ilen �eklin Boyutu
        private Point _highlightedShapeLocation; // Se�ilen �eklin Yeri
        private int _highlightedShapeTypeIndex; //Se�ilen �eklin �ekil T�r�
        private int _highlightedArrayLocationIndex; // Se�ilen �eklin Listedeki Yeri
        private int _highlightedColorIndex; // Se�ilen �eklin Renginin indisi
        private Color _highlightedColor; // Se�ilen �ekling Rengi

        private Point _dyeConstraintCheck = new Point(0, 0);
        private Point _dyeStartingPos = new Point(0, 0);
        private Point _dyeMinPos = new Point(0, 0);
        private Point _dyeMaxPos = new Point(0, 0);

        
        Button[] _buttonColors = new Button[9];
        Button[] _buttonShapes = new Button[4];

        public Form1()
        {
            InitializeComponent();
            _shapeIndex = 0;
            _colorIndex = 0;
            button1.BackColor = Color.Gray;
            button5.BackColor = Color.Gray;
            _pen = new Pen(Color.Red);
            g = pictureBox1.CreateGraphics();
            isPressing = false;
            isSelectingShape = false;
            Shape.Shapes = new List<Shape>();
            Shape.DrawnShapeSize = new List<Point>();
            Shape.DrawnShapeLocation = new List<Point>();
            isSelectedShape = false;
            byButton = true;

            _buttonShapes[0] = button1;
            _buttonShapes[1] = button2;
            _buttonShapes[2] = button3;
            _buttonShapes[3] = button4;

            _buttonColors[0] = button5;
            _buttonColors[1] = button6;
            _buttonColors[2] = button7;
            _buttonColors[3] = button8;
            _buttonColors[4] = button9;
            _buttonColors[5] = button10;
            _buttonColors[6] = button11;
            _buttonColors[7] = button12;
            _buttonColors[8] = button13;
        }

        private void ResetButtonColors() // Butonlar�n arkaplan renklerini default hale getir.
        {
            foreach (Button button in _buttonShapes)
            {
                button.BackColor = SystemColors.Control;
            }
            foreach (Button button in _buttonColors)
            {
                button.BackColor = SystemColors.Control;
            }
        }

        private void ButtonColorChanges() // Butonlar�n Renklerini De�i�tir.
        {
            if (isSelectingShape == false) // �ekil Se�miyorken
            {
                ResetButtonColors();
                _buttonShapes[_shapeIndex].BackColor = Color.Gray;
                _buttonColors[_colorIndex].BackColor = Color.Gray;
            }
            else if (isSelectedShape) // �ekil Se�iyorken ve �ekil Se�mi�ken
            {
                ResetButtonColors();
                _buttonShapes[_highlightedShapeTypeIndex].BackColor = Color.Gray;
                _buttonColors[_highlightedColorIndex].BackColor = Color.Gray;
            }
            else ResetButtonColors(); // �ekil Se�iyorken ve �ekil Se�memi�ken
        }

        //Shapes
        private void button1_Click(object sender, EventArgs e)
        {
            _shapeIndex = 0;
            ButtonColorChanges();
            isSelectingShape = false;
            if (isSelectedShape)
            {
                byButton = true;
                RedrawSelectedShape();
                byButton = false;
                isSelectedShape = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _shapeIndex = 1;
            ButtonColorChanges();
            isSelectingShape = false;
            if (isSelectedShape)
            {
                byButton = true;
                RedrawSelectedShape();
                byButton = false;
                isSelectedShape = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _shapeIndex = 2;
            ButtonColorChanges();
            isSelectingShape = false;
            if (isSelectedShape)
            {
                byButton = true;
                RedrawSelectedShape();
                byButton = false;
                isSelectedShape = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _shapeIndex = 3;
            ButtonColorChanges();
            isSelectingShape = false;
            if (isSelectedShape)
            {
                byButton = true;
                RedrawSelectedShape();
                byButton = false;
                isSelectedShape = false;
            }
        }
        //Colors
        private void button5_Click(object sender, EventArgs e)
        {
            _colorIndex = 0;
            _pen.Color = Color.Red;
            if (isSelectedShape)
            {
                DyeSelectedShape(_pen.Color);
            }
            ButtonColorChanges();
            isSelectingShape = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _colorIndex = 1;
            _pen.Color = Color.Blue;
            if (isSelectedShape)
            {
                DyeSelectedShape(_pen.Color);
            }
            ButtonColorChanges();
            isSelectingShape = false;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            _colorIndex = 2;
            _pen.Color = Color.DarkGreen;
            if (isSelectedShape)
            {
                DyeSelectedShape(_pen.Color);
            }
            ButtonColorChanges();
            isSelectingShape = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _colorIndex = 3;
            _pen.Color = Color.Orange;
            if (isSelectedShape)
            {
                DyeSelectedShape(_pen.Color);
            }
            ButtonColorChanges();
            isSelectingShape = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            _colorIndex = 4;
            _pen.Color = Color.Black;
            if (isSelectedShape)
            {
                DyeSelectedShape(_pen.Color);
            }
            ButtonColorChanges();
            isSelectingShape = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            _colorIndex = 5;
            _pen.Color = Color.Yellow;
            if (isSelectedShape)
            {
                DyeSelectedShape(_pen.Color);
            }
            ButtonColorChanges();
            isSelectingShape = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            _colorIndex = 6;
            _pen.Color = Color.Purple;
            if (isSelectedShape)
            {
                DyeSelectedShape(_pen.Color);
            }
            ButtonColorChanges();
            isSelectingShape = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            _colorIndex = 7;
            _pen.Color = Color.DarkRed;
            if (isSelectedShape)
            {
                DyeSelectedShape(_pen.Color);
            }
            ButtonColorChanges();
            isSelectingShape = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            _colorIndex = 8;
            _pen.Color = Color.White;
            if (isSelectedShape)
            {
                DyeSelectedShape(_pen.Color);
            }
            ButtonColorChanges();
            isSelectingShape = false;
        }

        private void button14_Click(object sender, EventArgs e) // �ekil Se�me
        {
            isSelectingShape = true;
            isSelectedShape = false;
            _highlightedShapeTypeIndex = -1;
        }

        private void button15_Click(object sender, EventArgs e) //Se�ilen Cismi Silme
        {
            if (isSelectedShape)
            {
                Brush brushWhite = new SolidBrush(Color.White);
                Point shapeLocation = new Point(Shape.DrawnShapeLocation[_highlightedArrayLocationIndex].X, Shape.DrawnShapeLocation[_highlightedArrayLocationIndex].Y);
                Point shapeSize = new Point(Shape.DrawnShapeSize[_highlightedArrayLocationIndex].X, Shape.DrawnShapeSize[_highlightedArrayLocationIndex].Y);
                g.FillRectangle(brushWhite, shapeLocation.X - 1, shapeLocation.Y - 1, shapeSize.X + 2, shapeSize.Y + 2);
                Shape.DrawnShapeSize.Remove(Shape.DrawnShapeSize[_highlightedArrayLocationIndex]);
                Shape.DrawnShapeLocation.Remove(Shape.DrawnShapeLocation[_highlightedArrayLocationIndex]);
                Shape.Shapes.Remove(Shape.Shapes[_highlightedArrayLocationIndex]);
                isSelectingShape = false;
                isSelectedShape = false;
            }
        }

        private void button16_Click(object sender, EventArgs e) // Yeni Sayfa A�ma
        {
            NewPage();
        }

        private void button17_Click(object sender, EventArgs e) // Dosyadan Y�kleme
        {
            int i = 0;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Metin Dosyalar� (*.txt)|*.txt";
            openFileDialog.Title = "Y�kle";
            openFileDialog.ShowDialog();

            string filePath = openFileDialog.FileName;

            if (!string.IsNullOrEmpty(filePath))
            {
                NewPage();
                StreamReader reader = new StreamReader(filePath);
                while (!reader.EndOfStream)
                {
                    string sizeLine = reader.ReadLine();
                    string locationLine = reader.ReadLine();
                    string indexLine = reader.ReadLine();
                    string colorLine = reader.ReadLine();
                    string colorIndexLine = reader.ReadLine();

                    string[] sizeValues = sizeLine.Split(',');
                    string[] locationValues = locationLine.Split(',');
                    int index = int.Parse(indexLine);
                    string[] colorValues = colorLine.Split(',');
                    int colorIndex = int.Parse(colorIndexLine);

                    Point shapeSize = new Point(int.Parse(sizeValues[0]), int.Parse(sizeValues[1]));
                    Point shapeLocation = new Point(int.Parse(locationValues[0]), int.Parse(locationValues[1]));
                    Color shapeColor = Color.FromArgb(int.Parse(colorValues[0]), int.Parse(colorValues[1]), int.Parse(colorValues[2]));

                    if (index == 0)
                    {
                        Square square = new Square(shapeSize, shapeLocation, shapeColor, colorIndex);
                        Shape.DrawnShapeSize.Add(shapeSize);
                        Shape.DrawnShapeLocation.Add(shapeLocation);
                        Shape.Shapes.Add(square);
                        Brush b = new SolidBrush(shapeColor);
                        square.Draw(g, b, shapeLocation.X, shapeLocation.Y, shapeSize.X, shapeSize.Y);
                    }
                    else if (index == 1)
                    {
                        Circle circle = new Circle(shapeSize, shapeLocation, shapeColor, colorIndex);
                        Shape.DrawnShapeSize.Add(shapeSize);
                        Shape.DrawnShapeLocation.Add(shapeLocation);
                        Shape.Shapes.Add(circle);
                        Brush b = new SolidBrush(shapeColor);
                        circle.Draw(g, b, shapeLocation.X, shapeLocation.Y, shapeSize.X, shapeSize.Y);
                    }
                    else if (index == 2)
                    {
                        Triangle triangle = new Triangle(shapeSize, shapeLocation, shapeColor, colorIndex);
                        Shape.DrawnShapeSize.Add(shapeSize);
                        Shape.DrawnShapeLocation.Add(shapeLocation);
                        Shape.Shapes.Add(triangle);
                        Brush b = new SolidBrush(shapeColor);
                        triangle.Draw(g, b, shapeLocation.X, shapeLocation.Y, shapeSize.X, shapeSize.Y);
                    }
                    else if (index == 3)
                    {
                        Hexagon hexagon = new Hexagon(shapeSize, shapeLocation, shapeColor, colorIndex);
                        Shape.DrawnShapeSize.Add(shapeSize);
                        Shape.DrawnShapeLocation.Add(shapeLocation);
                        Shape.Shapes.Add(hexagon);
                        Brush b = new SolidBrush(shapeColor);
                        hexagon.Draw(g, b, shapeLocation.X, shapeLocation.Y, shapeSize.X, shapeSize.Y);
                    }
                    i++;
                }

            }

        }

        //Dosyaya Kaydet
        private void button18_Click(object sender, EventArgs e)
        {
            int i = 0;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Metin Dosyalar� (*.txt)|*.txt";
            saveFileDialog.Title = "Kaydet";
            saveFileDialog.ShowDialog();

            string filePath = saveFileDialog.FileName;

            if (!string.IsNullOrEmpty(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    while (i < Shape.Shapes.Count)
                    {
                        writer.WriteLine($"{Shape.Shapes[i].shapeSize.X},{Shape.Shapes[i].shapeSize.Y}");
                        writer.WriteLine($"{Shape.Shapes[i].shapeLocation.X},{Shape.Shapes[i].shapeLocation.Y}");
                        writer.WriteLine(Shape.Shapes[i].shapeIndex);
                        writer.WriteLine($"{Shape.Shapes[i].color.R},{Shape.Shapes[i].color.G},{Shape.Shapes[i].color.B}");
                        writer.WriteLine(Shape.Shapes[i].colorIndex);
                        i++;
                    }
                }
            }
        }

        private void NewPage() // Yeni Sayfa A�ma ve Ayarlar� Fabrika Ayarlar�na D�nd�rme
        {
            _shapeIndex = 0;
            _highlightedShapeTypeIndex = -1;

            _colorIndex = 0;
            button1.BackColor = Color.Gray;
            button5.BackColor = Color.Gray;

            _pen = new Pen(Color.Red);
            isSelectingShape = false;
            isSelectedShape = false;
            byButton = true;

            Shape.Shapes.Clear();
            Shape.DrawnShapeSize.Clear();
            Shape.DrawnShapeLocation.Clear();

            g.Clear(Color.White);
            
            button2.BackColor = SystemColors.Control;
            button3.BackColor = SystemColors.Control;
            button4.BackColor = SystemColors.Control;
            button6.BackColor = SystemColors.Control;
            button7.BackColor = SystemColors.Control;
            button8.BackColor = SystemColors.Control;
            button9.BackColor = SystemColors.Control;
            button10.BackColor = SystemColors.Control;
            button11.BackColor = SystemColors.Control;
            button12.BackColor = SystemColors.Control;
            button13.BackColor = SystemColors.Control;
            button14.BackColor = SystemColors.Control;
        }

        private void RedrawSelectedShape() // Se�ilen Cismi Tekrardan �izme (Highlight�n� kald�rmak i�in)
        {
            int i = 0;
            while (i < Shape.Shapes.Count)
            {
                if (Shape.DrawnShapeSize[i] == _highlightedShapeSize)
                {
                    Brush brush = new SolidBrush(Shape.Shapes[i].color);
                    if(_shapeIndex == 0 && byButton)
                    {
                        Shape.Shapes[i] = new Square(_highlightedShapeLocation, _highlightedShapeLocation, Shape.Shapes[i].color, _colorIndex);
                    }
                    else if(_shapeIndex == 1 && byButton)
                    {
                        Shape.Shapes[i] = new Circle(_highlightedShapeLocation, _highlightedShapeLocation, Shape.Shapes[i].color, _colorIndex);
                    }
                    else if(_shapeIndex == 2 && byButton)
                    {
                        Shape.Shapes[i] = new Triangle(_highlightedShapeLocation, _highlightedShapeLocation, Shape.Shapes[i].color, _colorIndex);
                    }
                    else if(_shapeIndex == 3 && byButton)
                    {
                        Shape.Shapes[i] = new Hexagon(_highlightedShapeLocation, _highlightedShapeLocation, Shape.Shapes[i].color, _colorIndex);
                    }
                    Shape.Shapes[i].Draw(g, brush, _highlightedShapeLocation.X, _highlightedShapeLocation.Y, _highlightedShapeSize.X, _highlightedShapeSize.Y);
                    isSelectedShape = false;
                }
                i++;
            }
        }

        private void DyeSelectedShape(Color color) // Se�ilen Cismi Boyama
        {
            int i = 0;
            while (i < Shape.Shapes.Count)
            {
                if (Shape.DrawnShapeSize[i] == _highlightedShapeSize)
                {
                    Shape.Shapes[i].color = color;
                    Shape.Shapes[i].colorIndex = _colorIndex;
                    Brush brush = new SolidBrush(color);
                    Shape.Shapes[i].Draw(g, brush, _highlightedShapeLocation.X, _highlightedShapeLocation.Y, _highlightedShapeSize.X, _highlightedShapeSize.Y);
                    isSelectedShape = false;
                }
                i++;
            }
        }

        private void StartPainting(MouseEventArgs e) // �izim Yapmaya Ba�la
        {
            isPressing = true;
            _dyeConstraintCheck = e.Location;
            _dyeStartingPos = e.Location;
            _dyeMinPos.X = e.Location.X;
            _dyeMinPos.Y = e.Location.Y;
        }

        private void ChooseObject(MouseEventArgs e) //Yeni �ekil Se�
        {
            int i;
            if (isSelectedShape == true)
            {
                byButton = false;
                RedrawSelectedShape();
            }
            if (0 < Shape.Shapes.Count)
            {
                i = 0;
                while (i < Shape.Shapes.Count)
                {
                    if (Shape.DrawnShapeLocation[i].X < e.Location.X && Shape.DrawnShapeLocation[i].Y < e.Location.Y
                    && Shape.DrawnShapeLocation[i].X + Shape.DrawnShapeSize[i].X > e.Location.X
                    && Shape.DrawnShapeLocation[i].Y + Shape.DrawnShapeSize[i].Y > e.Location.Y)
                    {
                        _highlightedShapeSize = Shape.DrawnShapeSize[i];
                        _highlightedShapeLocation = Shape.DrawnShapeLocation[i];

                        _highlightedShapeTypeIndex = Shape.Shapes[i].shapeIndex;
                        _highlightedArrayLocationIndex = i;

                        _highlightedColorIndex = Shape.Shapes[i].colorIndex;
                        _highlightedColor = Shape.Shapes[i].color;

                        isSelectedShape = true;
                        ButtonColorChanges();

                        //�ekil Se�ilme Boyamas�
                        Color semiTransparentColor = Color.FromArgb(32, Color.Black);
                        Brush semiTransparentBrush = new SolidBrush(semiTransparentColor);

                        Rectangle rectangle = new Rectangle(_highlightedShapeLocation.X, _highlightedShapeLocation.Y, _highlightedShapeSize.X, _highlightedShapeSize.Y);
                        g.FillRectangle(semiTransparentBrush, rectangle);

                        return;
                    }
                    i++;
                }
            }
        }

        private void RemoveWhileCarryingObject(MouseEventArgs e) //Objeyi ta��maya ba�lad���nda eski halini sil.
        {
            if (Shape.DrawnShapeLocation[_highlightedArrayLocationIndex].X < e.Location.X && Shape.DrawnShapeLocation[_highlightedArrayLocationIndex].Y < e.Location.Y
                    && Shape.DrawnShapeLocation[_highlightedArrayLocationIndex].X + Shape.DrawnShapeSize[_highlightedArrayLocationIndex].X > e.Location.X
                    && Shape.DrawnShapeLocation[_highlightedArrayLocationIndex].Y + Shape.DrawnShapeSize[_highlightedArrayLocationIndex].Y > e.Location.Y)
            {// Do�ru �ekile sol t�k at�l�rsa

                _highlightedShapeSize = Shape.DrawnShapeSize[_highlightedArrayLocationIndex];
                _highlightedShapeLocation = Shape.DrawnShapeLocation[_highlightedArrayLocationIndex];
                Shape.DrawnShapeSize.Remove(_highlightedShapeSize); // boyut
                Shape.DrawnShapeLocation.Remove(_highlightedShapeLocation); //sol �st k��e
                Shape.Shapes.Remove(Shape.Shapes[_highlightedArrayLocationIndex]);
                isPressing = true;
                return;
            }
            else
            {
                ChooseObject(e);
            }
        }

        private void StartDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isSelectingShape) // �ekil �izerken sol t�k
            {
                StartPainting(e); // �izime ba�lama sol t�k�
            }
            else if (!isSelectedShape) // �ekil Se�memi�ken sol t�k e1
            {
                ChooseObject(e); // Yeni Obje Se�
            }
            else if (isSelectedShape) // �ekil Se�mi�ken herhangi sol t�k ve ta��ma ba�lama
            {
                RemoveWhileCarryingObject(e); // OR Choose NEW
            }
        }

        private void StopDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            Brush brushWhite = new SolidBrush(Color.White);
            _dyeMaxPos = _dyeConstraintCheck;

            if (!isSelectingShape)// �izimi Tamamlama
            {
                isPressing = false;
                if (_shapeIndex == 0) // Kare �iz
                {
                    Point shapeSize = new Point(_dyeMaxPos.X - _dyeMinPos.X, _dyeMaxPos.Y - _dyeMinPos.Y); // d�zg�n
                    Shape.DrawnShapeSize.Add(shapeSize);

                    //Shape.DrawnShapeLocation.Add(new Point(_temptriggerStartPos.X, _temptriggerStartPos.Y));
                    Point shapeLocation = new Point(_dyeMinPos.X, _dyeMinPos.Y);
                    Shape.DrawnShapeLocation.Add(shapeLocation);


                    Square square = new Square(shapeSize, shapeLocation, _pen.Color, _colorIndex);
                    Shape.Shapes.Add(square);
                }
                else if (_shapeIndex == 1) // Daire �iz
                {
                    Point shapeSize = new Point(_dyeMaxPos.X - _dyeMinPos.X, _dyeMaxPos.Y - _dyeMinPos.Y); // d�zg�n
                    Shape.DrawnShapeSize.Add(shapeSize);

                    Point shapeLocation = new Point(_dyeMinPos.X, _dyeMinPos.Y);
                    Shape.DrawnShapeLocation.Add(shapeLocation);


                    Circle circle = new Circle(shapeSize, shapeLocation, _pen.Color, _colorIndex);
                    Shape.Shapes.Add(circle);

                }
                else if (_shapeIndex == 2) // ��gen �iz
                {
                    Point shapeSize = new Point(_dyeMaxPos.X - _dyeMinPos.X, _dyeMaxPos.Y - _dyeMinPos.Y); // d�zg�n
                    Shape.DrawnShapeSize.Add(shapeSize);

                    Point shapeLocation = new Point(_dyeMinPos.X, _dyeMinPos.Y);
                    Shape.DrawnShapeLocation.Add(shapeLocation);


                    Triangle triangle = new Triangle(shapeSize, shapeLocation, _pen.Color, _colorIndex);
                    Shape.Shapes.Add(triangle);
                }
                else if (_shapeIndex == 3) // Alt�gen �iz
                {
                    Point shapeSize = new Point(_dyeMaxPos.X - _dyeMinPos.X, _dyeMaxPos.Y - _dyeMinPos.Y); // d�zg�n
                    Shape.DrawnShapeSize.Add(shapeSize);

                    Point shapeLocation = new Point(_dyeMinPos.X, _dyeMinPos.Y);
                    Shape.DrawnShapeLocation.Add(shapeLocation);


                    Hexagon hexagon = new Hexagon(shapeSize, shapeLocation, _pen.Color, _colorIndex);
                    Shape.Shapes.Add(hexagon);
                }
            }
            else if (isSelectedShape & isPressing) //Cismi Ta��ma
            {
                isPressing = false;
                isSelectedShape = false;
                g.FillRectangle(brushWhite, _highlightedShapeLocation.X - 1, _highlightedShapeLocation.Y - 1, _highlightedShapeSize.X + 2, _highlightedShapeSize.Y + 2);
                Point safeMousePos = e.Location;
                if (pictureBox1.Width <= e.Location.X + _highlightedShapeSize.X / 2)//Do�udan Cisim Ta��yorsa
                {
                    safeMousePos.X = pictureBox1.Width - _highlightedShapeSize.X / 2;
                }
                else if (0 >= e.Location.X - _highlightedShapeSize.X / 2)//Bat�dan Cisim Ta��yorsa
                {
                    safeMousePos.X = _highlightedShapeSize.X / 2;
                }
                if (pictureBox1.Height <= e.Location.Y + _highlightedShapeSize.Y / 2)//G�neyden Cisim Ta��yorsa
                {
                    safeMousePos.Y = pictureBox1.Height - _highlightedShapeSize.Y / 2;
                }
                else if (0 >= e.Location.Y - _highlightedShapeSize.Y / 2)//Kuzeyden Cisim Ta��yorsa
                {
                    safeMousePos.Y = _highlightedShapeSize.Y / 2;
                }
                if (_highlightedShapeTypeIndex == 0) // Se�ili Cisim T�r� Kareyse
                {
                    Shape.DrawnShapeSize.Add(_highlightedShapeSize);

                    Point shapeLocation = new Point(safeMousePos.X - _highlightedShapeSize.X / 2, safeMousePos.Y - _highlightedShapeSize.Y / 2);
                    Shape.DrawnShapeLocation.Add(shapeLocation);

                    Square square = new Square(_highlightedShapeSize, shapeLocation, _highlightedColor, _highlightedColorIndex);

                    Shape.Shapes.Add(square);
                    Brush brush = new SolidBrush(square.color);
                    square.Draw(g, brush, shapeLocation.X, shapeLocation.Y, _highlightedShapeSize.X, _highlightedShapeSize.Y);
                }
                else if (_highlightedShapeTypeIndex == 1) // Se�ili Cisim T�r� Daireyse
                {
                    Shape.DrawnShapeSize.Add(_highlightedShapeSize);

                    Point shapeLocation = new Point(safeMousePos.X - _highlightedShapeSize.X / 2, safeMousePos.Y - _highlightedShapeSize.Y / 2);
                    Shape.DrawnShapeLocation.Add(shapeLocation);

                    Circle circle = new Circle(_highlightedShapeSize, shapeLocation, _highlightedColor, _highlightedColorIndex);

                    Shape.Shapes.Add(circle);
                    Brush brush = new SolidBrush(circle.color);
                    circle.Draw(g, brush, shapeLocation.X, shapeLocation.Y, _highlightedShapeSize.X, _highlightedShapeSize.Y);
                }
                else if (_highlightedShapeTypeIndex == 2) // Se�ili Cisim T�r� ��gense
                {
                    Shape.DrawnShapeSize.Add(_highlightedShapeSize);

                    Point shapeLocation = new Point(safeMousePos.X - _highlightedShapeSize.X / 2, safeMousePos.Y - _highlightedShapeSize.Y / 2);
                    Shape.DrawnShapeLocation.Add(shapeLocation);
                    Triangle triangle = new Triangle(_highlightedShapeSize, shapeLocation, _highlightedColor, _highlightedColorIndex);

                    Shape.Shapes.Add(triangle);
                    Brush brush = new SolidBrush(triangle.color);
                    triangle.Draw(g, brush, shapeLocation.X, shapeLocation.Y, _highlightedShapeSize.X, _highlightedShapeSize.Y);
                }
                else if (_highlightedShapeTypeIndex == 3) // Se�ili Cisim T�r� Alt�gense
                {
                    Shape.DrawnShapeSize.Add(_highlightedShapeSize);

                    Point shapeLocation = new Point(safeMousePos.X - _highlightedShapeSize.X / 2, safeMousePos.Y - _highlightedShapeSize.Y / 2);
                    Shape.DrawnShapeLocation.Add(shapeLocation);

                    Hexagon hexagon = new Hexagon(_highlightedShapeSize, shapeLocation, _highlightedColor, _highlightedColorIndex);

                    Shape.Shapes.Add(hexagon);
                    Brush brush = new SolidBrush(hexagon.color);
                    hexagon.Draw(g, brush, shapeLocation.X, shapeLocation.Y, _highlightedShapeSize.X, _highlightedShapeSize.Y);
                }

            }
        }

        private void KeepDrawing_MouseMove(object sender, MouseEventArgs e) //�izim yap�l�rken boyama.
        {
            Brush brush = new SolidBrush(_pen.Color);
            Brush WhiteBrush = new SolidBrush(Color.White);
            if (!isSelectingShape && isPressing && _dyeConstraintCheck.X < e.Location.X && _dyeConstraintCheck.Y < e.Location.Y
            && pictureBox1.Width > e.Location.X && pictureBox1.Height > e.Location.Y)
            {
                Point shapeSize = new Point(e.Location.X - _dyeStartingPos.X, e.Location.Y - _dyeStartingPos.Y);
                Point shapeLocation = _dyeStartingPos;
                _dyeConstraintCheck = e.Location;
                if (_shapeIndex == 0) //Kare �izimi
                {
                    g.FillRectangle(brush, shapeLocation.X, shapeLocation.Y, shapeSize.X, shapeSize.Y);
                }
                else if (_shapeIndex == 1) //Daire �izimi
                {

                    g.FillRectangle(WhiteBrush, shapeLocation.X - 1, shapeLocation.Y - 1, shapeSize.X + 2, shapeSize.Y + 2);
                    g.FillEllipse(brush, shapeLocation.X, shapeLocation.Y, shapeSize.X, shapeSize.Y);
                }
                else if (_shapeIndex == 2) //��gen �izimi
                {
                    Point[] points = new Point[3];
                    points[0] = new Point(shapeLocation.X + shapeSize.X / 2, shapeLocation.Y); // en �st orta k��e
                    points[1] = new Point(shapeLocation.X, shapeLocation.Y + shapeSize.Y); // en sol alt k��e
                    points[2] = new Point(shapeSize.X + shapeLocation.X, shapeSize.Y + shapeLocation.Y); // en sa� alt k��e
                    g.FillRectangle(WhiteBrush, shapeLocation.X - 1, shapeLocation.Y - 1, shapeSize.X + 2, shapeSize.Y + 2);
                    g.FillPolygon(brush, points);
                }
                else if (_shapeIndex == 3) //Alt�gen �izimi
                {
                    Point[] points = new Point[6];
                    points[0] = new Point(shapeLocation.X + shapeSize.X / 2, shapeLocation.Y); //en �st orta k��e
                    points[1] = new Point(shapeLocation.X + shapeSize.X, shapeLocation.Y + shapeSize.Y / 3); // �st sa� k��e
                    points[2] = new Point(shapeLocation.X + shapeSize.X, shapeLocation.Y + 2 * shapeSize.Y / 3); // alt sa� k��e
                    points[3] = new Point(shapeLocation.X + shapeSize.X / 2, shapeLocation.Y + shapeSize.Y); // en alt orta k��e 
                    points[4] = new Point(shapeLocation.X, shapeLocation.Y + 2 * shapeSize.Y / 3); // alt sol k��e
                    points[5] = new Point(shapeLocation.X, shapeLocation.Y + shapeSize.Y / 3); // �st sol k��e
                    g.FillRectangle(WhiteBrush, shapeLocation.X - 1, shapeLocation.Y - 1, shapeSize.X + 2, shapeSize.Y + 2);
                    g.FillPolygon(brush, points);
                }
            }
        }
    }
}