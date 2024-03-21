using System;
using System.Collections.Generic;

public class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
}

public abstract class Shape
{
    public abstract void Move(double deltaX, double deltaY);
}

public class Circle : Shape
{
    public Point Center { get; set; }
    public double Radius { get; set; }

    public Circle(Point center, double radius)
    {
        Center = center;
        Radius = radius;
    }

    public override void Move(double deltaX, double deltaY)
    {
        Center.X += deltaX;
        Center.Y += deltaY;
    }
}

public class Triangle : Shape
{
    public Point Point1 { get; set; }
    public Point Point2 { get; set; }
    public Point Point3 { get; set; }

    public Triangle(Point point1, Point point2, Point point3)
    {
        Point1 = point1;
        Point2 = point2;
        Point3 = point3;
    }

    public override void Move(double deltaX, double deltaY)
    {
        Point1.X += deltaX;
        Point1.Y += deltaY;

        Point2.X += deltaX;
        Point2.Y += deltaY;

        Point3.X += deltaX;
        Point3.Y += deltaY;
    }
}

public class ShapesGroup
{
    private List<Shape> shapes;

    public ShapesGroup()
    {
        shapes = new List<Shape>();
    }

    public void AddShape(Shape shape)
    {
        shapes.Add(shape);
    }

    public void Move(double deltaX, double deltaY)
    {
        foreach (var shape in shapes)
        {
            shape.Move(deltaX, deltaY);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Circle circle = new Circle(new Point(0, 0), 5);
        Triangle triangle = new Triangle(new Point(0, 0), new Point(3, 0), new Point(0, 4));

        ShapesGroup group = new ShapesGroup();
        group.AddShape(circle);
        group.AddShape(triangle);

        Console.WriteLine("Перед зсувом:");
        Console.WriteLine("Коло: Центр - ({0}, {1}), Радiус - {2}", circle.Center.X, circle.Center.Y, circle.Radius);
        Console.WriteLine("Трикутник: ({0}, {1}), ({2}, {3}), ({4}, {5})", triangle.Point1.X, triangle.Point1.Y, triangle.Point2.X, triangle.Point2.Y, triangle.Point3.X, triangle.Point3.Y);

        group.Move(2, 3);

        Console.WriteLine("\nПiсля зсуву:");
        Console.WriteLine("Коло: Центр - ({0}, {1}), Радiус - {2}", circle.Center.X, circle.Center.Y, circle.Radius);
        Console.WriteLine("Трикутник: ({0}, {1}), ({2}, {3}), ({4}, {5})", triangle.Point1.X, triangle.Point1.Y, triangle.Point2.X, triangle.Point2.Y, triangle.Point3.X, triangle.Point3.Y);
    }

}
