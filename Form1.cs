namespace Solution
{
    public partial class Form1 : Form
    {
        private List<IShape> _shapes = new List<IShape>(); // Список фигур

        public Form1()
        {
            InitializeComponent();
        }

        private void Update(object? sender, EventArgs e)
        {
            foreach (var shape in _shapes)
            {
                shape.CheckBoundaryCollision(panel1.Width, panel1.Height); // Проверка столкновения с границами панели

                shape.Move(); // Перемещение фигуры

                foreach (var shape2 in _shapes)
                {
                    if (shape != shape2 && shape.IntersectsWith(shape2))
                    {
                        // Если фигуры сталкиваются, меняем их направление движения для отталкивания
                        double angle = Math.Atan2(shape.Center.Y - shape2.Center.Y, shape.Center.X - shape2.Center.X);
                        shape.SpeedX = (int)Math.Round(5 * Math.Cos(angle));
                        shape.SpeedY = (int)Math.Round(5 * Math.Sin(angle));
                    }
                }
            }
            panel1.Invalidate(); // Перерисовка панели для отображения новых положений фигур
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                foreach (var shape in _shapes)
                {
                    if (shape.ClickedOn(e.X, e.Y)) // Если нажали на фигуру
                    {
                        if (colorDialog1.ShowDialog() == DialogResult.OK) // Показываем диалог выбора цвета
                            shape.Color = colorDialog1.Color; // Изменяем цвет фигуры

                        panel1.Invalidate(); // Перерисовка панели для отображения изменений
                        return;
                    }
                }
            }

            if (e.Button == MouseButtons.Left)
            {
                if (circleRadioBtn.Checked) // Если выбран режим "Круг"
                {
                    Random random = new Random();
                    int radius = random.Next(18, 30);

                    if (e.X - radius <= 0 || e.X + radius >= panel1.Width
                        || e.Y - radius <= 0 || e.Y + radius >= panel1.Height)
                        return; // Проверка, чтобы круг не выходил за границы панели

                    int speedX = random.Next(-5, 5);
                    int speedY = random.Next(-5, 5);
                    Color color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

                    var circle = new Circle(new Point2D(e.X, e.Y), radius, speedX, speedY, color);

                    _shapes.Add(circle); // Добавляем круг в список фигур
                }

                if (rectRadioBtn.Checked) // Если выбран режим "Квадрат"
                {
                    Random random = new Random();
                    int side = random.Next(36, 60); // Предполагая, что сторона квадрата может быть в 2 раза больше радиуса круга

                    if (e.X - side / 2 <= 0 || e.X + side / 2 >= panel1.Width
                        || e.Y - side / 2 <= 0 || e.Y + side / 2 >= panel1.Height)
                        return; // Проверка, чтобы квадрат не выходил за границы панели

                    int speedX = random.Next(-5, 5);
                    int speedY = random.Next(-5, 5);
                    Color color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

                    var square = new Square(new Point2D(e.X, e.Y), side, speedX, speedY, color);

                    _shapes.Add(square); // Добавляем квадрат в список фигур
                }

                panel1.Invalidate(); // Перерисовка панели для отображения новых фигур
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in _shapes)
            {
                shape.DrawShape(e); // Отрисовка каждой фигуры
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop(); // Остановка таймера (анимации)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start(); // Запуск таймера (анимации)
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //_shapes.Clear(); // Очищаем список фигур при выборе опции "Круг"
            //panel1.Invalidate(); // Перерисовка панели
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //_shapes.Clear(); // Очищаем список фигур при выборе опции "Квадрат"
            //panel1.Invalidate(); // Перерисовка панели
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string instructions = "Добро пожаловать!\n\n" +
                                  "1. Чтобы добавить круг, выберите опцию 'Круг' и кликните левой кнопкой мыши на панель.\n" +
                                  "2. Чтобы добавить квадрат, выберите опцию 'Квадрат' и кликните левой кнопкой мыши на панели.\n" +
                                  "3. Чтобы изменить цвет круга или квадрата, кликните правой кнопкой мыши по фигуре и выберите новый цвет.\n" +
                                  "4. Чтобы запустить анимацию, нажмите на кнопку 'Начать анимацию'. Чтобы остановить анимацию, нажмите на кнопку 'Остановить анимацию'.\n" +
                                  "5. Чтобы изменить скорость анимации, используйте ползунок 'Скорость анимации'.\n" +
                                  "\n" +
                                  "Примечание:\n" +
                                  "- Квадрат не реализован, но программа написана таким образом, чтобы было легко добавлять новые фигуры.\n" +
                                  "- Одновременно на панели могут быть только объекты одного класса.";

            MessageBox.Show(instructions, "Инструкции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
