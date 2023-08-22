namespace Solution
{
    public partial class Form1 : Form
    {
        private List<IShape> _shapes = new List<IShape>(); // ������ �����

        public Form1()
        {
            InitializeComponent();
        }

        private void Update(object? sender, EventArgs e)
        {
            foreach (var shape in _shapes)
            {
                shape.CheckBoundaryCollision(panel1.Width, panel1.Height); // �������� ������������ � ��������� ������

                shape.Move(); // ����������� ������

                foreach (var shape2 in _shapes)
                {
                    if (shape != shape2 && shape.IntersectsWith(shape2))
                    {
                        // ���� ������ ������������, ������ �� ����������� �������� ��� ������������
                        double angle = Math.Atan2(shape.Center.Y - shape2.Center.Y, shape.Center.X - shape2.Center.X);
                        shape.SpeedX = (int)Math.Round(5 * Math.Cos(angle));
                        shape.SpeedY = (int)Math.Round(5 * Math.Sin(angle));
                    }
                }
            }
            panel1.Invalidate(); // ����������� ������ ��� ����������� ����� ��������� �����
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                foreach (var shape in _shapes)
                {
                    if (shape.ClickedOn(e.X, e.Y)) // ���� ������ �� ������
                    {
                        if (colorDialog1.ShowDialog() == DialogResult.OK) // ���������� ������ ������ �����
                            shape.Color = colorDialog1.Color; // �������� ���� ������

                        panel1.Invalidate(); // ����������� ������ ��� ����������� ���������
                        return;
                    }
                }
            }

            if (e.Button == MouseButtons.Left)
            {
                if (circleRadioBtn.Checked) // ���� ������ ����� "����"
                {
                    Random random = new Random();
                    int radius = random.Next(18, 30);

                    if (e.X - radius <= 0 || e.X + radius >= panel1.Width
                        || e.Y - radius <= 0 || e.Y + radius >= panel1.Height)
                        return; // ��������, ����� ���� �� ������� �� ������� ������

                    int speedX = random.Next(-5, 5);
                    int speedY = random.Next(-5, 5);
                    Color color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

                    var circle = new Circle(new Point2D(e.X, e.Y), radius, speedX, speedY, color);

                    _shapes.Add(circle); // ��������� ���� � ������ �����
                }

                if (rectRadioBtn.Checked) // ���� ������ ����� "�������"
                {
                    Random random = new Random();
                    int side = random.Next(36, 60); // �����������, ��� ������� �������� ����� ���� � 2 ���� ������ ������� �����

                    if (e.X - side / 2 <= 0 || e.X + side / 2 >= panel1.Width
                        || e.Y - side / 2 <= 0 || e.Y + side / 2 >= panel1.Height)
                        return; // ��������, ����� ������� �� ������� �� ������� ������

                    int speedX = random.Next(-5, 5);
                    int speedY = random.Next(-5, 5);
                    Color color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

                    var square = new Square(new Point2D(e.X, e.Y), side, speedX, speedY, color);

                    _shapes.Add(square); // ��������� ������� � ������ �����
                }

                panel1.Invalidate(); // ����������� ������ ��� ����������� ����� �����
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in _shapes)
            {
                shape.DrawShape(e); // ��������� ������ ������
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop(); // ��������� ������� (��������)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start(); // ������ ������� (��������)
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //_shapes.Clear(); // ������� ������ ����� ��� ������ ����� "����"
            //panel1.Invalidate(); // ����������� ������
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //_shapes.Clear(); // ������� ������ ����� ��� ������ ����� "�������"
            //panel1.Invalidate(); // ����������� ������
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string instructions = "����� ����������!\n\n" +
                                  "1. ����� �������� ����, �������� ����� '����' � �������� ����� ������� ���� �� ������.\n" +
                                  "2. ����� �������� �������, �������� ����� '�������' � �������� ����� ������� ���� �� ������.\n" +
                                  "3. ����� �������� ���� ����� ��� ��������, �������� ������ ������� ���� �� ������ � �������� ����� ����.\n" +
                                  "4. ����� ��������� ��������, ������� �� ������ '������ ��������'. ����� ���������� ��������, ������� �� ������ '���������� ��������'.\n" +
                                  "5. ����� �������� �������� ��������, ����������� �������� '�������� ��������'.\n" +
                                  "\n" +
                                  "����������:\n" +
                                  "- ������� �� ����������, �� ��������� �������� ����� �������, ����� ���� ����� ��������� ����� ������.\n" +
                                  "- ������������ �� ������ ����� ���� ������ ������� ������ ������.";

            MessageBox.Show(instructions, "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
