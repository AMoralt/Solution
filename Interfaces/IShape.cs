namespace Solution
{
    public interface IShape
    {
        int SpeedX { get; set; }
        int SpeedY { get; set; }
        Color Color { get; set; }
        public Point2D Center { get; }
        //Движение фигуры
        void Move();
        //отрисовка фигуры
        void DrawShape(PaintEventArgs e);
        //Проверка на коллизию со стеной
        void CheckBoundaryCollision(int panelWidth, int panelHeight);
        //Проверка на коллизию с другими фигурами
        bool IntersectsWith(IShape shape);
        //Проверка кликнули ли на фигуру
        bool ClickedOn(int x, int y);
    }
}
