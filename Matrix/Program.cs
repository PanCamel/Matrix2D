using ClassLibrary;

Matrix2D matrixA = new Matrix2D(1, 2, 3, 4);
Matrix2D matrixB = new Matrix2D(5, 6, 7, 8);

Console.WriteLine("Matrix A:");
Console.WriteLine(matrixA);

Console.WriteLine("Matrix B:");
Console.WriteLine(matrixB);

Console.WriteLine("Addition:");
Console.WriteLine(matrixA + matrixB);

Console.WriteLine("Subtraction:");
Console.WriteLine(matrixA - matrixB);

Console.WriteLine("Multiplication:");
Console.WriteLine(matrixA * matrixB);

Console.WriteLine("Scalar Multiplication:");
Console.WriteLine(2 * matrixA);
Console.WriteLine(matrixA * 2);

Console.WriteLine("Transpose of Matrix A:");
Console.WriteLine(matrixA.Transpose());

Console.WriteLine("Determinant of Matrix A:");
Console.WriteLine(matrixA.Det());

string input = "[1, 2], [3, 4]";
Console.WriteLine($"Input string: {input}");
var matrix = Matrix2D.Parse(input);
Console.WriteLine(matrix);