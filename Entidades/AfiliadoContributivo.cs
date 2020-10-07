using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class AfiliadoContributivo:Afiliado
    {

        public AfiliadoContributivo()
        {
            this.diasAfiliacion = 0;
            this.liquidacionAfiliacion = 0;
            this.primaAdicional = 0;
            this.valorUPCDiaria = 2400;
            this.edad = 0;
        }

        public override string ImprimirDatos()
        {
            return "dias de afiliacion: " + diasAfiliacion + "\n" +
                "liquidacion de afiliacion: " + liquidacionAfiliacion + "\n" +
                "prima adicional: " + primaAdicional + "\n" +
                "valor UPC diaria: " + valorUPCDiaria + "\n";
        }
        public override double CalcularLiquidacionAfiliacion()
        {
            primaAdicional = CalcularPrimaAdicional();
            liquidacionAfiliacion = diasAfiliacion * valorUPCDiaria * primaAdicional;
            return liquidacionAfiliacion;
        }

        public override double CalcularPrimaAdicional()
        {
            if (edad < 1)
            {
                return 2.5;
            }
            else if ((edad >= 1) && (edad <= 15))
            {
                return 0.9;
            }
            else if ((edad >= 16) && (edad <= 18))
            {
                return 0.3;
            }
            else if ((edad >= 19) && (edad <= 44))
            {
                return 1.5;
            }
            else if ((edad >= 45) && (edad <= 69))
            {
                return 3.0;
            }
            else
            {
                return 3.5;
            }
        }
    }
}
