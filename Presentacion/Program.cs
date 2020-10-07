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
                Console.WriteLine("3)mostrar liquidaciones");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        RegistrarAfiliacion();
                        afiliadoServices.Guardar(afiliado);
                        break;
                    case 2:
                        MostrarDatos();
                        break;
                }
            } while (opcion != 3);
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
            Console.Clear();
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
            Console.ReadKey();
        }
    }
}
