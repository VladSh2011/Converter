using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Converter
{
    class Model
    {
        public double CtoF(double x) => x * 9 / 5 + 32;
        public double FtoC(double x) => (x - 32) * 5 / 9;
        public double CtoK(double x) => x + 273.15;
        public double KtoC(double x) => x - 273.15;
        public double FtoK(double x) => FtoC(x) + 273.15;
        public double KtoF(double x) => 273.15 - FtoC(x);
    }
}