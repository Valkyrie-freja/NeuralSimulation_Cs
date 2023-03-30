using System.Data.Common;
using System.Runtime.CompilerServices;
//using Nauron;

public class Main_class {

    static double dt = 1;
    const double x0 = 1.0;

    class Neuron {
        private const double kTau = 20.0;
        private const double kTau_inv = 1.0 / kTau;
        private const double kPotential_rest = -65.0;
        private const double kPotential_reset = -65.0;
        private const double kR_m = 1.0;
        private const double i_ext = 12.0;
        private const double kSpikeThreshold = -55.0;

        // 膜電位
        public double potential_membrane = kPotential_reset;

        private double dvdt(double v_, double t) {
            potential_membrane = v_;
            return (-(potential_membrane - kPotential_rest) + kR_m * i_ext) * kTau_inv;
        }
        
        private void spike() {
            if (potential_membrane < kSpikeThreshold) return;
            potential_membrane = kPotential_rest;
        }
        
        public void ProcessCalculation() {
            potential_membrane = RungeKutta_Approximate(dvdt, potential_membrane, 1.0);
            spike();
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

    public static double Eular_Approximate(Func<double, double, double> f, 
                                           double x, double t) {
        return x + dt * f(x, t);
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
        Neuron os = new Neuron();

        const double v0 = -65.0;
        os.potential_membrane = v0;
        for (double t = 0; t < 300; t = t + dt) {
            os.ProcessCalculation();
            Console.WriteLine($"{t}, {os.potential_membrane}");
        }
    }
    
}