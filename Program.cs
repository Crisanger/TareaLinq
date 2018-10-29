using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaLinq
{
    public class Program
    {
        public class cosas
        {
            public string stNombre { get; set; }
            public int doValor { get; set; }
            public string stTipo { get; set; }
        }
        public class tipos
        {
            public string stNombre { get; set; }
            public string stUso { get; set; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("==============================");
            Console.WriteLine("=         Bienvenido         =");
            Console.WriteLine("==============================");
            Console.WriteLine("");
            //Declaro la lista
            List<cosas> informacion = new List<cosas>();
            List<tipos> informacionTipos = new List<tipos>();
            informacionTipos.Add(new tipos { stNombre = "comida", stUso = "Alimentarse" });
            informacionTipos.Add(new tipos { stNombre = "bebida", stUso = "remojar la comida" });
            informacionTipos.Add(new tipos { stNombre = "transporte", stUso = "Llegar rapido" });


            Console.WriteLine("Ingrese un nombre");
            string nombre1 = Console.ReadLine();
            Console.WriteLine("Ingrese el valor");
            string valor1 = Console.ReadLine();
            Console.WriteLine("Ingrese el tipo");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Tipos: comida , bebida, transporte");
            Console.WriteLine("----------------------------------");
            string tipo1 = Console.ReadLine();
            informacion.Add(new cosas
            {
                stNombre = nombre1,
                doValor = Convert.ToInt32(valor1),
                stTipo = tipo1
            });

            for (int x = 0; x < 10; x++)
            {
                Console.WriteLine("¿Quiere ingresar otra cosa? s/n");
                string respuesta = Console.ReadLine();
                if (respuesta.Equals("s"))
                {
                    x = 0;
                    Console.WriteLine("Ingrese un nombre");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el valor");
                    string valor = Console.ReadLine();
                    Console.WriteLine("Ingrese el tipo");
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("Tipos: comida , bebida, transporte");
                    Console.WriteLine("----------------------------------");
                    string tipo = Console.ReadLine();
                    informacion.Add(new cosas {
                        stNombre = nombre,
                        doValor = Convert.ToInt32(valor),
                        stTipo = tipo
                    });
                }
                else
                {
                    x = 11;
                }

            }

            //CONTENIDO DE LA LISTA
            Console.WriteLine("=====================");
            Console.WriteLine("Contenido de la lista");
            foreach (var item in informacion)
            {
                Console.WriteLine("Nombre: " + item.stNombre);
                Console.WriteLine("Valor: " + item.doValor);
                Console.WriteLine("Tipo: " + item.stTipo);
                Console.WriteLine("-------------------");
            }

            // MIN - MAX
            var minmax = (from q in informacion select q.doValor).ToList(); // .Min(); .Max();
            Console.WriteLine("================");
            Console.WriteLine("Uso de Min y Max");
            Console.WriteLine("Valor menor: " + minmax.Min());
            Console.WriteLine("Valor mayor: " + minmax.Max());

            // FIRST - LAST ORDEFAULT
            Console.WriteLine("=============================");
            Console.WriteLine("Uso de First y Last orDefault");
            var firstlast = (from q in informacion select q.stNombre).ToList(); // .FirstOrDefault(); LastOrDefault();
            Console.WriteLine("Primera cosa: " + firstlast.FirstOrDefault());
            Console.WriteLine("Ultimo cosa: " + firstlast.LastOrDefault());

            // TOLIST - WHERE - SELECT
            Console.WriteLine("=============================");
            Console.WriteLine("Uso de ToList, where, select ");
            var cosasBaratas = (from q in informacion where q.doValor <= 6000 select q).ToList(); // select q.stNombre
            foreach (var item in cosasBaratas)
            {
                Console.WriteLine("Cosas baratas: " + item.stNombre); // item
            }

            //USO DE JOIN
            Console.WriteLine("=======================================================");
            Console.WriteLine("Uso de Join ");
            var usoJoin = (from q in informacion join
                           q1 in informacionTipos on
                           q.stTipo equals q1.stNombre
                           //where q.stTipo == "comida"
                           select new { cosas = q.stNombre, tipos=q1.stUso }).ToList();
            foreach (var item in usoJoin)
            {
                
                var c1 = item.cosas; var c2= item.tipos;
                Console.WriteLine("Cosa: " + c1 + ", se usa para: " + c2);
            }

            while (true) ;
        }
    }
}
