using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;
using Entidades;

namespace Presentacion
{
    class Program
    {
        static Afiliado afiliado;
        static AfiliadoServices afiliadoServices = new AfiliadoServices();
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("---MENU PRINCIPAL---");
                Console.WriteLine("1)registrar nuevo afiliado");
                Console.WriteLine("2)mostrar afiliados");
                Console.WriteLine("3)eliminar un afiliado por numero de liquidacion");
                Console.WriteLine("4)modificar afiliado");
                Console.WriteLine("5)salir");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        RegistrarAfiliacion();
                        afiliadoServices.Guardar(afiliado);
                        break;
                    case 2:
                        Console.Clear();
                        MostrarDatos();
                        break;
                    case 3:
                        EliminarAfiliado();
                        break;
                    case 4:
                        ModificarAfiliado();
                        break;
                    default:
                        break;
                }
            } while (opcion != 5);
        }
        static void RegistrarAfiliacion()
        {
            char tipoAfiliacion;

            do
            {
                Console.Clear();
                Console.WriteLine("digite su regimen: ");
                Console.WriteLine("C) contributivo");
                Console.WriteLine("S) subsidiado");
                tipoAfiliacion = Convert.ToChar(Console.ReadLine().ToUpper());
            } while ((tipoAfiliacion != 'S') && (tipoAfiliacion != 'C'));
            if (tipoAfiliacion == 'S')
            {
                afiliado = new AfiliadoSubsidiado();
            }
            else
            {
                afiliado = new AfiliadoContributivo();
            }
            LlenarDatosAfiliacion();
        }
        static void LlenarDatosAfiliacion()
        {
            Console.Clear();
            Console.WriteLine("---LLENAR DATOS DE CUENTA---");
            Console.Write("digite su identificacion: ");
            afiliado.identificacionAfiliado = Console.ReadLine();
            Console.Write("digite su primer nombre: ");
            afiliado.nombre1Afiliado = Console.ReadLine();
            Console.Write("digite su segundo nombre: ");
            afiliado.nombre2Afiliado = Console.ReadLine();
            Console.Write("digite su primer apellido: ");
            afiliado.apellido1Afiliado = Console.ReadLine();
            Console.Write("digite su segundo apellido: ");
            afiliado.apellido2Afiliado = Console.ReadLine();
            do
            {
                Console.Write("digite su sexo: ");
                afiliado.sexo = Convert.ToChar(Console.ReadLine().ToUpper());
            } while ((afiliado.sexo != 'M') && (afiliado.sexo != 'F'));
            Console.Write("digite su edad: ");
            afiliado.edad = Convert.ToInt32( Console.ReadLine());
            Console.Write("digite sus dias de afiliacion: ");
            afiliado.diasAfiliacion = Convert.ToInt32( Console.ReadLine());
            afiliado.liquidacionAfiliacion = afiliado.CalcularLiquidacionAfiliacion();
            Console.WriteLine(afiliadoServices.AsignarNumeroLiquidacion(afiliado));
            Console.WriteLine("se llenaron los datos exitosamente");
            Console.ReadKey();
        }
        static void MostrarDatos()
        {
            if (afiliadoServices.ConsultarTodos().listaVacia == true)
            {
                Console.WriteLine(afiliadoServices.ConsultarTodos().mensaje);
            }
            else
            {
                List<Afiliado> liquidaciones = afiliadoServices.ConsultarTodos().afiliaciones;
                foreach (var item in liquidaciones)
                {
                    Console.WriteLine(item.ImprimirDatos());
                }
            }
            Console.WriteLine("presione una tecla para continuar");
            Console.ReadKey();
        }
        static void EliminarAfiliado()
        {
            Console.Clear();
            if (afiliadoServices.ConsultarTodos().afiliaciones.Any())
            {
                Console.WriteLine("LISTA DE DATOS AL MOMENTO");
                MostrarDatos();
                int numeroLiquidacionEliminar;
                Console.Write("\ndigite la identificacion de la liquidacion a eliminar: ");
                numeroLiquidacionEliminar = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(afiliadoServices.EliminarLiquidacion(numeroLiquidacionEliminar));
                Console.WriteLine("---LISTA DE DATOS AL ACTUALIZADA---");
                MostrarDatos();
            }
            else
            {
                Console.WriteLine("no hay elementos en la lista");
            }
        }
        static void ModificarAfiliado()
        {
            Console.Clear();
            if (afiliadoServices.ConsultarTodos().afiliaciones.Any())
            {
                Console.WriteLine("LISTA DE DATOS AL MOMENTO");
                MostrarDatos();
                int numeroLiquidacionConsulta, nuevaEdad;
                Console.Write("\ndigite la identificacion de la liquidacion a modificar: ");
                numeroLiquidacionConsulta = Convert.ToInt32(Console.ReadLine());
                Console.Write("digite la nueva edad: ");
                nuevaEdad = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(afiliadoServices.ModificarEdad(numeroLiquidacionConsulta,nuevaEdad));
                Console.WriteLine("---LISTA DE DATOS AL ACTUALIZADA---");
                MostrarDatos();
            }
        }
    }
}
