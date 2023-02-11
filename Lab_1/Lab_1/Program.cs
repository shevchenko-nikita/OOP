using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;

class TCircle
{

    public TCircle()
    {
        radius = 0;
        x = 0;
        y = 0;
    }

    public TCircle(double _radius, double _x, double _y)
    {
        radius = _radius;
        x = _x;
        y = _y;
    }

    public TCircle(TCircle other)
    {
        radius = other.radius;
        x = other.x;
        y = other.y;
    }

    public virtual void enter_data()
    {
        Console.Write("Enter a radius value: ");
        radius = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter a coordinate value: ");
        string[] num = Console.ReadLine().Split(' ');
        x = Convert.ToDouble(num[0]);
        y = Convert.ToDouble(num[1]);
    }

    public virtual void print_data()
    {
        Console.WriteLine("Radius - " + radius);
        Console.WriteLine("Coordinate - (" + x + ", " + y + ")");
    }

    public virtual double get_area()
    {
        return pi * Math.Pow(radius, 2);
    }

    public bool is_belongs(double x1, double y1)
    {
        return Math.Sqrt(Math.Pow(x1 - x, 2) + Math.Pow(y1 - y, 2)) <= radius;
    }

    public static TCircle operator +(TCircle lhs, TCircle rhs)
    {
        return new TCircle(lhs.radius + rhs.radius, lhs.x, lhs.y);
    }

    public static TCircle operator -(TCircle lhs, TCircle rhs)
    {
        return new TCircle(lhs.radius - rhs.radius, lhs.x, lhs.y);
    }

    public static TCircle operator *(TCircle lhs, TCircle rhs)
    {
        return new TCircle(lhs.radius * rhs.radius, lhs.x, lhs.y);
    }

    protected double radius;
    protected double x;
    protected double y;
    protected const double pi = 3.14;
}

class TBall : TCircle
{
    public TBall() : base()
    {
        z = 0;
    }

    public TBall(double _radius, double _x, double _y, double _z) : base(_radius, _x, _y)
    {
        z = _z;
    }

    public TBall(TBall other)
    {
        radius = other.radius;
        x = other.x;
        y = other.y;
        z = other.z;
    }

    public override void enter_data()
    {
        Console.Write("Enter a radius value: ");
        radius = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter a coordinate value: ");
        string[] num = Console.ReadLine().Split(' ');
        x = Convert.ToDouble(num[0]);
        y = Convert.ToDouble(num[1]);
        z = Convert.ToDouble(num[2]);
    }

    public override void print_data()
    {
        Console.WriteLine("Radius - " + radius);
        Console.WriteLine("Coordinate - (" + x + ", " + y + ", " + z + ")");
    }

    public override double get_area()
    {
        return 4 * pi * Math.Pow(radius, 2);
    }

    public double get_volume()
    {
        return 4 * pi * Math.Pow(radius, 3) / 3;
    }

    public bool is_belongs(double x1, double y1, double z1)
    {
        return Math.Sqrt(Math.Pow(x1 - x, 2) + Math.Pow(y1 - y, 2) + Math.Pow(z1 - z, 2)) <= radius;
    }

    public static TBall operator +(TBall lhs, TBall rhs)
    {
        return new TBall(lhs.radius + rhs.radius, lhs.x, lhs.y, lhs.z);
    }

    public static TBall operator -(TBall lhs, TBall rhs)
    {
        return new TBall(lhs.radius - rhs.radius, lhs.x, lhs.y, lhs.z);
    }

    public static TBall operator *(TBall lhs, TBall rhs)
    {
        return new TBall(lhs.radius * rhs.radius, lhs.x, lhs.y, lhs.z);
    }

    protected double z;
}


class Program
{
    static void test_constructors()
    {
        Console.WriteLine("Circle:");
        TCircle circle_default_constructor = new TCircle();
        circle_default_constructor.print_data();

        TCircle circle_consttructor_with_parametrs = new TCircle(4, 2, 3);
        circle_consttructor_with_parametrs.print_data();

        TCircle circle_copy_constructor = new TCircle(circle_consttructor_with_parametrs);
        circle_copy_constructor.print_data();

        Console.WriteLine("Ball:");
        TBall ball_default_constructor = new TBall();
        ball_default_constructor.print_data();
        TBall ball_consttructor_with_parametrs = new TBall(4, 2, 3, 5);
ball_consttructor_with_parametrs.print_data();

TBall ball_copy_constructor = new TBall(ball_consttructor_with_parametrs);
ball_copy_constructor.print_data();
    }
    static void test_methods()
{
    Console.WriteLine("Circle:");
    TCircle circle = new TCircle(5, 0, 0);
    Console.WriteLine("Area: " + circle.get_area());

    Console.WriteLine("Enter coordinate:");

    string[] input = Console.ReadLine().Split(' ');
    double x = Convert.ToDouble(input[0]);
    double y = Convert.ToDouble(input[1]);

    if (circle.is_belongs(x, y))
    {
        Console.WriteLine("Point is belong circle");
    }
    else
    {
        Console.WriteLine("Point isn't belong circle");
    }

    Console.WriteLine("\nBall:");
    TBall ball = new TBall(5, 0, 0, 0);
    Console.WriteLine("Area: " + ball.get_area());
    Console.WriteLine("Volume: " + ball.get_volume());

    Console.WriteLine("Enter coordinate:");

    string[] input1 = Console.ReadLine().Split(' ');
    x = Convert.ToDouble(input1[0]);
    y = Convert.ToDouble(input1[1]);
    double z = Convert.ToDouble(input1[2]);

    if (ball.is_belongs(x, y, z))
    {
        Console.WriteLine("Point is belong ball");
    }
    else
    {
        Console.WriteLine("Point isn't belong ball");
    }
}

static void test_operators()
{
    Console.WriteLine("Circle:");
    TCircle circle1 = new TCircle(4, 0, 0);
    TCircle circle2 = new TCircle(2, 0, 0);
    TCircle circle3 = new TCircle(5, 0, 0);

    circle1 = circle1 - circle2;

    Console.WriteLine("circle1 - circle2:");
    circle1.print_data();

    Console.WriteLine("circle1 + circle3:");
    circle1 = circle1 + circle3;
    circle1.print_data();

    Console.WriteLine("circle1 * circle2:");
    circle1 = circle1 * circle2;
    circle1.print_data();

    Console.WriteLine("\nBall:");
    TBall ball1 = new TBall(4, 0, 0, 0);
    TBall ball2 = new TBall(3, 0, 0, 0);
    TBall ball3 = new TBall(5, 0, 0, 0);

    ball1 = ball1 - ball2;

    Console.WriteLine("ball1 - ball2:");
    ball1.print_data();

    Console.WriteLine("ball1 + ball3:");
    ball1 = ball1 + ball3;
    ball1.print_data();

    Console.WriteLine("ball1 * ball2:");
    ball1 = ball1 * ball2;
    ball1.print_data();
}
static void Main(string[] args)
{

    test_constructors();
    test_methods();
    test_operators();



}


}