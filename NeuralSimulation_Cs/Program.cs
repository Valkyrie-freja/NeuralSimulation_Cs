using System.Runtime.CompilerServices;

//class Neuron
//{

//}
public class Main_class {
    private static double RungeKutta_Approximate(Func<double, double, double> f, double x, double t) {
        const double dt = 0.0000001;
        double dx1 = dt * f(x            , t           );
        double dx2 = dt * f(x + 0.5 * dx1, t + 0.5 * dt);
        double dx3 = dt * f(x + 0.5 * dx2, t + 0.5 * dt);
        double dx4 = dt * f(x +       dx3, t +       dt);

        return x + (dx1 + 2 * dx2 + 2 * dx3 + dx4) / 6.0;
    }

    public static void Main() {
        //double a = RungeKutta_Approximate(Sum, 2.0, 3.0);
        //Console.WriteLine(a);
    }
}