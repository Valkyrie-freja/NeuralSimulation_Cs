/*
namespace Nauron {
    class Neuron {
        private const double kTau = 0;
        private const double kTau_inv = 1.0 / kTau;
        private const double kPotential_rest = 0;
        private const double kR_m = 1;

        private double potential_membrane = 0;
        double dvdt(double i_ext) {
            return ( -(potential_membrane - kPotential_rest) + kR_m * i_ext) * kTau_inv;
        }
    }

    class Approximate {
        public static double RungeKutta_Approximate(Func<double, double, double> f, double x, double t) {
            double dx1 = dt * f(x, t);
            double dx2 = dt * f(x + 0.5 * dx1, t + 0.5 * dt);
            double dx3 = dt * f(x + 0.5 * dx2, t + 0.5 * dt);
            double dx4 = dt * f(x + dx3, t + dt);

            return x + (dx1 + 2 * dx2 + 2 * dx3 + dx4) / 6.0;
        }

        public static double RungeKutta_Approximate(Func<double, double, double, double, double, double> f, double v, double m, double h, double n, double i) {
            double dv1 = dt * f(v, m, h, n, i);
            double dv2 = dt * f(v + 0.5 * dv1, t + 0.5 * dt);
            double dv3 = dt * f(v + 0.5 * dv2, t + 0.5 * dt);
            double dv4 = dt * f(v + dv3, t + dt);

            return v + (dx1 + 2 * dx2 + 2 * dx3 + dx4) / 6.0;
        }
    }
}*/