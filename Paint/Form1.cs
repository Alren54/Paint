using Microsoft.VisualBasic.Devices;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        private int _shapeIndex; //Þekil  Türü Göstergeci
        private int _colorIndex; //Renk Göstergeci
        private Pen _pen;
        private Graphics g;
        
        private bool isPressing; //Mouse Basýlý Tutuluyor
        private bool isSelectingShape; //Þekil Seçilebilir
        private bool isSelectedShape; //Þekil Seçili
        private bool byButton; // Þekil Deðiþtirilme Talebinin Butona basýlarak olmasýný saðlar.

        private Point _highlightedShapeSize; // Seçilen Þeklin Boyutu
        private Point _highlightedShapeLocation; // Seçilen Þeklin Yeri
        private int _highlightedShapeTypeIndex; //Seçilen Þeklin Þekil Türü
        private int _highlightedArrayLocationIndex; // Seçilen Þeklin Listedeki Yeri
        private int _highlightedColorIndex; // Seçilen Þeklin Renginin indisi
        private Color _highlightedColor; // Seçilen Þekling Rengi

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

        private void ResetButtonColors() // Butonlarýn arkaplan renklerini default hale getir.
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

        private void ButtonColorChanges() // Butonlarýn Renklerini Deðiþtir.
        {
            if (isSelectingShape == false) // Þekil Seçmiyorken
            {
                ResetButtonColors();
                _buttonShapes[_shapeIndex].BackColor = Color.Gray;
                _buttonColors[_colorIndex].BackColor = Color.Gray;
            }
            else if (isSelectedShape) // Þekil Seçiyorken ve Þekil Seçmiþken
            {
                ResetButtonColors();
                _buttonShapes[_highlightedShapeTypeIndex].BackColor = Color.Gray;
                _buttonColors[_highlightedColorIndex].BackColor = Color.Gray;
            }
            else ResetButtonColors(); // Þekil Seçiyorken ve Þekil Seçmemiþken
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

        private void button14_Click(object sender, EventArgs e) // Þekil Seçme
        {
            isSelectingShape = true;
            isSelectedShape = false;
            _highlightedShapeTypeIndex = -1;
        }

        private void button15_Click(object sender, EventArgs e) //Seçilen Cismi Silme
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

        private void button16_Click(object sender, EventArgs e) // Yeni Sayfa Açma
        {
            NewPage();
        }

        private void button17_Click(object sender, EventArgs e) // Dosyadan Yükleme
        {
            int i = 0;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Metin Dosyalarý (*.txt)|*.txt";
            openFileDialog.Title = "Yükle";
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
            saveFileDialog.Filter = "Metin Dosyalarý (*.txt)|*.txt";
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

        private void NewPage() // Yeni Sayfa Açma ve Ayarlarý Fabrika Ayarlarýna Döndürme
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

        private void RedrawSelectedShape() // Seçilen Cismi Tekrardan Çizme (Highlightýný kaldýrmak için)
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

        private void DyeSelectedShape(Color color) // Seçilen Cismi Boyama
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

        private void StartPainting(MouseEventArgs e) // Çizim Yapmaya Baþla
        {
            isPressing = true;
            _dyeConstraintCheck = e.Location;
            _dyeStartingPos = e.Location;
            _dyeMinPos.X = e.Location.X;
            _dyeMinPos.Y = e.Location.Y;
        }

        private void ChooseObject(MouseEventArgs e) //Yeni Þekil Seç
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

                        //Þekil Seçilme Boyamasý
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

        private void RemoveWhileCarryingObject(MouseEventArgs e) //Objeyi taþýmaya baþladýðýnda eski halini sil.
        {
            if (Shape.DrawnShapeLocation[_highlightedArrayLocationIndex].X < e.Location.X && Shape.DrawnShapeLocation[_highlightedArrayLocationIndex].Y < e.Location.Y
                    && Shape.DrawnShapeLocation[_highlightedArrayLocationIndex].X + Shape.DrawnShapeSize[_highlightedArrayLocationIndex].X > e.Location.X
                    && Shape.DrawnShapeLocation[_highlightedArrayLocationIndex].Y + Shape.DrawnShapeSize[_highlightedArrayLocationIndex].Y > e.Location.Y)
            {// Doðru þekile sol týk atýlýrsa

                _highlightedShapeSize = Shape.DrawnShapeSize[_highlightedArrayLocationIndex];
                _highlightedShapeLocation = Shape.DrawnShapeLocation[_highlightedArrayLocationIndex];
                Shape.DrawnShapeSize.Remove(_highlightedShapeSize); // boyut
                Shape.DrawnShapeLocation.Remove(_highlightedShapeLocation); //sol üst köþe
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
            if (!isSelectingShape) // Þekil çizerken sol týk
            {
                StartPainting(e); // Çizime baþlama sol týký
            }
            else if (!isSelectedShape) // Þekil Seçmemiþken sol týk e1
            {
                ChooseObject(e); // Yeni Obje Seç
            }
            else if (isSelectedShape) // Þekil Seçmiþken herhangi sol týk ve taþýma baþlama
            {
                RemoveWhileCarryingObject(e); // OR Choose NEW
            }
        }

        private void StopDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            Brush brushWhite = new SolidBrush(Color.White);
            _dyeMaxPos = _dyeConstraintCheck;

            if (!isSelectingShape)// Çizimi Tamamlama
            {
                isPressing = false;
                if (_shapeIndex == 0) // Kare Çiz
                {
                    Point shapeSize = new Point(_dyeMaxPos.X - _dyeMinPos.X, _dyeMaxPos.Y - _dyeMinPos.Y); // düzgün
                    Shape.DrawnShapeSize.Add(shapeSize);

                    //Shape.DrawnShapeLocation.Add(new Point(_temptriggerStartPos.X, _temptriggerStartPos.Y));
                    Point shapeLocation = new Point(_dyeMinPos.X, _dyeMinPos.Y);
                    Shape.DrawnShapeLocation.Add(shapeLocation);


                    Square square = new Square(shapeSize, shapeLocation, _pen.Color, _colorIndex);
                    Shape.Shapes.Add(square);
                }
                else if (_shapeIndex == 1) // Daire Çiz
                {
                    Point shapeSize = new Point(_dyeMaxPos.X - _dyeMinPos.X, _dyeMaxPos.Y - _dyeMinPos.Y); // düzgün
                    Shape.DrawnShapeSize.Add(shapeSize);

                    Point shapeLocation = new Point(_dyeMinPos.X, _dyeMinPos.Y);
                    Shape.DrawnShapeLocation.Add(shapeLocation);


                    Circle circle = new Circle(shapeSize, shapeLocation, _pen.Color, _colorIndex);
                    Shape.Shapes.Add(circle);

                }
                else if (_shapeIndex == 2) // Üçgen Çiz
                {
                    Point shapeSize = new Point(_dyeMaxPos.X - _dyeMinPos.X, _dyeMaxPos.Y - _dyeMinPos.Y); // düzgün
                    Shape.DrawnShapeSize.Add(shapeSize);

                    Point shapeLocation = new Point(_dyeMinPos.X, _dyeMinPos.Y);
                    Shape.DrawnShapeLocation.Add(shapeLocation);


                    Triangle triangle = new Triangle(shapeSize, shapeLocation, _pen.Color, _colorIndex);
                    Shape.Shapes.Add(triangle);
                }
                else if (_shapeIndex == 3) // Altýgen Çiz
                {
                    Point shapeSize = new Point(_dyeMaxPos.X - _dyeMinPos.X, _dyeMaxPos.Y - _dyeMinPos.Y); // düzgün
                    Shape.DrawnShapeSize.Add(shapeSize);

                    Point shapeLocation = new Point(_dyeMinPos.X, _dyeMinPos.Y);
                    Shape.DrawnShapeLocation.Add(shapeLocation);


                    Hexagon hexagon = new Hexagon(shapeSize, shapeLocation, _pen.Color, _colorIndex);
                    Shape.Shapes.Add(hexagon);
                }
            }
            else if (isSelectedShape & isPressing) //Cismi Taþýma
            {
                isPressing = false;
                isSelectedShape = false;
                g.FillRectangle(brushWhite, _highlightedShapeLocation.X - 1, _highlightedShapeLocation.Y - 1, _highlightedShapeSize.X + 2, _highlightedShapeSize.Y + 2);
                Point safeMousePos = e.Location;
                if (pictureBox1.Width <= e.Location.X + _highlightedShapeSize.X / 2)//Doðudan Cisim Taþýyorsa
                {
                    safeMousePos.X = pictureBox1.Width - _highlightedShapeSize.X / 2;
                }
                else if (0 >= e.Location.X - _highlightedShapeSize.X / 2)//Batýdan Cisim Taþýyorsa
                {
                    safeMousePos.X = _highlightedShapeSize.X / 2;
                }
                if (pictureBox1.Height <= e.Location.Y + _highlightedShapeSize.Y / 2)//Güneyden Cisim Taþýyorsa
                {
                    safeMousePos.Y = pictureBox1.Height - _highlightedShapeSize.Y / 2;
                }
                else if (0 >= e.Location.Y - _highlightedShapeSize.Y / 2)//Kuzeyden Cisim Taþýyorsa
                {
                    safeMousePos.Y = _highlightedShapeSize.Y / 2;
                }
                if (_highlightedShapeTypeIndex == 0) // Seçili Cisim Türü Kareyse
                {
                    Shape.DrawnShapeSize.Add(_highlightedShapeSize);

                    Point shapeLocation = new Point(safeMousePos.X - _highlightedShapeSize.X / 2, safeMousePos.Y - _highlightedShapeSize.Y / 2);
                    Shape.DrawnShapeLocation.Add(shapeLocation);

                    Square square = new Square(_highlightedShapeSize, shapeLocation, _highlightedColor, _highlightedColorIndex);

                    Shape.Shapes.Add(square);
                    Brush brush = new SolidBrush(square.color);
                    square.Draw(g, brush, shapeLocation.X, shapeLocation.Y, _highlightedShapeSize.X, _highlightedShapeSize.Y);
                }
                else if (_highlightedShapeTypeIndex == 1) // Seçili Cisim Türü Daireyse
                {
                    Shape.DrawnShapeSize.Add(_highlightedShapeSize);

                    Point shapeLocation = new Point(safeMousePos.X - _highlightedShapeSize.X / 2, safeMousePos.Y - _highlightedShapeSize.Y / 2);
                    Shape.DrawnShapeLocation.Add(shapeLocation);

                    Circle circle = new Circle(_highlightedShapeSize, shapeLocation, _highlightedColor, _highlightedColorIndex);

                    Shape.Shapes.Add(circle);
                    Brush brush = new SolidBrush(circle.color);
                    circle.Draw(g, brush, shapeLocation.X, shapeLocation.Y, _highlightedShapeSize.X, _highlightedShapeSize.Y);
                }
                else if (_highlightedShapeTypeIndex == 2) // Seçili Cisim Türü Üçgense
                {
                    Shape.DrawnShapeSize.Add(_highlightedShapeSize);

                    Point shapeLocation = new Point(safeMousePos.X - _highlightedShapeSize.X / 2, safeMousePos.Y - _highlightedShapeSize.Y / 2);
                    Shape.DrawnShapeLocation.Add(shapeLocation);
                    Triangle triangle = new Triangle(_highlightedShapeSize, shapeLocation, _highlightedColor, _highlightedColorIndex);

                    Shape.Shapes.Add(triangle);
                    Brush brush = new SolidBrush(triangle.color);
                    triangle.Draw(g, brush, shapeLocation.X, shapeLocation.Y, _highlightedShapeSize.X, _highlightedShapeSize.Y);
                }
                else if (_highlightedShapeTypeIndex == 3) // Seçili Cisim Türü Altýgense
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

        private void KeepDrawing_MouseMove(object sender, MouseEventArgs e) //Çizim yapýlýrken boyama.
        {
            Brush brush = new SolidBrush(_pen.Color);
            Brush WhiteBrush = new SolidBrush(Color.White);
            if (!isSelectingShape && isPressing && _dyeConstraintCheck.X < e.Location.X && _dyeConstraintCheck.Y < e.Location.Y
            && pictureBox1.Width > e.Location.X && pictureBox1.Height > e.Location.Y)
            {
                Point shapeSize = new Point(e.Location.X - _dyeStartingPos.X, e.Location.Y - _dyeStartingPos.Y);
                Point shapeLocation = _dyeStartingPos;
                _dyeConstraintCheck = e.Location;
                if (_shapeIndex == 0) //Kare Çizimi
                {
                    g.FillRectangle(brush, shapeLocation.X, shapeLocation.Y, shapeSize.X, shapeSize.Y);
                }
                else if (_shapeIndex == 1) //Daire Çizimi
                {

                    g.FillRectangle(WhiteBrush, shapeLocation.X - 1, shapeLocation.Y - 1, shapeSize.X + 2, shapeSize.Y + 2);
                    g.FillEllipse(brush, shapeLocation.X, shapeLocation.Y, shapeSize.X, shapeSize.Y);
                }
                else if (_shapeIndex == 2) //Üçgen Çizimi
                {
                    Point[] points = new Point[3];
                    points[0] = new Point(shapeLocation.X + shapeSize.X / 2, shapeLocation.Y); // en üst orta köþe
                    points[1] = new Point(shapeLocation.X, shapeLocation.Y + shapeSize.Y); // en sol alt köþe
                    points[2] = new Point(shapeSize.X + shapeLocation.X, shapeSize.Y + shapeLocation.Y); // en sað alt köþe
                    g.FillRectangle(WhiteBrush, shapeLocation.X - 1, shapeLocation.Y - 1, shapeSize.X + 2, shapeSize.Y + 2);
                    g.FillPolygon(brush, points);
                }
                else if (_shapeIndex == 3) //Altýgen Çizimi
                {
                    Point[] points = new Point[6];
                    points[0] = new Point(shapeLocation.X + shapeSize.X / 2, shapeLocation.Y); //en üst orta köþe
                    points[1] = new Point(shapeLocation.X + shapeSize.X, shapeLocation.Y + shapeSize.Y / 3); // üst sað köþe
                    points[2] = new Point(shapeLocation.X + shapeSize.X, shapeLocation.Y + 2 * shapeSize.Y / 3); // alt sað köþe
                    points[3] = new Point(shapeLocation.X + shapeSize.X / 2, shapeLocation.Y + shapeSize.Y); // en alt orta köþe 
                    points[4] = new Point(shapeLocation.X, shapeLocation.Y + 2 * shapeSize.Y / 3); // alt sol köþe
                    points[5] = new Point(shapeLocation.X, shapeLocation.Y + shapeSize.Y / 3); // üst sol köþe
                    g.FillRectangle(WhiteBrush, shapeLocation.X - 1, shapeLocation.Y - 1, shapeSize.X + 2, shapeSize.Y + 2);
                    g.FillPolygon(brush, points);
                }
            }
        }
    }
}