using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AfiliadoContributivo:Afiliado
    {

        public AfiliadoContributivo()
        {
            this.diasAfiliacion = 0;
            this.liquidacionAfiliacion = 0;
            this.primaAdicional = 0;
            this.valorUPCDiaria = 2400;
            this.edad = 0;
            this.numeroLiquidacion = 0;
            this.identificacionAfiliado = string.Empty;
            this.nombre1Afiliado = string.Empty;
            this.nombre2Afiliado = string.Empty;
            this.apellido1Afiliado = string.Empty;
            this.apellido2Afiliado = string.Empty;
            this.tipoAfiliacion = 'C';
        }

        public override string ImprimirDatos()
        {
            return "tipo afiliacion: " + tipoAfiliacion + "\n" +
                "dias de afiliacion: " + diasAfiliacion + "\n" +
                "liquidacion de afiliacion: " + liquidacionAfiliacion + "\n" +
                "prima adicional: " + primaAdicional + "\n" +
                "valor UPC diaria: " + valorUPCDiaria + "\n"+
                "edad: "+edad+"\n"+
                "numero de liquidacion: "+ numeroLiquidacion+"\n"+
                "identificacion del afiliado: "+ identificacionAfiliado+"\n"+
                "nombre: "+ nombre1Afiliado+" " + nombre2Afiliado + " "+
                apellido1Afiliado+" "+ apellido2Afiliado+"\n"+
                "sexo: "+ sexo+"\n";
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
