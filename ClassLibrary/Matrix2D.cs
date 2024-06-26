namespace ClassLibrary;

public class Matrix2D : IEquatable<Matrix2D>
{
    public readonly int[,] matrix = new int[2, 2];

    public int this[int i, int j]
    {
        get { return matrix[i, j]; }
    }

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

    public static explicit operator int[,](Matrix2D matrix2D)
    {
        int[,] result = new int[2, 2];

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                result[i, j] = matrix2D.matrix[i, j];
            }
        }

        return result;
    }

    public static Matrix2D Parse(string input)
    {
        if (input == null)
            throw new ArgumentNullException(nameof(input));

        input = input.Trim();

        if (input.Length < 9 || input[0] != '[' || input[input.Length - 1] != ']')
            throw new FormatException("Invalid format");

        var matrixElements = input.Substring(1, input.Length - 2).Split(new[] { "], [" }, StringSplitOptions.None);

        if (matrixElements.Length != 2)
            throw new FormatException("Invalid format");

        var elements = new List<int>();
        foreach (var element in matrixElements)
        {
            var innerElements = element.Split(',', StringSplitOptions.RemoveEmptyEntries);
            if (innerElements.Length != 2)
                throw new FormatException("Invalid format");

            foreach (var innerElement in innerElements)
            {
                if (!int.TryParse(innerElement.Trim(), out var value))
                    throw new FormatException("Invalid format");
                elements.Add(value);
            }
        }

        return new Matrix2D(elements[0], elements[1], elements[2], elements[3]);
    }
}