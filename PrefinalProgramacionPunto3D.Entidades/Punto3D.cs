using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefinalProgramacionPunto3D.Entidades
{
    public class Punto3D
    {
        public int DatoX { get; set; }
        public int DatoY { get; set; }
        public int DatoZ { get; set; }
        public string Color { get; set; }

        public Punto3D() { }

        public Punto3D(int x, int y, int z, string color)
        {
            DatoX = x;
            DatoY = y;
            DatoZ = z;
            Color = color;
        }

        public double GetDistancia()
        {
            return Math.Sqrt(Math.Pow(DatoX, 2) + Math.Pow(DatoY, 2) + Math.Pow(DatoZ, 2));
        }

        public override string ToString()
        {
            return $"Punto3D(X: {DatoX}, Y: {DatoY}, Z: {DatoZ}, Color: {Color})";
        }
    }
}
