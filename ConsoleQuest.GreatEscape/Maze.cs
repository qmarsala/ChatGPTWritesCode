namespace ConsoleQuest
{
    public class Maze
    {
        public int Width { get; }
        public int Height { get; }
        public bool[,] Grid { get; }
        public (int x, int y) Start { get; set; }
        public (int x, int y) End { get; set; }

        public Maze(int width, int height)
        {
            Width = width;
            Height = height;
            Grid = new bool[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Grid[i, j] = true;
                }
            }
        }

        public void SetWall(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return;
            }
            Grid[x, y] = true;
        }

        public bool IsWall(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return false;
            }
            return Grid[x, y];
        }

        public void RemoveWall(int row, int col)
        {
            Grid[row, col] = false;
        }

        public bool IsExit(int x, int y)
        {
            return (x == End.x && y == End.y);
        }
    }
}