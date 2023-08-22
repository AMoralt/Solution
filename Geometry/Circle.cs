namespace Solution
{
    public class Circle : IShape
    {
        public Circle(Point2D center, int radius, int speedX, int speedY, Color color)
        {
            Center = center;
            Radius = radius;
            SpeedX = speedX;
            SpeedY = speedY;
            Color = color;
        }
        public Point2D Center { get; }
        public int Radius { get; }
        public int SpeedX { get; set; }
        public int SpeedY { get; set; }
        public Color Color { get; set; }

        //Движение круга
        public void Move()
        {
            Center.X += SpeedX;
            Center.Y += SpeedY;
        }

        //отрисовка круга
        public void DrawShape(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(new SolidBrush(Color), 
                Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
        }
        //Проверка на коллизию со стеной
        public void CheckBoundaryCollision(int panelWidth, int panelHeight)
        {
            if (Center.X -  Radius <= 0 ||  Center.X +  Radius >= panelWidth)
            {
                 SpeedX *= -1;
            }

            if ( Center.Y -  Radius <= 0 ||  Center.Y +  Radius >= panelHeight)
            {
                 SpeedY *= -1;
            }
        }

        //Проверка на коллизию с другими кругами
        bool IShape.IntersectsWith(IShape shape)
        {
            if (shape is Circle circle)
            {
                double distance = Math.Sqrt(Math.Pow(Center.X - circle.Center.X, 2) +
                                        Math.Pow(Center.Y - circle.Center.Y, 2));

                return distance <= (Radius + circle.Radius);
            }
            if (shape is Square square)
            {
                var x = Math.Max(square.Center.X - square.HalfSide, Math.Min(Center.X, square.Center.X + square.HalfSide));
                var y = Math.Max(square.Center.Y - square.HalfSide, Math.Min(Center.Y, square.Center.Y + square.HalfSide));

                var distanceSquare = Math.Sqrt( Math.Pow((x - Center.X),2) +   Math.Pow((y - Center.Y),2));

                return distanceSquare <= Radius;
            }
            return false;
        }

        //Проверка кликнули ли на круг
        bool IShape.ClickedOn(int x, int y)
        {
            int temp = (Center.X - x) * (Center.X - x)
                            + (Center.Y - y) * (Center.Y - y);

            return temp <=  Radius * Radius;
        }
    }
}
