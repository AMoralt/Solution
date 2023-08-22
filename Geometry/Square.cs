namespace Solution
{
    public class Square : IShape
    {
        public Square(Point2D center, int side, int speedX, int speedY, Color color)
        {
            Center = center;
            Side = side;
            SpeedX = speedX;
            SpeedY = speedY;
            Color = color;
            HalfSide = side/2;
        }
        public Point2D Center { get; }
        public int Side { get; }
        public int HalfSide { get; init; }
        public int SpeedX { get; set; }
        public int SpeedY { get; set; }
        public Color Color { get; set; }

        //Движение 
        public void Move()
        {
            Center.X += SpeedX;
            Center.Y += SpeedY;
        }

        //отрисовка 
        public void DrawShape(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color), 
                Center.X - HalfSide, Center.Y - HalfSide, Side, Side);
        }
        //Проверка на коллизию со стеной
        public void CheckBoundaryCollision(int panelWidth, int panelHeight)
        {
            if (Center.X - HalfSide <= 0 ||  Center.X + HalfSide >= panelWidth)
            {
                 SpeedX *= -1;
            }

            if ( Center.Y - HalfSide <= 0 ||  Center.Y + HalfSide >= panelHeight)
            {
                 SpeedY *= -1;
            }
        }

        //Проверка на коллизию с другими фигурами
        bool IShape.IntersectsWith(IShape shape)
        {
            if (shape is Circle circle)
            {
                var x = Math.Max(Center.X - HalfSide, Math.Min(circle.Center.X, Center.X + HalfSide));
                var y = Math.Max(Center.Y - HalfSide, Math.Min(circle.Center.Y, Center.Y + HalfSide));

                var distanceSquare = Math.Sqrt(Math.Pow((x - circle.Center.X), 2) + Math.Pow((y - circle.Center.Y), 2));

                return distanceSquare <= circle.Radius;
            }
            if (shape is Square square)
            {
                return
                   Math.Abs(Center.X - square.Center.X) <= HalfSide + square.HalfSide
                   && Math.Abs(Center.Y - square.Center.Y) <= HalfSide + square.HalfSide;
            }
            return false;
        }

        // Проверка кликнули ли на квадрат
        bool IShape.ClickedOn(int x, int y)
        {
            return x >= Center.X - Side / 2 && x <= Center.X + Side / 2 &&
                   y >= Center.Y - Side / 2 && y <= Center.Y + Side / 2;
        }
    }
}
