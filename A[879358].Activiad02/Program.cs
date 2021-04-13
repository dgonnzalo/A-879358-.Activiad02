using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_879358_.Activiad02
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salida = false;
            List<Equipos> listadoDeEquipos = new List<Equipos> ();
            //Equipos[] arrayEquipos;
            int verificacionDeResultados = 0;
            


            do
            {
                Console.Clear();
                
                Console.WriteLine("Menu Futbol 5 : Por favor, seleccione una opción" );
                Console.WriteLine("1. SubMenú de equipos de Futbol");
                Console.WriteLine("2. Carga de Fixture");
                Console.WriteLine("3. Puntajes");
                Console.WriteLine("4. Resetear Torneo");
                Console.WriteLine("5. Salir");

                string opcion = Console.ReadLine();
                    //Helper.validacionNumero(5, 1);
                

                switch (opcion)
                {
                    case "1":
                        {
                            Console.Clear();
                            bool validacion2 = false;
                            string opcion2;

                            Console.WriteLine("1. Agregar Equipos");
                            Console.WriteLine("2. Listado de Inscriptos");
                            Console.WriteLine("3. Volver a Menú Principal");
                            

                            do
                            {
                                opcion2 = Console.ReadLine();
                                

                                switch (opcion2)
                                {
                                    case "1":
                                        {
                                            bool escape = false;
                                            do
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Ingrese nombre del Equipo o 0 para volver al Menú");
                                                string nombreDelEquipo = Console.ReadLine();                                                
                                                
                                                if (nombreDelEquipo == "0")
                                                {
                                                    escape = true;
                                                    
                                                }
                                                else
                                                    listadoDeEquipos.Add(new Equipos (nombreDelEquipo));
                                                                                               
                                            } while (!escape);
                                           
                                            validacion2 = true;
                                            break;

                                        }
                                    case "2":
                                        {
                                           
                                            Console.WriteLine("Listado de Equipos:");

                                            foreach (Equipos item in listadoDeEquipos)
                                            {
                                                Console.WriteLine("Equipo:" + item.ReflejarNombre);                                             
                                            }
                                            
                                            validacion2 = true;
                                            break;
                                        }
                                  
                                    case "3":
                                        {
                                            validacion2 = true;
                                            break;
                                        }
                                    default:
                                        Console.WriteLine("ingrese una opcion valida");
                                        break;
                                }
                            } while (!validacion2);
                            Console.ReadKey();
                            break;
                        }
                    case "2":
                        {
                            

                            if (verificacionDeResultados == 0)
                            {

                                for (int i = 0; i < listadoDeEquipos.Count(); i++)
                                {
                                    for (int c = i + 1; c < listadoDeEquipos.Count(); c++)
                                    {
                                        int resultado1;
                                        int resultado2;

                                        Console.WriteLine("Ingrese el resultado de " +
                                            listadoDeEquipos[i].ReflejarNombre + " vs " + listadoDeEquipos[c].ReflejarNombre);

                                        resultado1 = Helper.validacionNumero();
                                        resultado2 = Helper.validacionNumero();

                                        if (resultado1 > resultado2)
                                        {
                                            listadoDeEquipos[i].SumarPuntajeporGanar();
                                        }

                                        else if (resultado1 < resultado2)
                                        {
                                            listadoDeEquipos[c].SumarPuntajeporGanar();
                                        }

                                        else 
                                        {
                                            listadoDeEquipos[i].SumarPuntajeporEmpatar();
                                            listadoDeEquipos[c].SumarPuntajeporEmpatar();

                                        }

                                    }

                                    
                                }
                                verificacionDeResultados = 1;
                            }

                            else
                                Console.WriteLine("Usted ya ingresó los resultados");

                            Console.ReadKey();
                            break;
                        }
                    case "3":
                        {
                            List<Equipos> copia = new List<Equipos>();
                            foreach(Equipos equipo in listadoDeEquipos)
                            {
                                copia.Add(equipo);
                            }
                            List<Equipos> equiposOrdenados = ordenamientoDescendiente(copia);
                            
                            foreach(Equipos equipo in equiposOrdenados)
                            {
                                Console.WriteLine(equipo.ReflejarNombre + ": " + equipo.ReflejarPuntaje);
                            }
                            Console.ReadKey();
                            break;
                        }
                    case "4":
                        {
                            listadoDeEquipos.Clear();
                            verificacionDeResultados = 0;
                            break;
                        }
                    case "5":
                        {
                            salida = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Ingrese una opción valida");
                            Console.ReadKey();
                            break;
                        }

                }
            } while (!salida);
            Console.ReadKey();

        }

        private static  List < Equipos> ordenamientoDescendiente(List<Equipos> equipos)
        {
            List<Equipos> equiposOrdenados = new List<Equipos>();

            bool termino = false;

            while (!termino && ! (equipos.Count()== 0))
            {
                int mayorIdx = 0;
                Equipos mayorParcial = equipos[0];
      
                for (int i = 0; i < equipos.Count; i++)
                {
                    Equipos equipoActual = equipos[i];
                    if (equipoActual.ReflejarPuntaje > mayorParcial.ReflejarPuntaje)
                    {
                        mayorParcial = equipoActual;
                        mayorIdx = i;
                    }
                }
                equiposOrdenados.Add(mayorParcial);
                equipos.RemoveAt(mayorIdx);

                if (equipos.Count() == 0)
                {
                    termino = true;
                }
            }
            return equiposOrdenados;
        }
    }
}
