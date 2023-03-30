using System.Data.Common;
using System.Runtime.CompilerServices;
//using Nauron;

public class Main_class {

    static double dt = 0.25;
    const double x0 = 1.0;

    class Neuron {
        private const double kTau = 0;
        private const double kTau_inv = 1.0 / kTau;
        private const double kPotential_rest = 0;
        private const double kR_m = 1;
        private const double i_ext = 1;

        private double potential_membrane = 0;
        public double dvdt(double potential_membrance, double t) {
            return (-(potential_membrane - kPotential_rest) + kR_m * i_ext) * kTau_inv;
        }
    }

    public static double RungeKutta_Approximate(Func<double, double, double> f, 
                                                double x, double t) {
        double dx1 = dt * f(x, t);
        double dx2 = dt * f(x + 0.5 * dx1, t + 0.5 * dt);
        double dx3 = dt * f(x + 0.5 * dx2, t + 0.5 * dt);
        double dx4 = dt * f(x + dx3, t + dt);

        return x + (dx1 + 2 * dx2 + 2 * dx3 + dx4) / 6.0;
    }

    /*
    public static double RungeKutta_Approximate(Func<double, double, double, double, double, double> f, 
                                                double v, double m, double h, double n, double i) {
        double dv1 = dt * f(v, m, h, n, i);
        double dv2 = dt * f(v + 0.5 * dv1, t + 0.5 * dt);
        double dv3 = dt * f(v + 0.5 * dv2, t + 0.5 * dt);
        double dv4 = dt * f(v + dv3, t + dt);

        return v + (dv1 + 2 * dv2 + 2 * dv3 + dv4) / 6.0;
    }*/

    public static void Main() {
        double f(double x, double t) { return x; }
        Neuron os = new Neuron();

        for (int i = 0; i < 10; i++) {
            dt = dt/2.0;
            double ans = x0;
            for (double t = 0; t < 1.0; t = t + dt) {
                ans = RungeKutta_Approximate(os.dvdt, ans, t);
            }
            Console.WriteLine($"{dt} \t| {ans}"); 
        }
    }
    
}