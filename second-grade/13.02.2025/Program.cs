interface IResult
{
	double Perimeter(int side);
	double Area(int side);
}

class Figure()
{
	public string name { get; set; }
}

class Circle : Figure, IResult
{
	public int radius;

	public Circle(int radius)
	{
		this.radius = radius;
		this.name = "circle";
	}

	double IResult.Perimeter(int radius)
	{
		double perimeter = 2 * 3.14 * radius;
		return perimeter;
	}

	double IResult.Area(int radius)
	{
		int diameter = 2 * radius;
		double area = (3.14 * Math.Pow(diameter, 2)) / 4;
		return area;
	}
}

class Square : Figure, IResult
{
	public int side;

	public Square(int side)
	{
		this.side = side;
		this.name = "square";
	}

	double IResult.Perimeter(int side)
	{
		double perimeter = side * 4;
		return perimeter;
	}

	double IResult.Area(int side)
	{
		double area = Math.Pow(side, 2);
		return area;
	}
}

class Triangle : Figure, IResult
{
	public int side { get; set; }

	public Triangle(int side)
	{
		this.side = side;
		this.name = "triangle";
	}

	double IResult.Perimeter(int side)
	{
		double perimeter = 3 * side;
		return perimeter;
	}

	double IResult.Area(int side)
	{
		double area = (Math.Sqrt(3) / 4) * Math.Pow(side, 2);
		return area;
	}
}

class Program
{
	static void Main()
	{
		Square square = new Square(4);
		Console.WriteLine($"- Square:\nPerimeter: {((IResult)square).Perimeter(4)}\nArea: {((IResult)square).Area(4)}");

		Circle circle = new Circle(5);
		Console.WriteLine($"- Circle:\nPerimeter: {((IResult)circle).Perimeter(5)}\nArea: {((IResult)circle).Area(5)}");

		Triangle triangle = new Triangle(6);
		Console.WriteLine($"- Triangle\nPerimeter: {((IResult)triangle).Perimeter(6)}\nArea: {((IResult)triangle).Area(6)}");
	}
}
