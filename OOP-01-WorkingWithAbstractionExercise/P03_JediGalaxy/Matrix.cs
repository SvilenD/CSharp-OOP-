namespace JediGalaxy
{
    public class Matrix
    {
        private int rows;
        private int cols;
        private int value;
        private int[,] matrix;

        public Matrix(int[] dimensions)
        {
            this.rows = dimensions[0];
            this.cols = dimensions[1];
            this.value = 0;
            this.matrix = new int[rows, cols];
        }

        public int[,] Create()
        {
            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.cols; col++)
                {
                    this.matrix[row, col] = this.value++;
                }
            }
            return this.matrix;
        }

        public int[,] GetMatrix()
        {
            return this.matrix;
        }
    }
}