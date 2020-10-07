using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Entidades
{
    class AfiliadoSubsidiado : Afiliado
    {
        public AfiliadoSubsidiado()
        {
            this.diasAfiliacion = 0;
            this.liquidacionAfiliacion = 0;
            this.primaAdicional = 0;
            this.valorUPCDiaria = 2000;
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
                return 2.0;
            }
            else if ((edad >= 1) && (edad <= 15))
            {
                return 0.8;
            }
            else if ((edad >= 16) && (edad <= 18))
            {
                if (sexo=='M')
                {
                    return 0.2;
                }
                else
                {
                    return 0.3;
                }
            }
            else if ((edad >= 19) && (edad <= 44))
            {
                return 1.0;
            }
            else if ((edad >= 45) && (edad <= 69))
            {
                return 2.5;
            }
            else
            {
                return 3.0;
            }
        }
    }
}
