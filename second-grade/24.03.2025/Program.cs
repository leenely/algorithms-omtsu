using System;

namespace Point
{
  public class Point
  {
    public int x;
    public int y;

    public Point(int x, int y)
    {
      this.x = x;
      this.y = y;
    }

    public string PositionNow()
    {
      return $"({this.x}, {this.y})";
    }
  }

  public class PointOutOfBoundsEvent
  {
    public Point OutPoint;

    public PointOutOfBoundsEvent(Point OutPoint)
    {
      this.OutPoint = OutPoint;
      Console.WriteLine("Вызвано");
    }
  }

  public delegate void PointOutOfBoundsEventHandler(Point outPoint);

  public class Game
  {
    public Point topLeft;
    public Point topRight;
    public Point bottomLeft;
    public Point bottomRight;
    public int minX, maxX;
    public int minY, maxY;

    public Point currentPoint;

    public event PointOutOfBoundsEventHandler OnPointOutOfBounds;

    public Game(Point topLeft, Point topRight, Point bottomLeft, Point bottomRight, Point currentPoint)
    {
      this.topLeft = topLeft;
      this.topRight = topRight;
      this.bottomLeft = bottomLeft;
      this.bottomRight = bottomRight;
      this.currentPoint = currentPoint;

      minX = Math.Min(topLeft.x, Math.Min(topRight.x, Math.Min(bottomLeft.x, bottomRight.x)));
      maxX = Math.Max(topLeft.x, Math.Max(topRight.x, Math.Max(bottomLeft.x, bottomRight.x)));
      minY = Math.Min(topLeft.y, Math.Min(topRight.y, Math.Min(bottomLeft.y, bottomRight.y)));
      maxY = Math.Max(topLeft.y, Math.Max(topRight.y, Math.Max(bottomLeft.y, bottomRight.y)));
    }

    public Random random = new Random();

    public bool IsPointInField()
    {
      return (this.currentPoint.x >= minX && this.currentPoint.x <= maxX && this.currentPoint.y >= minY && this.currentPoint.y <= maxY);
    }

    public void RandomMove()
    {
      int newX = this.currentPoint.x + random.Next(-2, 2);
      int newY = this.currentPoint.y + random.Next(-2, 2);

      this.currentPoint.x = newX;
      this.currentPoint.y = newY;

      if (!IsPointInField())
      {
        OnPointOutOfBounds?.Invoke(currentPoint);
      }

      Console.WriteLine($"Текущая позиция: {currentPoint.x}, {currentPoint.y}");
    }
  }

  class Program
  {
    static void Main()
    {
      Point topLeft = new Point(0, 0);
      Point topRight = new Point(10, 0);
      Point bottomLeft = new Point(0, 10);
      Point bottomRight = new Point(3, 10);

      Point startPoint = new Point(5, 5);

      Game game = new Game(topLeft, topRight, bottomLeft, bottomRight, startPoint);

      game.OnPointOutOfBounds += (point) =>
      {
        Console.WriteLine($"Точка {point.PositionNow()} вышла за пределы поля");
      };

      for (int i = 0; i <= 10; i++)
      {
        game.RandomMove();
      }
    }
  }
}