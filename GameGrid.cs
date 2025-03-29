namespace Tetris_Application__wpf_
{
    public class GameGrid
    {
        private readonly int[,] grid;
        public int Rows { get; }
        public int Columns { get; }
        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        public GameGrid(int rows, int columns)
        {
            Rows = rows; Columns = columns;
            grid = new int[rows, columns];
        }

        public bool IsInside(int r, int c) // Check if the given row or column is inside the grid.
        {
            return r >=0 && r < Rows && c >= 0 && c < Columns;  
        }

        public bool IsEmpty(int r, int c) // Check if the cell is empty or not.
        {
            return IsInside(r, c) && grid[r,c] == 0;
        }

        public bool IsRowFull(int r) // Check whether or not the row is full.
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] == 0) { return false; }
            }
            return true;
        }

        public bool IsRowEmpty(int r) // Checks if a given row is empty.
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0) { return false; }
            }
            return true;
        }

        private void ClearRow(int r)
        {
            for(int c = 0;c < Columns; c++)
            {
                grid[r,c] = 0;
            }
        }

        private void MoveRowDown(int r, int numRows)
        {
            //if (r + numRows >= Rows) return;

            for (int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r,c];
                grid[r,c] = 0;
            }
        }

        public int ClearFullRows()
        {
            int cleared = 0;

            for(int r = Rows - 1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                    //Console.WriteLine($"Cleared row {r}");
                }
                else if(cleared > 0)
                {
                    /*if (!IsRowEmpty(r))
                    {
                        MoveRowDown(r, cleared);
                    }*/
                    MoveRowDown(r, cleared);
                }
            }
            return cleared;
        }
    }
}
