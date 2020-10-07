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
        static void Main(string[] args)
        {
            Console.WriteLine("---AFILIACION CONTRIBUTIVA---");
            Afiliado afiliadoContributivo = new AfiliadoContributivo();
            Console.Write("digite los dias de afiliacion: ");
            afiliadoContributivo.diasAfiliacion = Convert.ToInt32( Console.ReadLine());
            Console.Write("digite su sexo: ");
            afiliadoContributivo.sexo = Convert.ToChar(Console.ReadLine());
            Console.Write("digite su edad: ");
            afiliadoContributivo.edad = Convert.ToInt32(Console.ReadLine());
            afiliadoContributivo.liquidacionAfiliacion = afiliadoContributivo.CalcularLiquidacionAfiliacion();
            Console.Write(afiliadoContributivo.ImprimirDatos());
            Console.WriteLine("---AFILIACION SUBSIDIADA---");
            Afiliado afiliadoSubsidiado = new AfiliadoSubsidiado();
            Console.Write("digite los dias de afiliacion: ");
            afiliadoSubsidiado.diasAfiliacion = Convert.ToInt32(Console.ReadLine());
            Console.Write("digite su sexo: ");
            afiliadoSubsidiado.sexo = Convert.ToChar(Console.ReadLine());
            Console.Write("digite su edad: ");
            afiliadoSubsidiado.edad = Convert.ToInt32(Console.ReadLine());
            afiliadoSubsidiado.liquidacionAfiliacion = afiliadoSubsidiado.CalcularLiquidacionAfiliacion();
            Console.Write(afiliadoSubsidiado.ImprimirDatos());
        }
    }
}
