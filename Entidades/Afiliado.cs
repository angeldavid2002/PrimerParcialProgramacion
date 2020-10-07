using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Afiliado
    {
        public double liquidacionAfiliacion { get; set; }
        public int diasAfiliacion { get; set; }
        public double valorUPCDiaria { get; set; }
        public double primaAdicional { get; set; }
        public int edad { get; set; }
        public Char sexo { get; set; }
        public abstract string ImprimirDatos();
        public abstract double CalcularLiquidacionAfiliacion();
        public abstract double CalcularPrimaAdicional();

    }
}
