using ClassLibrary;

namespace TestsMatrix2D;

public class UnitTest1
{
    [Fact]
    public void Matrix2D_Constructor_WithParameters()
    {
        // Arrange
        int a = 1, b = 2, c = 3, d = 4;

        // Act
        var matrix = new Matrix2D(a, b, c, d);

        // Assert
        Assert.Equal(a, matrix[0, 0]);
        Assert.Equal(b, matrix[0, 1]);
        Assert.Equal(c, matrix[1, 0]);
        Assert.Equal(d, matrix[1, 1]);
    }

    [Fact]
    public void Matrix2D_Constructor_Default()
    {
        // Arrange & Act
        var matrix = new Matrix2D();

        // Assert
        Assert.Equal(1, matrix[0, 0]);
        Assert.Equal(0, matrix[0, 1]);
        Assert.Equal(0, matrix[1, 0]);
        Assert.Equal(1, matrix[1, 1]);
    }

    [Fact]
    public void Matrix2D_Transpose()
    {
        // Arrange
        var matrix = new Matrix2D(1, 2, 3, 4);

        // Act
        var transposedMatrix = matrix.Transpose();

        // Assert
        Assert.Equal(1, transposedMatrix[0, 0]);
        Assert.Equal(3, transposedMatrix[0, 1]);
        Assert.Equal(2, transposedMatrix[1, 0]);
        Assert.Equal(4, transposedMatrix[1, 1]);
    }

    [Fact]
    public void Matrix2D_Determinant()
    {
        // Arrange
        var matrix = new Matrix2D(1, 2, 3, 4);

        // Act
        var determinant = Matrix2D.Determinant(matrix);

        // Assert
        Assert.Equal(-2, determinant);
    }

    [Fact]
    public void Matrix2D_Det()
    {
        // Arrange
        var matrix = new Matrix2D(1, 2, 3, 4);

        // Act
        var det = matrix.Det();

        // Assert
        Assert.Equal(-2, det);
    }
}