using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsProject
{
    public static class ElectronDistribution
    {
        public delegate double R(double r);
        // атомные единицы измерения
        public static double Z = 1;
        public static double a0 = 1;
        // характеристика положения электрона
        private static int n;
        private static int l;

        public static R GetElectronDistribution(int n, int l)
        {
            ElectronDistribution.n = n;
            ElectronDistribution.l = l;
            return D_nl();
        }
        private static R D_nl()
        {
            (int n, int l) electronCharacteristics = (n, l);
            switch (electronCharacteristics)
            {
                case (1, 0):
                    return D_10;
                case (2, 0):
                    return D_20;
                case (2, 1):
                    return D_21;
                case (3, 0):
                    return D_30;
                case (3, 1):
                    return D_31;
                case (3, 2):
                    return D_32;
                case (4, 0):
                    return D_40;
                case (4, 1):
                    return D_41;
                case (4, 2):
                    return D_42;
                case (4, 3):
                    return D_43;
                default:
                    throw new Exception("Incorrect n and l");
            }
        }
        private static double R_10(double r)
        {
            return (double)2 * Math.Pow((Z / a0), (double)3 / 2) * Math.Exp(-(double)Z * r / a0);
        }
        private static double D_10(double r)
        {
            return 4 * Math.PI * Math.Pow(r, 2) * Math.Pow(R_10(r), 2);
        }
        private static double R_20(double r)
        {
            return (double)((double)1 / (2 * Math.Sqrt(2))) * Math.Pow((Z / a0), (double)3 / 2) * ((double)2 - (double)Z * r / a0) * Math.Exp(-(double)Z * r / (2 * a0));
        }
        private static double D_20(double r)
        {
            return 4 * Math.PI * Math.Pow(r, 2) * Math.Pow(R_20(r), 2);
        }
        private static double R_21(double r)
        {
            return (double)((double)1 / (2 * Math.Sqrt(6))) * Math.Pow((Z / a0), (double)5 / 2) * r * Math.Exp(-(double)Z * r / (2 * a0));
        }
        private static double D_21(double r)
        {
            return 4 * Math.PI * Math.Pow(r, 2) * Math.Pow(R_21(r), 2);
        }
        private static double R_30(double r)
        {
            return (double)((double)1 / (9 * Math.Sqrt(3))) * Math.Pow((Z / a0), (double)3 / 2) * ((double)6 - (double)4 * Z * r / a0 + Math.Pow((double)2 * Z * r / (3 * a0), 2)) * Math.Exp(-(double)Z * r / (3 * a0));
        }
        private static double D_30(double r)
        {
            return 4 * Math.PI * Math.Pow(r, 2) * Math.Pow(R_30(r), 2);
        }
        private static double R_31(double r)
        {
            return (double)((double)1 / 27 * Math.Sqrt((double)2 / 3)) * Math.Pow((Z / a0), (double)5 / 2) * ((double)4 - (double)2 * Z * r / (3 * a0)) * r * Math.Exp(-(double)Z * r / (3 * a0));
        }
        private static double D_31(double r)
        {
            return 4 * Math.PI * Math.Pow(r, 2) * Math.Pow(R_31(r), 2);
        }
        private static double R_32(double r)
        {
            return (double)((double)2 / 81 * Math.Sqrt((double)2 / 15)) * Math.Pow((Z / a0), (double)7 / 2) * Math.Pow(r, 2) * Math.Exp(-(double)Z * r / (3 * a0));
        }
        private static double D_32(double r)
        {
            return 4 * Math.PI * Math.Pow(r, 2) * Math.Pow(R_32(r), 2);
        }
        private static double R_40(double r)
        {
            return (double)((double)1 / 96) * Math.Pow((Z / a0), (double)3 / 2) * ((double)24 - (double)18 * Z * r / a0 + (double)12 * Math.Pow((double)Z * r / (2 * a0), 2) - Math.Pow((double)Z * r / (2 * a0), 3)) * Math.Exp(-(double)Z * r / (4 * a0));
        }
        private static double D_40(double r)
        {
            return 4 * Math.PI * Math.Pow(r, 2) * Math.Pow(R_40(r), 2);
        }
        private static double R_41(double r)
        {
            return (double)((double)1 / (64*Math.Sqrt(15))) * Math.Pow((Z / a0), (double)5 / 2) * ((double)20 - (double)5 * Z * r / a0 + Math.Pow((double)Z * r / (2 * a0), 2)) * r * Math.Exp(-(double)Z * r / (4 * a0));
        }
        private static double D_41(double r)
        {
            return 4 * Math.PI * Math.Pow(r, 2) * Math.Pow(R_41(r), 2);
        }
        private static double R_42(double r)
        {
            return (double)((double)1 / (384 * Math.Sqrt(5))) * Math.Pow((Z / a0), (double)7 / 2) * ((double)6 - (double)Z * r / (2 * a0)) * Math.Pow(r, 2) * Math.Exp(-(double)Z * r / (4 * a0));
        }
        private static double D_42(double r)
        {
            return 4 * Math.PI * Math.Pow(r, 2) * Math.Pow(R_42(r), 2);
        }
        private static double R_43(double r)
        {
            return (double)((double)1 / (384 * Math.Sqrt(35))) * Math.Pow((Z / a0), (double)7 / 2)* Math.Pow(r, 3) * Math.Exp(-(double)Z * r / (4 * a0));
        }
        private static double D_43(double r)
        {
            return 4 * Math.PI * Math.Pow(r, 2) * Math.Pow(R_43(r), 2);
        }
    }
}
