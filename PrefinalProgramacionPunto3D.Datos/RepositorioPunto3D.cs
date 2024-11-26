using PrefinalProgramacionPunto3D.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefinalProgramacionPunto3D.Datos
{
    public class RepositorioPunto3D
    {
        private List<Punto3D>? puntos3d;
        private string nombreArchivo = "Punto3D.txt";
        private string rutaProyecto = Environment.CurrentDirectory;
        private string? rutaCompletaArchivo;
        public RepositorioPunto3D()
        {
            puntos3d = new List<Punto3D>();
            rutaCompletaArchivo = Path.Combine(rutaProyecto, nombreArchivo);
            puntos3d = LeerDatos();
        }
        
        public bool Existe(Punto3D Punto3d)
        {
            return puntos3d!.Any(r => r.DatoX == Punto3d.DatoX &&
                    r.DatoY == Punto3d.DatoY &&
                    r.DatoZ == Punto3d.DatoZ);
        }
        public void Agregar(Punto3D punto3ds)
        {
            puntos3d!.Add(punto3ds);
        }
        public List<Punto3D>? GetPunto3D()
        {
            return puntos3d;
        }
        public void GuardarDatos()
        {
            using (var escritor = new StreamWriter(rutaCompletaArchivo!))
            {
                foreach (var punto3d in puntos3d)
                {
                    string linea = ConstruirLinea(punto3d);
                    escritor.WriteLine(linea);
                }
            }
        }
        private List<Punto3D> LeerDatos()
        {
            var lista = new List<Punto3D>();
            if (!File.Exists(rutaCompletaArchivo))
            {
                return lista;
            }
            using (var lector = new StreamReader(rutaCompletaArchivo!))
            {
                while (!lector.EndOfStream)
                {
                    string? lineaLeida = lector.ReadLine();
                    Punto3D punto3ds = ConstruirPunto3D(lineaLeida);
                    lista.Add(punto3ds);
                }
            }
            return lista;
        }

        private Punto3D ConstruirPunto3D(string? lineaLeida)
        {
            var campos = lineaLeida!.Split("|");
            int PuntoZ = int.Parse(campos[0]);
            int PuntoX = int.Parse(campos[1]);
            int PuntoY = int.Parse(campos[2]);
            String Color = (campos[3]);
            return new Punto3D(PuntoX, PuntoY, PuntoZ,Color);
        }

        private string ConstruirLinea(Punto3D punto3d)
        {
            return $"{punto3d.DatoZ}|{punto3d.DatoY}|{punto3d.DatoX.GetHashCode()}";
        }

        public void Borrar(Punto3D punto3ds)
        {
            puntos3d.Remove(punto3ds);
        }
        public List<Punto3D> GetListaOrdenada(Orden orden)
        {
            if (orden == Orden.Asc)
            {
                return puntos3d.OrderBy(r => r.Color).ToList();
            }
            return puntos3d.OrderByDescending(r => r.Color).ToList();
        }

       
    }
}
