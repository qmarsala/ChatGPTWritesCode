namespace ConsoleQuest
{
    public class Maze
    {
        public int Width { get; }
        public int Height { get; }
        private readonly bool[,] _grid;

        public Maze(int width, int height)
        {
            Width = width;
            Height = height;
            _grid = new bool[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    _grid[i, j] = true;
                }
            }
        }

        public bool GetCell(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return false;
            }
            return _grid[x, y];
        }

        public void RemoveWall(int row, int col)
        {
            _grid[row, col] = false;
        }
    }
}