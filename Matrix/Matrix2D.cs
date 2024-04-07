namespace Matrix;

public class Matrix2D : IEquatable<Matrix2D>
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

    public bool Equals(Matrix2D other)
    {
        if (other == null)
            return false;

        return matrix[0, 0] == other.matrix[0, 0] && matrix[0, 1] == other.matrix[0, 1] &&
               matrix[1, 0] == other.matrix[1, 0] && matrix[1, 1] == other.matrix[1, 1];
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Matrix2D);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(matrix[0, 0], matrix[0, 1], matrix[1, 0], matrix[1, 0]);
    }

    public static bool operator ==(Matrix2D a, Matrix2D b)
    {
        if (ReferenceEquals(a, b))
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Equals(b);
    }

    public static bool operator !=(Matrix2D a, Matrix2D b)
    {
        return !(a == b);
    }

    public static Matrix2D operator +(Matrix2D a, Matrix2D b)
    {
        return new Matrix2D(
            a.matrix[0, 0] + b.matrix[0, 0],
            a.matrix[0, 1] + b.matrix[0, 1],
            a.matrix[1, 0] + b.matrix[1, 0],
            a.matrix[1, 1] + b.matrix[1, 1]);
    }

    public static Matrix2D operator -(Matrix2D a, Matrix2D b)
    {
        return new Matrix2D(
            a.matrix[0, 0] - b.matrix[0, 0],
            a.matrix[0, 1] - b.matrix[0, 1],
            a.matrix[1, 0] - b.matrix[1, 0],
            a.matrix[1, 1] - b.matrix[1, 1]);
    }

    public static Matrix2D operator *(Matrix2D a, Matrix2D b)
    {
        return new Matrix2D(
            a.matrix[0, 0] * b.matrix[0, 0] + a.matrix[0, 1] * b.matrix[1, 0],
            a.matrix[0, 0] * b.matrix[0, 1] + a.matrix[0, 1] * b.matrix[1, 1],
            a.matrix[1, 0] * b.matrix[0, 0] + a.matrix[1, 1] * b.matrix[1, 0],
            a.matrix[1, 0] * b.matrix[0, 1] + a.matrix[1, 1] * b.matrix[1, 1]
        );
    }

    public static Matrix2D operator *(int k, Matrix2D a)
    {
        return new Matrix2D(
            k * a.matrix[0, 0],
            k * a.matrix[0, 1],
            k * a.matrix[1, 0],
            k * a.matrix[1, 1]
        );
    }

    public static Matrix2D operator *(Matrix2D a, int k)
    {
        return k * a;
    }

    public static Matrix2D operator -(Matrix2D a)
    {
        return -1 * a;
    }

    public Matrix2D Transpose()
    {
        return new Matrix2D(
            matrix[0, 0],
            matrix[1, 0],
            matrix[0, 1],
            matrix[1, 1]
        );
    }

    public static int Determinant(Matrix2D a)
    {
        return a.matrix[0, 0] * a.matrix[1, 1] - a.matrix[0, 1] * a.matrix[1, 0];
    }

    public int Det()
    {
        return Determinant(this);
    }
}