namespace Matrix;

public class Matrix2D
{
    public readonly int[,] matrix = new int[2, 2];

    public Matrix2D(int a, int b, int c, int d)
    {
        matrix[0, 0] = a;
        matrix[0, 1] = b;
        matrix[1, 0] = c;
        matrix[1, 1] = d;
    }

    public Matrix2D() : this(1, 0, 0, 1)
    {
    }

    public static readonly Matrix2D Id = new Matrix2D();
    public static readonly Matrix2D Zero = new Matrix2D(0, 0, 0, 0);

    public override string ToString()
    {
        return $"[[{matrix[0, 0]}, {matrix[0, 1]}], [{matrix[1, 0]}, {matrix[1, 1]}]]";
    }
}